using DevExpress.XtraEditors;
using OkulSistemOtomasyon.Data;
using OkulSistemOtomasyon.Helpers;
using OkulSistemOtomasyon.Models;

namespace OkulSistemOtomasyon.Forms
{
    public partial class SifreDegistirForm : XtraForm
    {
        private readonly Kullanici _kullanici;
        private readonly OkulDbContext _context;

        public SifreDegistirForm(Kullanici kullanici)
        {
            InitializeComponent();
            _kullanici = kullanici;
            _context = new OkulDbContext();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // Validasyon
            if (string.IsNullOrWhiteSpace(txtEskiSifre.Text))
            {
                MessageHelper.UyariMesaji("Lütfen mevcut şifrenizi girin!");
                txtEskiSifre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtYeniSifre.Text))
            {
                MessageHelper.UyariMesaji("Lütfen yeni şifrenizi girin!");
                txtYeniSifre.Focus();
                return;
            }

            if (txtYeniSifre.Text.Length < 5)
            {
                MessageHelper.UyariMesaji("Yeni şifre en az 5 karakter olmalıdır!");
                txtYeniSifre.Focus();
                return;
            }

            if (txtYeniSifre.Text != txtYeniSifreTekrar.Text)
            {
                MessageHelper.UyariMesaji("Yeni şifreler eşleşmiyor!");
                txtYeniSifreTekrar.Focus();
                return;
            }

            // Eski şifre kontrolü
            if (txtEskiSifre.Text != _kullanici.Sifre)
            {
                MessageHelper.HataMesaji("Mevcut şifre yanlış!");
                txtEskiSifre.Focus();
                return;
            }

            // Yeni şifre eski şifre ile aynı olamaz
            if (txtYeniSifre.Text == _kullanici.Sifre)
            {
                MessageHelper.UyariMesaji("Yeni şifre, eski şifrenizle aynı olamaz!");
                txtYeniSifre.Focus();
                return;
            }

            try
            {
                // Veritabanından kullanıcıyı bul ve güncelle
                var kullanici = _context.Kullanicilar.Find(_kullanici.KullaniciId);
                if (kullanici != null)
                {
                    kullanici.Sifre = txtYeniSifre.Text;
                    kullanici.IlkGiris = false;
                    kullanici.SonSifreDegistirmeTarihi = DateTime.Now;
                    
                    _context.SaveChanges();
                    
                    MessageHelper.BasariMesaji("Şifreniz başarıyla değiştirildi!");
                    
                    // Kullanıcı nesnesini de güncelle
                    _kullanici.Sifre = txtYeniSifre.Text;
                    _kullanici.IlkGiris = false;
                    _kullanici.SonSifreDegistirmeTarihi = DateTime.Now;
                    
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Şifre değiştirme sırasında hata oluştu:\n{ex.Message}");
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // İlk girişse ve şifre değiştirmediyse kapatmaya izin verme
            if (_kullanici.IlkGiris && this.DialogResult != DialogResult.OK)
            {
                var sonuc = MessageBox.Show(
                    "Güvenliğiniz için şifrenizi değiştirmeniz gerekmektedir!\n\n" +
                    "Şifre değiştirmeden çıkmak isterseniz, giriş işlemi iptal edilecektir.\n\n" +
                    "Çıkmak istediğinize emin misiniz?",
                    "Uyarı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (sonuc == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }

            if (!e.Cancel)
            {
                _context?.Dispose();
            }
            
            base.OnFormClosing(e);
        }
    }
}
