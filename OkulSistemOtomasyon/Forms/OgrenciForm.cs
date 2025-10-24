using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.EntityFrameworkCore;
using OkulSistemOtomasyon.Data;
using OkulSistemOtomasyon.Helpers;
using OkulSistemOtomasyon.Models;

namespace OkulSistemOtomasyon.Forms
{
    public partial class OgrenciForm : XtraForm
    {
        private OkulDbContext _context;

        public OgrenciForm()
        {
            InitializeComponent();
            _context = new OkulDbContext();
        }

        private void OgrenciForm_Load(object sender, EventArgs e)
        {
            VeriYukle();
            BolumleriYukle();
            SiniflariYukle();
            DanismanlariYukle();
        }

        private void VeriYukle()
        {
            try
            {
                var ogrenciler = _context.Ogrenciler
                    .Include(o => o.Bolum)
                    .Include(o => o.Danisman)
                    .Select(o => new
                    {
                        o.OgrenciId,
                        o.OgrenciNo,
                        o.Ad,
                        o.Soyad,
                        o.TC,
                        o.DogumTarihi,
                        o.Telefon,
                        o.Email,
                        BolumAdi = o.Bolum != null ? o.Bolum.BolumAdi : "",
                        DanismanAdi = o.Danisman != null ? (o.Danisman.Ad + " " + o.Danisman.Soyad) : "Yok",
                        o.Sinif,
                        o.KayitYili,
                        o.KayitTarihi,
                        o.Aktif
                    })
                    .ToList();

                gridControl1.DataSource = ogrenciler;
                gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Veri yüklenirken hata oluştu:\n{ex.Message}");
            }
        }

        private void BolumleriYukle()
        {
            try
            {
                var bolumler = _context.Bolumler
                    .ToList()
                    .Where(b => b.Aktif)
                    .Select(b => new { b.BolumId, b.BolumAdi })
                    .ToList();

                lookUpBolum.Properties.DataSource = bolumler;
                lookUpBolum.Properties.DisplayMember = "BolumAdi";
                lookUpBolum.Properties.ValueMember = "BolumId";
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Bölümler yüklenirken hata oluştu:\n{ex.Message}");
            }
        }

