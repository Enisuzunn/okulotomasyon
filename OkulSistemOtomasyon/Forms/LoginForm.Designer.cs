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
            this.panelSecim = new DevExpress.XtraEditors.PanelControl();
            this.btnOgrenciAkademisyen = new DevExpress.XtraEditors.SimpleButton();
            this.btnYonetici = new DevExpress.XtraEditors.SimpleButton();
            this.lblSecimBaslik = new DevExpress.XtraEditors.LabelControl();
            this.panelGiris = new DevExpress.XtraEditors.PanelControl();
            this.btnGeriDon = new DevExpress.XtraEditors.SimpleButton();
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
            ((System.ComponentModel.ISupportInitialize)(this.panelSecim)).BeginInit();
            this.panelSecim.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelGiris)).BeginInit();
            this.panelGiris.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelHeader.Appearance.Options.UseBackColor = true;
            this.panelHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelHeader.Controls.Add(this.lblBaslik);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(500, 100);
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
            this.lblBaslik.Size = new System.Drawing.Size(500, 100);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "🎓 ÜNİVERSİTE SİSTEM OTOMASYONU";
            // 
            // panelCenter
            // 
            this.panelCenter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelCenter.Controls.Add(this.panelSecim);
            this.panelCenter.Controls.Add(this.panelGiris);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 100);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(500, 350);
            this.panelCenter.TabIndex = 1;
            // 
            // panelSecim
            // 
            this.panelSecim.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelSecim.Controls.Add(this.btnOgrenciAkademisyen);
            this.panelSecim.Controls.Add(this.btnYonetici);
            this.panelSecim.Controls.Add(this.lblSecimBaslik);
            this.panelSecim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSecim.Location = new System.Drawing.Point(0, 0);
            this.panelSecim.Name = "panelSecim";
            this.panelSecim.Padding = new System.Windows.Forms.Padding(40, 30, 40, 30);
            this.panelSecim.Size = new System.Drawing.Size(500, 350);
            this.panelSecim.TabIndex = 0;
            // 
            // lblSecimBaslik
            // 
            this.lblSecimBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSecimBaslik.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSecimBaslik.Appearance.Options.UseFont = true;
            this.lblSecimBaslik.Appearance.Options.UseForeColor = true;
            this.lblSecimBaslik.Appearance.Options.UseTextOptions = true;
            this.lblSecimBaslik.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblSecimBaslik.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblSecimBaslik.Location = new System.Drawing.Point(40, 40);
            this.lblSecimBaslik.Name = "lblSecimBaslik";
            this.lblSecimBaslik.Size = new System.Drawing.Size(420, 30);
            this.lblSecimBaslik.TabIndex = 0;
            this.lblSecimBaslik.Text = "Giriş Türünü Seçiniz";
            // 
            // btnOgrenciAkademisyen
            // 
            this.btnOgrenciAkademisyen.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnOgrenciAkademisyen.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnOgrenciAkademisyen.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnOgrenciAkademisyen.Appearance.Options.UseBackColor = true;
            this.btnOgrenciAkademisyen.Appearance.Options.UseFont = true;
            this.btnOgrenciAkademisyen.Appearance.Options.UseForeColor = true;
            this.btnOgrenciAkademisyen.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnOgrenciAkademisyen.AppearanceHovered.Options.UseBackColor = true;
            this.btnOgrenciAkademisyen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOgrenciAkademisyen.Location = new System.Drawing.Point(40, 100);
            this.btnOgrenciAkademisyen.Name = "btnOgrenciAkademisyen";
            this.btnOgrenciAkademisyen.Size = new System.Drawing.Size(420, 70);
            this.btnOgrenciAkademisyen.TabIndex = 1;
            this.btnOgrenciAkademisyen.Text = "🎓 Öğrenci / Akademisyen Girişi";
            this.btnOgrenciAkademisyen.Click += new System.EventHandler(this.btnOgrenciAkademisyen_Click);
            // 
            // btnYonetici
            // 
            this.btnYonetici.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnYonetici.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnYonetici.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnYonetici.Appearance.Options.UseBackColor = true;
            this.btnYonetici.Appearance.Options.UseFont = true;
            this.btnYonetici.Appearance.Options.UseForeColor = true;
            this.btnYonetici.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnYonetici.AppearanceHovered.Options.UseBackColor = true;
            this.btnYonetici.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYonetici.Location = new System.Drawing.Point(40, 190);
            this.btnYonetici.Name = "btnYonetici";
            this.btnYonetici.Size = new System.Drawing.Size(420, 70);
            this.btnYonetici.TabIndex = 2;
            this.btnYonetici.Text = "👨‍💼 Yönetici Girişi";
            this.btnYonetici.Click += new System.EventHandler(this.btnYonetici_Click);
            // 
            // panelGiris
            // 
            this.panelGiris.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelGiris.Controls.Add(this.btnGeriDon);
            this.panelGiris.Controls.Add(this.lblSifremiUnuttum);
            this.panelGiris.Controls.Add(this.chkSifreGoster);
            this.panelGiris.Controls.Add(this.lblAltBaslik);
            this.panelGiris.Controls.Add(this.btnGiris);
            this.panelGiris.Controls.Add(this.txtSifre);
            this.panelGiris.Controls.Add(this.txtKullaniciAdi);
            this.panelGiris.Controls.Add(this.lblSifre);
            this.panelGiris.Controls.Add(this.lblKullaniciAdi);
            this.panelGiris.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGiris.Location = new System.Drawing.Point(0, 0);
            this.panelGiris.Name = "panelGiris";
            this.panelGiris.Padding = new System.Windows.Forms.Padding(40, 30, 40, 30);
            this.panelGiris.Size = new System.Drawing.Size(500, 350);
            this.panelGiris.TabIndex = 1;
            this.panelGiris.Visible = false;
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
            this.txtKullaniciAdi.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtKullaniciAdi.Properties.Appearance.Options.UseBackColor = true;
            this.txtKullaniciAdi.Properties.NullValuePrompt = "Kullanıcı adınızı giriniz";
            this.txtKullaniciAdi.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtKullaniciAdi.Size = new System.Drawing.Size(420, 40);
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
            this.txtSifre.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtSifre.Properties.Appearance.Options.UseBackColor = true;
            this.txtSifre.Properties.NullValuePrompt = "Şifrenizi giriniz";
            this.txtSifre.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtSifre.Size = new System.Drawing.Size(420, 40);
            this.txtSifre.TabIndex = 3;
            // 
            // chkSifreGoster
            // 
            this.chkSifreGoster = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSifreGoster.Properties)).BeginInit();
            this.chkSifreGoster.Location = new System.Drawing.Point(40, 214);
            this.chkSifreGoster.Name = "chkSifreGoster";
            this.chkSifreGoster.Properties.Caption = "Şifreyi Göster";
            this.chkSifreGoster.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkSifreGoster.Properties.Appearance.Options.UseFont = true;
            this.chkSifreGoster.Size = new System.Drawing.Size(150, 20);
            this.chkSifreGoster.TabIndex = 6;
            this.chkSifreGoster.CheckedChanged += new System.EventHandler(this.chkSifreGoster_CheckedChanged);
            // 
            // lblSifremiUnuttum
            // 
            this.lblSifremiUnuttum = new DevExpress.XtraEditors.LabelControl();
            this.lblSifremiUnuttum.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSifremiUnuttum.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblSifremiUnuttum.Appearance.Options.UseFont = true;
            this.lblSifremiUnuttum.Appearance.Options.UseForeColor = true;
            this.lblSifremiUnuttum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSifremiUnuttum.Location = new System.Drawing.Point(360, 216);
            this.lblSifremiUnuttum.Name = "lblSifremiUnuttum";
            this.lblSifremiUnuttum.Size = new System.Drawing.Size(100, 15);
            this.lblSifremiUnuttum.TabIndex = 7;
            this.lblSifremiUnuttum.Text = "Şifremi Unuttum?";
            this.lblSifremiUnuttum.Click += new System.EventHandler(this.lblSifremiUnuttum_Click);
            // 
            // btnGiris
            // 
            this.btnGiris.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnGiris.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnGiris.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnGiris.Appearance.Options.UseBackColor = true;
            this.btnGiris.Appearance.Options.UseFont = true;
            this.btnGiris.Appearance.Options.UseForeColor = true;
            this.btnGiris.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnGiris.AppearanceHovered.Options.UseBackColor = true;
            this.btnGiris.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGiris.Location = new System.Drawing.Point(40, 250);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new System.Drawing.Size(420, 50);
            this.btnGiris.TabIndex = 4;
            this.btnGiris.Text = "🔐 GİRİŞ YAP";
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click);
            // 
            // btnGeriDon
            // 
            this.btnGeriDon.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnGeriDon.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnGeriDon.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnGeriDon.Appearance.Options.UseBackColor = true;
            this.btnGeriDon.Appearance.Options.UseFont = true;
            this.btnGeriDon.Appearance.Options.UseForeColor = true;
            this.btnGeriDon.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.btnGeriDon.AppearanceHovered.Options.UseBackColor = true;
            this.btnGeriDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGeriDon.Location = new System.Drawing.Point(170, 5);
            this.btnGeriDon.Name = "btnGeriDon";
            this.btnGeriDon.Size = new System.Drawing.Size(160, 35);
            this.btnGeriDon.TabIndex = 8;
            this.btnGeriDon.Text = "⬅ Geri Dön";
            this.btnGeriDon.Click += new System.EventHandler(this.btnGeriDon_Click);

            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnGiris;
            this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 450);
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş - Üniversite Sistem Otomasyonu";
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).EndInit();
            this.panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelCenter)).EndInit();
            this.panelCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelSecim)).EndInit();
            this.panelSecim.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelGiris)).EndInit();
            this.panelGiris.ResumeLayout(false);
            this.panelGiris.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSifreGoster.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelHeader;
        private DevExpress.XtraEditors.LabelControl lblBaslik;
        private DevExpress.XtraEditors.PanelControl panelCenter;
        private DevExpress.XtraEditors.PanelControl panelSecim;
        private DevExpress.XtraEditors.SimpleButton btnOgrenciAkademisyen;
        private DevExpress.XtraEditors.SimpleButton btnYonetici;
        private DevExpress.XtraEditors.LabelControl lblSecimBaslik;
        private DevExpress.XtraEditors.PanelControl panelGiris;
        private DevExpress.XtraEditors.SimpleButton btnGeriDon;
        private DevExpress.XtraEditors.LabelControl lblAltBaslik;
        private DevExpress.XtraEditors.SimpleButton btnGiris;
        private DevExpress.XtraEditors.TextEdit txtSifre;
        private DevExpress.XtraEditors.TextEdit txtKullaniciAdi;
        private DevExpress.XtraEditors.LabelControl lblSifre;
        private DevExpress.XtraEditors.LabelControl lblKullaniciAdi;
        private DevExpress.XtraEditors.CheckEdit chkSifreGoster;
        private DevExpress.XtraEditors.LabelControl lblSifremiUnuttum;
    }
}
