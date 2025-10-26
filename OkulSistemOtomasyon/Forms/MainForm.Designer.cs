namespace OkulSistemOtomasyon.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnOgrenciYonetim = new DevExpress.XtraBars.BarButtonItem();
            this.btnAkademisyenYonetim = new DevExpress.XtraBars.BarButtonItem();
            this.btnBolumYonetim = new DevExpress.XtraBars.BarButtonItem();
            this.btnDersYonetim = new DevExpress.XtraBars.BarButtonItem();
            this.btnNotYonetim = new DevExpress.XtraBars.BarButtonItem();
            this.btnKullaniciYonetim = new DevExpress.XtraBars.BarButtonItem();
            this.btnCikis = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItemKullanici = new DevExpress.XtraBars.BarStaticItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager();
            
            // Dashboard Kontrolleri
            this.dashboardPanel = new DevExpress.XtraEditors.PanelControl();
            this.tileControl = new DevExpress.XtraEditors.TileControl();
            this.tileOgrenci = new DevExpress.XtraEditors.TileItem();
            this.tileAkademisyen = new DevExpress.XtraEditors.TileItem();
            this.tileDers = new DevExpress.XtraEditors.TileItem();
            this.tileBolum = new DevExpress.XtraEditors.TileItem();
            this.chartControl = new DevExpress.XtraCharts.ChartControl();
            this.groupAktiviteler = new DevExpress.XtraEditors.GroupControl();
            this.listBoxAktiviteler = new DevExpress.XtraEditors.ListBoxControl();
            this.groupBekleyenler = new DevExpress.XtraEditors.GroupControl();
            this.lblBekleyenTalepler = new DevExpress.XtraEditors.LabelControl();
            this.lblDanismanAtama = new DevExpress.XtraEditors.LabelControl();
            this.lblNotGirilmemis = new DevExpress.XtraEditors.LabelControl();
            this.lblDashboardBaslik = new DevExpress.XtraEditors.LabelControl();

            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardPanel)).BeginInit();
            this.dashboardPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupAktiviteler)).BeginInit();
            this.groupAktiviteler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxAktiviteler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBekleyenler)).BeginInit();
            this.groupBekleyenler.SuspendLayout();
            this.SuspendLayout();
            
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnOgrenciYonetim,
            this.btnAkademisyenYonetim,
            this.btnBolumYonetim,
            this.btnDersYonetim,
            this.btnNotYonetim,
            this.btnKullaniciYonetim,
            this.btnCikis,
            this.barStaticItem1,
            this.barStaticItemKullanici});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 11;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2});
            this.ribbonControl1.Size = new System.Drawing.Size(1200, 158);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            
            // 
            // btnOgrenciYonetim
            // 
            this.btnOgrenciYonetim.Caption = "Öğrenci Yönetimi";
            this.btnOgrenciYonetim.Id = 1;
            this.btnOgrenciYonetim.Name = "btnOgrenciYonetim";
            this.btnOgrenciYonetim.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOgrenciYonetim_ItemClick);
            
            // 
            // btnAkademisyenYonetim
            // 
            this.btnAkademisyenYonetim.Caption = "Akademisyen Yönetimi";
            this.btnAkademisyenYonetim.Id = 2;
            this.btnAkademisyenYonetim.Name = "btnAkademisyenYonetim";
            this.btnAkademisyenYonetim.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAkademisyenYonetim_ItemClick);
            
            // 
            // btnBolumYonetim
            // 
            this.btnBolumYonetim.Caption = "Bölüm Yönetimi";
            this.btnBolumYonetim.Id = 3;
            this.btnBolumYonetim.Name = "btnBolumYonetim";
            this.btnBolumYonetim.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBolumYonetim_ItemClick);
            
            // 
            // btnDersYonetim
            // 
            this.btnDersYonetim.Caption = "Ders Yönetimi";
            this.btnDersYonetim.Id = 4;
            this.btnDersYonetim.Name = "btnDersYonetim";
            this.btnDersYonetim.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDersYonetim_ItemClick);
            
            // 
            // btnNotYonetim
            // 
            this.btnNotYonetim.Caption = "Not Girişi";
            this.btnNotYonetim.Id = 5;
            this.btnNotYonetim.Name = "btnNotYonetim";
            this.btnNotYonetim.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNotYonetim_ItemClick);
            
            // 
            // btnKullaniciYonetim
            // 
            this.btnKullaniciYonetim.Caption = "Kullanıcı Yönetimi";
            this.btnKullaniciYonetim.Id = 6;
            this.btnKullaniciYonetim.Name = "btnKullaniciYonetim";
            this.btnKullaniciYonetim.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnKullaniciYonetim_ItemClick);
            
            // 
            // btnCikis
            // 
            this.btnCikis.Caption = "Çıkış";
            this.btnCikis.Id = 7;
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCikis_ItemClick);
            
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "Kullanıcı:";
            this.barStaticItem1.Id = 9;
            this.barStaticItem1.Name = "barStaticItem1";
            
            // 
            // barStaticItemKullanici
            // 
            this.barStaticItemKullanici.Caption = "-";
            this.barStaticItemKullanici.Id = 10;
            this.barStaticItemKullanici.Name = "barStaticItemKullanici";
            
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Ana Sayfa";
            
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnOgrenciYonetim);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnAkademisyenYonetim);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnBolumYonetim);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDersYonetim);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Yönetim";
            
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnNotYonetim);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "İşlemler";
            
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Sistem";
            
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnKullaniciYonetim);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnCikis);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Sistem İşlemleri";
            
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.barStaticItem1);
            this.ribbonStatusBar1.ItemLinks.Add(this.barStaticItemKullanici);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 618);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1200, 24);
            
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            
            // 
            // dashboardPanel
            // 
            this.dashboardPanel.Controls.Add(this.lblDashboardBaslik);
            this.dashboardPanel.Controls.Add(this.tileControl);
            this.dashboardPanel.Controls.Add(this.chartControl);
            this.dashboardPanel.Controls.Add(this.groupAktiviteler);
            this.dashboardPanel.Controls.Add(this.groupBekleyenler);
            this.dashboardPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dashboardPanel.Location = new System.Drawing.Point(0, 158);
            this.dashboardPanel.Name = "dashboardPanel";
            this.dashboardPanel.Size = new System.Drawing.Size(1200, 460);
            this.dashboardPanel.TabIndex = 5;
            
            // 
            // lblDashboardBaslik
            // 
            this.lblDashboardBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblDashboardBaslik.Appearance.Options.UseFont = true;
            this.lblDashboardBaslik.Location = new System.Drawing.Point(20, 10);
            this.lblDashboardBaslik.Name = "lblDashboardBaslik";
            this.lblDashboardBaslik.Size = new System.Drawing.Size(350, 30);
            this.lblDashboardBaslik.TabIndex = 0;
            this.lblDashboardBaslik.Text = "📊 SİSTEM PANELİ - HOŞ GELDİNİZ";
            
            // 
            // tileControl
            // 
            this.tileControl.Groups.Add(new DevExpress.XtraEditors.TileGroup());
            this.tileControl.Groups[0].Items.Add(this.tileOgrenci);
            this.tileControl.Groups[0].Items.Add(this.tileAkademisyen);
            this.tileControl.Groups[0].Items.Add(this.tileDers);
            this.tileControl.Groups[0].Items.Add(this.tileBolum);
            this.tileControl.Location = new System.Drawing.Point(20, 50);
            this.tileControl.MaxId = 4;
            this.tileControl.Name = "tileControl";
            this.tileControl.Size = new System.Drawing.Size(1160, 120);
            this.tileControl.TabIndex = 1;
            
            // 
            // tileOgrenci
            // 
            this.tileOgrenci.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.tileOgrenci.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileOgrenci.Elements.Add(new DevExpress.XtraEditors.TileItemElement() { Text = "👥 ÖĞRENCİ", TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft });
            this.tileOgrenci.Elements.Add(new DevExpress.XtraEditors.TileItemElement() { Text = "0", Appearance = new DevExpress.Utils.AppearanceObject() { Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold), Options = new DevExpress.Utils.AppearanceOptions() { UseFont = true } }, TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter });
            this.tileOgrenci.Elements.Add(new DevExpress.XtraEditors.TileItemElement() { Text = "Toplam", TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomLeft });
            this.tileOgrenci.Id = 0;
            this.tileOgrenci.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.tileOgrenci.Name = "tileOgrenci";
            
            // 
            // tileAkademisyen
            // 
            this.tileAkademisyen.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.tileAkademisyen.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileAkademisyen.Elements.Add(new DevExpress.XtraEditors.TileItemElement() { Text = "👨‍🏫 AKADEMİSYEN", TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft });
            this.tileAkademisyen.Elements.Add(new DevExpress.XtraEditors.TileItemElement() { Text = "0", Appearance = new DevExpress.Utils.AppearanceObject() { Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold), Options = new DevExpress.Utils.AppearanceOptions() { UseFont = true } }, TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter });
            this.tileAkademisyen.Elements.Add(new DevExpress.XtraEditors.TileItemElement() { Text = "Toplam", TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomLeft });
            this.tileAkademisyen.Id = 1;
            this.tileAkademisyen.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.tileAkademisyen.Name = "tileAkademisyen";
            
            // 
            // tileDers
            // 
            this.tileDers.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(230, 126, 34);
            this.tileDers.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileDers.Elements.Add(new DevExpress.XtraEditors.TileItemElement() { Text = "📚 DERS", TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft });
            this.tileDers.Elements.Add(new DevExpress.XtraEditors.TileItemElement() { Text = "0", Appearance = new DevExpress.Utils.AppearanceObject() { Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold), Options = new DevExpress.Utils.AppearanceOptions() { UseFont = true } }, TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter });
            this.tileDers.Elements.Add(new DevExpress.XtraEditors.TileItemElement() { Text = "Toplam", TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomLeft });
            this.tileDers.Id = 2;
            this.tileDers.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.tileDers.Name = "tileDers";
            
            // 
            // tileBolum
            // 
            this.tileBolum.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(155, 89, 182);
            this.tileBolum.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileBolum.Elements.Add(new DevExpress.XtraEditors.TileItemElement() { Text = "🎓 BÖLÜM", TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft });
            this.tileBolum.Elements.Add(new DevExpress.XtraEditors.TileItemElement() { Text = "0", Appearance = new DevExpress.Utils.AppearanceObject() { Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold), Options = new DevExpress.Utils.AppearanceOptions() { UseFont = true } }, TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter });
            this.tileBolum.Elements.Add(new DevExpress.XtraEditors.TileItemElement() { Text = "Toplam", TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomLeft });
            this.tileBolum.Id = 3;
            this.tileBolum.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.tileBolum.Name = "tileBolum";
            
            // 
            // chartControl
            // 
            this.chartControl.Location = new System.Drawing.Point(20, 180);
            this.chartControl.Name = "chartControl";
            this.chartControl.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartControl.Size = new System.Drawing.Size(450, 260);
            this.chartControl.TabIndex = 2;
            
            // 
            // groupAktiviteler
            // 
            this.groupAktiviteler.Controls.Add(this.listBoxAktiviteler);
            this.groupAktiviteler.Location = new System.Drawing.Point(480, 180);
            this.groupAktiviteler.Name = "groupAktiviteler";
            this.groupAktiviteler.Size = new System.Drawing.Size(380, 260);
            this.groupAktiviteler.TabIndex = 3;
            this.groupAktiviteler.Text = "📋 SON AKTİVİTELER";
            
            // 
            // listBoxAktiviteler
            // 
            this.listBoxAktiviteler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxAktiviteler.Location = new System.Drawing.Point(2, 23);
            this.listBoxAktiviteler.Name = "listBoxAktiviteler";
            this.listBoxAktiviteler.Size = new System.Drawing.Size(376, 235);
            this.listBoxAktiviteler.TabIndex = 0;
            
            // 
            // groupBekleyenler
            // 
            this.groupBekleyenler.Controls.Add(this.lblBekleyenTalepler);
            this.groupBekleyenler.Controls.Add(this.lblDanismanAtama);
            this.groupBekleyenler.Controls.Add(this.lblNotGirilmemis);
            this.groupBekleyenler.Location = new System.Drawing.Point(870, 180);
            this.groupBekleyenler.Name = "groupBekleyenler";
            this.groupBekleyenler.Size = new System.Drawing.Size(310, 260);
            this.groupBekleyenler.TabIndex = 4;
            this.groupBekleyenler.Text = "⏳ BEKLEYEN İŞLEMLER";
            
            // 
            // lblBekleyenTalepler
            // 
            this.lblBekleyenTalepler.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblBekleyenTalepler.Appearance.ForeColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.lblBekleyenTalepler.Appearance.Options.UseFont = true;
            this.lblBekleyenTalepler.Appearance.Options.UseForeColor = true;
            this.lblBekleyenTalepler.Location = new System.Drawing.Point(15, 40);
            this.lblBekleyenTalepler.Name = "lblBekleyenTalepler";
            this.lblBekleyenTalepler.Size = new System.Drawing.Size(200, 20);
            this.lblBekleyenTalepler.TabIndex = 0;
            this.lblBekleyenTalepler.Text = "✓ 0 Ders Kayıt Talebi";
            
            // 
            // lblDanismanAtama
            // 
            this.lblDanismanAtama.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblDanismanAtama.Appearance.ForeColor = System.Drawing.Color.FromArgb(230, 126, 34);
            this.lblDanismanAtama.Appearance.Options.UseFont = true;
            this.lblDanismanAtama.Appearance.Options.UseForeColor = true;
            this.lblDanismanAtama.Location = new System.Drawing.Point(15, 80);
            this.lblDanismanAtama.Name = "lblDanismanAtama";
            this.lblDanismanAtama.Size = new System.Drawing.Size(250, 20);
            this.lblDanismanAtama.TabIndex = 1;
            this.lblDanismanAtama.Text = "✓ 0 Danışman Ataması Gerekli";
            
            // 
            // lblNotGirilmemis
            // 
            this.lblNotGirilmemis.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblNotGirilmemis.Appearance.ForeColor = System.Drawing.Color.FromArgb(241, 196, 15);
            this.lblNotGirilmemis.Appearance.Options.UseFont = true;
            this.lblNotGirilmemis.Appearance.Options.UseForeColor = true;
            this.lblNotGirilmemis.Location = new System.Drawing.Point(15, 120);
            this.lblNotGirilmemis.Name = "lblNotGirilmemis";
            this.lblNotGirilmemis.Size = new System.Drawing.Size(220, 20);
            this.lblNotGirilmemis.TabIndex = 2;
            this.lblNotGirilmemis.Text = "✓ 0 Derste Not Girilmemiş";
            
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 642);
            this.Controls.Add(this.dashboardPanel);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Ribbon = this.ribbonControl1;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "Üniversite Yönetim Sistemi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardPanel)).EndInit();
            this.dashboardPanel.ResumeLayout(false);
            this.dashboardPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupAktiviteler)).EndInit();
            this.groupAktiviteler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxAktiviteler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBekleyenler)).EndInit();
            this.groupBekleyenler.ResumeLayout(false);
            this.groupBekleyenler.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnOgrenciYonetim;
        private DevExpress.XtraBars.BarButtonItem btnAkademisyenYonetim;
        private DevExpress.XtraBars.BarButtonItem btnBolumYonetim;
        private DevExpress.XtraBars.BarButtonItem btnDersYonetim;
        private DevExpress.XtraBars.BarButtonItem btnNotYonetim;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnKullaniciYonetim;
        private DevExpress.XtraBars.BarButtonItem btnCikis;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarStaticItem barStaticItemKullanici;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        
        // Dashboard Kontrolleri
        private DevExpress.XtraEditors.PanelControl dashboardPanel;
        private DevExpress.XtraEditors.LabelControl lblDashboardBaslik;
        private DevExpress.XtraEditors.TileControl tileControl;
        private DevExpress.XtraEditors.TileItem tileOgrenci;
        private DevExpress.XtraEditors.TileItem tileAkademisyen;
        private DevExpress.XtraEditors.TileItem tileDers;
        private DevExpress.XtraEditors.TileItem tileBolum;
        private DevExpress.XtraCharts.ChartControl chartControl;
        private DevExpress.XtraEditors.GroupControl groupAktiviteler;
        private DevExpress.XtraEditors.ListBoxControl listBoxAktiviteler;
        private DevExpress.XtraEditors.GroupControl groupBekleyenler;
        private DevExpress.XtraEditors.LabelControl lblBekleyenTalepler;
        private DevExpress.XtraEditors.LabelControl lblDanismanAtama;
        private DevExpress.XtraEditors.LabelControl lblNotGirilmemis;
    }
}
