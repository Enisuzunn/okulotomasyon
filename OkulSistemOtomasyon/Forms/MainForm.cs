using DevExpress.XtraBars.Ribbon;
using OkulSistemOtomasyon.Data;
using OkulSistemOtomasyon.Helpers;
using Microsoft.EntityFrameworkCore;

namespace OkulSistemOtomasyon.Forms
{
    public partial class MainForm : RibbonForm
    {
        private OkulDbContext _context;

        public MainForm()
        {
            InitializeComponent();
            _context = new OkulDbContext();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (SessionManager.AktifKullanici != null)
            {
                barStaticItemKullanici.Caption = $"{SessionManager.AktifKullanici.TamAd} ({SessionManager.AktifKullanici.RolAdi})";
            }

            // Admin değilse kullanıcı yönetimini gizle
            if (!SessionManager.AdminMi())
            {
                btnKullaniciYonetim.Enabled = false;
            }

            // Dashboard'u yükle
            DashboardYukle();
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
                tileOgrenci.Elements[2].Text = $"+{buAyOgrenciSayisi} bu ay";
                
                tileAkademisyen.Elements[1].Text = akademisyenSayisi.ToString();
                tileAkademisyen.Elements[2].Text = $"+{buAyAkademisyenSayisi} bu ay";
                
                tileDers.Elements[1].Text = dersSayisi.ToString();
                
                tileBolum.Elements[1].Text = bolumSayisi.ToString();

                // Bekleyen işlemleri yükle
                lblBekleyenTalepler.Text = $"{bekleyenTalepSayisi} Ders Kayıt Talebi";
                lblDanismanAtama.Text = $"{danismansizOgrenciSayisi} Danışman Ataması Gerekli";
                lblNotGirilmemis.Text = $"{notGirilmemisKayitSayisi} Derste Not Girilmemiş";

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
                
                // Renkli palette
                var renkler = new System.Drawing.Color[]
                {
                    System.Drawing.Color.FromArgb(52, 152, 219),   // Mavi
                    System.Drawing.Color.FromArgb(46, 204, 113),   // Yeşil
                    System.Drawing.Color.FromArgb(230, 126, 34),   // Turuncu
                    System.Drawing.Color.FromArgb(155, 89, 182),   // Mor
                    System.Drawing.Color.FromArgb(231, 76, 60),    // Kırmızı
                    System.Drawing.Color.FromArgb(241, 196, 15),   // Sarı
                    System.Drawing.Color.FromArgb(26, 188, 156),   // Turkuaz
                    System.Drawing.Color.FromArgb(149, 165, 166)   // Gri
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

        private void btnAnaSayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Tüm MDI child formları kapat
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            
            // Dashboard'u göster
            dashboardPanel.Visible = true;
        }

        private void btnOgrenciYonetim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AcForm<OgrenciForm>();
        }

        private void btnAkademisyenYonetim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AcForm<AkademisyenForm>();
        }

        private void btnBolumYonetim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AcForm<BolumForm>();
        }

        private void btnDersYonetim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AcForm<DersForm>();
        }

        private void btnNotYonetim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AcForm<NotForm>();
        }

        private void btnKullaniciYonetim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AcForm<KullaniciForm>();
        }

        private void btnCikis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageHelper.OnayMesaji("Programdan çıkmak istediğinize emin misiniz?", "Çıkış"))
            {
                Application.Exit();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _context?.Dispose();
            base.OnFormClosing(e);
        }
    }
}
