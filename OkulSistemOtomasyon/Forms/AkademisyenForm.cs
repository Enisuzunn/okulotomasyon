using DevExpress.XtraEditors;
using OkulSistemOtomasyon.Data;
using OkulSistemOtomasyon.Helpers;
using OkulSistemOtomasyon.Models;

namespace OkulSistemOtomasyon.Forms
{
    public partial class AkademisyenForm : XtraForm
    {
        private OkulDbContext _context;

        public AkademisyenForm()
        {
            InitializeComponent();
            _context = new OkulDbContext();
            this.Text = "Akademisyen Yönetimi";
        }

        private void AkademisyenForm_Load(object sender, EventArgs e)
        {
            VeriYukle();
            BolumleriYukle();
            cmbUnvan.Properties.Items.AddRange(new string[] 
            { 
                "Profesör", 
                "Doçent", 
                "Dr. Öğr. Üyesi", 
                "Öğr. Gör.", 
                "Arş. Gör." 
            });
            cmbUnvan.SelectedIndex = 0;
            checkAktif.Checked = true;
        }

        private void BolumleriYukle()
        {
            try
            {
                var bolumler = _context.Bolumler
                    .Where(b => b.IsActive)
                    .Select(b => new { b.BolumId, b.BolumAdi })
                    .ToList();

                // Eğer formda lookUpBolum kontrolü varsa yükle
                // Yoksa sadece devam et
                var lookUpControl = this.Controls.Find("lookUpBolum", true).FirstOrDefault() as LookUpEdit;
                if (lookUpControl != null)
                {
                    lookUpControl.Properties.DataSource = bolumler;
                    lookUpControl.Properties.DisplayMember = "BolumAdi";
                    lookUpControl.Properties.ValueMember = "BolumId";
                }
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Bölümler yüklenirken hata oluştu:\n{ex.Message}");
            }
        }