        private void SiniflariYukle()
        {
            try
            {
                // Sınıf (1-8 yıl) dropdown'u doldur
                cmbSinif.Properties.Items.Clear();
                for (int i = 1; i <= 8; i++)
                {
                    cmbSinif.Properties.Items.Add(i.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Sınıflar yüklenirken hata oluştu:\n{ex.Message}");
            }
        }

        private void DanismanlariYukle()
        {
            try
            {
                // Başlangıçta danışman seçimini devre dışı bırak
                lookUpDanisman.Properties.DataSource = null;
                lookUpDanisman.EditValue = null;
                lookUpDanisman.Properties.NullText = "Önce bölüm seçiniz";
                lookUpDanisman.Properties.DisplayMember = "TamAd";
                lookUpDanisman.Properties.ValueMember = "Id";
                lookUpDanisman.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Danışman kontrolü başlatılırken hata oluştu:\n{ex.Message}");
            }
        }

        private void lookUpBolum_EditValueChanged(object sender, EventArgs e)
        {
            // Bölüm değiştiğinde, o bölümdeki akademisyenleri filtrele
            if (lookUpBolum.EditValue != null)
            {
                try
                {
                    int bolumId = Convert.ToInt32(lookUpBolum.EditValue);
                    
                    // Seçilen bölümdeki akademisyenleri yükle
                    var akademisyenler = _context.Akademisyenler
                        .Where(a => a.IsActive && a.BolumId == bolumId)
                        .Select(a => new 
                        { 
                            a.Id,
                            a.BolumId,
                            TamAd = a.Ad + " " + a.Soyad + " (" + a.Unvan + ")"
                        })
                        .ToList();

                    lookUpDanisman.Properties.DataSource = akademisyenler;
                    lookUpDanisman.EditValue = null; // Seçimi temizle
                    lookUpDanisman.Enabled = true; // Danışman seçimini aktif et
                    
                    // Liste boşsa kullanıcıyı bilgilendir
                    if (akademisyenler.Count == 0)
                    {
                        lookUpDanisman.Properties.NullText = "Bu bölümde akademisyen yok";
                    }
                    else
                    {
                        lookUpDanisman.Properties.NullText = "Danışman Seçiniz (İsteğe Bağlı)";
                    }
                }
                catch (Exception ex)
                {
                    MessageHelper.HataMesaji($"Danışmanlar filtrelenirken hata oluştu:\n{ex.Message}");
                }
            }
            else
            {
                // Bölüm seçimi kaldırıldıysa danışman seçimini devre dışı bırak
                lookUpDanisman.Properties.DataSource = null;
                lookUpDanisman.EditValue = null;
                lookUpDanisman.Properties.NullText = "Önce bölüm seçiniz";
                lookUpDanisman.Enabled = false;
            }
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            TemizleFormlar();
            txtAd.Focus();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (!FormuDogrula()) return;

            try
            {
                var ogrenci = new Ogrenci
                {
                    OgrenciNo = txtOgrenciNo.Text.Trim(),
                    Ad = txtAd.Text.Trim(),
                    Soyad = txtSoyad.Text.Trim(),
                    TC = txtTC.Text.Trim(),
                    DogumTarihi = dateDogumTarihi.DateTime,
                    Telefon = txtTelefon.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Adres = txtAdres.Text.Trim(),
                    BolumId = Convert.ToInt32(lookUpBolum.EditValue),
                    DanismanId = lookUpDanisman.EditValue != null ? Convert.ToInt32(lookUpDanisman.EditValue) : (int?)null,
                    Sinif = Convert.ToInt32(cmbSinif.EditValue ?? 1),
                    KayitYili = Convert.ToInt32(txtKayitYili.Text.Trim()),
                    Aktif = checkAktif.Checked
                };

                _context.Ogrenciler.Add(ogrenci);
                _context.SaveChanges();

                // OTOMATIK KULLANICI HESABI OLUŞTUR
                // Öğrenci numarası ile kullanıcı adı ve varsayılan şifre oluştur
                var kullanici = new Kullanici
                {
                    KullaniciAdi = ogrenci.OgrenciNo,
                    Sifre = ogrenci.OgrenciNo,  // Varsayılan şifre = Öğrenci numarası
                    Ad = ogrenci.Ad,
                    Soyad = ogrenci.Soyad,
                    Email = ogrenci.Email,
                    Rol = KullaniciRolu.Ogrenci,
                    OgrenciId = ogrenci.Id,  // İlişkilendir
                    IlkGiris = true,  // İlk giriş zorunlu şifre değiştirme
                    Aktif = true
                };
                
                _context.Kullanicilar.Add(kullanici);
                _context.SaveChanges();

                MessageHelper.BasariMesaji(
                    $"Öğrenci başarıyla eklendi!\n\n" +
                    $"Kullanıcı hesabı otomatik oluşturuldu:\n" +
                    $"Kullanıcı Adı: {ogrenci.OgrenciNo}\n" +
                    $"Varsayılan Şifre: {ogrenci.OgrenciNo}\n\n" +
                    $"⚠️ Öğrenci ilk girişinde şifresini değiştirmek zorunda kalacaktır.");
                    
                VeriYukle();
                TemizleFormlar();
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
                MessageHelper.UyariMesaji("Lütfen güncellenecek öğrenciyi seçin!");
                return;
            }

            if (!FormuDogrula()) return;

            try
            {
                var selectedRow = gridView1.GetFocusedRow() as dynamic;
                int ogrenciId = selectedRow.OgrenciId;

                var ogrenci = _context.Ogrenciler.Find(ogrenciId);
                if (ogrenci != null)
                {
                    ogrenci.OgrenciNo = txtOgrenciNo.Text.Trim();
                    ogrenci.Ad = txtAd.Text.Trim();
                    ogrenci.Soyad = txtSoyad.Text.Trim();
                    ogrenci.TC = txtTC.Text.Trim();
                    ogrenci.DogumTarihi = dateDogumTarihi.DateTime;
                    ogrenci.Telefon = txtTelefon.Text.Trim();
                    ogrenci.Email = txtEmail.Text.Trim();
                    ogrenci.Adres = txtAdres.Text.Trim();
                    ogrenci.BolumId = Convert.ToInt32(lookUpBolum.EditValue);
                    ogrenci.DanismanId = lookUpDanisman.EditValue != null ? Convert.ToInt32(lookUpDanisman.EditValue) : (int?)null;
                    ogrenci.Sinif = Convert.ToInt32(cmbSinif.EditValue ?? 1);
                    ogrenci.KayitYili = Convert.ToInt32(txtKayitYili.Text.Trim());
                    ogrenci.Aktif = checkAktif.Checked;

                    _context.SaveChanges();

                    MessageHelper.BasariMesaji("Öğrenci başarıyla güncellendi.");
                    VeriYukle();
                    TemizleFormlar();
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
                MessageHelper.UyariMesaji("Lütfen silinecek öğrenciyi seçin!");
                return;
            }

            var selectedRow = gridView1.GetFocusedRow() as dynamic;
            int ogrenciId = selectedRow.OgrenciId;

            MessageHelper.SilmeOnayMesaji(() =>
            {
                var ogrenci = _context.Ogrenciler.Find(ogrenciId);
                if (ogrenci != null)
                {
                    _context.Ogrenciler.Remove(ogrenci);
                    _context.SaveChanges();
                    VeriYukle();
                    TemizleFormlar();
                }
            });
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.GetFocusedRow() == null) return;

            try
            {
                var selectedRow = gridView1.GetFocusedRow() as dynamic;
                int ogrenciId = selectedRow.OgrenciId;

                var ogrenci = _context.Ogrenciler.Find(ogrenciId);
                if (ogrenci != null)
                {
                    txtOgrenciNo.Text = ogrenci.OgrenciNo;
                    txtAd.Text = ogrenci.Ad;
                    txtSoyad.Text = ogrenci.Soyad;
                    txtTC.Text = ogrenci.TC;
                    dateDogumTarihi.DateTime = ogrenci.DogumTarihi;
                    txtTelefon.Text = ogrenci.Telefon;
                    txtEmail.Text = ogrenci.Email;
                    txtAdres.Text = ogrenci.Adres;
                    cmbSinif.EditValue = ogrenci.Sinif.ToString();
                    txtKayitYili.Text = ogrenci.KayitYili.ToString();
                    checkAktif.Checked = ogrenci.Aktif;
                    
                    // Önce bölümü seç (bu danışman listesini yükleyecek)
                    lookUpBolum.EditValue = ogrenci.BolumId;
                    
                    // Sonra danışmanı seç (artık liste hazır olacak)
                    // Application.DoEvents ile event'lerin işlenmesini bekle
                    System.Windows.Forms.Application.DoEvents();
                    lookUpDanisman.EditValue = ogrenci.DanismanId;
                }
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Veri okuma hatası:\n{ex.Message}");
            }
        }

        private bool FormuDogrula()
        {
            if (string.IsNullOrWhiteSpace(txtAd.Text))
            {
                MessageHelper.UyariMesaji("Ad alanı boş bırakılamaz!");
                txtAd.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSoyad.Text))
            {
                MessageHelper.UyariMesaji("Soyad alanı boş bırakılamaz!");
                txtSoyad.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTC.Text))
            {
                MessageHelper.UyariMesaji("TC Kimlik No boş bırakılamaz!");
                txtTC.Focus();
                return false;
            }

            if (!ValidationHelper.TCKimlikNoDogrula(txtTC.Text))
            {
                MessageHelper.UyariMesaji("Geçersiz TC Kimlik No!");
                txtTC.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtOgrenciNo.Text))
            {
                MessageHelper.UyariMesaji("Öğrenci No boş bırakılamaz!");
                txtOgrenciNo.Focus();
                return false;
            }

