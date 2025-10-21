using DevExpress.XtraEditors;
using Microsoft.EntityFrameworkCore;
using OkulSistemOtomasyon.Data;
using OkulSistemOtomasyon.Helpers;
using OkulSistemOtomasyon.Models;

namespace OkulSistemOtomasyon.Forms
{
    public partial class DersForm : XtraForm
    {
        private OkulDbContext _context;

        public DersForm()
        {
            InitializeComponent();
            _context = new OkulDbContext();
            this.Text = "Ders Yönetimi";
        }

        private void DersForm_Load(object sender, EventArgs e)
        {
            VeriYukle();
            LookUpDoldur();
            spinKredi.EditValue = 3;
            spinAKTS.EditValue = 5;
            cmbDonem.SelectedIndex = 0; // "Güz Dönemi"
            checkAktif.Checked = true;
        }

        private void VeriYukle()
        {
            try
            {
                var dersler = _context.Dersler
                    .Include(d => d.Bolum)
                    .Include(d => d.Akademisyen)
                    .Select(d => new
                    {
                        d.DersId,
                        d.DersAdi,
                        d.DersKodu,
                        d.Kredi,
                        d.AKTS,
                        BolumAdi = d.Bolum != null ? d.Bolum.BolumAdi : "",
                        AkademisyenAdi = d.Akademisyen != null ? d.Akademisyen.Ad + " " + d.Akademisyen.Soyad : "",
                        Donem = d.DonemBilgisi,
                        d.Aktif
                    })
                    .ToList();

                gridControl1.DataSource = dersler;
                gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Veri yüklenirken hata oluştu:\n{ex.Message}");
            }
        }

        private void LookUpDoldur()
        {
            var bolumler = _context.Bolumler.ToList().Where(b => b.Aktif).Select(b => new { b.BolumId, b.BolumAdi }).ToList();
            lookUpBolum.Properties.DataSource = bolumler;
            lookUpBolum.Properties.DisplayMember = "BolumAdi";
            lookUpBolum.Properties.ValueMember = "BolumId";

            var akademisyenler = _context.Akademisyenler.ToList().Where(a => a.Aktif).Select(a => new { a.AkademisyenId, TamAd = a.Unvan + " " + a.Ad + " " + a.Soyad }).ToList();
            lookUpAkademisyen.Properties.DataSource = akademisyenler;
            lookUpAkademisyen.Properties.DisplayMember = "TamAd";
            lookUpAkademisyen.Properties.ValueMember = "AkademisyenId";
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            txtDersAdi.Text = string.Empty;
            txtDersKodu.Text = string.Empty;
            spinKredi.EditValue = 3;
            spinAKTS.EditValue = 5;
            lookUpBolum.EditValue = null;
            lookUpAkademisyen.EditValue = null;
            cmbDonem.SelectedIndex = 0;
            checkAktif.Checked = true;
            txtDersAdi.Focus();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDersAdi.Text))
            {
                MessageHelper.UyariMesaji("Ders adı boş olamaz!");
                return;
            }

            if (lookUpBolum.EditValue == null)
            {
                MessageHelper.UyariMesaji("Bölüm seçmelisiniz!");
                return;
            }

            try
            {
                var ders = new Ders
                {
                    DersAdi = txtDersAdi.Text.Trim(),
                    DersKodu = txtDersKodu.Text.Trim(),
                    Kredi = Convert.ToInt32(spinKredi.EditValue),
                    AKTS = Convert.ToInt32(spinAKTS.EditValue),
                    BolumId = Convert.ToInt32(lookUpBolum.EditValue),
                    AkademisyenId = lookUpAkademisyen.EditValue != null ? Convert.ToInt32(lookUpAkademisyen.EditValue) : (int?)null,
                    DonemBilgisi = cmbDonem.Text,
                    Aktif = checkAktif.Checked
                };

                _context.Dersler.Add(ders);
                _context.SaveChanges();

                MessageHelper.BasariMesaji("Ders başarıyla eklendi.");
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
                MessageHelper.UyariMesaji("Lütfen güncellenecek dersi seçin!");
                return;
            }

            try
            {
                var selectedRow = gridView1.GetFocusedRow() as dynamic;
                int dersId = selectedRow.DersId;

                var ders = _context.Dersler.Find(dersId);
                if (ders != null)
                {
                    ders.DersAdi = txtDersAdi.Text.Trim();
                    ders.DersKodu = txtDersKodu.Text.Trim();
                    ders.Kredi = Convert.ToInt32(spinKredi.EditValue);
                    ders.AKTS = Convert.ToInt32(spinAKTS.EditValue);
                    ders.BolumId = Convert.ToInt32(lookUpBolum.EditValue);
                    ders.AkademisyenId = lookUpAkademisyen.EditValue != null ? Convert.ToInt32(lookUpAkademisyen.EditValue) : (int?)null;
                    ders.DonemBilgisi = cmbDonem.Text;
                    ders.Aktif = checkAktif.Checked;

                    _context.SaveChanges();
                    MessageHelper.BasariMesaji("Ders başarıyla güncellendi.");
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
                MessageHelper.UyariMesaji("Lütfen silinecek dersi seçin!");
                return;
            }

            var selectedRow = gridView1.GetFocusedRow() as dynamic;
            int dersId = selectedRow.DersId;

            MessageHelper.SilmeOnayMesaji(() =>
            {
                var ders = _context.Dersler.Find(dersId);
                if (ders != null)
                {
                    _context.Dersler.Remove(ders);
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
                int dersId = selectedRow.DersId;

                var ders = _context.Dersler.Find(dersId);
                if (ders != null)
                {
                    txtDersAdi.Text = ders.DersAdi;
                    txtDersKodu.Text = ders.DersKodu;
                    spinKredi.EditValue = ders.Kredi;
                    spinAKTS.EditValue = ders.AKTS;
                    lookUpBolum.EditValue = ders.BolumId;
                    lookUpAkademisyen.EditValue = ders.AkademisyenId;
                    cmbDonem.Text = ders.DonemBilgisi;
                    checkAktif.Checked = ders.Aktif;
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
