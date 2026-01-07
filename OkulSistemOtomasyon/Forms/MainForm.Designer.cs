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
            this.components = new System.ComponentModel.Container();
            
            // Ana konteynerler
            this.panelSidebar = new DevExpress.XtraEditors.PanelControl();
            this.accordionControl = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accordionGroupMenu = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionItemAnaSayfa = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionItemOgrenci = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionItemAkademisyen = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionItemBolum = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionItemDers = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionGroupIslemler = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionItemNotGirisi = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionGroupSistem = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionItemKullanici = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionItemEmailAyarlari = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionItemCikis = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            
            // Logo Panel
            this.panelLogo = new DevExpress.XtraEditors.PanelControl();
            this.lblLogo = new DevExpress.XtraEditors.LabelControl();
            this.lblLogoAlt = new DevExpress.XtraEditors.LabelControl();
            
            // Header Panel (Üst bar)
            this.panelHeader = new DevExpress.XtraEditors.PanelControl();
            this.btnToggleSidebar = new DevExpress.XtraEditors.SimpleButton();
            this.lblBaslik = new DevExpress.XtraEditors.LabelControl();
            this.lblKullaniciBilgi = new DevExpress.XtraEditors.LabelControl();
            this.btnHeaderCikis = new DevExpress.XtraEditors.SimpleButton();
            
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
            
            // XtraTabbedMdiManager
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);

            ((System.ComponentModel.ISupportInitialize)(this.panelSidebar)).BeginInit();
            this.panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelLogo)).BeginInit();
            this.panelLogo.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            
            // ==================== SIDEBAR ====================
            // 
            // panelSidebar
            // 
            this.panelSidebar.Appearance.BackColor = System.Drawing.Color.FromArgb(24, 29, 39);
            this.panelSidebar.Appearance.Options.UseBackColor = true;
            this.panelSidebar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelSidebar.Controls.Add(this.accordionControl);
            this.panelSidebar.Controls.Add(this.panelLogo);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(260, 800);
            this.panelSidebar.TabIndex = 0;
            
            // 
            // panelLogo
            // 
            this.panelLogo.Appearance.BackColor = System.Drawing.Color.FromArgb(17, 21, 28);
            this.panelLogo.Appearance.Options.UseBackColor = true;
            this.panelLogo.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelLogo.Controls.Add(this.lblLogo);
            this.panelLogo.Controls.Add(this.lblLogoAlt);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(260, 90);
            this.panelLogo.TabIndex = 0;
            
            // 
            // lblLogo
            // 
            this.lblLogo.Appearance.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblLogo.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Appearance.Options.UseFont = true;
            this.lblLogo.Appearance.Options.UseForeColor = true;
            this.lblLogo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblLogo.Location = new System.Drawing.Point(15, 18);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(230, 35);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "🎓 UniSys";
            
            // 
            // lblLogoAlt
            // 
            this.lblLogoAlt.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLogoAlt.Appearance.ForeColor = System.Drawing.Color.FromArgb(127, 140, 159);
            this.lblLogoAlt.Appearance.Options.UseFont = true;
            this.lblLogoAlt.Appearance.Options.UseForeColor = true;
            this.lblLogoAlt.Location = new System.Drawing.Point(15, 55);
            this.lblLogoAlt.Name = "lblLogoAlt";
            this.lblLogoAlt.Size = new System.Drawing.Size(230, 20);
            this.lblLogoAlt.TabIndex = 1;
            this.lblLogoAlt.Text = "Üniversite Yönetim Sistemi";
            
            // 
            // accordionControl
            // 
            this.accordionControl.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.accordionControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.accordionControl.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
                this.accordionGroupMenu,
                this.accordionGroupIslemler,
                this.accordionGroupSistem
            });
            this.accordionControl.Location = new System.Drawing.Point(0, 90);
            this.accordionControl.Name = "accordionControl";
            this.accordionControl.OptionsMinimizing.AllowMinimizeMode = DevExpress.Utils.DefaultBoolean.False;
            this.accordionControl.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Hidden;
            this.accordionControl.ShowGroupExpandButtons = false;
            this.accordionControl.Size = new System.Drawing.Size(260, 710);
            this.accordionControl.TabIndex = 1;
            this.accordionControl.ElementClick += new DevExpress.XtraBars.Navigation.ElementClickEventHandler(this.accordionControl_ElementClick);
            
            // 
            // accordionGroupMenu - YÖNETİM
            // 
            this.accordionGroupMenu.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
                this.accordionItemAnaSayfa,
                this.accordionItemOgrenci,
                this.accordionItemAkademisyen,
                this.accordionItemBolum,
                this.accordionItemDers
            });
            this.accordionGroupMenu.Expanded = true;
            this.accordionGroupMenu.Name = "accordionGroupMenu";
            this.accordionGroupMenu.Text = "YÖNETİM";
            
            // 
            // accordionItemAnaSayfa
            // 
            this.accordionItemAnaSayfa.Name = "accordionItemAnaSayfa";
            this.accordionItemAnaSayfa.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionItemAnaSayfa.Text = "  🏠  Ana Sayfa";
            
            // 
            // accordionItemOgrenci
            // 
            this.accordionItemOgrenci.Name = "accordionItemOgrenci";
            this.accordionItemOgrenci.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionItemOgrenci.Text = "  👨‍🎓  Öğrenci Yönetimi";
            
            // 
            // accordionItemAkademisyen
            // 
            this.accordionItemAkademisyen.Name = "accordionItemAkademisyen";
            this.accordionItemAkademisyen.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionItemAkademisyen.Text = "  👨‍🏫  Akademisyen Yönetimi";
            
            // 
            // accordionItemBolum
            // 
            this.accordionItemBolum.Name = "accordionItemBolum";
            this.accordionItemBolum.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionItemBolum.Text = "  🏛️  Bölüm Yönetimi";
            
            // 
            // accordionItemDers
            // 
            this.accordionItemDers.Name = "accordionItemDers";
            this.accordionItemDers.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionItemDers.Text = "  📚  Ders Yönetimi";
            
            // 
            // accordionGroupIslemler - İŞLEMLER
            // 
            this.accordionGroupIslemler.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
                this.accordionItemNotGirisi
            });
            this.accordionGroupIslemler.Expanded = true;
            this.accordionGroupIslemler.Name = "accordionGroupIslemler";
            this.accordionGroupIslemler.Text = "İŞLEMLER";
            
            // 
            // accordionItemNotGirisi
            // 
            this.accordionItemNotGirisi.Name = "accordionItemNotGirisi";
            this.accordionItemNotGirisi.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionItemNotGirisi.Text = "  📝  Not Girişi";
            
            // 
            // accordionGroupSistem - SİSTEM
            // 
            this.accordionGroupSistem.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
                this.accordionItemKullanici,
                this.accordionItemEmailAyarlari,
                this.accordionItemCikis
            });
            this.accordionGroupSistem.Expanded = true;
            this.accordionGroupSistem.Name = "accordionGroupSistem";
            this.accordionGroupSistem.Text = "SİSTEM";
            
            // 
            // accordionItemKullanici
            // 
            this.accordionItemKullanici.Name = "accordionItemKullanici";
            this.accordionItemKullanici.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionItemKullanici.Text = "  👤  Kullanıcı Yönetimi";
            
            // 
            // accordionItemEmailAyarlari
            // 
            this.accordionItemEmailAyarlari.Name = "accordionItemEmailAyarlari";
            this.accordionItemEmailAyarlari.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionItemEmailAyarlari.Text = "  📧  E-Posta Ayarları";
            
            // 
            // accordionItemCikis
            // 
            this.accordionItemCikis.Name = "accordionItemCikis";
            this.accordionItemCikis.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionItemCikis.Text = "  🚪  Çıkış";
            
            // ==================== HEADER ====================
            // 
            // panelHeader
            // 
            this.panelHeader.Appearance.BackColor = System.Drawing.Color.White;
            this.panelHeader.Appearance.Options.UseBackColor = true;
            this.panelHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelHeader.Controls.Add(this.btnToggleSidebar);
            this.panelHeader.Controls.Add(this.lblBaslik);
            this.panelHeader.Controls.Add(this.lblKullaniciBilgi);
            this.panelHeader.Controls.Add(this.btnHeaderCikis);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(260, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1140, 70);
            this.panelHeader.TabIndex = 1;
            
            // 
            // btnToggleSidebar
            // 
            this.btnToggleSidebar.Appearance.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnToggleSidebar.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnToggleSidebar.Appearance.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnToggleSidebar.Appearance.Options.UseBackColor = true;
            this.btnToggleSidebar.Appearance.Options.UseFont = true;
            this.btnToggleSidebar.Appearance.Options.UseForeColor = true;
            this.btnToggleSidebar.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.btnToggleSidebar.AppearanceHovered.Options.UseBackColor = true;
            this.btnToggleSidebar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnToggleSidebar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToggleSidebar.Location = new System.Drawing.Point(15, 15);
            this.btnToggleSidebar.Name = "btnToggleSidebar";
            this.btnToggleSidebar.Size = new System.Drawing.Size(45, 40);
            this.btnToggleSidebar.TabIndex = 3;
            this.btnToggleSidebar.Text = "☰";
            this.btnToggleSidebar.Click += new System.EventHandler(this.btnToggleSidebar_Click);
            
            // 
            // lblBaslik
            // 
            this.lblBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.Appearance.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblBaslik.Appearance.Options.UseFont = true;
            this.lblBaslik.Appearance.Options.UseForeColor = true;
            this.lblBaslik.Location = new System.Drawing.Point(75, 20);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(300, 30);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "📊 Dashboard";
            
            // 
            // lblKullaniciBilgi
            // 
            this.lblKullaniciBilgi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKullaniciBilgi.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKullaniciBilgi.Appearance.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblKullaniciBilgi.Appearance.Options.UseFont = true;
            this.lblKullaniciBilgi.Appearance.Options.UseForeColor = true;
            this.lblKullaniciBilgi.Location = new System.Drawing.Point(700, 23);
            this.lblKullaniciBilgi.Name = "lblKullaniciBilgi";
            this.lblKullaniciBilgi.Size = new System.Drawing.Size(300, 20);
            this.lblKullaniciBilgi.TabIndex = 1;
            this.lblKullaniciBilgi.Text = "👤 Hoş Geldiniz";
            
            // 
            // btnHeaderCikis
            // 
            this.btnHeaderCikis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHeaderCikis.Appearance.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnHeaderCikis.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnHeaderCikis.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnHeaderCikis.Appearance.Options.UseBackColor = true;
            this.btnHeaderCikis.Appearance.Options.UseFont = true;
            this.btnHeaderCikis.Appearance.Options.UseForeColor = true;
            this.btnHeaderCikis.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.btnHeaderCikis.AppearanceHovered.Options.UseBackColor = true;
            this.btnHeaderCikis.AppearancePressed.BackColor = System.Drawing.Color.FromArgb(185, 28, 28);
            this.btnHeaderCikis.AppearancePressed.Options.UseBackColor = true;
            this.btnHeaderCikis.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnHeaderCikis.Location = new System.Drawing.Point(1020, 17);
            this.btnHeaderCikis.Name = "btnHeaderCikis";
            this.btnHeaderCikis.Size = new System.Drawing.Size(100, 36);
            this.btnHeaderCikis.TabIndex = 2;
            this.btnHeaderCikis.Text = "Çıkış";
            this.btnHeaderCikis.Click += new System.EventHandler(this.btnHeaderCikis_Click);
            
            // ==================== DASHBOARD ====================
            // 
            // dashboardPanel
            // 
            this.dashboardPanel.Appearance.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.dashboardPanel.Appearance.Options.UseBackColor = true;
            this.dashboardPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.dashboardPanel.Controls.Add(this.tileControl);
            this.dashboardPanel.Controls.Add(this.chartControl);
            this.dashboardPanel.Controls.Add(this.groupAktiviteler);
            this.dashboardPanel.Controls.Add(this.groupBekleyenler);
            this.dashboardPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dashboardPanel.Location = new System.Drawing.Point(260, 70);
            this.dashboardPanel.Name = "dashboardPanel";
            this.dashboardPanel.Padding = new System.Windows.Forms.Padding(20);
            this.dashboardPanel.Size = new System.Drawing.Size(1140, 730);
            this.dashboardPanel.TabIndex = 2;
            
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
            this.tileControl.IndentBetweenGroups = 15;
            this.tileControl.IndentBetweenItems = 20;
            this.tileControl.ItemSize = 130;
            this.tileControl.Location = new System.Drawing.Point(20, 20);
            this.tileControl.MaxId = 4;
            this.tileControl.Name = "tileControl";
            this.tileControl.Padding = new System.Windows.Forms.Padding(0);
            this.tileControl.Size = new System.Drawing.Size(1100, 180);
            this.tileControl.TabIndex = 0;
            
            // 
            // tileOgrenci
            // 
            this.tileOgrenci.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.tileOgrenci.AppearanceItem.Normal.BackColor2 = System.Drawing.Color.FromArgb(37, 99, 235);
            this.tileOgrenci.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Transparent;
            this.tileOgrenci.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.tileOgrenci.AppearanceItem.Normal.ForeColor = System.Drawing.Color.White;
            this.tileOgrenci.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileOgrenci.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tileOgrenci.AppearanceItem.Normal.Options.UseFont = true;
            this.tileOgrenci.AppearanceItem.Normal.Options.UseForeColor = true;
            this.tileOgrenci.AppearanceItem.Hovered.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
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
            this.tileAkademisyen.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.tileAkademisyen.AppearanceItem.Normal.BackColor2 = System.Drawing.Color.FromArgb(5, 150, 105);
            this.tileAkademisyen.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Transparent;
            this.tileAkademisyen.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.tileAkademisyen.AppearanceItem.Normal.ForeColor = System.Drawing.Color.White;
            this.tileAkademisyen.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileAkademisyen.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tileAkademisyen.AppearanceItem.Normal.Options.UseFont = true;
            this.tileAkademisyen.AppearanceItem.Normal.Options.UseForeColor = true;
            this.tileAkademisyen.AppearanceItem.Hovered.BackColor = System.Drawing.Color.FromArgb(5, 150, 105);
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
            this.tileDers.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(245, 158, 11);
            this.tileDers.AppearanceItem.Normal.BackColor2 = System.Drawing.Color.FromArgb(217, 119, 6);
            this.tileDers.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Transparent;
            this.tileDers.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.tileDers.AppearanceItem.Normal.ForeColor = System.Drawing.Color.White;
            this.tileDers.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileDers.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tileDers.AppearanceItem.Normal.Options.UseFont = true;
            this.tileDers.AppearanceItem.Normal.Options.UseForeColor = true;
            this.tileDers.AppearanceItem.Hovered.BackColor = System.Drawing.Color.FromArgb(217, 119, 6);
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
            this.tileBolum.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(139, 92, 246);
            this.tileBolum.AppearanceItem.Normal.BackColor2 = System.Drawing.Color.FromArgb(124, 58, 237);
            this.tileBolum.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Transparent;
            this.tileBolum.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.tileBolum.AppearanceItem.Normal.ForeColor = System.Drawing.Color.White;
            this.tileBolum.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileBolum.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tileBolum.AppearanceItem.Normal.Options.UseFont = true;
            this.tileBolum.AppearanceItem.Normal.Options.UseForeColor = true;
            this.tileBolum.AppearanceItem.Hovered.BackColor = System.Drawing.Color.FromArgb(124, 58, 237);
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
            this.chartControl.Location = new System.Drawing.Point(20, 220);
            this.chartControl.Name = "chartControl";
            this.chartControl.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartControl.Size = new System.Drawing.Size(400, 280);
            this.chartControl.TabIndex = 1;
            
            // 
            // groupAktiviteler
            // 
            this.groupAktiviteler.Appearance.BackColor = System.Drawing.Color.White;
            this.groupAktiviteler.Appearance.Options.UseBackColor = true;
            this.groupAktiviteler.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.groupAktiviteler.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.groupAktiviteler.AppearanceCaption.Options.UseFont = true;
            this.groupAktiviteler.AppearanceCaption.Options.UseForeColor = true;
            this.groupAktiviteler.Controls.Add(this.listBoxAktiviteler);
            this.groupAktiviteler.Location = new System.Drawing.Point(440, 220);
            this.groupAktiviteler.Name = "groupAktiviteler";
            this.groupAktiviteler.Size = new System.Drawing.Size(340, 280);
            this.groupAktiviteler.TabIndex = 2;
            this.groupAktiviteler.Text = "📋 SON AKTİVİTELER";
            
            // 
            // listBoxAktiviteler
            // 
            this.listBoxAktiviteler.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.listBoxAktiviteler.Appearance.Options.UseFont = true;
            this.listBoxAktiviteler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxAktiviteler.Location = new System.Drawing.Point(2, 26);
            this.listBoxAktiviteler.Name = "listBoxAktiviteler";
            this.listBoxAktiviteler.Size = new System.Drawing.Size(336, 252);
            this.listBoxAktiviteler.TabIndex = 0;
            
            // 
            // groupBekleyenler
            // 
            this.groupBekleyenler.Appearance.BackColor = System.Drawing.Color.White;
            this.groupBekleyenler.Appearance.Options.UseBackColor = true;
            this.groupBekleyenler.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.groupBekleyenler.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.groupBekleyenler.AppearanceCaption.Options.UseFont = true;
            this.groupBekleyenler.AppearanceCaption.Options.UseForeColor = true;
            this.groupBekleyenler.Controls.Add(this.lblBekleyenTalepler);
            this.groupBekleyenler.Controls.Add(this.lblDanismanAtama);
            this.groupBekleyenler.Controls.Add(this.lblNotGirilmemis);
            this.groupBekleyenler.Location = new System.Drawing.Point(800, 220);
            this.groupBekleyenler.Name = "groupBekleyenler";
            this.groupBekleyenler.Size = new System.Drawing.Size(320, 280);
            this.groupBekleyenler.TabIndex = 3;
            this.groupBekleyenler.Text = "⚠️ BEKLEYEN İŞLEMLER";
            
            // 
            // lblBekleyenTalepler
            // 
            this.lblBekleyenTalepler.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblBekleyenTalepler.Appearance.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68);
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
            this.lblDanismanAtama.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDanismanAtama.Appearance.ForeColor = System.Drawing.Color.FromArgb(245, 158, 11);
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
            this.lblNotGirilmemis.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblNotGirilmemis.Appearance.ForeColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.lblNotGirilmemis.Appearance.Options.UseFont = true;
            this.lblNotGirilmemis.Appearance.Options.UseForeColor = true;
            this.lblNotGirilmemis.Location = new System.Drawing.Point(20, 150);
            this.lblNotGirilmemis.Name = "lblNotGirilmemis";
            this.lblNotGirilmemis.Size = new System.Drawing.Size(280, 25);
            this.lblNotGirilmemis.TabIndex = 2;
            this.lblNotGirilmemis.Text = "📝 0 Derste Not Girilmemiş";
            
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            this.xtraTabbedMdiManager1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Top;
            
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.dashboardPanel);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Üniversite Yönetim Sistemi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelSidebar)).EndInit();
            this.panelSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelLogo)).EndInit();
            this.panelLogo.ResumeLayout(false);
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
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        // Sidebar
        private DevExpress.XtraEditors.PanelControl panelSidebar;
        private DevExpress.XtraEditors.PanelControl panelLogo;
        private DevExpress.XtraEditors.LabelControl lblLogo;
        private DevExpress.XtraEditors.LabelControl lblLogoAlt;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionGroupMenu;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionItemAnaSayfa;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionItemOgrenci;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionItemAkademisyen;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionItemBolum;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionItemDers;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionGroupIslemler;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionItemNotGirisi;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionGroupSistem;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionItemKullanici;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionItemEmailAyarlari;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionItemCikis;
        
        // Header
        private DevExpress.XtraEditors.PanelControl panelHeader;
        private DevExpress.XtraEditors.SimpleButton btnToggleSidebar;
        private DevExpress.XtraEditors.LabelControl lblBaslik;
        private DevExpress.XtraEditors.LabelControl lblKullaniciBilgi;
        private DevExpress.XtraEditors.SimpleButton btnHeaderCikis;
        
        // Dashboard
        private DevExpress.XtraEditors.PanelControl dashboardPanel;
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
        
        // MDI Manager
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
    }
}
