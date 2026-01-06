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
            this.btnAnaSayfa = new DevExpress.XtraBars.BarButtonItem();
            this.btnOgrenciYonetim = new DevExpress.XtraBars.BarButtonItem();
            this.btnAkademisyenYonetim = new DevExpress.XtraBars.BarButtonItem();
            this.btnBolumYonetim = new DevExpress.XtraBars.BarButtonItem();
            this.btnDersYonetim = new DevExpress.XtraBars.BarButtonItem();
            this.btnNotYonetim = new DevExpress.XtraBars.BarButtonItem();
            this.btnKullaniciYonetim = new DevExpress.XtraBars.BarButtonItem();
            this.btnEmailAyarlari = new DevExpress.XtraBars.BarButtonItem();
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
            
            // Header Panel
            this.panelHeader = new DevExpress.XtraEditors.PanelControl();
            this.lblBaslik = new DevExpress.XtraEditors.LabelControl();
            this.lblAltBaslik = new DevExpress.XtraEditors.LabelControl();
            
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
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).BeginInit();
            this.panelHeader.SuspendLayout();
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
            this.btnAnaSayfa,
            this.btnOgrenciYonetim,
            this.btnAkademisyenYonetim,
            this.btnBolumYonetim,
            this.btnDersYonetim,
            this.btnNotYonetim,
            this.btnKullaniciYonetim,
            this.btnEmailAyarlari,
            this.btnCikis,
            this.barStaticItem1,
            this.barStaticItemKullanici});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 12;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2});
            this.ribbonControl1.Size = new System.Drawing.Size(1200, 158);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            
            // 
            // btnAnaSayfa
            // 
            this.btnAnaSayfa.Caption = "Ana Sayfa";
            this.btnAnaSayfa.Id = 11;
            this.btnAnaSayfa.Name = "btnAnaSayfa";
            this.btnAnaSayfa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAnaSayfa_ItemClick);
            
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
            // btnEmailAyarlari
            // 
            this.btnEmailAyarlari.Caption = "📧 E-Posta Ayarları";
            this.btnEmailAyarlari.Id = 13;
            this.btnEmailAyarlari.Name = "btnEmailAyarlari";
            this.btnEmailAyarlari.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEmailAyarlari_ItemClick);
            
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
            this.ribbonPageGroup1.ItemLinks.Add(this.btnAnaSayfa);
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
            this.ribbonPageGroup3.ItemLinks.Add(this.btnEmailAyarlari);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnCikis);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Sistem İşlemleri";
            
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.barStaticItem1);
            this.ribbonStatusBar1.ItemLinks.Add(this.barStaticItemKullanici);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 718);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1200, 24);
            
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            
            // 
            // panelHeader
            // 
            this.panelHeader.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelHeader.Appearance.Options.UseBackColor = true;
            this.panelHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelHeader.Controls.Add(this.lblBaslik);
            this.panelHeader.Controls.Add(this.lblAltBaslik);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 158);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1200, 80);
            this.panelHeader.TabIndex = 10;
            // 
            // lblBaslik
            // 
            this.lblBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Appearance.Options.UseFont = true;
            this.lblBaslik.Appearance.Options.UseForeColor = true;
            this.lblBaslik.Location = new System.Drawing.Point(25, 12);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(400, 37);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "🏠 SİSTEM PANELİ";
            // 
            // lblAltBaslik
            // 
            this.lblAltBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblAltBaslik.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.lblAltBaslik.Appearance.Options.UseFont = true;
            this.lblAltBaslik.Appearance.Options.UseForeColor = true;
            this.lblAltBaslik.Location = new System.Drawing.Point(25, 52);
            this.lblAltBaslik.Name = "lblAltBaslik";
            this.lblAltBaslik.Size = new System.Drawing.Size(400, 20);
            this.lblAltBaslik.TabIndex = 1;
            this.lblAltBaslik.Text = "Hoş Geldiniz! Sistemin genel durumunu buradan takip edebilirsiniz.";
            
            // 
            // dashboardPanel
            // 
            this.dashboardPanel.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.dashboardPanel.Appearance.Options.UseBackColor = true;
            this.dashboardPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.dashboardPanel.Controls.Add(this.tileControl);
            this.dashboardPanel.Controls.Add(this.chartControl);
            this.dashboardPanel.Controls.Add(this.groupAktiviteler);
            this.dashboardPanel.Controls.Add(this.groupBekleyenler);
            this.dashboardPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dashboardPanel.Location = new System.Drawing.Point(0, 238);
            this.dashboardPanel.Name = "dashboardPanel";
            this.dashboardPanel.Padding = new System.Windows.Forms.Padding(15);
            this.dashboardPanel.Size = new System.Drawing.Size(1200, 480);
            this.dashboardPanel.TabIndex = 5;
            
            // 
            // tileControl
            // 
            this.tileControl.AllowDrag = false;
            this.tileControl.AllowItemHover = true;
            this.tileControl.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.tileControl.AppearanceItem.Normal.Options.UseFont = true;
            this.tileControl.BackColor = System.Drawing.Color.Transparent;
            this.tileControl.Groups.Add(new DevExpress.XtraEditors.TileGroup());
            this.tileControl.Groups[0].Items.Add(this.tileOgrenci);
            this.tileControl.Groups[0].Items.Add(this.tileAkademisyen);
            this.tileControl.Groups[0].Items.Add(this.tileDers);
            this.tileControl.Groups[0].Items.Add(this.tileBolum);
            this.tileControl.IndentBetweenGroups = 10;
            this.tileControl.IndentBetweenItems = 25;
            this.tileControl.ItemSize = 110;
            this.tileControl.Location = new System.Drawing.Point(20, 15);
            this.tileControl.MaxId = 4;
            this.tileControl.Name = "tileControl";
            this.tileControl.Padding = new System.Windows.Forms.Padding(0);
            this.tileControl.Size = new System.Drawing.Size(1160, 150);
            this.tileControl.TabIndex = 1;
            
            // 
            // tileOgrenci
            // 
            this.tileOgrenci.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.tileOgrenci.AppearanceItem.Normal.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.tileOgrenci.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Transparent;
            this.tileOgrenci.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.tileOgrenci.AppearanceItem.Normal.ForeColor = System.Drawing.Color.White;
            this.tileOgrenci.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileOgrenci.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tileOgrenci.AppearanceItem.Normal.Options.UseFont = true;
            this.tileOgrenci.AppearanceItem.Normal.Options.UseForeColor = true;
            this.tileOgrenci.AppearanceItem.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.tileOgrenci.AppearanceItem.Hovered.Options.UseBackColor = true;
            this.tileOgrenci.Id = 0;
            this.tileOgrenci.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.tileOgrenci.Name = "tileOgrenci";
            var tileElementBaslik1 = new DevExpress.XtraEditors.TileItemElement();
            tileElementBaslik1.Text = "👨‍🎓 ÖĞRENCİ";
            tileElementBaslik1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft;
            this.tileOgrenci.Elements.Add(tileElementBaslik1);
            var tileElementSayi1 = new DevExpress.XtraEditors.TileItemElement();
            tileElementSayi1.Text = "0";
            tileElementSayi1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.tileOgrenci.Elements.Add(tileElementSayi1);
            var tileElementAlt1 = new DevExpress.XtraEditors.TileItemElement();
            tileElementAlt1.Text = "Kayıtlı";
            tileElementAlt1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomRight;
            this.tileOgrenci.Elements.Add(tileElementAlt1);
            
            // 
            // tileAkademisyen
            // 
            this.tileAkademisyen.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.tileAkademisyen.AppearanceItem.Normal.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(132)))), ((int)(((byte)(73)))));
            this.tileAkademisyen.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Transparent;
            this.tileAkademisyen.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.tileAkademisyen.AppearanceItem.Normal.ForeColor = System.Drawing.Color.White;
            this.tileAkademisyen.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileAkademisyen.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tileAkademisyen.AppearanceItem.Normal.Options.UseFont = true;
            this.tileAkademisyen.AppearanceItem.Normal.Options.UseForeColor = true;
            this.tileAkademisyen.AppearanceItem.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(132)))), ((int)(((byte)(73)))));
            this.tileAkademisyen.AppearanceItem.Hovered.Options.UseBackColor = true;
            this.tileAkademisyen.Id = 1;
            this.tileAkademisyen.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.tileAkademisyen.Name = "tileAkademisyen";
            var tileElementBaslik2 = new DevExpress.XtraEditors.TileItemElement();
            tileElementBaslik2.Text = "👨‍🏫 AKADEMİSYEN";
            tileElementBaslik2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft;
            this.tileAkademisyen.Elements.Add(tileElementBaslik2);
            var tileElementSayi2 = new DevExpress.XtraEditors.TileItemElement();
            tileElementSayi2.Text = "0";
            tileElementSayi2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.tileAkademisyen.Elements.Add(tileElementSayi2);
            var tileElementAlt2 = new DevExpress.XtraEditors.TileItemElement();
            tileElementAlt2.Text = "Aktif";
            tileElementAlt2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomRight;
            this.tileAkademisyen.Elements.Add(tileElementAlt2);
            
            // 
            // tileDers
            // 
            this.tileDers.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.tileDers.AppearanceItem.Normal.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            this.tileDers.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Transparent;
            this.tileDers.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.tileDers.AppearanceItem.Normal.ForeColor = System.Drawing.Color.White;
            this.tileDers.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileDers.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tileDers.AppearanceItem.Normal.Options.UseFont = true;
            this.tileDers.AppearanceItem.Normal.Options.UseForeColor = true;
            this.tileDers.AppearanceItem.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            this.tileDers.AppearanceItem.Hovered.Options.UseBackColor = true;
            this.tileDers.Id = 2;
            this.tileDers.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.tileDers.Name = "tileDers";
            var tileElementBaslik3 = new DevExpress.XtraEditors.TileItemElement();
            tileElementBaslik3.Text = "📚 DERS";
            tileElementBaslik3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft;
            this.tileDers.Elements.Add(tileElementBaslik3);
            var tileElementSayi3 = new DevExpress.XtraEditors.TileItemElement();
            tileElementSayi3.Text = "0";
            tileElementSayi3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.tileDers.Elements.Add(tileElementSayi3);
            var tileElementAlt3 = new DevExpress.XtraEditors.TileItemElement();
            tileElementAlt3.Text = "Aktif";
            tileElementAlt3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomRight;
            this.tileDers.Elements.Add(tileElementAlt3);
            
            // 
            // tileBolum
            // 
            this.tileBolum.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.tileBolum.AppearanceItem.Normal.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.tileBolum.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Transparent;
            this.tileBolum.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.tileBolum.AppearanceItem.Normal.ForeColor = System.Drawing.Color.White;
            this.tileBolum.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileBolum.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tileBolum.AppearanceItem.Normal.Options.UseFont = true;
            this.tileBolum.AppearanceItem.Normal.Options.UseForeColor = true;
            this.tileBolum.AppearanceItem.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.tileBolum.AppearanceItem.Hovered.Options.UseBackColor = true;
            this.tileBolum.Id = 3;
            this.tileBolum.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.tileBolum.Name = "tileBolum";
            var tileElementBaslik4 = new DevExpress.XtraEditors.TileItemElement();
            tileElementBaslik4.Text = "🏛️ BÖLÜM";
            tileElementBaslik4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft;
            this.tileBolum.Elements.Add(tileElementBaslik4);
            var tileElementSayi4 = new DevExpress.XtraEditors.TileItemElement();
            tileElementSayi4.Text = "0";
            tileElementSayi4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.tileBolum.Elements.Add(tileElementSayi4);
            var tileElementAlt4 = new DevExpress.XtraEditors.TileItemElement();
            tileElementAlt4.Text = "Toplam";
            tileElementAlt4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomRight;
            this.tileBolum.Elements.Add(tileElementAlt4);
            
            // 
            // chartControl
            // 
            this.chartControl.BackColor = System.Drawing.Color.White;
            this.chartControl.Location = new System.Drawing.Point(20, 200);
            this.chartControl.Name = "chartControl";
            this.chartControl.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartControl.Size = new System.Drawing.Size(420, 260);
            this.chartControl.TabIndex = 2;
            
            // 
            // groupAktiviteler
            // 
            this.groupAktiviteler.Appearance.BackColor = System.Drawing.Color.White;
            this.groupAktiviteler.Appearance.Options.UseBackColor = true;
            this.groupAktiviteler.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.groupAktiviteler.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.groupAktiviteler.AppearanceCaption.Options.UseFont = true;
            this.groupAktiviteler.AppearanceCaption.Options.UseForeColor = true;
            this.groupAktiviteler.Controls.Add(this.listBoxAktiviteler);
            this.groupAktiviteler.Location = new System.Drawing.Point(460, 200);
            this.groupAktiviteler.Name = "groupAktiviteler";
            this.groupAktiviteler.Size = new System.Drawing.Size(360, 260);
            this.groupAktiviteler.TabIndex = 3;
            this.groupAktiviteler.Text = "📋 SON AKTİVİTELER";
            
            // 
            // listBoxAktiviteler
            // 
            this.listBoxAktiviteler.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.listBoxAktiviteler.Appearance.Options.UseFont = true;
            this.listBoxAktiviteler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxAktiviteler.Location = new System.Drawing.Point(2, 26);
            this.listBoxAktiviteler.Name = "listBoxAktiviteler";
            this.listBoxAktiviteler.Size = new System.Drawing.Size(356, 232);
            this.listBoxAktiviteler.TabIndex = 0;
            
            // 
            // groupBekleyenler
            // 
            this.groupBekleyenler.Appearance.BackColor = System.Drawing.Color.White;
            this.groupBekleyenler.Appearance.Options.UseBackColor = true;
            this.groupBekleyenler.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.groupBekleyenler.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.groupBekleyenler.AppearanceCaption.Options.UseFont = true;
            this.groupBekleyenler.AppearanceCaption.Options.UseForeColor = true;
            this.groupBekleyenler.Controls.Add(this.lblBekleyenTalepler);
            this.groupBekleyenler.Controls.Add(this.lblDanismanAtama);
            this.groupBekleyenler.Controls.Add(this.lblNotGirilmemis);
            this.groupBekleyenler.Location = new System.Drawing.Point(840, 200);
            this.groupBekleyenler.Name = "groupBekleyenler";
            this.groupBekleyenler.Size = new System.Drawing.Size(340, 260);
            this.groupBekleyenler.TabIndex = 4;
            this.groupBekleyenler.Text = "⚠️ BEKLEYEN İŞLEMLER";
            
            // 
            // lblBekleyenTalepler
            // 
            this.lblBekleyenTalepler.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBekleyenTalepler.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblBekleyenTalepler.Appearance.Options.UseFont = true;
            this.lblBekleyenTalepler.Appearance.Options.UseForeColor = true;
            this.lblBekleyenTalepler.Location = new System.Drawing.Point(20, 50);
            this.lblBekleyenTalepler.Name = "lblBekleyenTalepler";
            this.lblBekleyenTalepler.Size = new System.Drawing.Size(280, 25);
            this.lblBekleyenTalepler.TabIndex = 0;
            this.lblBekleyenTalepler.Text = "📌 0 Ders Kayıt Talebi";
            
            // 
            // lblDanismanAtama
            // 
            this.lblDanismanAtama.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDanismanAtama.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.lblDanismanAtama.Appearance.Options.UseFont = true;
            this.lblDanismanAtama.Appearance.Options.UseForeColor = true;
            this.lblDanismanAtama.Location = new System.Drawing.Point(20, 100);
            this.lblDanismanAtama.Name = "lblDanismanAtama";
            this.lblDanismanAtama.Size = new System.Drawing.Size(280, 25);
            this.lblDanismanAtama.TabIndex = 1;
            this.lblDanismanAtama.Text = "👤 0 Danışman Ataması Gerekli";
            
            // 
            // lblNotGirilmemis
            // 
            this.lblNotGirilmemis.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblNotGirilmemis.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblNotGirilmemis.Appearance.Options.UseFont = true;
            this.lblNotGirilmemis.Appearance.Options.UseForeColor = true;
            this.lblNotGirilmemis.Location = new System.Drawing.Point(20, 150);
            this.lblNotGirilmemis.Name = "lblNotGirilmemis";
            this.lblNotGirilmemis.Size = new System.Drawing.Size(280, 25);
            this.lblNotGirilmemis.TabIndex = 2;
            this.lblNotGirilmemis.Text = "📝 0 Derste Not Girilmemiş";
            
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 742);
            this.Controls.Add(this.dashboardPanel);
            this.Controls.Add(this.panelHeader);
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
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardPanel)).EndInit();
            this.dashboardPanel.ResumeLayout(false);
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
        private DevExpress.XtraBars.BarButtonItem btnAnaSayfa;
        private DevExpress.XtraBars.BarButtonItem btnOgrenciYonetim;
        private DevExpress.XtraBars.BarButtonItem btnAkademisyenYonetim;
        private DevExpress.XtraBars.BarButtonItem btnBolumYonetim;
        private DevExpress.XtraBars.BarButtonItem btnDersYonetim;
        private DevExpress.XtraBars.BarButtonItem btnNotYonetim;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnKullaniciYonetim;
        private DevExpress.XtraBars.BarButtonItem btnEmailAyarlari;
        private DevExpress.XtraBars.BarButtonItem btnCikis;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarStaticItem barStaticItemKullanici;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        
        // Header
        private DevExpress.XtraEditors.PanelControl panelHeader;
        private DevExpress.XtraEditors.LabelControl lblBaslik;
        private DevExpress.XtraEditors.LabelControl lblAltBaslik;
        
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
