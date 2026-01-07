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

            // Grid stillerini ayarla
            StilleriAyarla();
            
            AkademisyenBilgileriniGoster();
            VerdigiDersleriYukle();
            DanismanOgrencileriniYukle();
            DersKayitTalepleriniYukle();
            // AI model kontrolü kaldırıldı - manuel "AI Eğit" butonu ile yapılacak
        }

        /// <summary>
        /// Tüm grid'lere modern stil uygular
        /// </summary>
        private void StilleriAyarla()
        {
            // Tüm GridView'lara ortak stil
            var gridViews = new[] { gridViewDersler, gridViewOgrenciler, gridViewDanismanOgrenciler, gridViewTalepler };
            
            foreach (var view in gridViews)
            {
                // Satır yüksekliği
                view.RowHeight = 30;
                
                // Alternating row colors (zebra stili)
                view.OptionsView.EnableAppearanceEvenRow = true;
                view.OptionsView.EnableAppearanceOddRow = true;
                view.Appearance.EvenRow.BackColor = Color.FromArgb(245, 248, 250);
                view.Appearance.OddRow.BackColor = Color.White;
                
                // Header stili - Koyu arka plan, beyaz yazı
                var headerColor = Color.FromArgb(44, 62, 80); // Koyu lacivert
                view.Appearance.HeaderPanel.BackColor = headerColor;
                view.Appearance.HeaderPanel.ForeColor = Color.White;
                view.Appearance.HeaderPanel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
                view.Appearance.HeaderPanel.Options.UseBackColor = true;
                view.Appearance.HeaderPanel.Options.UseForeColor = true;
                view.Appearance.HeaderPanel.Options.UseFont = true;
                view.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                
                // Column header için de aynı stili uygula
                view.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
                view.ColumnPanelRowHeight = 35;
                
                // Seçili satır stili
                view.Appearance.FocusedRow.BackColor = Color.FromArgb(52, 152, 219);
                view.Appearance.FocusedRow.ForeColor = Color.White;
                view.Appearance.FocusedRow.Options.UseBackColor = true;
                view.Appearance.FocusedRow.Options.UseForeColor = true;
                
                // Satır hover efekti
                view.Appearance.HotTrackedRow.BackColor = Color.FromArgb(214, 234, 248);
                view.Appearance.HotTrackedRow.Options.UseBackColor = true;
                view.OptionsSelection.EnableAppearanceFocusedRow = true;
                view.OptionsSelection.EnableAppearanceHideSelection = false;
                
                // Genel font
                view.Appearance.Row.Font = new Font("Segoe UI", 9.5F);
                view.Appearance.Row.Options.UseFont = true;
                
                // Row indicator (satır numarası gösterici)
                view.OptionsView.ShowIndicator = true;
                view.IndicatorWidth = 40;
            }
            
            // Tab stil ayarları
            xtraTabControl1.Appearance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            xtraTabControl1.Appearance.Options.UseFont = true;
            xtraTabControl1.AppearancePage.Header.Font = new Font("Segoe UI", 10F);
            xtraTabControl1.AppearancePage.Header.Options.UseFont = true;
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

                // Sonucu göster
                if (riskSonuc.Basarili || finalSonuc.Basarili)
                {
                    MessageHelper.BasariMesaji(mesaj);
                }
                else
                {
                    MessageHelper.UyariMesaji(mesaj);
                }
                
                // Öğrenci listesini yenile (AI tahminleri görünsün)
                // NOT: Sadece ekran yenilenir, gerçek notlar DEĞİŞMEZ
                if (gridViewDersler.GetFocusedRow() != null)
                {
                    var selectedDers = gridViewDersler.GetFocusedRow() as dynamic;
                    int dersId = selectedDers.DersId;
                    OgrencileriYukle(dersId);
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
                // Cache'i temizle - güncel verileri getirmek için
                _context.ChangeTracker.Clear();
                
                // Ders kredisini al
                var ders = _context.Dersler.Find(dersId);
                float dersKredisi = ders?.Kredi ?? 3;

                // SADECE seçili derse kayıtlı öğrencileri getir (güncel veri için AsNoTracking)
                var notlar = _context.OgrenciNotlari
                    .AsNoTracking()
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

                    // AI tahminleri (sadece final girilmemişse anlamlı)
                    string finalNotuTahmini = "-";
                    string riskDurumu = "-";
                    string riskYuzdesiStr = "-";

                    // Final notu girildiyse - gerçek sonuç göster
                    if (n.Final.HasValue && n.Vize.HasValue)
                    {
                        // Ortalama hesapla
                        decimal ortalama = (n.Vize.Value * 0.4m) + (n.Final.Value * 0.6m);
                        
                        // Geçme durumunu göster
                        if (ortalama >= 50)
                        {
                            riskDurumu = "✅ Geçti";
                        }
                        else
                        {
                            riskDurumu = "❌ Kaldı";
                        }
                        riskYuzdesiStr = $"{ortalama:F0}"; // Ortalama göster
                        finalNotuTahmini = "-"; // Final zaten girilmiş, tahmine gerek yok
                    }
                    // Final girilmemişse ama Vize varsa - TAHMİN yap
                    else if (n.Vize.HasValue && !n.Final.HasValue)
                    {
                        float tahminiFinali;
                        bool aiKullanildi = false;
                        
                        // Final notu tahmini
                        if (mlService.FinalModelHazirMi)
                        {
                            // AI modeli eğitilmiş - gerçek tahmin yap
                            var finalTahmin = mlService.FinalTahminYap(vize, proje, dersKredisi);
                            if (finalTahmin != null)
                            {
                                tahminiFinali = Math.Max(0, Math.Min(100, finalTahmin.TahminiFinalNotu));
                                aiKullanildi = true;
                            }
                            else
                            {
                                // AI tahmin edemedi, formüle düş
                                tahminiFinali = vize * 0.9f + (proje > 0 ? proje * 0.1f : 0);
                            }
                        }
                        else
                        {
                            // Model yok, basit formül kullan
                            tahminiFinali = vize * 0.9f + (proje > 0 ? proje * 0.1f : 0);
                        }
                        
                        // Final tahmini göster
                        finalNotuTahmini = aiKullanildi ? $"🤖 {tahminiFinali:F0}" : $"~{tahminiFinali:F0}";
                        
                        // Tahmini ortalama hesapla (Risk yüzdesi yerine)
                        float tahminiOrtalama = (vize * 0.4f) + (tahminiFinali * 0.6f);
                        riskYuzdesiStr = $"{tahminiOrtalama:F0}"; // Tahmini ortalama göster
                        
                        // Geçme durumu (tahmini ortalamaya göre)
                        if (tahminiOrtalama >= 50)
                        {
                            riskDurumu = "🟢 Geçer";
                        }
                        else if (tahminiOrtalama >= 45)
                        {
                            riskDurumu = "🟡 Sınırda";
                        }
                        else
                        {
                            riskDurumu = "🔴 Kalır";
                        }
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
                        FinalNotuTahmini = finalNotuTahmini,
                        RiskDurumu = riskDurumu,
                        RiskYuzdesi = riskYuzdesiStr
                    };
                }).ToList();

                gridControlOgrenciler.DataSource = ogrenciler;
                gridViewOgrenciler.BestFitColumns();
                
                // Sütun başlıklarını Türkçeleştir ve güzelleştir
                if (gridViewOgrenciler.Columns["FinalNotuTahmini"] != null)
                    gridViewOgrenciler.Columns["FinalNotuTahmini"].Caption = "Tahmini Final";
                if (gridViewOgrenciler.Columns["RiskDurumu"] != null)
                    gridViewOgrenciler.Columns["RiskDurumu"].Caption = "Durum";
                if (gridViewOgrenciler.Columns["RiskYuzdesi"] != null)
                    gridViewOgrenciler.Columns["RiskYuzdesi"].Caption = "Tahmini Ort.";
                if (gridViewOgrenciler.Columns["AdSoyad"] != null)
                    gridViewOgrenciler.Columns["AdSoyad"].Caption = "Ad Soyad";
                if (gridViewOgrenciler.Columns["ProjeNotu"] != null)
                    gridViewOgrenciler.Columns["ProjeNotu"].Caption = "Proje";
                if (gridViewOgrenciler.Columns["OgrenciNo"] != null)
                    gridViewOgrenciler.Columns["OgrenciNo"].Caption = "Öğrenci No";
                if (gridViewOgrenciler.Columns["OgrenciId"] != null)
                    gridViewOgrenciler.Columns["OgrenciId"].Visible = false; // ID gizle

                // Risk durumuna göre satır renklendirme
                gridViewOgrenciler.RowCellStyle -= GridViewOgrenciler_RowCellStyle;
                gridViewOgrenciler.RowCellStyle += GridViewOgrenciler_RowCellStyle;

                lblOgrenciSayisi.Text = $"Kayıtlı Öğrenci: {ogrenciler.Count}";
                
                // AI model durumunu göster
                if (mlService.FinalModelHazirMi)
                {
                    lblOgrenciSayisi.Text += " | 🤖 AI Aktif";
                }
                else
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
            // Durum sütununa göre TÜM SATIRI renklendir
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (view == null) return;
            
            var riskDurumu = view.GetRowCellValue(e.RowHandle, "RiskDurumu")?.ToString() ?? "";
            
            // Geçti/Kaldı/Geçer/Kalır durumlarına göre renklendirme
            if (riskDurumu.Contains("Geçti") || riskDurumu.Contains("Geçer"))
            {
                // Yeşil tonları - Geçenler
                e.Appearance.BackColor = Color.FromArgb(220, 255, 220);
                if (e.Column.FieldName == "RiskDurumu")
                {
                    e.Appearance.BackColor = Color.FromArgb(144, 238, 144); // Daha koyu yeşil
                    e.Appearance.ForeColor = Color.DarkGreen;
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                }
            }
            else if (riskDurumu.Contains("Kaldı") || riskDurumu.Contains("Kalır"))
            {
                // Kırmızı tonları - Kalanlar
                e.Appearance.BackColor = Color.FromArgb(255, 220, 220);
                if (e.Column.FieldName == "RiskDurumu")
                {
                    e.Appearance.BackColor = Color.FromArgb(255, 160, 160); // Daha koyu kırmızı
                    e.Appearance.ForeColor = Color.DarkRed;
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                }
            }
            else if (riskDurumu.Contains("Sınırda"))
            {
                // Sarı tonları - Sınırda
                e.Appearance.BackColor = Color.FromArgb(255, 255, 200);
                if (e.Column.FieldName == "RiskDurumu")
                {
                    e.Appearance.BackColor = Color.FromArgb(255, 230, 100);
                    e.Appearance.ForeColor = Color.DarkOrange;
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                }
            }
            
            // AI tahmini sütununu vurgula
            if (e.Column.FieldName == "FinalNotuTahmini")
            {
                var tahmin = e.CellValue?.ToString() ?? "";
                if (tahmin.Contains("🤖"))
                {
                    e.Appearance.ForeColor = Color.Blue;
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                }
            }
        }

        /// <summary>
        /// Risk yüzdesine göre durum stringi döndürür
        /// AI modeli yokken veya tahmin yapılamazken kullanılır
        /// </summary>
        private string RiskDurumuBelirle(float riskYuzdesi)
        {
            if (riskYuzdesi >= 60)
                return "🔴 Yüksek Risk";
            else if (riskYuzdesi >= 30)
                return "🟡 Orta Risk";
            else
                return "🟢 Düşük Risk";
        }

        /// <summary>
        /// Vize ve proje notuna göre kalma riski yüzdesi hesaplar
        /// Matematiksel formül ile gradyan değerler üretir
        /// Geçme notu: 50 (Ortalama = Vize*0.4 + Final*0.6)
        /// AI modeli yokken fallback olarak kullanılır
        /// </summary>
        private float HesaplaRiskYuzdesi(float vize, float proje)
        {
            // Temel risk: Vize notuna göre (ters orantılı)
            // Vize 100 → %0 risk, Vize 0 → %100 risk
            // Geçme notu 50 olduğunu varsayarak, 50'nin altında risk artıyor
            
            float temelRisk;
            
            if (vize >= 80)
                temelRisk = 5 + (100 - vize) * 0.25f;   // 80-100 arası: %5-10
            else if (vize >= 70)
                temelRisk = 10 + (80 - vize) * 1f;      // 70-80 arası: %10-20
            else if (vize >= 60)
                temelRisk = 20 + (70 - vize) * 1.5f;    // 60-70 arası: %20-35
            else if (vize >= 50)
                temelRisk = 35 + (60 - vize) * 2f;      // 50-60 arası: %35-55
            else if (vize >= 40)
                temelRisk = 55 + (50 - vize) * 2.5f;    // 40-50 arası: %55-80
            else
                temelRisk = 80 + (40 - vize) * 0.5f;    // 0-40 arası: %80-100

            // Proje notu varsa riski azalt (max %15 azaltma)
            if (proje > 0)
            {
                float projeEtkisi = (proje / 100f) * 15f;  // Proje 100 ise %15 azaltma
                temelRisk -= projeEtkisi;
            }

            // 0-100 arasında sınırla
            return Math.Max(0, Math.Min(100, temelRisk));
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
                        Sinif = o.Sinif.HasValue && o.Sinif.Value > 0 ? o.Sinif.Value : (int?)null,
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
