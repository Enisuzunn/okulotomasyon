using DevExpress.XtraEditors;
using Microsoft.EntityFrameworkCore;
using OkulSistemOtomasyon.Data;
using OkulSistemOtomasyon.Helpers;
using OkulSistemOtomasyon.Models;
using OkulSistemOtomasyon.AI.Services;

namespace OkulSistemOtomasyon.Forms
{
    public partial class AkademisyenPanelForm : XtraForm
    {
        private readonly Kullanici _kullanici;
        private readonly Akademisyen _akademisyen;
        private readonly OkulDbContext _context;

        public AkademisyenPanelForm(Kullanici kullanici)
        {
            InitializeComponent();
            _kullanici = kullanici;
            _context = new OkulDbContext();
            
            try
            {
                // Kullanıcının AkademisyenId'si var mı kontrol et
                if (!kullanici.AkademisyenId.HasValue || kullanici.AkademisyenId.Value == 0)
                {
                    MessageHelper.HataMesaji("Bu kullanıcı için akademisyen kaydı bulunamadı!\n\n" +
                        $"Kullanıcı: {kullanici.KullaniciAdi}\n" +
                        $"AkademisyenId: {kullanici.AkademisyenId}");
                    this.Load += (s, e) => this.Close();
                    return;
                }
                
                // AkademisyenId'yi yerel değişkene ata (EF Core çeviri problemi için)
                int akademisyenId = kullanici.AkademisyenId.Value;
                
                // Akademisyen bilgilerini yükle (Include kullanmadan, ID property sorunu nedeniyle)
                _akademisyen = _context.Akademisyenler
                    .AsNoTracking()
                    .FirstOrDefault(a => a.Id == akademisyenId);

                if (_akademisyen == null)
                {
                    MessageHelper.HataMesaji($"Akademisyen bilgileri veritabanında bulunamadı!\n\n" +
                        $"Aranan ID: {akademisyenId}\n" +
                        $"Kullanıcı: {kullanici.KullaniciAdi}\n\n" +
                        "Lütfen veritabanını kontrol edin.");
                    this.Load += (s, e) => this.Close();
                    return;
                }

                this.Text = $"Akademisyen Paneli - {_akademisyen.Unvan} {_akademisyen.Ad} {_akademisyen.Soyad}";
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Akademisyen paneli açılırken hata oluştu:\n\n" +
                    $"Hata: {ex.Message}\n\n" +
                    $"Detay: {ex.InnerException?.Message}\n\n" +
                    $"Stack: {ex.StackTrace}");
                this.Load += (s, e) => this.Close();
            }
        }

        private void AkademisyenPanelForm_Load(object sender, EventArgs e)
        {
            if (_akademisyen == null)
            {
                this.Close();
                return;
            }

            AkademisyenBilgileriniGoster();
            VerdigiDersleriYukle();
            DanismanOgrencileriniYukle();
            DersKayitTalepleriniYukle();
            AIModelDurumuKontrol();
        }

