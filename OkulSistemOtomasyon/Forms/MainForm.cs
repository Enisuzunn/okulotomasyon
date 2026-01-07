using OkulSistemOtomasyon.Data;
using OkulSistemOtomasyon.Helpers;
using Microsoft.EntityFrameworkCore;

namespace OkulSistemOtomasyon.Forms
{
    public partial class MainForm : Form
    {
        private OkulDbContext _context;
        private bool _sidebarOpen = true;
        private const int SIDEBAR_WIDTH = 260;
        private Button? _selectedMenuButton;

        // Renk sabitleri
        private readonly Color SIDEBAR_BG = Color.FromArgb(24, 29, 39);
        private readonly Color MENU_ITEM_BG = Color.FromArgb(24, 29, 39);
        private readonly Color MENU_ITEM_HOVER = Color.FromArgb(51, 65, 85);
        private readonly Color MENU_ITEM_SELECTED = Color.FromArgb(59, 130, 246);
        private readonly Color MENU_ITEM_TEXT = Color.FromArgb(226, 232, 240);
        private readonly Color MENU_GROUP_TEXT = Color.FromArgb(148, 163, 184);

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
            using (var form = new Form())
            {
                form.Text = "🧪 Geliştirici Araçları (F12)";
                form.Size = new Size(400, 320);
                form.StartPosition = FormStartPosition.CenterParent;
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.MaximizeBox = false;
                form.MinimizeBox = false;

                var lblInfo = new Label
                {
                    Text = "⚠️ Bu özellikler sadece test/geliştirme amaçlıdır!",
                    Location = new Point(20, 15),
                    AutoSize = true,
                    ForeColor = Color.OrangeRed,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                };

                var btn1 = new Button
                {
                    Text = "📚 Tüm Bölümlere Veri Ekle (Akademisyen + Ders + Öğrenci)",
                    Location = new Point(20, 50),
                    Size = new Size(350, 40),
                    BackColor = Color.FromArgb(59, 130, 246),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand
                };
                btn1.Click += (s, e) =>
                {
                    form.Close();
                    var (ogr, ders, akd, mesaj) = DatabaseInitializer.TumBolumlereVeriEkle();
                    MessageHelper.BilgiMesaji(mesaj);
                    DashboardYukle();
                };

                var btn2 = new Button
                {
                    Text = "🧪 Test Öğrencileri Ekle (AI Eğitimi için)",
                    Location = new Point(20, 100),
                    Size = new Size(350, 40),
                    BackColor = Color.FromArgb(34, 197, 94),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand
                };
                btn2.Click += (s, e) =>
                {
                    form.Close();
                    var (ogrenciSayisi, notSayisi, mesaj) = DatabaseInitializer.TestOgrencileriEkle();
                    MessageHelper.BilgiMesaji(mesaj);
                    DashboardYukle();
                };

                var btn3 = new Button
                {
                    Text = "🗑️ Test Öğrencilerini Sil",
                    Location = new Point(20, 150),
                    Size = new Size(350, 40),
                    BackColor = Color.FromArgb(239, 68, 68),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand
                };
                btn3.Click += (s, e) =>
                {
                    form.Close();
                    var (silinenOgrenci, silinenNot) = DatabaseInitializer.TestOgrencileriSil();
                    if (silinenOgrenci > 0)
                    {
                        MessageHelper.BasariMesaji($"✅ {silinenOgrenci} test öğrencisi ve {silinenNot} not kaydı silindi.");
                    }
                    else
                    {
                        MessageHelper.UyariMesaji("Silinecek test öğrencisi bulunamadı.");
                    }
                    DashboardYukle();
                };

                var btn4 = new Button
                {
                    Text = "⚠️ VERİTABANINI SIFIRLA (Tüm Veriler Silinir!)",
                    Location = new Point(20, 200),
                    Size = new Size(350, 40),
                    BackColor = Color.FromArgb(127, 29, 29),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand
                };
                btn4.Click += (s, e) =>
                {
                    var onay = MessageBox.Show(
                        "⚠️ DİKKAT!\n\nTüm veriler silinecek ve veritabanı sıfırlanacak!\n\nDevam etmek istiyor musunuz?",
                        "Veritabanı Sıfırlama",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);
                    
                    if (onay == DialogResult.Yes)
                    {
                        form.Close();
                        DatabaseInitializer.ResetDatabase();
                        MessageHelper.BasariMesaji("✅ Veritabanı sıfırlandı. Uygulama yeniden başlatılacak.");
                        Application.Restart();
                    }
                };

                var btnKapat = new Button
                {
                    Text = "Kapat",
                    Location = new Point(150, 250),
                    Size = new Size(100, 30),
                    DialogResult = DialogResult.Cancel
                };

                form.Controls.AddRange(new Control[] { lblInfo, btn1, btn2, btn3, btn4, btnKapat });
                form.ShowDialog(this);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (SessionManager.AktifKullanici != null)
            {
                lblKullaniciBilgi.Text = $"👤 {SessionManager.AktifKullanici.TamAd} ({SessionManager.AktifKullanici.RolAdi})";
            }

            // Custom menüyü oluştur
            CreateCustomMenu();

            // Dashboard'u yükle
            DashboardYukle();
            
            // Dashboard elemanlarını ortala
            DashboardElemanlariniOrtala();
            dashboardPanel.Resize += (s, ev) => DashboardElemanlariniOrtala();
        }

