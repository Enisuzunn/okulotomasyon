using OkulSistemOtomasyon.Data;
using OkulSistemOtomasyon.Helpers;
using Microsoft.EntityFrameworkCore;

namespace OkulSistemOtomasyon.Forms
{
    public partial class MainForm : Form
    {
        private OkulDbContext _context;

        public MainForm()
        {
            InitializeComponent();
            _context = new OkulDbContext();
            
            // F12 kısayolu için KeyPreview aktif
            this.KeyPreview = true;
            this.KeyDown += MainForm_KeyDown;
        }

        /// <summary>
        /// F12: Test/Debug menüsü açar
        /// </summary>
        private void MainForm_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                TestMenusuGoster();
                e.Handled = true;
            }
        }

        /// <summary>
        /// Test menüsü - Geliştirici araçları
        /// </summary>
        private void TestMenusuGoster()
        {
            var sonuc = MessageBox.Show(
                "🧪 TEST MENÜSÜ\n\n" +
                "Evet: 8 Test öğrencisi EKLE (Algoritma Analizi dersine)\n" +
                "Hayır: Test öğrencilerini SİL\n" +
                "İptal: Kapat\n\n" +
                "⚠️ Bu özellik sadece test amaçlıdır!",
                "Geliştirici Araçları (F12)",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Information);

            if (sonuc == DialogResult.Yes)
            {
                // Test öğrencileri ekle
                var (ogrenciSayisi, notSayisi, mesaj) = DatabaseInitializer.TestOgrencileriEkle();
                MessageHelper.BilgiMesaji(mesaj);
                DashboardYukle(); // Sayıları güncelle
            }
            else if (sonuc == DialogResult.No)
            {
                // Test öğrencileri sil
                var (silinenOgrenci, silinenNot) = DatabaseInitializer.TestOgrencileriSil();
                if (silinenOgrenci > 0)
                {
                    MessageHelper.BasariMesaji($"✅ {silinenOgrenci} test öğrencisi ve {silinenNot} not kaydı silindi.");
                }
                else
                {
                    MessageHelper.UyariMesaji("Silinecek test öğrencisi bulunamadı.");
                }
                DashboardYukle(); // Sayıları güncelle
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (SessionManager.AktifKullanici != null)
            {
                lblKullaniciBilgi.Text = $"👤 {SessionManager.AktifKullanici.TamAd} ({SessionManager.AktifKullanici.RolAdi})";
            }

            // Admin değilse kullanıcı yönetimini gizle
            if (!SessionManager.AdminMi())
            {
                accordionItemKullanici.Visible = false;
            }

            // Dashboard'u yükle
            DashboardYukle();
            
            // Aktif menü öğesini işaretle
            accordionItemAnaSayfa.Appearance.Normal.BackColor = Color.FromArgb(59, 130, 246);
            accordionItemAnaSayfa.Appearance.Normal.ForeColor = Color.White;
        }

        private void DashboardYukle()
        {
            try
            {
                // İstatistikleri hesapla
                var ogrenciSayisi = _context.Ogrenciler.Count(o => o.IsActive);
                var akademisyenSayisi = _context.Akademisyenler.Count(a => a.IsActive);
                var dersSayisi = _context.Dersler.Count(d => d.IsActive);
                var bolumSayisi = _context.Bolumler.Count(b => b.IsActive);

                // Bu ay eklenen öğrenci sayısı
                var buAyBaslangic = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                var buAyOgrenciSayisi = _context.Ogrenciler.Count(o => o.CreatedDate >= buAyBaslangic);

                // Bu ay eklenen akademisyen sayısı
                var buAyAkademisyenSayisi = _context.Akademisyenler.Count(a => a.CreatedDate >= buAyBaslangic);

                // Bekleyen ders kayıt talepleri
                var bekleyenTalepSayisi = _context.DersKayitTalepleri
                    .Count(t => t.Durum == Models.DersKayitDurumu.Beklemede);

                // Danışmanı olmayan öğrenciler
                var danismansizOgrenciSayisi = _context.Ogrenciler
                    .Count(o => o.IsActive && o.DanismanId == null);

                // Notu olmayan ders kayıtları
                var notGirilmemisKayitSayisi = _context.OgrenciNotlari
                    .Count(n => n.Vize == null && n.Final == null);

                // Tile'ları güncelle
                // Element[0] = Başlık, Element[1] = Sayı, Element[2] = Alt bilgi
                tileOgrenci.Elements[1].Text = ogrenciSayisi.ToString();
                tileOgrenci.Elements[2].Text = "Kayıtlı";
                
                tileAkademisyen.Elements[1].Text = akademisyenSayisi.ToString();
                tileAkademisyen.Elements[2].Text = "Aktif";
                
                tileDers.Elements[1].Text = dersSayisi.ToString();
                tileDers.Elements[2].Text = "Aktif";
                
                tileBolum.Elements[1].Text = bolumSayisi.ToString();
                tileBolum.Elements[2].Text = "Toplam";

                // Bekleyen işlemleri yükle
                lblBekleyenTalepler.Text = $"📌 {bekleyenTalepSayisi} Ders Kayıt Talebi";
                lblDanismanAtama.Text = $"👤 {danismansizOgrenciSayisi} Danışman Ataması Gerekli";
                lblNotGirilmemis.Text = $"📝 {notGirilmemisKayitSayisi} Derste Not Girilmemiş";

                // Son aktiviteleri yükle
                SonAktiviteleriYukle();

                // Grafik verilerini yükle
                GrafikYukle();
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Dashboard yüklenirken hata: {ex.Message}");
            }
        }

        private void SonAktiviteleriYukle()
        {
            try
            {
                listBoxAktiviteler.Items.Clear();

                // Son eklenen öğrenciler (son 5)
                var sonOgrenciler = _context.Ogrenciler
                    .OrderByDescending(o => o.CreatedDate)
                    .Take(3)
                    .Select(o => new { o.Ad, o.Soyad, o.CreatedDate, Tip = "Öğrenci" })
                    .ToList();

                foreach (var ogr in sonOgrenciler)
                {
                    var sure = HesaplaSure(ogr.CreatedDate);
                    listBoxAktiviteler.Items.Add($"👤 {ogr.Ad} {ogr.Soyad} - Öğrenci eklendi ({sure})");
                }

                // Son eklenen dersler (son 3)
                var sonDersler = _context.Dersler
                    .OrderByDescending(d => d.CreatedDate)
                    .Take(2)
                    .Select(d => new { d.DersAdi, d.CreatedDate })
                    .ToList();

                foreach (var ders in sonDersler)
                {
                    var sure = HesaplaSure(ders.CreatedDate);
                    listBoxAktiviteler.Items.Add($"📚 {ders.DersAdi} - Ders eklendi ({sure})");
                }
            }
            catch { }
        }

        private string HesaplaSure(DateTime tarih)
        {
            var fark = DateTime.Now - tarih;
            
            if (fark.TotalMinutes < 1) return "Az önce";
            if (fark.TotalMinutes < 60) return $"{(int)fark.TotalMinutes} dk önce";
            if (fark.TotalHours < 24) return $"{(int)fark.TotalHours} saat önce";
            if (fark.TotalDays < 7) return $"{(int)fark.TotalDays} gün önce";
            
            return tarih.ToShortDateString();
        }

        private void GrafikYukle()
        {
            try
            {
                // Bölümlere göre öğrenci dağılımı
                var bolumDagilim = _context.Ogrenciler
                    .Include(o => o.Bolum)
                    .Where(o => o.IsActive && o.Bolum != null)
                    .GroupBy(o => o.Bolum.BolumAdi)
                    .Select(g => new { Bolum = g.Key, Sayi = g.Count() })
                    .OrderByDescending(x => x.Sayi)
                    .Take(5)
                    .ToList();

                // ChartControl'ü temizle ve yeniden yükle
                chartControl.Series.Clear();
                
                var series = new DevExpress.XtraCharts.Series("Öğrenci Sayısı", DevExpress.XtraCharts.ViewType.Pie);
                
                // Modern renkler
                var renkler = new System.Drawing.Color[]
                {
                    System.Drawing.Color.FromArgb(59, 130, 246),   // Mavi
                    System.Drawing.Color.FromArgb(16, 185, 129),   // Yeşil
                    System.Drawing.Color.FromArgb(245, 158, 11),   // Turuncu
                    System.Drawing.Color.FromArgb(139, 92, 246),   // Mor
                    System.Drawing.Color.FromArgb(239, 68, 68),    // Kırmızı
                    System.Drawing.Color.FromArgb(236, 72, 153),   // Pembe
                    System.Drawing.Color.FromArgb(6, 182, 212),    // Turkuaz
                    System.Drawing.Color.FromArgb(107, 114, 128)   // Gri
                };
                
                for (int i = 0; i < bolumDagilim.Count; i++)
                {
                    var point = new DevExpress.XtraCharts.SeriesPoint(bolumDagilim[i].Bolum, bolumDagilim[i].Sayi);
                    point.Color = renkler[i % renkler.Length];
                    series.Points.Add(point);
                }

                chartControl.Series.Add(series);
                
                // Pie chart ayarları
                if (series.View is DevExpress.XtraCharts.PieSeriesView pieView)
                {
                    pieView.RuntimeExploding = false;
                }
                
                // Legend ayarları
                chartControl.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
                chartControl.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Right;
                chartControl.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.Center;
                
                // Başlık
                chartControl.Titles.Clear();
                var title = new DevExpress.XtraCharts.ChartTitle();
                title.Text = "Bölümlere Göre Öğrenci Dağılımı";
                title.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
                chartControl.Titles.Add(title);
            }
            catch { }
        }

        private void AcForm<T>() where T : Form, new()
        {
            // Dashboard'u gizle
            dashboardPanel.Visible = false;
            
            // Aynı tipte form açıksa onu getir
            foreach (Form childForm in MdiChildren)
            {
                if (childForm is T)
                {
                    childForm.Activate();
                    return;
                }
            }

            // Yoksa yeni form aç
            T form = new T();
            form.MdiParent = this;
            form.Show();
        }

        /// <summary>
        /// AccordionControl tıklama olayı - Menü navigasyonu
        /// </summary>
        private void accordionControl_ElementClick(object sender, DevExpress.XtraBars.Navigation.ElementClickEventArgs e)
        {
            // Sadece Item'lara tıklanınca işlem yap
            if (e.Element.Style != DevExpress.XtraBars.Navigation.ElementStyle.Item)
                return;
            
            // Tüm item'ların rengini sıfırla
            ResetMenuColors();
            
            // Aktif item'ı vurgula
            e.Element.Appearance.Normal.BackColor = Color.FromArgb(59, 130, 246);
            e.Element.Appearance.Normal.ForeColor = Color.White;
            
            // Header başlığını güncelle
            string baslik = "📊 Dashboard";
            
            if (e.Element == accordionItemAnaSayfa)
            {
                AnaSayfaGoster();
                baslik = "📊 Dashboard";
            }
            else if (e.Element == accordionItemOgrenci)
            {
                AcForm<OgrenciForm>();
                baslik = "👨‍🎓 Öğrenci Yönetimi";
            }
            else if (e.Element == accordionItemAkademisyen)
            {
                AcForm<AkademisyenForm>();
                baslik = "👨‍🏫 Akademisyen Yönetimi";
            }
            else if (e.Element == accordionItemBolum)
            {
                AcForm<BolumForm>();
                baslik = "🏛️ Bölüm Yönetimi";
            }
            else if (e.Element == accordionItemDers)
            {
                AcForm<DersForm>();
                baslik = "📚 Ders Yönetimi";
            }
            else if (e.Element == accordionItemNotGirisi)
            {
                AcForm<NotForm>();
                baslik = "📝 Not Girişi";
            }
            else if (e.Element == accordionItemKullanici)
            {
                AcForm<KullaniciForm>();
                baslik = "👤 Kullanıcı Yönetimi";
            }
            else if (e.Element == accordionItemEmailAyarlari)
            {
                using (var form = new EmailAyarlariForm())
                {
                    form.ShowDialog();
                }
                return; // Dialog form olduğu için header değişmesin
            }
            else if (e.Element == accordionItemCikis)
            {
                CikisYap();
                return;
            }
            
            lblBaslik.Text = baslik;
        }

        /// <summary>
        /// Menü renklerini sıfırla
        /// </summary>
        private void ResetMenuColors()
        {
            var items = new[] {
                accordionItemAnaSayfa,
                accordionItemOgrenci,
                accordionItemAkademisyen,
                accordionItemBolum,
                accordionItemDers,
                accordionItemNotGirisi,
                accordionItemKullanici,
                accordionItemEmailAyarlari,
                accordionItemCikis
            };
            
            foreach (var item in items)
            {
                item.Appearance.Normal.BackColor = Color.FromArgb(24, 29, 39);
                item.Appearance.Normal.ForeColor = Color.FromArgb(200, 206, 218);
            }
        }

        /// <summary>
        /// Ana sayfa göster
        /// </summary>
        private void AnaSayfaGoster()
        {
            // Tüm MDI child formları kapat
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            
            // Dashboard'u göster
            dashboardPanel.Visible = true;
            DashboardYukle();
        }

        /// <summary>
        /// Çıkış işlemi
        /// </summary>
        private void CikisYap()
        {
            if (MessageHelper.OnayMesaji("Programdan çıkmak istediğinize emin misiniz?", "Çıkış"))
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Header'daki çıkış butonu
        /// </summary>
        private void btnHeaderCikis_Click(object sender, EventArgs e)
        {
            CikisYap();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _context?.Dispose();
            base.OnFormClosing(e);
        }
    }
}
