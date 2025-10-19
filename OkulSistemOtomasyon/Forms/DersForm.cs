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
        }

        private void DersForm_Load(object sender, EventArgs e)
        {
            VeriYukle();
            LookUpDoldur();
            spinHaftalikSaat.EditValue = 4;
            cmbDonem.SelectedIndex = 0; // "1. Dönem"
            checkAktif.Checked = true;
        }

        private void VeriYukle()
        {
            try
            {
                var dersler = _context.Dersler
                    .Include(d => d.Sinif)
                    .Include(d => d.Ogretmen)
                    .Select(d => new
                    {
                        d.DersId,
                        d.DersAdi,
                        d.DersKodu,
                        HaftalikSaat = d.HaftalikDersSaati,
                        SinifAdi = d.Sinif != null ? d.Sinif.SinifAdi : "",
                        OgretmenAdi = d.Ogretmen != null ? d.Ogretmen.Ad + " " + d.Ogretmen.Soyad : "",
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
            var siniflar = _context.Siniflar.Where(s => s.Aktif).Select(s => new { s.SinifId, s.SinifAdi }).ToList();
            lookUpSinif.Properties.DataSource = siniflar;
            lookUpSinif.Properties.DisplayMember = "SinifAdi";
            lookUpSinif.Properties.ValueMember = "SinifId";

            var ogretmenler = _context.Ogretmenler.Where(o => o.Aktif).Select(o => new { o.OgretmenId, TamAd = o.Ad + " " + o.Soyad }).ToList();
            lookUpOgretmen.Properties.DataSource = ogretmenler;
            lookUpOgretmen.Properties.DisplayMember = "TamAd";
            lookUpOgretmen.Properties.ValueMember = "OgretmenId";
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            txtDersAdi.Text = string.Empty;
            txtDersKodu.Text = string.Empty;
            spinHaftalikSaat.EditValue = 4;
            lookUpSinif.EditValue = null;
            lookUpOgretmen.EditValue = null;
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

            if (lookUpSinif.EditValue == null)
            {
                MessageHelper.UyariMesaji("Sınıf seçmelisiniz!");
                return;
            }

            try
            {
                var ders = new Ders
                {
                    DersAdi = txtDersAdi.Text.Trim(),
                    DersKodu = txtDersKodu.Text.Trim(),
                    HaftalikDersSaati = Convert.ToInt32(spinHaftalikSaat.EditValue),
                    SinifId = Convert.ToInt32(lookUpSinif.EditValue),
                    OgretmenId = lookUpOgretmen.EditValue != null ? Convert.ToInt32(lookUpOgretmen.EditValue) : (int?)null,
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
                    ders.HaftalikDersSaati = Convert.ToInt32(spinHaftalikSaat.EditValue);
                    ders.SinifId = Convert.ToInt32(lookUpSinif.EditValue);
                    ders.OgretmenId = lookUpOgretmen.EditValue != null ? Convert.ToInt32(lookUpOgretmen.EditValue) : (int?)null;
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
                    spinHaftalikSaat.EditValue = ders.HaftalikDersSaati;
                    lookUpSinif.EditValue = ders.SinifId;
                    lookUpOgretmen.EditValue = ders.OgretmenId;
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
