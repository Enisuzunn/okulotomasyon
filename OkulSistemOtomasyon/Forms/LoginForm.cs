using DevExpress.XtraEditors;
using Microsoft.EntityFrameworkCore;
using OkulSistemOtomasyon.Data;
using OkulSistemOtomasyon.Helpers;
using OkulSistemOtomasyon.Models;

namespace OkulSistemOtomasyon.Forms
{
    public partial class LoginForm : XtraForm
    {
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
                        .Where(k => k.KullaniciAdi == kullaniciAdi && k.Sifre == sifre)
                        .FirstOrDefault();

                    if (kullanici != null && kullanici.Aktif)
                    {
                        // Son giriş tarihini güncelle
                        kullanici.SonGirisTarihi = DateTime.Now;
                        context.SaveChanges();

                        // Oturum aç
                        SessionManager.GirisYap(kullanici);

                        // Role göre yönlendirme
                        this.Hide();
                        
                        switch (kullanici.Rol)
                        {
                            case KullaniciRolu.Admin:
                                MessageHelper.BilgiMesaji($"Hoş geldiniz Sayın Yönetici, {kullanici.TamAd}!");
                                var mainForm = new MainForm();
                                mainForm.FormClosed += (s, args) => this.Close();
                                mainForm.Show();
                                break;

                            case KullaniciRolu.Akademisyen:
                                MessageHelper.BilgiMesaji($"Hoş geldiniz {kullanici.Akademisyen?.Unvan} {kullanici.TamAd}!");
                                var akademisyenPanel = new AkademisyenPanelForm();
                                akademisyenPanel.FormClosed += (s, args) => this.Close();
                                akademisyenPanel.Show();
                                break;

                            case KullaniciRolu.Ogrenci:
                                MessageHelper.BilgiMesaji($"Hoş geldiniz {kullanici.TamAd}!\nÖğrenci No: {kullanici.Ogrenci?.OgrenciNo}");
                                var ogrenciPanel = new OgrenciPanelForm();
                                ogrenciPanel.FormClosed += (s, args) => this.Close();
                                ogrenciPanel.Show();
                                break;

                            default:
                                MessageHelper.HataMesaji("Bilinmeyen kullanıcı rolü!");
                                this.Show();
                                btnGiris.Enabled = true;
                                btnGiris.Text = "GİRİŞ YAP";
                                break;
                        }
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
    }
}