        /// <summary>
        /// Custom menü butonlarını oluştur
        /// </summary>
        private void CreateCustomMenu()
        {
            panelMenu.Controls.Clear();
            int yPos = 10;

            // ========== YÖNETİM ==========
            yPos = AddGroupLabel("YÖNETİM", yPos);
            var btnAnaSayfa = AddMenuButton("🏠  Ana Sayfa", yPos, () => { AnaSayfaGoster(); lblBaslik.Text = "📊 Dashboard"; });
            _selectedMenuButton = btnAnaSayfa; // Varsayılan seçili
            btnAnaSayfa.BackColor = MENU_ITEM_SELECTED;
            yPos += 45;
            
            AddMenuButton("👨‍🎓  Öğrenci Yönetimi", yPos, () => { AcForm<OgrenciForm>(); lblBaslik.Text = "👨‍🎓 Öğrenci Yönetimi"; });
            yPos += 45;
            
            AddMenuButton("👨‍🏫  Akademisyen Yönetimi", yPos, () => { AcForm<AkademisyenForm>(); lblBaslik.Text = "👨‍🏫 Akademisyen Yönetimi"; });
            yPos += 45;
            
            AddMenuButton("🏛️  Bölüm Yönetimi", yPos, () => { AcForm<BolumForm>(); lblBaslik.Text = "🏛️ Bölüm Yönetimi"; });
            yPos += 45;
            
            AddMenuButton("📚  Ders Yönetimi", yPos, () => { AcForm<DersForm>(); lblBaslik.Text = "📚 Ders Yönetimi"; });
            yPos += 55;

            // ========== İŞLEMLER ==========
            yPos = AddGroupLabel("İŞLEMLER", yPos);
            AddMenuButton("📝  Not Girişi", yPos, () => { AcForm<NotForm>(); lblBaslik.Text = "📝 Not Girişi"; });
            yPos += 55;

            // ========== SİSTEM ==========
            yPos = AddGroupLabel("SİSTEM", yPos);
            
            // Admin değilse kullanıcı yönetimini gösterme
            if (SessionManager.AdminMi())
            {
                AddMenuButton("👤  Kullanıcı Yönetimi", yPos, () => { AcForm<KullaniciForm>(); lblBaslik.Text = "👤 Kullanıcı Yönetimi"; });
                yPos += 45;
            }
            
            AddMenuButton("📧  E-Posta Ayarları", yPos, () => { using (var form = new EmailAyarlariForm()) { form.ShowDialog(); } }, false);
            yPos += 45;
            
            AddMenuButton("🚪  Çıkış", yPos, CikisYap, false);
        }

