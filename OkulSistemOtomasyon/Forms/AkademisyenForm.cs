using DevExpress.XtraEditors;
using OkulSistemOtomasyon.Helpers;
using OkulSistemOtomasyon.Models;
using OkulSistemOtomasyon.Services;

namespace OkulSistemOtomasyon.Forms
{
    /// <summary>
    /// Akademisyen Yönetim Formu
    /// OOP: Dependency Injection ile service kullanımı
    /// OOP: Separation of Concerns - Form sadece UI ile ilgilenir
    /// </summary>
    public partial class AkademisyenForm : XtraForm
    {
        private readonly IAkademisyenService _akademisyenService;

        public AkademisyenForm()
        {
            InitializeComponent();
            
            // Dependency Injection - ServiceLocator pattern
            _akademisyenService = ServiceLocator.GetAkademisyenService();
            
            this.Text = "Akademisyen Yönetimi";
        }

        private void AkademisyenForm_Load(object sender, EventArgs e)
        {
            VeriYukle();
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

        private void VeriYukle()
        {
            try
            {
                // OOP: Service layer üzerinden veri çekme
                var akademisyenler = _akademisyenService.GetWithDersler()
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
                        VerdigiDersler = a.Dersler.Count(d => d.IsActive)
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
            // OOP: Business logic service'de, form sadece UI işleri yapıyor
            var akademisyen = new Akademisyen
            {
                TC = txtTC.Text.Trim(),
                Ad = txtAd.Text.Trim(),
                Soyad = txtSoyad.Text.Trim(),
                Unvan = cmbUnvan.Text,
                UzmanlikAlani = txtUzmanlikAlani.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Telefon = txtTelefon.Text.Trim()
            };
            
            // IsActive property'sini set et
            akademisyen.GetType().GetProperty("IsActive")?.SetValue(akademisyen, checkAktif.Checked);

            // Service layer üzerinden kaydet
            if (_akademisyenService.Add(akademisyen, out string errorMessage))
            {
                MessageHelper.BasariMesaji("Akademisyen başarıyla eklendi.");
                VeriYukle();
                btnYeni_Click(null, null);
            }
            else
            {
                MessageHelper.UyariMesaji(errorMessage);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
            {
                MessageHelper.UyariMesaji("Lütfen güncellenecek akademisyeni seçin!");
                return;
            }

            try
            {
                var selectedRow = gridView1.GetFocusedRow() as dynamic;
                int akademisyenId = selectedRow.AkademisyenId;

                // OOP: Service layer üzerinden akademisyeni al
                var akademisyen = _akademisyenService.GetById(akademisyenId);
                if (akademisyen != null)
                {
                    akademisyen.TC = txtTC.Text.Trim();
                    akademisyen.Ad = txtAd.Text.Trim();
                    akademisyen.Soyad = txtSoyad.Text.Trim();
                    akademisyen.Unvan = cmbUnvan.Text;
                    akademisyen.UzmanlikAlani = txtUzmanlikAlani.Text.Trim();
                    akademisyen.Email = txtEmail.Text.Trim();
                    akademisyen.Telefon = txtTelefon.Text.Trim();
                    
                    // IsActive property'sini set et
                    akademisyen.GetType().GetProperty("IsActive")?.SetValue(akademisyen, checkAktif.Checked);

                    // Service layer üzerinden güncelle
                    if (_akademisyenService.Update(akademisyen, out string errorMessage))
                    {
                        MessageHelper.BasariMesaji("Akademisyen başarıyla güncellendi.");
                        VeriYukle();
                    }
                    else
                    {
                        MessageHelper.UyariMesaji(errorMessage);
                    }
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
                // OOP: Service layer üzerinden sil
                if (_akademisyenService.Delete(akademisyenId, out string errorMessage))
                {
                    VeriYukle();
                    btnYeni_Click(null, null);
                }
                else
                {
                    MessageHelper.HataMesaji(errorMessage);
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

                // OOP: Service layer üzerinden veri al
                var akademisyen = _akademisyenService.GetById(akademisyenId);
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
            // Context artık ServiceLocator tarafından yönetiliyor
            // Form kapanırken özel bir işlem yapma
            base.OnFormClosing(e);
        }
    }
}