            if (lookUpBolum.EditValue == null)
            {
                MessageHelper.UyariMesaji("Bölüm seçimi yapılmalıdır!");
                lookUpBolum.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtKayitYili.Text))
            {
                MessageHelper.UyariMesaji("Kayıt yılı boş bırakılamaz!");
                txtKayitYili.Focus();
                return false;
            }

            if (!string.IsNullOrEmpty(txtEmail.Text) && !ValidationHelper.EmailDogrula(txtEmail.Text))
            {
                MessageHelper.UyariMesaji("Geçersiz email adresi!");
                txtEmail.Focus();
                return false;
            }

            return true;
        }

        private void TemizleFormlar()
        {
            txtOgrenciNo.Text = string.Empty;
            txtAd.Text = string.Empty;
            txtSoyad.Text = string.Empty;
            txtTC.Text = string.Empty;
            dateDogumTarihi.DateTime = DateTime.Now.AddYears(-18);
            txtTelefon.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAdres.Text = string.Empty;
            lookUpBolum.EditValue = null;
            lookUpDanisman.EditValue = null;
            cmbSinif.EditValue = "1";
            txtKayitYili.Text = DateTime.Now.Year.ToString();
            checkAktif.Checked = true;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _context?.Dispose();
            base.OnFormClosing(e);
        }
    }
}
