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
            this.btnOgretmenYonetim = new DevExpress.XtraBars.BarButtonItem();
            this.btnSinifYonetim = new DevExpress.XtraBars.BarButtonItem();
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
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnOgrenciYonetim,
            this.btnOgretmenYonetim,
            this.btnSinifYonetim,
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
            // btnOgretmenYonetim
            // 
            this.btnOgretmenYonetim.Caption = "Öğretmen Yönetimi";
            this.btnOgretmenYonetim.Id = 2;
            this.btnOgretmenYonetim.Name = "btnOgretmenYonetim";
            this.btnOgretmenYonetim.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOgretmenYonetim_ItemClick);
            // 
            // btnSinifYonetim
            // 
            this.btnSinifYonetim.Caption = "Sınıf Yönetimi";
            this.btnSinifYonetim.Id = 3;
            this.btnSinifYonetim.Name = "btnSinifYonetim";
            this.btnSinifYonetim.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSinifYonetim_ItemClick);
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
            this.ribbonPageGroup1.ItemLinks.Add(this.btnOgretmenYonetim);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSinifYonetim);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 642);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Ribbon = this.ribbonControl1;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "Okul Sistem Otomasyonu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnOgrenciYonetim;
        private DevExpress.XtraBars.BarButtonItem btnOgretmenYonetim;
        private DevExpress.XtraBars.BarButtonItem btnSinifYonetim;
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
    }
}