        /// <summary>
        /// AI model durumunu kontrol eder ve gerekirse bilgi verir
        /// </summary>
        private void AIModelDurumuKontrol()
        {
            try
            {
                var mlService = MLModelService.Instance;
                
                if (!mlService.ModelHazirMi)
                {
                    int veriSayisi = mlService.EgitimVeriSayisi();
                    if (veriSayisi >= 10)
                    {
                        // Yeterli veri var, model eğitilebilir
                        var result = MessageBox.Show(
                            $"🤖 Yapay Zeka Modeli Hazır Değil\n\n" +
                            $"Mevcut eğitim verisi: {veriSayisi} kayıt\n" +
                            $"AI modelini şimdi eğitmek ister misiniz?\n\n" +
                            $"Bu işlem birkaç saniye sürebilir.",
                            "AI Model Eğitimi",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            AIModelEgit();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // AI hatası sessizce geçilir, ana işlevselliği etkilemez
                System.Diagnostics.Debug.WriteLine($"AI kontrol hatası: {ex.Message}");
            }
        }

        /// <summary>
        /// AI modellerini eğitir
        /// </summary>
        public void AIModelEgit()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                
                var mlService = MLModelService.Instance;
                var (riskSonuc, finalSonuc) = mlService.TumModelleriEgit();

                Cursor = Cursors.Default;

                string mesaj = "🤖 AI Model Eğitim Sonuçları\n\n";
                
                mesaj += "📊 Risk Analizi Modeli:\n";
                mesaj += riskSonuc.Basarili 
                    ? $"   ✅ Başarılı (Doğruluk: %{riskSonuc.Dogruluk * 100:F1})\n"
                    : $"   ❌ {riskSonuc.Mesaj}\n";

                mesaj += "\n📈 Final Tahmin Modeli:\n";
                mesaj += finalSonuc.Basarili 
                    ? $"   ✅ Başarılı (Doğruluk: %{finalSonuc.Dogruluk * 100:F1})\n"
                    : $"   ❌ {finalSonuc.Mesaj}\n";

                mesaj += $"\n📝 Eğitim Verisi: {riskSonuc.EgitimVeriSayisi} kayıt";

                if (riskSonuc.Basarili && finalSonuc.Basarili)
                {
                    MessageHelper.BasariMesaji(mesaj);
                    
                    // Öğrenci listesini yenile (AI tahminleri görünsün)
                    if (gridViewDersler.GetFocusedRow() != null)
                    {
                        var selectedDers = gridViewDersler.GetFocusedRow() as dynamic;
                        int dersId = selectedDers.DersId;
                        OgrencileriYukle(dersId);
                    }
                }
                else if (!riskSonuc.Basarili && riskSonuc.Mesaj.Contains("positive class"))
                {
                    // Risk modeli için hem geçen hem kalan öğrenci gerekli
                    var result = MessageBox.Show(
                        $"{mesaj}\n\n" +
                        "⚠️ Risk analizi için hem geçen hem kalan öğrenci verisi gerekli.\n\n" +
                        "Mevcut notları yenileyip çeşitli veriler oluşturmak ister misiniz?\n" +
                        "(Bu işlem tüm not kayıtlarını silip yeniden oluşturur)",
                        "Veri Yenileme",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        Cursor = Cursors.WaitCursor;
                        int yeniNotSayisi = Data.DatabaseInitializer.NotlariYenile();
                        Cursor = Cursors.Default;
                        
                        MessageHelper.BasariMesaji($"✅ {yeniNotSayisi} not kaydı yeniden oluşturuldu.\n\n" +
                            "Şimdi 'AI Eğit' butonuna tekrar basın.");
                        
                        // Listeyi yenile
                        if (gridViewDersler.GetFocusedRow() != null)
                        {
                            var selectedDers = gridViewDersler.GetFocusedRow() as dynamic;
                            int dersId = selectedDers.DersId;
                            OgrencileriYukle(dersId);
                        }
                    }
                }
                else
                {
                    MessageHelper.UyariMesaji(mesaj);
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageHelper.HataMesaji($"AI model eğitimi sırasında hata:\n{ex.Message}");
            }
        }

        private void AkademisyenBilgileriniGoster()
        {
            if (_akademisyen == null) return;

            lblHosgeldin.Text = $"Hoş Geldiniz, {_akademisyen.Unvan} {_akademisyen.Ad} {_akademisyen.Soyad}";
            lblEmail.Text = $"Email: {_akademisyen.Email}";
            lblUzmanlik.Text = $"Uzmanlık: {_akademisyen.UzmanlikAlani}";
        }

        private void VerdigiDersleriYukle()
        {
            if (_akademisyen == null) return;

            try
            {
                // Id property kullan (AkademisyenId yerine)
                int akademisyenId = _akademisyen.Id;
                
                // Önce veritabanından çek, sonra bellekte filtrele (Aktif NotMapped olduğu için)
                var dersler = _context.Dersler
                    .Include(d => d.Bolum)
                    .Where(d => d.AkademisyenId == akademisyenId)
                    .ToList() // Veritabanından çek
                    .Where(d => d.Aktif) // Bellekte filtrele
                    .Select(d => new
                    {
                        d.DersId,
                        d.DersAdi,
                        d.DersKodu,
                        d.Kredi,
                        BolumAdi = d.Bolum?.BolumAdi ?? "-",
                        OgrenciSayisi = _context.OgrenciNotlari
                            .Where(n => n.DersId == d.DersId)
                            .Select(n => n.OgrenciId)
                            .Distinct()
                            .Count()
                    })
                    .ToList();

                gridControlDersler.DataSource = dersler;
                gridViewDersler.BestFitColumns();

                lblDersSayisi.Text = $"Toplam Ders: {dersler.Count}";
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Dersler yüklenirken hata oluştu:\n{ex.Message}\n\nDetay: {ex.InnerException?.Message}");
            }
        }

        private void gridViewDersler_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridViewDersler.GetFocusedRow() == null) return;

            try
            {
                var selectedRow = gridViewDersler.GetFocusedRow() as dynamic;
                int dersId = selectedRow.DersId;

                OgrencileriYukle(dersId);
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Öğrenciler yüklenirken hata oluştu:\n{ex.Message}");
            }
        }

