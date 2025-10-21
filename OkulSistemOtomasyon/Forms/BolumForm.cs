using DevExpress.XtraEditors;
using OkulSistemOtomasyon.Data;
using OkulSistemOtomasyon.Helpers;
using OkulSistemOtomasyon.Models;

namespace OkulSistemOtomasyon.Forms
{
    public partial class BolumForm : XtraForm
    {
        private OkulDbContext _context;

        public BolumForm()
        {
            InitializeComponent();
            _context = new OkulDbContext();
            this.Text = "Bölüm Yönetimi";
        }

        private void BolumForm_Load(object sender, EventArgs e)
        {
            VeriYukle();
            cmbOgretimTuru.Properties.Items.AddRange(new string[] { "Normal Öğretim", "İkinci Öğretim", "Uzaktan Eğitim" });
            cmbOgretimTuru.SelectedIndex = 0;
            checkAktif.Checked = true;
        }

        private void VeriYukle()
        {
            try
            {
                var bolumler = _context.Bolumler
                    .ToList()
                    .Select(b => new
                    {
                        b.BolumId,
                        b.BolumAdi,
                        b.BolumKodu,
                        b.Fakulte,
                        b.OgretimTuru,
                        b.Kontenjan,
                        b.AkademikYil,
                        b.Aktif,
                        MevcutOgrenci = b.Ogrenciler.Count(o => o.Aktif)
                    })
                    .ToList();

                gridControl1.DataSource = bolumler;
                gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Veri yüklenirken hata oluştu:\n{ex.Message}");
            }
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            txtBolumAdi.Text = string.Empty;
            txtBolumKodu.Text = string.Empty;
            txtFakulte.Text = string.Empty;
            cmbOgretimTuru.SelectedIndex = 0;
            spinKontenjan.EditValue = 80;
            txtAkademikYil.Text = "2024-2025";
            checkAktif.Checked = true;
            txtBolumAdi.Focus();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBolumAdi.Text))
            {
                MessageHelper.UyariMesaji("Bölüm adı boş olamaz!");
                return;
            }

            try
            {
                var bolum = new Bolum
                {
                    BolumAdi = txtBolumAdi.Text.Trim(),
                    BolumKodu = txtBolumKodu.Text.Trim(),
                    Fakulte = txtFakulte.Text.Trim(),
                    OgretimTuru = cmbOgretimTuru.Text,
                    Kontenjan = Convert.ToInt32(spinKontenjan.EditValue),
                    AkademikYil = txtAkademikYil.Text.Trim(),
                    Aktif = checkAktif.Checked
                };

                _context.Bolumler.Add(bolum);
                _context.SaveChanges();

                MessageHelper.BasariMesaji("Bölüm başarıyla eklendi.");
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
                MessageHelper.UyariMesaji("Lütfen güncellenecek bölümü seçin!");
                return;
            }

            try
            {
                var selectedRow = gridView1.GetFocusedRow() as dynamic;
                int bolumId = selectedRow.BolumId;

                var bolum = _context.Bolumler.Find(bolumId);
                if (bolum != null)
                {
                    bolum.BolumAdi = txtBolumAdi.Text.Trim();
                    bolum.BolumKodu = txtBolumKodu.Text.Trim();
                    bolum.Fakulte = txtFakulte.Text.Trim();
                    bolum.OgretimTuru = cmbOgretimTuru.Text;
                    bolum.Kontenjan = Convert.ToInt32(spinKontenjan.EditValue);
                    bolum.AkademikYil = txtAkademikYil.Text.Trim();
                    bolum.Aktif = checkAktif.Checked;

                    _context.SaveChanges();
                    MessageHelper.BasariMesaji("Bölüm başarıyla güncellendi.");
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
                MessageHelper.UyariMesaji("Lütfen silinecek bölümü seçin!");
                return;
            }

            var selectedRow = gridView1.GetFocusedRow() as dynamic;
            int bolumId = selectedRow.BolumId;

            MessageHelper.SilmeOnayMesaji(() =>
            {
                var bolum = _context.Bolumler.Find(bolumId);
                if (bolum != null)
                {
                    _context.Bolumler.Remove(bolum);
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
                int bolumId = selectedRow.BolumId;

                var bolum = _context.Bolumler.Find(bolumId);
                if (bolum != null)
                {
                    txtBolumAdi.Text = bolum.BolumAdi;
                    txtBolumKodu.Text = bolum.BolumKodu;
                    txtFakulte.Text = bolum.Fakulte;
                    cmbOgretimTuru.Text = bolum.OgretimTuru;
                    spinKontenjan.EditValue = bolum.Kontenjan;
                    txtAkademikYil.Text = bolum.AkademikYil;
                    checkAktif.Checked = bolum.Aktif;
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
