using Microsoft.ML;
using Microsoft.ML.Data;
using OkulSistemOtomasyon.AI.Models;
using OkulSistemOtomasyon.Data;
using Microsoft.EntityFrameworkCore;

namespace OkulSistemOtomasyon.AI.Services
{
    /// <summary>
    /// ML.NET tabanlı yapay zeka servisi
    /// Risk analizi ve not tahmini için model eğitimi ve tahmin işlemleri
    /// </summary>
    public class MLModelService
    {
        private readonly MLContext _mlContext;
        private ITransformer? _riskModel;
        private ITransformer? _finalTahminModel;
        private PredictionEngine<OgrenciBasariVerisi, RiskTahminSonucu>? _riskPredictionEngine;
        private PredictionEngine<FinalTahminGirisi, FinalTahminSonucu>? _finalPredictionEngine;

        private readonly string _modelKlasoru;
        private readonly string _riskModelDosyasi;
        private readonly string _finalModelDosyasi;

        // Singleton pattern için
        private static MLModelService? _instance;
        private static readonly object _lock = new object();

        public static MLModelService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        _instance ??= new MLModelService();
                    }
                }
                return _instance;
            }
        }

        private MLModelService()
        {
            _mlContext = new MLContext(seed: 42);
            
            // Model klasörü yolu
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            _modelKlasoru = Path.Combine(appPath, "AI", "TrainedModels");
            _riskModelDosyasi = Path.Combine(_modelKlasoru, "risk_model.zip");
            _finalModelDosyasi = Path.Combine(_modelKlasoru, "final_tahmin_model.zip");

            // Klasör yoksa oluştur
            if (!Directory.Exists(_modelKlasoru))
            {
                Directory.CreateDirectory(_modelKlasoru);
            }

            // Mevcut modelleri yükle
            ModelYukle();
        }

        /// <summary>
        /// Veritabanındaki notlardan eğitim verisi hazırlar
        /// </summary>
        public List<OgrenciBasariVerisi> EgitimVerisiHazirla()
        {
            var egitimVerisi = new List<OgrenciBasariVerisi>();

            using (var context = new OkulDbContext())
            {
                // Final notu girilmiş kayıtları al
                var notlar = context.OgrenciNotlari
                    .Include(n => n.Ders)
                    .Where(n => n.Vize != null && n.Final != null)
                    .ToList();

                foreach (var not in notlar)
                {
                    // Ortalama hesapla
                    decimal vize = not.Vize ?? 0;
                    decimal final = not.Final ?? 0;
                    decimal proje = not.ProjeNotu ?? 0;
                    int kredi = not.Ders?.Kredi ?? 3;

                    decimal ortalama = (vize * 0.4m) + (final * 0.6m);
                    if (proje > 0)
                    {
                        ortalama = (ortalama * 0.8m) + (proje * 0.2m);
                    }

                    egitimVerisi.Add(new OgrenciBasariVerisi
                    {
                        VizeNotu = (float)vize,
                        ProjeNotu = (float)proje,
                        DersKredisi = kredi,
                        FinalNotu = (float)final,
                        Gecti = ortalama >= 60
                    });
                }
            }

            return egitimVerisi;
        }

        /// <summary>
        /// Risk analizi modeli eğitir (Binary Classification)
        /// </summary>
        public ModelEgitimSonucu RiskModeliEgit()
        {
            var sonuc = new ModelEgitimSonucu();

            try
            {
                var egitimVerisi = EgitimVerisiHazirla();

                if (egitimVerisi.Count < 10)
                {
                    sonuc.Basarili = false;
                    sonuc.Mesaj = $"Yeterli eğitim verisi yok. En az 10 kayıt gerekli, mevcut: {egitimVerisi.Count}";
                    return sonuc;
                }

                // Veriyi ML.NET formatına dönüştür
                IDataView dataView = _mlContext.Data.LoadFromEnumerable(egitimVerisi);

                // Veriyi eğitim ve test olarak ayır
                var split = _mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);

                // Pipeline oluştur
                var pipeline = _mlContext.Transforms.Concatenate("Features",
                        nameof(OgrenciBasariVerisi.VizeNotu),
                        nameof(OgrenciBasariVerisi.ProjeNotu),
                        nameof(OgrenciBasariVerisi.DersKredisi))
                    .Append(_mlContext.BinaryClassification.Trainers.FastTree(
                        labelColumnName: "Label",
                        featureColumnName: "Features",
                        numberOfLeaves: 20,
                        numberOfTrees: 100,
                        minimumExampleCountPerLeaf: 2));

                // Modeli eğit
                _riskModel = pipeline.Fit(split.TrainSet);

                // Model performansını değerlendir
                var predictions = _riskModel.Transform(split.TestSet);
                var metrics = _mlContext.BinaryClassification.Evaluate(predictions, "Label");

                // Modeli kaydet
                _mlContext.Model.Save(_riskModel, dataView.Schema, _riskModelDosyasi);

                // Prediction engine oluştur
                _riskPredictionEngine = _mlContext.Model.CreatePredictionEngine<OgrenciBasariVerisi, RiskTahminSonucu>(_riskModel);

                sonuc.Basarili = true;
                sonuc.Mesaj = "Risk modeli başarıyla eğitildi!";
                sonuc.Dogruluk = metrics.Accuracy;
                sonuc.EgitimVeriSayisi = egitimVerisi.Count;
            }
            catch (Exception ex)
            {
                sonuc.Basarili = false;
                sonuc.Mesaj = $"Model eğitimi sırasında hata: {ex.Message}";
            }

            return sonuc;
        }

        /// <summary>
        /// Final notu tahmin modeli eğitir (Regression)
        /// </summary>
        public ModelEgitimSonucu FinalTahminModeliEgit()
        {
            var sonuc = new ModelEgitimSonucu();

            try
            {
                var egitimVerisi = EgitimVerisiHazirla();

                if (egitimVerisi.Count < 10)
                {
                    sonuc.Basarili = false;
                    sonuc.Mesaj = $"Yeterli eğitim verisi yok. En az 10 kayıt gerekli, mevcut: {egitimVerisi.Count}";
                    return sonuc;
                }

                // Final tahmini için veri hazırla
                var finalEgitimVerisi = egitimVerisi.Select(v => new
                {
                    v.VizeNotu,
                    v.ProjeNotu,
                    v.DersKredisi,
                    Label = v.FinalNotu
                }).ToList();

                IDataView dataView = _mlContext.Data.LoadFromEnumerable(finalEgitimVerisi);

                // Veriyi eğitim ve test olarak ayır
                var split = _mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);

                // Pipeline oluştur
                var pipeline = _mlContext.Transforms.Concatenate("Features",
                        "VizeNotu",
                        "ProjeNotu",
                        "DersKredisi")
                    .Append(_mlContext.Regression.Trainers.FastTree(
                        labelColumnName: "Label",
                        featureColumnName: "Features",
                        numberOfLeaves: 20,
                        numberOfTrees: 100,
                        minimumExampleCountPerLeaf: 2));

                // Modeli eğit
                _finalTahminModel = pipeline.Fit(split.TrainSet);

                // Model performansını değerlendir
                var predictions = _finalTahminModel.Transform(split.TestSet);
                var metrics = _mlContext.Regression.Evaluate(predictions, "Label");

                // Modeli kaydet
                _mlContext.Model.Save(_finalTahminModel, dataView.Schema, _finalModelDosyasi);

                // Prediction engine oluştur
                _finalPredictionEngine = _mlContext.Model.CreatePredictionEngine<FinalTahminGirisi, FinalTahminSonucu>(_finalTahminModel);

                sonuc.Basarili = true;
                sonuc.Mesaj = "Final tahmin modeli başarıyla eğitildi!";
                sonuc.Dogruluk = 1 - metrics.MeanAbsoluteError / 100; // Normalize edilmiş hata
                sonuc.EgitimVeriSayisi = egitimVerisi.Count;
            }
            catch (Exception ex)
            {
                sonuc.Basarili = false;
                sonuc.Mesaj = $"Model eğitimi sırasında hata: {ex.Message}";
            }

            return sonuc;
        }

        /// <summary>
        /// Tüm modelleri eğitir
        /// </summary>
        public (ModelEgitimSonucu RiskSonuc, ModelEgitimSonucu FinalSonuc) TumModelleriEgit()
        {
            var riskSonuc = RiskModeliEgit();
            var finalSonuc = FinalTahminModeliEgit();
            return (riskSonuc, finalSonuc);
        }

        /// <summary>
        /// Kaydedilmiş modelleri yükler
        /// </summary>
        public void ModelYukle()
        {
            try
            {
                // Risk modeli yükle
                if (File.Exists(_riskModelDosyasi))
                {
                    _riskModel = _mlContext.Model.Load(_riskModelDosyasi, out _);
                    _riskPredictionEngine = _mlContext.Model.CreatePredictionEngine<OgrenciBasariVerisi, RiskTahminSonucu>(_riskModel);
                }

                // Final tahmin modeli yükle
                if (File.Exists(_finalModelDosyasi))
                {
                    _finalTahminModel = _mlContext.Model.Load(_finalModelDosyasi, out _);
                    _finalPredictionEngine = _mlContext.Model.CreatePredictionEngine<FinalTahminGirisi, FinalTahminSonucu>(_finalTahminModel);
                }
            }
            catch (Exception)
            {
                // Model yüklenemezse sessizce devam et
            }
        }

        /// <summary>
        /// Risk analizi yapar
        /// </summary>
        public RiskTahminSonucu? RiskTahminYap(float vizeNotu, float projeNotu = 0, float dersKredisi = 3)
        {
            if (_riskPredictionEngine == null)
            {
                return null;
            }

            var girdi = new OgrenciBasariVerisi
            {
                VizeNotu = vizeNotu,
                ProjeNotu = projeNotu,
                DersKredisi = dersKredisi
            };

            return _riskPredictionEngine.Predict(girdi);
        }

        /// <summary>
        /// Final notu tahmini yapar
        /// </summary>
        public FinalTahminSonucu? FinalTahminYap(float vizeNotu, float projeNotu = 0, float dersKredisi = 3)
        {
            if (_finalPredictionEngine == null)
            {
                return null;
            }

            var girdi = new FinalTahminGirisi
            {
                VizeNotu = vizeNotu,
                ProjeNotu = projeNotu,
                DersKredisi = dersKredisi
            };

            return _finalPredictionEngine.Predict(girdi);
        }

        /// <summary>
        /// Modelin hazır olup olmadığını kontrol eder
        /// </summary>
        public bool ModelHazirMi => _riskPredictionEngine != null;

        /// <summary>
        /// Final tahmin modelinin hazır olup olmadığını kontrol eder
        /// </summary>
        public bool FinalModelHazirMi => _finalPredictionEngine != null;

        /// <summary>
        /// Eğitim için yeterli veri var mı kontrol eder
        /// </summary>
        public bool YeterliVeriVarMi()
        {
            using (var context = new OkulDbContext())
            {
                return context.OgrenciNotlari
                    .Count(n => n.Vize != null && n.Final != null) >= 10;
            }
        }

        /// <summary>
        /// Mevcut eğitim verisi sayısını döndürür
        /// </summary>
        public int EgitimVeriSayisi()
        {
            using (var context = new OkulDbContext())
            {
                return context.OgrenciNotlari
                    .Count(n => n.Vize != null && n.Final != null);
            }
        }
    }

    /// <summary>
    /// Model eğitim sonucu
    /// </summary>
    public class ModelEgitimSonucu
    {
        public bool Basarili { get; set; }
        public string Mesaj { get; set; } = string.Empty;
        public double Dogruluk { get; set; }
        public int EgitimVeriSayisi { get; set; }
    }
}

