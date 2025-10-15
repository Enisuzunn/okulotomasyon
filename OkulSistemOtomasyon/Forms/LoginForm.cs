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
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text.Trim();
            string sifre = txtSifre.Text;

            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre))
            {
                MessageHelper.UyariMesaji("Kullanıcı adı ve şifre boş bırakılamaz!");
                return;
            }

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
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Giriş yapılırken bir hata oluştu:\n{ex.Message}");
            }
        }
    }
}
