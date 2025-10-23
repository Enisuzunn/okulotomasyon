namespace OkulSistemOtomasyon.Forms
{
    partial class SifreDegistirForm
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
            this.lblBaslik = new DevExpress.XtraEditors.LabelControl();
            this.lblAciklama = new DevExpress.XtraEditors.LabelControl();
            this.lblEskiSifre = new DevExpress.XtraEditors.LabelControl();
            this.txtEskiSifre = new DevExpress.XtraEditors.TextEdit();
            this.lblYeniSifre = new DevExpress.XtraEditors.LabelControl();
            this.txtYeniSifre = new DevExpress.XtraEditors.TextEdit();
            this.lblYeniSifreTekrar = new DevExpress.XtraEditors.LabelControl();
            this.txtYeniSifreTekrar = new DevExpress.XtraEditors.TextEdit();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.btnIptal = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtEskiSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniSifreTekrar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBaslik
            // 
            this.lblBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.Appearance.Options.UseFont = true;
            this.lblBaslik.Location = new System.Drawing.Point(30, 30);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(180, 30);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Şifre Değiştirme";
            // 
            // lblAciklama
            // 
            this.lblAciklama.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAciklama.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblAciklama.Appearance.Options.UseFont = true;
            this.lblAciklama.Appearance.Options.UseForeColor = true;
            this.lblAciklama.Location = new System.Drawing.Point(30, 70);
            this.lblAciklama.Name = "lblAciklama";
            this.lblAciklama.Size = new System.Drawing.Size(380, 19);
            this.lblAciklama.TabIndex = 1;
            this.lblAciklama.Text = "İlk girişiniz! Güvenliğiniz için lütfen şifrenizi değiştirin.";
            // 
            // lblEskiSifre
            // 
            this.lblEskiSifre.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEskiSifre.Appearance.Options.UseFont = true;
            this.lblEskiSifre.Location = new System.Drawing.Point(30, 120);
            this.lblEskiSifre.Name = "lblEskiSifre";
            this.lblEskiSifre.Size = new System.Drawing.Size(134, 19);
            this.lblEskiSifre.TabIndex = 2;
            this.lblEskiSifre.Text = "Mevcut Şifre (Okul No):";
            // 
            // txtEskiSifre
            // 
            this.txtEskiSifre.Location = new System.Drawing.Point(30, 145);
            this.txtEskiSifre.Name = "txtEskiSifre";
            this.txtEskiSifre.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtEskiSifre.Properties.Appearance.Options.UseFont = true;
            this.txtEskiSifre.Properties.PasswordChar = '●';
            this.txtEskiSifre.Properties.UseSystemPasswordChar = true;
            this.txtEskiSifre.Size = new System.Drawing.Size(400, 26);
            this.txtEskiSifre.TabIndex = 0;
            // 
            // lblYeniSifre
            // 
            this.lblYeniSifre.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblYeniSifre.Appearance.Options.UseFont = true;
            this.lblYeniSifre.Location = new System.Drawing.Point(30, 190);
            this.lblYeniSifre.Name = "lblYeniSifre";
            this.lblYeniSifre.Size = new System.Drawing.Size(64, 19);
            this.lblYeniSifre.TabIndex = 4;
            this.lblYeniSifre.Text = "Yeni Şifre:";
            // 
            // txtYeniSifre
            // 
            this.txtYeniSifre.Location = new System.Drawing.Point(30, 215);
            this.txtYeniSifre.Name = "txtYeniSifre";
            this.txtYeniSifre.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtYeniSifre.Properties.Appearance.Options.UseFont = true;
            this.txtYeniSifre.Properties.PasswordChar = '●';
            this.txtYeniSifre.Properties.UseSystemPasswordChar = true;
            this.txtYeniSifre.Size = new System.Drawing.Size(400, 26);
            this.txtYeniSifre.TabIndex = 1;
            // 
            // lblYeniSifreTekrar
            // 
            this.lblYeniSifreTekrar.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblYeniSifreTekrar.Appearance.Options.UseFont = true;
            this.lblYeniSifreTekrar.Location = new System.Drawing.Point(30, 260);
            this.lblYeniSifreTekrar.Name = "lblYeniSifreTekrar";
            this.lblYeniSifreTekrar.Size = new System.Drawing.Size(117, 19);
            this.lblYeniSifreTekrar.TabIndex = 6;
            this.lblYeniSifreTekrar.Text = "Yeni Şifre (Tekrar):";
            // 
            // txtYeniSifreTekrar
            // 
            this.txtYeniSifreTekrar.Location = new System.Drawing.Point(30, 285);
            this.txtYeniSifreTekrar.Name = "txtYeniSifreTekrar";
            this.txtYeniSifreTekrar.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtYeniSifreTekrar.Properties.Appearance.Options.UseFont = true;
            this.txtYeniSifreTekrar.Properties.PasswordChar = '●';
            this.txtYeniSifreTekrar.Properties.UseSystemPasswordChar = true;
            this.txtYeniSifreTekrar.Size = new System.Drawing.Size(400, 26);
            this.txtYeniSifreTekrar.TabIndex = 2;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnKaydet.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnKaydet.Appearance.Options.UseBackColor = true;
            this.btnKaydet.Appearance.Options.UseFont = true;
            this.btnKaydet.ImageOptions.SvgImage = global::OkulSistemOtomasyon.Properties.Resources.SaveIcon;
            this.btnKaydet.ImageOptions.SvgImageSize = new System.Drawing.Size(24, 24);
            this.btnKaydet.Location = new System.Drawing.Point(260, 340);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(170, 45);
            this.btnKaydet.TabIndex = 3;
            this.btnKaydet.Text = "Şifreyi Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.Appearance.BackColor = System.Drawing.Color.Gray;
            this.btnIptal.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnIptal.Appearance.Options.UseBackColor = true;
            this.btnIptal.Appearance.Options.UseFont = true;
            this.btnIptal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnIptal.Location = new System.Drawing.Point(30, 340);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(140, 45);
            this.btnIptal.TabIndex = 4;
            this.btnIptal.Text = "İptal";
            // 
            // SifreDegistirForm
            // 
            this.AcceptButton = this.btnKaydet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnIptal;
            this.ClientSize = new System.Drawing.Size(460, 410);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtYeniSifreTekrar);
            this.Controls.Add(this.lblYeniSifreTekrar);
            this.Controls.Add(this.txtYeniSifre);
            this.Controls.Add(this.lblYeniSifre);
            this.Controls.Add(this.txtEskiSifre);
            this.Controls.Add(this.lblEskiSifre);
            this.Controls.Add(this.lblAciklama);
            this.Controls.Add(this.lblBaslik);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SifreDegistirForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Şifre Değiştirme - İlk Giriş";
            ((System.ComponentModel.ISupportInitialize)(this.txtEskiSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniSifreTekrar.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblBaslik;
        private DevExpress.XtraEditors.LabelControl lblAciklama;
        private DevExpress.XtraEditors.LabelControl lblEskiSifre;
        private DevExpress.XtraEditors.TextEdit txtEskiSifre;
        private DevExpress.XtraEditors.LabelControl lblYeniSifre;
        private DevExpress.XtraEditors.TextEdit txtYeniSifre;
        private DevExpress.XtraEditors.LabelControl lblYeniSifreTekrar;
        private DevExpress.XtraEditors.TextEdit txtYeniSifreTekrar;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.SimpleButton btnIptal;
    }
}
