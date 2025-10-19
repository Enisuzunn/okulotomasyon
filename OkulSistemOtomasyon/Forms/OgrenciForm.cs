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
        }

        private void VeriYukle()
        {
            try
            {
                var ogrenciler = _context.Ogrenciler
                    .Include(o => o.Bolum)
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
                    Sinif = Convert.ToInt32(cmbSinif.EditValue ?? 1),
                    KayitYili = Convert.ToInt32(txtKayitYili.Text.Trim()),
                    Aktif = checkAktif.Checked
                };

                _context.Ogrenciler.Add(ogrenci);
                _context.SaveChanges();

                MessageHelper.BasariMesaji("Öğrenci başarıyla eklendi.");
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
                    lookUpBolum.EditValue = ogrenci.BolumId;
                    cmbSinif.EditValue = ogrenci.Sinif.ToString();
                    txtKayitYili.Text = ogrenci.KayitYili.ToString();
                    checkAktif.Checked = ogrenci.Aktif;
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
