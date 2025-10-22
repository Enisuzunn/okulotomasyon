using DevExpress.XtraEditors;
using Microsoft.EntityFrameworkCore;
using OkulSistemOtomasyon.Data;
using OkulSistemOtomasyon.Helpers;
using OkulSistemOtomasyon.Models;

namespace OkulSistemOtomasyon.Forms
{
    public partial class LoginForm : XtraForm
    {
        private KullaniciRolu? seciliRol = null;

        public LoginForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += LoginForm_KeyDown;
            
            // Enter tuşu ile giriş
            txtKullaniciAdi.KeyDown += TextBox_KeyDown;
            txtSifre.KeyDown += TextBox_KeyDown;
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGiris_Click(sender, e);
            }
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text.Trim();
            string sifre = txtSifre.Text;

            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre))
            {
                MessageHelper.UyariMesaji("Kullanıcı adı ve şifre boş bırakılamaz!");
                txtKullaniciAdi.Focus();
                return;
            }

            // Giriş butonu animasyonu
            btnGiris.Enabled = false;
            btnGiris.Text = "Giriş yapılıyor...";

            try
            {
                using (var context = new OkulDbContext())
                {
                    var kullanici = context.Kullanicilar
                        .Include(k => k.Akademisyen)
                        .Include(k => k.Ogrenci)
                            .ThenInclude(o => o.Bolum)
                        .Where(k => k.KullaniciAdi == kullaniciAdi && k.Sifre == sifre)
                        .FirstOrDefault();

                    if (kullanici != null && kullanici.Aktif)
                    {
                        // Rol kontrolü yap
                        if (seciliRol.HasValue && kullanici.Rol != seciliRol.Value)
                        {
                            MessageHelper.HataMesaji($"Bu kullanıcı {seciliRol.Value} değildir!\nLütfen doğru giriş türünü seçiniz.");
                            txtSifre.Text = string.Empty;
                            txtKullaniciAdi.Focus();
                            btnGiris.Enabled = true;
                            btnGiris.Text = "GİRİŞ YAP";
                            return;
                        }

                        // Son giriş tarihini güncelle
                        kullanici.SonGirisTarihi = DateTime.Now;
                        context.SaveChanges();

                        // Oturum aç
                        SessionManager.GirisYap(kullanici);

                        // Hoş geldin mesajı
                        switch (kullanici.Rol)
                        {
                            case KullaniciRolu.Admin:
                                MessageHelper.BilgiMesaji($"Hoş geldiniz Sayın Yönetici, {kullanici.TamAd}!");
                                break;

                            case KullaniciRolu.Akademisyen:
                                MessageHelper.BilgiMesaji($"Hoş geldiniz {kullanici.Akademisyen?.Unvan} {kullanici.TamAd}!");
                                break;

                            case KullaniciRolu.Ogrenci:
                                MessageHelper.BilgiMesaji($"Hoş geldiniz {kullanici.TamAd}!\nÖğrenci No: {kullanici.Ogrenci?.OgrenciNo}");
                                break;
                        }

                        // Başarılı giriş - formu kapat ve Program.cs'de devam et
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else if (kullanici != null && !kullanici.Aktif)
                    {
                        MessageHelper.UyariMesaji("Hesabınız pasif durumda. Sistem yöneticisi ile iletişime geçiniz.");
                        btnGiris.Enabled = true;
                        btnGiris.Text = "GİRİŞ YAP";
                    }
                    else
                    {
                        MessageHelper.HataMesaji("Kullanıcı adı veya şifre hatalı!");
                        txtSifre.Text = string.Empty;
                        txtKullaniciAdi.Focus();
                        btnGiris.Enabled = true;
                        btnGiris.Text = "GİRİŞ YAP";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Giriş yapılırken bir hata oluştu:\n{ex.Message}");
                btnGiris.Enabled = true;
                btnGiris.Text = "GİRİŞ YAP";
            }
        }

        private void lblSifremiUnuttum_Click(object sender, EventArgs e)
        {
            MessageHelper.BilgiMesaji(
                "Şifrenizi sıfırlamak için sistem yöneticisi ile iletişime geçiniz.\n\n" +
                "═══════════════════════════\n" +
                "TEST KULLANICILARI\n" +
                "═══════════════════════════\n\n" +
                "👨‍💼 YÖNETİCİ\n" +
                "Kullanıcı Adı: admin\n" +
                "Şifre: admin123\n\n" +
                "👨‍🏫 AKADEMİSYEN\n" +
                "Kullanıcı Adı: ahmet.yilmaz\n" +
                "Şifre: 12345\n\n" +
                "🎓 ÖĞRENCİ\n" +
                "Kullanıcı Adı: 220201001\n" +
                "Şifre: 12345"
            );
        }

        private void chkSifreGoster_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSifreGoster.Checked)
            {
                txtSifre.Properties.UseSystemPasswordChar = false;
                txtSifre.Properties.PasswordChar = '\0';
            }
            else
            {
                txtSifre.Properties.UseSystemPasswordChar = true;
                txtSifre.Properties.PasswordChar = '●';
            }
        }

        private void btnOgrenciAkademisyen_Click(object sender, EventArgs e)
        {
            seciliRol = null; // Öğrenci veya Akademisyen (her ikisi de olabilir)
            lblAltBaslik.Text = "Öğrenci / Akademisyen Girişi";
            panelSecim.Visible = false;
            panelGiris.Visible = true;
            txtKullaniciAdi.Focus();
        }

        private void btnYonetici_Click(object sender, EventArgs e)
        {
            seciliRol = KullaniciRolu.Admin;
            lblAltBaslik.Text = "Yönetici Girişi";
            panelSecim.Visible = false;
            panelGiris.Visible = true;
            txtKullaniciAdi.Focus();
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            txtKullaniciAdi.Text = string.Empty;
            txtSifre.Text = string.Empty;
            seciliRol = null;
            panelGiris.Visible = false;
            panelSecim.Visible = true;
        }
    }
}