        private void VeriYukle()
        {
            try
            {
                var akademisyenler = _context.Akademisyenler
                    .ToList()
                    .Select(a => new
                    {
                        a.AkademisyenId,
                        a.TC,
                        AdSoyad = a.Ad + " " + a.Soyad,
                        a.Unvan,
                        a.UzmanlikAlani,
                        a.Email,
                        a.Telefon,
                        a.Aktif,
                        VerdigiDersler = a.Dersler.Count(d => d.Aktif)
                    })
                    .ToList();

                gridControl1.DataSource = akademisyenler;
                gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Veri yüklenirken hata oluştu:\n{ex.Message}");
            }
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            txtTC.Text = string.Empty;
            txtAd.Text = string.Empty;
            txtSoyad.Text = string.Empty;
            cmbUnvan.SelectedIndex = 0;
            txtUzmanlikAlani.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTelefon.Text = string.Empty;
            checkAktif.Checked = true;
            txtTC.Focus();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (!ValidationHelper.TCKimlikNoDogrula(txtTC.Text))
            {
                MessageHelper.UyariMesaji("Geçerli bir TC Kimlik No giriniz (11 hane)!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAd.Text) || string.IsNullOrWhiteSpace(txtSoyad.Text))
            {
                MessageHelper.UyariMesaji("Ad ve soyad boş olamaz!");
                return;
            }

            try
            {
                // TC kontrolü
                var mevcutAkademisyen = _context.Akademisyenler.FirstOrDefault(a => a.TC == txtTC.Text.Trim());
                if (mevcutAkademisyen != null)
                {
                    MessageHelper.UyariMesaji("Bu TC Kimlik No ile kayıtlı akademisyen zaten var!");
                    return;
                }

                var akademisyen = new Akademisyen
                {
                    TC = txtTC.Text.Trim(),
                    Ad = txtAd.Text.Trim(),
                    Soyad = txtSoyad.Text.Trim(),
                    Unvan = cmbUnvan.Text,
                    UzmanlikAlani = txtUzmanlikAlani.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Telefon = txtTelefon.Text.Trim(),
                    Aktif = checkAktif.Checked
                };

                // BÖLÜM ATAMA: lookUpBolum kontrolü varsa ondan al, yoksa ilk bölümü ata
                var lookUpControl = this.Controls.Find("lookUpBolum", true).FirstOrDefault() as LookUpEdit;
                if (lookUpControl != null && lookUpControl.EditValue != null)
                {
                    akademisyen.BolumId = Convert.ToInt32(lookUpControl.EditValue);
                }
                else
                {
                    // Bölüm kontrolü yoksa veya seçilmediyse, ilk aktif bölümü ata
                    var ilkBolum = _context.Bolumler.FirstOrDefault(b => b.IsActive);
                    if (ilkBolum != null)
                    {
                        akademisyen.BolumId = ilkBolum.BolumId;
                    }
                }

                _context.Akademisyenler.Add(akademisyen);
                _context.SaveChanges();

                // OTOMATIK KULLANICI HESABI OLUŞTUR
                // E-posta adresinin @ öncesi kısmını kullanıcı adı olarak kullan
                string kullaniciAdi = txtEmail.Text.Trim().Contains("@") 
                    ? txtEmail.Text.Trim().Split('@')[0] 
                    : txtTC.Text.Trim();  // E-posta yoksa TC'yi kullan
                    
                var kullanici = new Kullanici
                {
                    KullaniciAdi = kullaniciAdi,
                    Sifre = "12345",  // Varsayılan şifre
                    Ad = akademisyen.Ad,
                    Soyad = akademisyen.Soyad,
                    Email = akademisyen.Email,
                    Rol = KullaniciRolu.Akademisyen,
                    AkademisyenId = akademisyen.Id,  // İlişkilendir
                    IlkGiris = true,  // İlk giriş zorunlu şifre değiştirme
                    Aktif = true
                };
                
                _context.Kullanicilar.Add(kullanici);
                _context.SaveChanges();

                MessageHelper.BasariMesaji(
                    $"Akademisyen başarıyla eklendi!\n\n" +
                    $"Kullanıcı hesabı otomatik oluşturuldu:\n" +
                    $"Kullanıcı Adı: {kullaniciAdi}\n" +
                    $"Varsayılan Şifre: 12345\n\n" +
                    $"⚠️ İlk girişinde şifresini değiştirmek zorunda kalacaktır.");
                    
                VeriYukle();
                btnYeni_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Kayıt sırasında hata oluştu:\n{ex.Message}");
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
            {
                MessageHelper.UyariMesaji("Lütfen güncellenecek akademisyeni seçin!");
                return;
            }

            if (!ValidationHelper.TCKimlikNoDogrula(txtTC.Text))
            {
                MessageHelper.UyariMesaji("Geçerli bir TC Kimlik No giriniz!");
                return;
            }

            try
            {
                var selectedRow = gridView1.GetFocusedRow() as dynamic;
                int akademisyenId = selectedRow.AkademisyenId;

                var akademisyen = _context.Akademisyenler.Find(akademisyenId);
                if (akademisyen != null)
                {
                    akademisyen.TC = txtTC.Text.Trim();
                    akademisyen.Ad = txtAd.Text.Trim();
                    akademisyen.Soyad = txtSoyad.Text.Trim();
                    akademisyen.Unvan = cmbUnvan.Text;
                    akademisyen.UzmanlikAlani = txtUzmanlikAlani.Text.Trim();
                    akademisyen.Email = txtEmail.Text.Trim();
                    akademisyen.Telefon = txtTelefon.Text.Trim();
                    akademisyen.Aktif = checkAktif.Checked;

                    // BÖLÜM GÜNCELLEME
                    var lookUpControl = this.Controls.Find("lookUpBolum", true).FirstOrDefault() as LookUpEdit;
                    if (lookUpControl != null && lookUpControl.EditValue != null)
                    {
                        akademisyen.BolumId = Convert.ToInt32(lookUpControl.EditValue);
                    }

                    _context.SaveChanges();
                    MessageHelper.BasariMesaji("Akademisyen başarıyla güncellendi.");
                    VeriYukle();
                }
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Güncelleme sırasında hata oluştu:\n{ex.Message}");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
            {
                MessageHelper.UyariMesaji("Lütfen silinecek akademisyeni seçin!");
                return;
            }

            var selectedRow = gridView1.GetFocusedRow() as dynamic;
            int akademisyenId = selectedRow.AkademisyenId;

            MessageHelper.SilmeOnayMesaji(() =>
            {
                var akademisyen = _context.Akademisyenler.Find(akademisyenId);
                if (akademisyen != null)
                {
                    _context.Akademisyenler.Remove(akademisyen);
                    _context.SaveChanges();
                    VeriYukle();
                    btnYeni_Click(null, null);
                }
            });
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.GetFocusedRow() == null) return;

            try
            {
                var selectedRow = gridView1.GetFocusedRow() as dynamic;
                int akademisyenId = selectedRow.AkademisyenId;

                var akademisyen = _context.Akademisyenler.Find(akademisyenId);
                if (akademisyen != null)
                {
                    txtTC.Text = akademisyen.TC;
                    txtAd.Text = akademisyen.Ad;
                    txtSoyad.Text = akademisyen.Soyad;
                    cmbUnvan.Text = akademisyen.Unvan;
                    txtUzmanlikAlani.Text = akademisyen.UzmanlikAlani;
                    txtEmail.Text = akademisyen.Email;
                    txtTelefon.Text = akademisyen.Telefon;
                    checkAktif.Checked = akademisyen.Aktif;
                }
            }
            catch { }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _context?.Dispose();
            base.OnFormClosing(e);
        }
    }
}