        private void OgrencileriYukle(int dersId)
        {
            try
            {
                // Ders kredisini al
                var ders = _context.Dersler.Find(dersId);
                float dersKredisi = ders?.Kredi ?? 3;

                // SADECE seçili derse kayıtlı öğrencileri getir
                var notlar = _context.OgrenciNotlari
                    .Include(n => n.Ogrenci)
                    .Where(n => n.DersId == dersId)
                    .ToList();

                // AI servisi
                var mlService = MLModelService.Instance;

                // Öğrenci listesini AI tahminleriyle oluştur
                var ogrenciler = notlar.Select(n =>
                {
                    float vize = (float)(n.Vize ?? 0);
                    float proje = (float)(n.ProjeNotu ?? 0);

                    // AI tahminleri
                    string aiTahmini = "-";
                    string riskDurumu = "-";
                    string riskYuzdesiStr = "-";

                    if (n.Vize.HasValue && mlService.ModelHazirMi)
                    {
                        // Final tahmini
                        var finalTahmin = mlService.FinalTahminYap(vize, proje, dersKredisi);
                        if (finalTahmin != null)
                        {
                            aiTahmini = $"{finalTahmin.TahminiFinalNotu:F1}";
                        }

                        // Risk analizi
                        var riskTahmin = mlService.RiskTahminYap(vize, proje, dersKredisi);
                        if (riskTahmin != null)
                        {
                            riskDurumu = riskTahmin.RiskDurumu;
                            // Risk yüzdesini 0-100 arasına sınırla ve düzgün formatla
                            float riskYuzdesi = Math.Max(0, Math.Min(100, riskTahmin.KalmaRiskiYuzdesi));
                            riskYuzdesiStr = $"%{riskYuzdesi:F0}";
                        }
                    }
                    else if (n.Vize.HasValue)
                    {
                        // Model yoksa basit tahmin
                        aiTahmini = $"~{vize * 0.9:F0}";
                        float riskYuzdesi = vize < 40 ? 80 : (vize < 60 ? 50 : 20);
                        riskYuzdesiStr = $"%{riskYuzdesi:F0}";
                        riskDurumu = riskYuzdesi >= 60 ? "🔴 Yüksek Risk" : 
                                     riskYuzdesi >= 30 ? "🟡 Orta Risk" : "🟢 Düşük Risk";
                    }

                    return new
                    {
                        n.OgrenciId,
                        n.Ogrenci.OgrenciNo,
                        AdSoyad = n.Ogrenci.Ad + " " + n.Ogrenci.Soyad,
                        n.Ogrenci.Email,
                        n.Vize,
                        n.Final,
                        n.Butunleme,
                        n.ProjeNotu,
                        AITahmini = aiTahmini,
                        RiskDurumu = riskDurumu,
                        RiskYuzdesi = riskYuzdesiStr
                    };
                }).ToList();

                gridControlOgrenciler.DataSource = ogrenciler;
                gridViewOgrenciler.BestFitColumns();

                // Risk durumuna göre satır renklendirme
                gridViewOgrenciler.RowCellStyle -= GridViewOgrenciler_RowCellStyle;
                gridViewOgrenciler.RowCellStyle += GridViewOgrenciler_RowCellStyle;

                lblOgrenciSayisi.Text = $"Kayıtlı Öğrenci: {ogrenciler.Count}";
                
                // AI model durumunu göster
                if (!mlService.ModelHazirMi)
                {
                    lblOgrenciSayisi.Text += " | ⚠️ AI Model henüz eğitilmedi";
                }
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Öğrenciler yüklenirken hata oluştu:\n{ex.Message}\n\nDetay: {ex.InnerException?.Message}");
            }
        }