        /// <summary>
        /// Grup başlığı ekle
        /// </summary>
        private int AddGroupLabel(string text, int yPos)
        {
            var label = new Label
            {
                Text = text,
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                ForeColor = MENU_GROUP_TEXT,
                BackColor = SIDEBAR_BG,
                Location = new Point(15, yPos),
                Size = new Size(230, 25),
                AutoSize = false
            };
            panelMenu.Controls.Add(label);
            return yPos + 30;
        }

        /// <summary>
        /// Menü butonu ekle
        /// </summary>
        private Button AddMenuButton(string text, int yPos, Action onClick, bool trackSelection = true)
        {
            var btn = new Button
            {
                Text = text,
                Font = new Font("Segoe UI", 11F),
                ForeColor = MENU_ITEM_TEXT,
                BackColor = MENU_ITEM_BG,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(5, yPos),
                Size = new Size(250, 40),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(15, 0, 0, 0),
                Cursor = Cursors.Hand
            };
            
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = MENU_ITEM_HOVER;
            btn.FlatAppearance.MouseDownBackColor = MENU_ITEM_SELECTED;
            
            btn.Click += (s, e) =>
            {
                if (trackSelection)
                {
                    // Önceki seçili butonu sıfırla
                    if (_selectedMenuButton != null)
                    {
                        _selectedMenuButton.BackColor = MENU_ITEM_BG;
                    }
                    
                    // Yeni seçili butonu işaretle
                    _selectedMenuButton = btn;
                    btn.BackColor = MENU_ITEM_SELECTED;
                }
                
                onClick();
            };
            
            panelMenu.Controls.Add(btn);
            return btn;
        }

        /// <summary>
        /// Dashboard elemanlarını yatayda ortala
        /// </summary>
        private void DashboardElemanlariniOrtala()
        {
            int panelWidth = dashboardPanel.ClientSize.Width;
            int padding = 20;
            int spacing = 15;
            
            // Tile Control'ü ortala
            int tileWidth = Math.Min(1080, panelWidth - 2 * padding);
            tileControl.Width = tileWidth;
            tileControl.Left = (panelWidth - tileWidth) / 2;
            
            // Alt kutuların toplam genişliği
            int boxWidth = (tileWidth - 2 * spacing) / 3;
            int totalBoxWidth = 3 * boxWidth + 2 * spacing;
            int startX = (panelWidth - totalBoxWidth) / 2;
            
            // Chart Control
            chartControl.Width = boxWidth;
            chartControl.Left = startX;
            
            // Son Aktiviteler
            groupAktiviteler.Width = boxWidth;
            groupAktiviteler.Left = startX + boxWidth + spacing;
            
            // Bekleyen İşlemler
            groupBekleyenler.Width = boxWidth;
            groupBekleyenler.Left = startX + 2 * (boxWidth + spacing);
        }

