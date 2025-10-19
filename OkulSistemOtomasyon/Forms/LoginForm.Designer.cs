namespace OkulSistemOtomasyon.Forms
{
    partial class LoginForm
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
            this.lblBaslik = new DevExpress.XtraEditors.LabelControl();
            this.panelCenter = new DevExpress.XtraEditors.PanelControl();
            this.lblAltBaslik = new DevExpress.XtraEditors.LabelControl();
            this.btnGiris = new DevExpress.XtraEditors.SimpleButton();
            this.txtSifre = new DevExpress.XtraEditors.TextEdit();
            this.txtKullaniciAdi = new DevExpress.XtraEditors.TextEdit();
            this.lblSifre = new DevExpress.XtraEditors.LabelControl();
            this.lblKullaniciAdi = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelCenter)).BeginInit();
            this.panelCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panelHeader.Appearance.Options.UseBackColor = true;
            this.panelHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelHeader.Controls.Add(this.lblBaslik);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(500, 80);
            this.panelHeader.TabIndex = 0;
            // 
            // lblBaslik
            // 
            this.lblBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Appearance.Options.UseFont = true;
            this.lblBaslik.Appearance.Options.UseForeColor = true;
            this.lblBaslik.Appearance.Options.UseTextOptions = true;
            this.lblBaslik.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblBaslik.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblBaslik.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblBaslik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBaslik.Location = new System.Drawing.Point(0, 0);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(500, 80);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "OKUL SİSTEM OTOMASYONU";
            // 
            // panelCenter
            // 
            this.panelCenter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelCenter.Controls.Add(this.lblAltBaslik);
            this.panelCenter.Controls.Add(this.btnGiris);
            this.panelCenter.Controls.Add(this.txtSifre);
            this.panelCenter.Controls.Add(this.txtKullaniciAdi);
            this.panelCenter.Controls.Add(this.lblSifre);
            this.panelCenter.Controls.Add(this.lblKullaniciAdi);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 80);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Padding = new System.Windows.Forms.Padding(40, 30, 40, 30);
            this.panelCenter.Size = new System.Drawing.Size(500, 320);
            this.panelCenter.TabIndex = 1;
            // 
            // lblAltBaslik
            // 
            this.lblAltBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblAltBaslik.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.lblAltBaslik.Appearance.Options.UseFont = true;
            this.lblAltBaslik.Appearance.Options.UseForeColor = true;
            this.lblAltBaslik.Appearance.Options.UseTextOptions = true;
            this.lblAltBaslik.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblAltBaslik.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblAltBaslik.Location = new System.Drawing.Point(40, 30);
            this.lblAltBaslik.Name = "lblAltBaslik";
            this.lblAltBaslik.Size = new System.Drawing.Size(420, 25);
            this.lblAltBaslik.TabIndex = 5;
            this.lblAltBaslik.Text = "Devam etmek için lütfen giriş yapın";
            // 
            // lblKullaniciAdi
            // 
            this.lblKullaniciAdi.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKullaniciAdi.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblKullaniciAdi.Appearance.Options.UseFont = true;
            this.lblKullaniciAdi.Appearance.Options.UseForeColor = true;
            this.lblKullaniciAdi.Location = new System.Drawing.Point(40, 75);
            this.lblKullaniciAdi.Name = "lblKullaniciAdi";
            this.lblKullaniciAdi.Size = new System.Drawing.Size(78, 19);
            this.lblKullaniciAdi.TabIndex = 0;
            this.lblKullaniciAdi.Text = "Kullanıcı Adı:";
            // 
            // lblSifre
            // 
            this.lblSifre.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSifre.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSifre.Appearance.Options.UseFont = true;
            this.lblSifre.Appearance.Options.UseForeColor = true;
            this.lblSifre.Location = new System.Drawing.Point(40, 145);
            this.lblSifre.Name = "lblSifre";
            this.lblSifre.Size = new System.Drawing.Size(32, 19);
            this.lblSifre.TabIndex = 2;
            this.lblSifre.Text = "Şifre:";
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Location = new System.Drawing.Point(40, 100);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtKullaniciAdi.Properties.Appearance.Options.UseFont = true;
            this.txtKullaniciAdi.Properties.AutoHeight = false;
            this.txtKullaniciAdi.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtKullaniciAdi.Size = new System.Drawing.Size(420, 38);
            this.txtKullaniciAdi.TabIndex = 1;
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(40, 170);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSifre.Properties.Appearance.Options.UseFont = true;
            this.txtSifre.Properties.AutoHeight = false;
            this.txtSifre.Properties.PasswordChar = '●';
            this.txtSifre.Properties.UseSystemPasswordChar = true;
            this.txtSifre.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtSifre.Size = new System.Drawing.Size(420, 38);
            this.txtSifre.TabIndex = 3;
            // 
            // btnGiris
            // 
            this.btnGiris.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnGiris.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnGiris.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnGiris.Appearance.Options.UseBackColor = true;
            this.btnGiris.Appearance.Options.UseFont = true;
            this.btnGiris.Appearance.Options.UseForeColor = true;
            this.btnGiris.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.btnGiris.AppearanceHovered.Options.UseBackColor = true;
            this.btnGiris.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGiris.Location = new System.Drawing.Point(40, 230);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new System.Drawing.Size(420, 45);
            this.btnGiris.TabIndex = 4;
            this.btnGiris.Text = "GİRİŞ YAP";
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click);

            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnGiris;
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş - Okul Sistem Otomasyonu";
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).EndInit();
            this.panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelCenter)).EndInit();
            this.panelCenter.ResumeLayout(false);
            this.panelCenter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelHeader;
        private DevExpress.XtraEditors.LabelControl lblBaslik;
        private DevExpress.XtraEditors.PanelControl panelCenter;
        private DevExpress.XtraEditors.LabelControl lblAltBaslik;
        private DevExpress.XtraEditors.SimpleButton btnGiris;
        private DevExpress.XtraEditors.TextEdit txtSifre;
        private DevExpress.XtraEditors.TextEdit txtKullaniciAdi;
        private DevExpress.XtraEditors.LabelControl lblSifre;
        private DevExpress.XtraEditors.LabelControl lblKullaniciAdi;
    }
}
