namespace OkulSistemOtomasyon.Forms
{
    partial class OgrenciPanelForm
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
            this.panelHeader = new DevExpress.XtraEditors.PanelControl();
            this.btnCikis = new DevExpress.XtraEditors.SimpleButton();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnNotYazdir = new DevExpress.XtraEditors.SimpleButton();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            this.lblSinif = new DevExpress.XtraEditors.LabelControl();
            this.lblBolum = new DevExpress.XtraEditors.LabelControl();
            this.lblOgrenciNo = new DevExpress.XtraEditors.LabelControl();
            this.lblOgrenciAd = new DevExpress.XtraEditors.LabelControl();
            this.panelFooter = new DevExpress.XtraEditors.PanelControl();
            this.lblAlinanKredi = new DevExpress.XtraEditors.LabelControl();
            this.lblToplamDers = new DevExpress.XtraEditors.LabelControl();
            this.lblGNO = new DevExpress.XtraEditors.LabelControl();
            this.gridNotlar = new DevExpress.XtraGrid.GridControl();
            this.gridViewNotlar = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelFooter)).BeginInit();
            this.panelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNotlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNotlar)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.btnCikis);
            this.panelHeader.Controls.Add(this.btnExport);
            this.panelHeader.Controls.Add(this.btnNotYazdir);
            this.panelHeader.Controls.Add(this.btnYenile);
            this.panelHeader.Controls.Add(this.lblSinif);
            this.panelHeader.Controls.Add(this.lblBolum);
            this.panelHeader.Controls.Add(this.lblOgrenciNo);
            this.panelHeader.Controls.Add(this.lblOgrenciAd);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1400, 120);
            this.panelHeader.TabIndex = 0;
            // 
            // btnCikis
            // 
            this.btnCikis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCikis.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCikis.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCikis.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnCikis.Appearance.Options.UseBackColor = true;
            this.btnCikis.Appearance.Options.UseFont = true;
            this.btnCikis.Appearance.Options.UseForeColor = true;
            this.btnCikis.Location = new System.Drawing.Point(1240, 60);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(140, 45);
            this.btnCikis.TabIndex = 7;
            this.btnCikis.Text = "🚪 Çıkış";
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnExport.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExport.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnExport.Appearance.Options.UseBackColor = true;
            this.btnExport.Appearance.Options.UseFont = true;
            this.btnExport.Appearance.Options.UseForeColor = true;
            this.btnExport.Location = new System.Drawing.Point(1090, 60);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(140, 45);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "📊 Dışa Aktar";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnNotYazdir
            // 
            this.btnNotYazdir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNotYazdir.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnNotYazdir.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNotYazdir.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnNotYazdir.Appearance.Options.UseBackColor = true;
            this.btnNotYazdir.Appearance.Options.UseFont = true;
            this.btnNotYazdir.Appearance.Options.UseForeColor = true;
            this.btnNotYazdir.Location = new System.Drawing.Point(940, 60);
            this.btnNotYazdir.Name = "btnNotYazdir";
            this.btnNotYazdir.Size = new System.Drawing.Size(140, 45);
            this.btnNotYazdir.TabIndex = 5;
            this.btnNotYazdir.Text = "🖨️ Yazdır";
            this.btnNotYazdir.Click += new System.EventHandler(this.btnNotYazdir_Click);
            // 
            // btnYenile
            // 
            this.btnYenile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYenile.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnYenile.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnYenile.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnYenile.Appearance.Options.UseBackColor = true;
            this.btnYenile.Appearance.Options.UseFont = true;
            this.btnYenile.Appearance.Options.UseForeColor = true;
            this.btnYenile.Location = new System.Drawing.Point(790, 60);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(140, 45);
            this.btnYenile.TabIndex = 4;
            this.btnYenile.Text = "🔄 Yenile";
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // lblSinif
            // 
            this.lblSinif.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSinif.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.lblSinif.Appearance.Options.UseFont = true;
            this.lblSinif.Appearance.Options.UseForeColor = true;
            this.lblSinif.Location = new System.Drawing.Point(20, 85);
            this.lblSinif.Name = "lblSinif";
            this.lblSinif.Size = new System.Drawing.Size(44, 19);
            this.lblSinif.TabIndex = 3;
            this.lblSinif.Text = "Sınıf: -";
            // 
            // lblBolum
            // 
            this.lblBolum.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBolum.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.lblBolum.Appearance.Options.UseFont = true;
            this.lblBolum.Appearance.Options.UseForeColor = true;
            this.lblBolum.Location = new System.Drawing.Point(20, 60);
            this.lblBolum.Name = "lblBolum";
            this.lblBolum.Size = new System.Drawing.Size(60, 19);
            this.lblBolum.TabIndex = 2;
            this.lblBolum.Text = "Bölüm: -";
            // 
            // lblOgrenciNo
            // 
            this.lblOgrenciNo.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblOgrenciNo.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.lblOgrenciNo.Appearance.Options.UseFont = true;
            this.lblOgrenciNo.Appearance.Options.UseForeColor = true;
            this.lblOgrenciNo.Location = new System.Drawing.Point(20, 35);
            this.lblOgrenciNo.Name = "lblOgrenciNo";
            this.lblOgrenciNo.Size = new System.Drawing.Size(94, 19);
            this.lblOgrenciNo.TabIndex = 1;
            this.lblOgrenciNo.Text = "Öğrenci No: -";
            // 
            // lblOgrenciAd
            // 
            this.lblOgrenciAd.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblOgrenciAd.Appearance.Options.UseFont = true;
            this.lblOgrenciAd.Location = new System.Drawing.Point(20, 10);
            this.lblOgrenciAd.Name = "lblOgrenciAd";
            this.lblOgrenciAd.Size = new System.Drawing.Size(177, 25);
            this.lblOgrenciAd.TabIndex = 0;
            this.lblOgrenciAd.Text = "🎓 Öğrenci Bilgileri";
            // 
            // panelFooter
            // 
            this.panelFooter.Controls.Add(this.lblAlinanKredi);
            this.panelFooter.Controls.Add(this.lblToplamDers);
            this.panelFooter.Controls.Add(this.lblGNO);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 700);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(1400, 60);
            this.panelFooter.TabIndex = 1;
            // 
            // lblAlinanKredi
            // 
            this.lblAlinanKredi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAlinanKredi.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblAlinanKredi.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblAlinanKredi.Appearance.Options.UseFont = true;
            this.lblAlinanKredi.Appearance.Options.UseForeColor = true;
            this.lblAlinanKredi.Location = new System.Drawing.Point(1200, 20);
            this.lblAlinanKredi.Name = "lblAlinanKredi";
            this.lblAlinanKredi.Size = new System.Drawing.Size(120, 20);
            this.lblAlinanKredi.TabIndex = 2;
            this.lblAlinanKredi.Text = "Alınan Kredi: 0";
            // 
            // lblToplamDers
            // 
            this.lblToplamDers.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblToplamDers.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblToplamDers.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.lblToplamDers.Appearance.Options.UseFont = true;
            this.lblToplamDers.Appearance.Options.UseForeColor = true;
            this.lblToplamDers.Location = new System.Drawing.Point(610, 20);
            this.lblToplamDers.Name = "lblToplamDers";
            this.lblToplamDers.Size = new System.Drawing.Size(170, 20);
            this.lblToplamDers.TabIndex = 1;
            this.lblToplamDers.Text = "Toplam Ders Sayısı: 0";
            // 
            // lblGNO
            // 
            this.lblGNO.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblGNO.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblGNO.Appearance.Options.UseFont = true;
            this.lblGNO.Appearance.Options.UseForeColor = true;
            this.lblGNO.Location = new System.Drawing.Point(20, 18);
            this.lblGNO.Name = "lblGNO";
            this.lblGNO.Size = new System.Drawing.Size(243, 21);
            this.lblGNO.TabIndex = 0;
            this.lblGNO.Text = "Genel Not Ortalaması: 0.00";
            // 
            // gridNotlar
            // 
            this.gridNotlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridNotlar.Location = new System.Drawing.Point(0, 120);
            this.gridNotlar.MainView = this.gridViewNotlar;
            this.gridNotlar.Name = "gridNotlar";
            this.gridNotlar.Size = new System.Drawing.Size(1400, 580);
            this.gridNotlar.TabIndex = 2;
            this.gridNotlar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewNotlar});
            // 
            // gridViewNotlar
            // 
            this.gridViewNotlar.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gridViewNotlar.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewNotlar.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.gridViewNotlar.Appearance.Row.Options.UseFont = true;
            this.gridViewNotlar.GridControl = this.gridNotlar;
            this.gridViewNotlar.Name = "gridViewNotlar";
            this.gridViewNotlar.OptionsBehavior.Editable = false;
            this.gridViewNotlar.OptionsBehavior.ReadOnly = true;
            this.gridViewNotlar.OptionsView.ShowGroupPanel = false;
            this.gridViewNotlar.RowHeight = 35;
            // 
            // OgrenciPanelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 760);
            this.Controls.Add(this.gridNotlar);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelHeader);
            this.Name = "OgrenciPanelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "📚 Öğrenci Not Paneli - Okul Yönetim Sistemi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OgrenciPanelForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelFooter)).EndInit();
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNotlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNotlar)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelHeader;
        private DevExpress.XtraEditors.LabelControl lblOgrenciAd;
        private DevExpress.XtraEditors.LabelControl lblOgrenciNo;
        private DevExpress.XtraEditors.LabelControl lblBolum;
        private DevExpress.XtraEditors.LabelControl lblSinif;
        private DevExpress.XtraEditors.SimpleButton btnYenile;
        private DevExpress.XtraEditors.SimpleButton btnNotYazdir;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.SimpleButton btnCikis;
        private DevExpress.XtraEditors.PanelControl panelFooter;
        private DevExpress.XtraEditors.LabelControl lblGNO;
        private DevExpress.XtraEditors.LabelControl lblToplamDers;
        private DevExpress.XtraEditors.LabelControl lblAlinanKredi;
        private DevExpress.XtraGrid.GridControl gridNotlar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewNotlar;
    }
}
