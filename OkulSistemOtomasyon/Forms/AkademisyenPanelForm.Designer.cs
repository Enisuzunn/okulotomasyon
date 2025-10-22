namespace OkulSistemOtomasyon.Forms
{
    partial class AkademisyenPanelForm
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
            this.lblHosgeldin = new DevExpress.XtraEditors.LabelControl();
            this.lblEmail = new DevExpress.XtraEditors.LabelControl();
            this.lblUzmanlik = new DevExpress.XtraEditors.LabelControl();
            this.btnCikis = new DevExpress.XtraEditors.SimpleButton();
            this.panelDersler = new DevExpress.XtraEditors.GroupControl();
            this.gridControlDersler = new DevExpress.XtraGrid.GridControl();
            this.gridViewDersler = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblDersSayisi = new DevExpress.XtraEditors.LabelControl();
            this.panelOgrenciler = new DevExpress.XtraEditors.GroupControl();
            this.gridControlOgrenciler = new DevExpress.XtraGrid.GridControl();
            this.gridViewOgrenciler = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblOgrenciSayisi = new DevExpress.XtraEditors.LabelControl();
            this.btnNotGir = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelDersler)).BeginInit();
            this.panelDersler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDersler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDersler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelOgrenciler)).BeginInit();
            this.panelOgrenciler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOgrenciler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOgrenciler)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelHeader.Appearance.Options.UseBackColor = true;
            this.panelHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelHeader.Controls.Add(this.lblHosgeldin);
            this.panelHeader.Controls.Add(this.lblEmail);
            this.panelHeader.Controls.Add(this.lblUzmanlik);
            this.panelHeader.Controls.Add(this.btnCikis);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1200, 100);
            this.panelHeader.TabIndex = 0;
            // 
            // lblHosgeldin
            // 
            this.lblHosgeldin.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHosgeldin.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblHosgeldin.Appearance.Options.UseFont = true;
            this.lblHosgeldin.Appearance.Options.UseForeColor = true;
            this.lblHosgeldin.Location = new System.Drawing.Point(20, 15);
            this.lblHosgeldin.Name = "lblHosgeldin";
            this.lblHosgeldin.Size = new System.Drawing.Size(200, 30);
            this.lblHosgeldin.TabIndex = 0;
            this.lblHosgeldin.Text = "Hoş Geldiniz";
            // 
            // lblEmail
            // 
            this.lblEmail.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEmail.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblEmail.Appearance.Options.UseFont = true;
            this.lblEmail.Appearance.Options.UseForeColor = true;
            this.lblEmail.Location = new System.Drawing.Point(20, 50);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(100, 19);
            this.lblEmail.TabIndex = 1;
            this.lblEmail.Text = "Email:";
            // 
            // lblUzmanlik
            // 
            this.lblUzmanlik.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUzmanlik.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblUzmanlik.Appearance.Options.UseFont = true;
            this.lblUzmanlik.Appearance.Options.UseForeColor = true;
            this.lblUzmanlik.Location = new System.Drawing.Point(20, 75);
            this.lblUzmanlik.Name = "lblUzmanlik";
            this.lblUzmanlik.Size = new System.Drawing.Size(100, 19);
            this.lblUzmanlik.TabIndex = 2;
            this.lblUzmanlik.Text = "Uzmanlık:";
            // 
            // btnCikis
            // 
            this.btnCikis.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCikis.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCikis.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnCikis.Appearance.Options.UseBackColor = true;
            this.btnCikis.Appearance.Options.UseFont = true;
            this.btnCikis.Appearance.Options.UseForeColor = true;
            this.btnCikis.Location = new System.Drawing.Point(1050, 30);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(130, 40);
            this.btnCikis.TabIndex = 3;
            this.btnCikis.Text = "🚪 Çıkış";
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // panelDersler
            // 
            this.panelDersler.Controls.Add(this.gridControlDersler);
            this.panelDersler.Controls.Add(this.lblDersSayisi);
            this.panelDersler.Location = new System.Drawing.Point(12, 115);
            this.panelDersler.Name = "panelDersler";
            this.panelDersler.Size = new System.Drawing.Size(580, 500);
            this.panelDersler.TabIndex = 1;
            this.panelDersler.Text = "📚 Verdiğim Dersler";
            // 
            // gridControlDersler
            // 
            this.gridControlDersler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDersler.Location = new System.Drawing.Point(2, 23);
            this.gridControlDersler.MainView = this.gridViewDersler;
            this.gridControlDersler.Name = "gridControlDersler";
            this.gridControlDersler.Size = new System.Drawing.Size(576, 445);
            this.gridControlDersler.TabIndex = 0;
            this.gridControlDersler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDersler});
            // 
            // gridViewDersler
            // 
            this.gridViewDersler.GridControl = this.gridControlDersler;
            this.gridViewDersler.Name = "gridViewDersler";
            this.gridViewDersler.OptionsBehavior.Editable = false;
            this.gridViewDersler.OptionsView.ShowGroupPanel = false;
            this.gridViewDersler.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewDersler_FocusedRowChanged);
            // 
            // lblDersSayisi
            // 
            this.lblDersSayisi.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDersSayisi.Appearance.Options.UseFont = true;
            this.lblDersSayisi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblDersSayisi.Location = new System.Drawing.Point(2, 468);
            this.lblDersSayisi.Name = "lblDersSayisi";
            this.lblDersSayisi.Padding = new System.Windows.Forms.Padding(5);
            this.lblDersSayisi.Size = new System.Drawing.Size(88, 30);
            this.lblDersSayisi.TabIndex = 1;
            this.lblDersSayisi.Text = "Toplam Ders: 0";
            // 
            // panelOgrenciler
            // 
            this.panelOgrenciler.Controls.Add(this.gridControlOgrenciler);
            this.panelOgrenciler.Controls.Add(this.lblOgrenciSayisi);
            this.panelOgrenciler.Controls.Add(this.btnNotGir);
            this.panelOgrenciler.Location = new System.Drawing.Point(608, 115);
            this.panelOgrenciler.Name = "panelOgrenciler";
            this.panelOgrenciler.Size = new System.Drawing.Size(580, 500);
            this.panelOgrenciler.TabIndex = 2;
            this.panelOgrenciler.Text = "👨‍🎓 Kayıtlı Öğrenciler ve Notlar";
            // 
            // gridControlOgrenciler
            // 
            this.gridControlOgrenciler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlOgrenciler.Location = new System.Drawing.Point(2, 23);
            this.gridControlOgrenciler.MainView = this.gridViewOgrenciler;
            this.gridControlOgrenciler.Name = "gridControlOgrenciler";
            this.gridControlOgrenciler.Size = new System.Drawing.Size(576, 395);
            this.gridControlOgrenciler.TabIndex = 0;
            this.gridControlOgrenciler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewOgrenciler});
            // 
            // gridViewOgrenciler
            // 
            this.gridViewOgrenciler.GridControl = this.gridControlOgrenciler;
            this.gridViewOgrenciler.Name = "gridViewOgrenciler";
            this.gridViewOgrenciler.OptionsBehavior.Editable = false;
            this.gridViewOgrenciler.OptionsView.ShowGroupPanel = false;
            // 
            // lblOgrenciSayisi
            // 
            this.lblOgrenciSayisi.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOgrenciSayisi.Appearance.Options.UseFont = true;
            this.lblOgrenciSayisi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblOgrenciSayisi.Location = new System.Drawing.Point(2, 418);
            this.lblOgrenciSayisi.Name = "lblOgrenciSayisi";
            this.lblOgrenciSayisi.Padding = new System.Windows.Forms.Padding(5);
            this.lblOgrenciSayisi.Size = new System.Drawing.Size(115, 30);
            this.lblOgrenciSayisi.TabIndex = 1;
            this.lblOgrenciSayisi.Text = "Kayıtlı Öğrenci: 0";
            // 
            // btnNotGir
            // 
            this.btnNotGir.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnNotGir.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnNotGir.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnNotGir.Appearance.Options.UseBackColor = true;
            this.btnNotGir.Appearance.Options.UseFont = true;
            this.btnNotGir.Appearance.Options.UseForeColor = true;
            this.btnNotGir.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnNotGir.Location = new System.Drawing.Point(2, 448);
            this.btnNotGir.Name = "btnNotGir";
            this.btnNotGir.Size = new System.Drawing.Size(576, 50);
            this.btnNotGir.TabIndex = 2;
            this.btnNotGir.Text = "📝 Not Gir / Güncelle";
            this.btnNotGir.Click += new System.EventHandler(this.btnNotGir_Click);
            // 
            // AkademisyenPanelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 630);
            this.Controls.Add(this.panelOgrenciler);
            this.Controls.Add(this.panelDersler);
            this.Controls.Add(this.panelHeader);
            this.Name = "AkademisyenPanelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Akademisyen Paneli";
            this.Load += new System.EventHandler(this.AkademisyenPanelForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelDersler)).EndInit();
            this.panelDersler.ResumeLayout(false);
            this.panelDersler.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDersler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDersler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelOgrenciler)).EndInit();
            this.panelOgrenciler.ResumeLayout(false);
            this.panelOgrenciler.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOgrenciler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOgrenciler)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelHeader;
        private DevExpress.XtraEditors.LabelControl lblHosgeldin;
        private DevExpress.XtraEditors.LabelControl lblEmail;
        private DevExpress.XtraEditors.LabelControl lblUzmanlik;
        private DevExpress.XtraEditors.SimpleButton btnCikis;
        private DevExpress.XtraEditors.GroupControl panelDersler;
        private DevExpress.XtraGrid.GridControl gridControlDersler;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDersler;
        private DevExpress.XtraEditors.LabelControl lblDersSayisi;
        private DevExpress.XtraEditors.GroupControl panelOgrenciler;
        private DevExpress.XtraGrid.GridControl gridControlOgrenciler;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewOgrenciler;
        private DevExpress.XtraEditors.LabelControl lblOgrenciSayisi;
        private DevExpress.XtraEditors.SimpleButton btnNotGir;
    }
}