        private void GridViewOgrenciler_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "RiskDurumu")
            {
                var riskDurumu = e.CellValue?.ToString() ?? "";
                if (riskDurumu.Contains("Yüksek"))
                {
                    e.Appearance.BackColor = Color.FromArgb(255, 200, 200);
                    e.Appearance.ForeColor = Color.DarkRed;
                }
                else if (riskDurumu.Contains("Orta"))
                {
                    e.Appearance.BackColor = Color.FromArgb(255, 255, 200);
                    e.Appearance.ForeColor = Color.DarkOrange;
                }
                else if (riskDurumu.Contains("Düşük"))
                {
                    e.Appearance.BackColor = Color.FromArgb(200, 255, 200);
                    e.Appearance.ForeColor = Color.DarkGreen;
                }
            }
        }

        private void btnNotGir_Click(object sender, EventArgs e)
        {
            if (gridViewDersler.GetFocusedRow() == null)
            {
                MessageHelper.UyariMesaji("Lütfen ders seçin!");
                return;
            }

            if (gridViewOgrenciler.GetFocusedRow() == null)
            {
                MessageHelper.UyariMesaji("Lütfen öğrenci seçin!");
                return;
            }

            try
            {
                var selectedDers = gridViewDersler.GetFocusedRow() as dynamic;
                var selectedOgrenci = gridViewOgrenciler.GetFocusedRow() as dynamic;

                int dersId = selectedDers.DersId;
                int ogrenciId = selectedOgrenci.OgrenciId;

                // Not giriş formu aç
                using (var notGirisForm = new NotGirisDialog(ogrenciId, dersId))
                {
                    if (notGirisForm.ShowDialog() == DialogResult.OK)
                    {
                        // Listeyi yenile
                        OgrencileriYukle(dersId);
                        MessageHelper.BasariMesaji("Not başarıyla kaydedildi!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Not girişi sırasında hata oluştu:\n{ex.Message}");
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            SessionManager.CikisYap();
            this.Close();
        }

        private void btnAIEgit_Click(object sender, EventArgs e)
        {
            var mlService = MLModelService.Instance;
            int veriSayisi = mlService.EgitimVeriSayisi();

            if (veriSayisi < 10)
            {
                MessageHelper.UyariMesaji($"⚠️ Yeterli Eğitim Verisi Yok!\n\n" +
                    $"Mevcut veri sayısı: {veriSayisi}\n" +
                    $"Gereken minimum: 10 kayıt\n\n" +
                    $"Not girişi yapıldıkça AI modeli daha iyi tahminler yapabilecek.");
                return;
            }

            AIModelEgit();
        }

        /// <summary>
        /// Danışman olduğu öğrencileri yükler
        /// NOT: Bu metod çağrılıyor ama henüz UI'da görünmüyor. 
        /// XtraTabControl eklendiğinde grid'e bağlanacak.
        /// </summary>
        private void DanismanOgrencileriniYukle()
        {
            try
            {
                // Akademisyen ID'sini al
                int akademisyenId = _akademisyen.Id;
                
                // Önce öğrencileri çek
                var ogrenciler = _context.Ogrenciler
                    .Include(o => o.Bolum)
                    .Where(o => o.DanismanId == akademisyenId)
                    .ToList(); // Veritabanından çek
                
                // Tüm notları da bellekte çek
                var tumNotlar = _context.OgrenciNotlari.ToList();
                
                // Sonra her öğrenci için ortalamayı hesapla (tamamen bellekte)
                var danismanOgrenciler = ogrenciler
                    .Select(o => new
                    {
                        o.OgrenciId,
                        o.OgrenciNo,
                        AdSoyad = o.Ad + " " + o.Soyad,
                        BolumAdi = o.Bolum != null ? o.Bolum.BolumAdi : "",
                        o.Sinif,
                        o.Email,
                        o.Telefon,
                        // Ortalama hesapla (tamamen bellekte)
                        Ortalama = tumNotlar
                            .Where(n => n.OgrenciId == o.Id)
                            .Select(n => n.Ortalama)
                            .DefaultIfEmpty(0)
                            .Average()
                    })
                    .ToList();

                gridControlDanismanOgrenciler.DataSource = danismanOgrenciler;
                gridViewDanismanOgrenciler.BestFitColumns();

                lblDanismanOgrenciSayisi.Text = $"Danışman Öğrenci Sayısı: {danismanOgrenciler.Count}";
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Danışman öğrencileri yüklenirken hata:\n{ex.Message}");
            }
        }

        private void DersKayitTalepleriniYukle()
        {
            try
            {
                // Danışman olduğu öğrencilerin bekleyen taleplerini göster
                int akademisyenId = _akademisyen.Id;

                var talepler = _context.DersKayitTalepleri
                    .Include(t => t.Ogrenci)
                    .Include(t => t.Ders)
                    .Where(t => t.Ogrenci.DanismanId == akademisyenId && t.Durum == DersKayitDurumu.Beklemede)
                    .OrderBy(t => t.TalepTarihi)
                    .Select(t => new
                    {
                        TalepId = t.Id,
                        OgrenciNo = t.Ogrenci.OgrenciNo,
                        OgrenciAd = t.Ogrenci.Ad + " " + t.Ogrenci.Soyad,
                        DersKodu = t.Ders.DersKodu,
                        DersAdi = t.Ders.DersAdi,
                        Kredi = t.Ders.Kredi,
                        TalepTarihi = t.TalepTarihi.ToString("dd.MM.yyyy HH:mm")
                    })
                    .ToList();

                gridControlTalepler.DataSource = talepler;
                gridViewTalepler.BestFitColumns();

                lblTalepSayisi.Text = $"Bekleyen Talep: {talepler.Count}";
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Talepler yüklenirken hata:\n{ex.Message}\n\nDetay: {ex.InnerException?.Message}");
            }
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            if (gridViewTalepler.GetFocusedRow() == null)
            {
                MessageHelper.UyariMesaji("Lütfen onaylamak istediğiniz talebi seçin!");
                return;
            }

            try
            {
                var selectedRow = gridViewTalepler.GetFocusedRow() as dynamic;
                int talepId = (int)selectedRow.TalepId;
                string ogrenciAd = selectedRow.OgrenciAd;
                string dersAdi = selectedRow.DersAdi;

                if (!MessageHelper.OnayMesaji($"Ders Kayıt Talebini Onayla?\n\n" +
                    $"Öğrenci: {ogrenciAd}\n" +
                    $"Ders: {dersAdi}\n\n" +
                    $"Onayladığınızda öğrenci bu derse otomatik olarak kayıt yapılacaktır."))
                {
                    return;
                }

                var talep = _context.DersKayitTalepleri.Find(talepId);
                if (talep == null)
                {
                    MessageHelper.HataMesaji("Talep bulunamadı!");
                    return;
                }

                // Talebi onayla
                talep.Durum = DersKayitDurumu.Onaylandi;
                talep.KararTarihi = DateTime.Now;

                // Öğrenci için OgrenciNot kaydı oluştur
                var ogrenciNot = new OgrenciNot
                {
                    OgrenciId = talep.OgrenciId,
                    DersId = talep.DersId
                    // Vize, Final vs. null olarak başlayacak
                };

                _context.OgrenciNotlari.Add(ogrenciNot);
                _context.SaveChanges();

                MessageHelper.BasariMesaji($"✅ Talep onaylandı!\n\n" +
                    $"Öğrenci: {ogrenciAd}\n" +
                    $"Ders: {dersAdi}\n\n" +
                    $"Öğrenci derse başarıyla kaydedildi.");

                DersKayitTalepleriniYukle();
                
                // Ders listesini yenile (öğrenci sayısı güncellenir)
                VerdigiDersleriYukle();

                // Eğer şu an seçili ders varsa öğrenci listesini de yenile
                if (gridViewDersler.GetFocusedRow() != null)
                {
                    var selectedDers = gridViewDersler.GetFocusedRow() as dynamic;
                    int currentDersId = selectedDers.DersId;
                    OgrencileriYukle(currentDersId);
                }
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Talep onaylanırken hata:\n{ex.Message}");
            }
        }

        private void btnReddet_Click(object sender, EventArgs e)
        {
            if (gridViewTalepler.GetFocusedRow() == null)
            {
                MessageHelper.UyariMesaji("Lütfen reddetmek istediğiniz talebi seçin!");
                return;
            }

            try
            {
                var selectedRow = gridViewTalepler.GetFocusedRow() as dynamic;
                int talepId = (int)selectedRow.TalepId;
                string ogrenciAd = selectedRow.OgrenciAd;
                string dersAdi = selectedRow.DersAdi;

                // Ret nedeni sor
                string redNedeni = DevExpress.XtraEditors.XtraInputBox.Show(
                    "Ret nedeni (opsiyonel):",
                    "Talep Reddetme",
                    "") ?? "";

                if (!MessageHelper.OnayMesaji($"Ders Kayıt Talebini Reddet?\n\n" +
                    $"Öğrenci: {ogrenciAd}\n" +
                    $"Ders: {dersAdi}\n\n" +
                    $"Talebi reddetmek istediğinize emin misiniz?"))
                {
                    return;
                }

                var talep = _context.DersKayitTalepleri.Find(talepId);
                if (talep == null)
                {
                    MessageHelper.HataMesaji("Talep bulunamadı!");
                    return;
                }

                // Talebi reddet
                talep.Durum = DersKayitDurumu.Reddedildi;
                talep.KararTarihi = DateTime.Now;
                if (!string.IsNullOrWhiteSpace(redNedeni))
                {
                    talep.DanismanNotu = redNedeni;
                }

                _context.SaveChanges();

                MessageHelper.BilgiMesaji($"Talep reddedildi.\n\n" +
                    $"Öğrenci: {ogrenciAd}\n" +
                    $"Ders: {dersAdi}");

                DersKayitTalepleriniYukle();
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Talep reddedilirken hata:\n{ex.Message}");
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _context?.Dispose();
            base.OnFormClosing(e);
        }
    }
}
