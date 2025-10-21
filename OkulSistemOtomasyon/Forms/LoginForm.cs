using DevExpress.XtraEditors;
using OkulSistemOtomasyon.Data;
using OkulSistemOtomasyon.Helpers;

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
                        .FirstOrDefault(k => k.KullaniciAdi == kullaniciAdi && k.Sifre == sifre && k.Aktif);

                    if (kullanici != null)
                    {
                        // Son giriş tarihini güncelle
                        kullanici.SonGirisTarihi = DateTime.Now;
                        context.SaveChanges();

                        // Oturum aç
                        SessionManager.GirisYap(kullanici);

                        MessageHelper.BilgiMesaji($"Hoş geldiniz, {kullanici.TamAd}!");
                        
                        this.DialogResult = DialogResult.OK;
                        this.Close();
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
            MessageHelper.BilgiMesaji("Şifrenizi sıfırlamak için sistem yöneticisi ile iletişime geçiniz.\n\nVarsayılan kullanıcı:\nKullanıcı Adı: admin\nŞifre: admin123");
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