        private void DashboardYukle()
        {
            try
            {
                var ogrenciSayisi = _context.Ogrenciler.Count(o => o.IsActive);
                var akademisyenSayisi = _context.Akademisyenler.Count(a => a.IsActive);
                var dersSayisi = _context.Dersler.Count(d => d.IsActive);
                var bolumSayisi = _context.Bolumler.Count(b => b.IsActive);

                var bekleyenTalepSayisi = _context.DersKayitTalepleri
                    .Count(t => t.Durum == Models.DersKayitDurumu.Beklemede);

                var danismansizOgrenciSayisi = _context.Ogrenciler
                    .Count(o => o.IsActive && o.DanismanId == null);

                var notGirilmemisKayitSayisi = _context.OgrenciNotlari
                    .Count(n => n.Vize == null && n.Final == null);

                tileOgrenci.Elements[1].Text = ogrenciSayisi.ToString();
                tileOgrenci.Elements[2].Text = "Kayıtlı";
                
                tileAkademisyen.Elements[1].Text = akademisyenSayisi.ToString();
                tileAkademisyen.Elements[2].Text = "Aktif";
                
                tileDers.Elements[1].Text = dersSayisi.ToString();
                tileDers.Elements[2].Text = "Aktif";
                
                tileBolum.Elements[1].Text = bolumSayisi.ToString();
                tileBolum.Elements[2].Text = "Toplam";

                lblBekleyenTalepler.Text = $"📌 {bekleyenTalepSayisi} Ders Kayıt Talebi";
                lblDanismanAtama.Text = $"👤 {danismansizOgrenciSayisi} Danışman Ataması Gerekli";
                lblNotGirilmemis.Text = $"📝 {notGirilmemisKayitSayisi} Derste Not Girilmemiş";

                SonAktiviteleriYukle();
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

                var sonOgrenciler = _context.Ogrenciler
                    .OrderByDescending(o => o.CreatedDate)
                    .Take(3)
                    .Select(o => new { o.Ad, o.Soyad, o.CreatedDate })
                    .ToList();

                foreach (var ogr in sonOgrenciler)
                {
                    var sure = HesaplaSure(ogr.CreatedDate);
                    listBoxAktiviteler.Items.Add($"👤 {ogr.Ad} {ogr.Soyad} - Öğrenci eklendi ({sure})");
                }

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
                var bolumDagilim = _context.Ogrenciler
                    .Include(o => o.Bolum)
                    .Where(o => o.IsActive && o.Bolum != null)
                    .GroupBy(o => o.Bolum.BolumAdi)
                    .Select(g => new { Bolum = g.Key, Sayi = g.Count() })
                    .OrderByDescending(x => x.Sayi)
                    .Take(5)
                    .ToList();

                chartControl.Series.Clear();
                
                var series = new DevExpress.XtraCharts.Series("Öğrenci Sayısı", DevExpress.XtraCharts.ViewType.Pie);
                
                var renkler = new Color[]
                {
                    Color.FromArgb(59, 130, 246),
                    Color.FromArgb(16, 185, 129),
                    Color.FromArgb(245, 158, 11),
                    Color.FromArgb(139, 92, 246),
                    Color.FromArgb(239, 68, 68),
                    Color.FromArgb(236, 72, 153),
                    Color.FromArgb(6, 182, 212),
                    Color.FromArgb(107, 114, 128)
                };
                
                for (int i = 0; i < bolumDagilim.Count; i++)
                {
                    var point = new DevExpress.XtraCharts.SeriesPoint(bolumDagilim[i].Bolum, bolumDagilim[i].Sayi);
                    point.Color = renkler[i % renkler.Length];
                    series.Points.Add(point);
                }

                chartControl.Series.Add(series);
                
                if (series.View is DevExpress.XtraCharts.PieSeriesView pieView)
                {
                    pieView.RuntimeExploding = false;
                }
                
                chartControl.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
                chartControl.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Right;
                chartControl.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.Center;
                
                chartControl.Titles.Clear();
                var title = new DevExpress.XtraCharts.ChartTitle();
                title.Text = "Bölümlere Göre Öğrenci Dağılımı";
                title.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                chartControl.Titles.Add(title);
            }
            catch { }
        }

        private void AcForm<T>() where T : Form, new()
        {
            dashboardPanel.Visible = false;
            
            foreach (Form childForm in MdiChildren)
            {
                if (childForm is T)
                {
                    childForm.Activate();
                    return;
                }
            }

            T form = new T();
            form.MdiParent = this;
            form.Show();
        }

        private void AnaSayfaGoster()
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            
            dashboardPanel.Visible = true;
            DashboardYukle();
        }

        private void CikisYap()
        {
            if (MessageHelper.OnayMesaji("Programdan çıkmak istediğinize emin misiniz?", "Çıkış"))
            {
                Application.Exit();
            }
        }

        private void btnHeaderCikis_Click(object sender, EventArgs e)
        {
            CikisYap();
        }

        private void btnToggleSidebar_Click(object sender, EventArgs e)
        {
            _sidebarOpen = !_sidebarOpen;
            
            if (_sidebarOpen)
            {
                panelSidebar.Width = SIDEBAR_WIDTH;
                panelSidebar.Visible = true;
            }
            else
            {
                panelSidebar.Width = 0;
                panelSidebar.Visible = false;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _context?.Dispose();
            base.OnFormClosing(e);
        }
    }
}
