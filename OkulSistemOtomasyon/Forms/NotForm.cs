using DevExpress.XtraEditors;
using Microsoft.EntityFrameworkCore;
using OkulSistemOtomasyon.Data;
using OkulSistemOtomasyon.Helpers;
using OkulSistemOtomasyon.Models;

namespace OkulSistemOtomasyon.Forms
{
    public partial class NotForm : XtraForm
    {
        private OkulDbContext _context;

        public NotForm()
        {
            InitializeComponent();
            _context = new OkulDbContext();
            this.Text = "Not Girişi";
        }

        private void NotForm_Load(object sender, EventArgs e)
        {
            VeriYukle();
            LookUpDoldur();
        }

        private void VeriYukle()
        {
            try
            {
                var notlar = _context.OgrenciNotlari
                    .Include(n => n.Ogrenci)
                    .Include(n => n.Ders)
                    .Select(n => new
                    {
                        n.NotId,
                        OgrenciAdi = n.Ogrenci != null ? n.Ogrenci.Ad + " " + n.Ogrenci.Soyad : "",
                        DersAdi = n.Ders != null ? n.Ders.DersAdi : "",
                        n.Vize,
                        n.Final,
                        n.ProjeNotu,
                        n.Butunleme,
                        Ortalama = n.Ortalama,
                        HarfNotu = n.HarfNotu,
                        n.Aciklama,
                        n.NotGirisTarihi
                    })
                    .ToList();

                gridControl1.DataSource = notlar;
                gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Veri yüklenirken hata oluştu:\n{ex.Message}");
            }
        }

        private void LookUpDoldur()
        {
            var ogrenciler = _context.Ogrenciler
                .Include(o => o.Bolum)
                .ToList()
                .Where(o => o.Aktif)
                .Select(o => new 
                { 
                    o.OgrenciId, 
                    TamAd = o.Ad + " " + o.Soyad + " - " + (o.Bolum != null ? o.Bolum.BolumAdi : "Bölüm Yok") + " - " + (o.Sinif.HasValue ? o.Sinif.Value + ". Sınıf" : "") 
                })
                .ToList();
            lookUpOgrenci.Properties.DataSource = ogrenciler;
            lookUpOgrenci.Properties.DisplayMember = "TamAd";
            lookUpOgrenci.Properties.ValueMember = "OgrenciId";

            var dersler = _context.Dersler.ToList().Where(d => d.Aktif).Select(d => new { d.DersId, d.DersAdi }).ToList();
            lookUpDers.Properties.DataSource = dersler;
            lookUpDers.Properties.DisplayMember = "DersAdi";
            lookUpDers.Properties.ValueMember = "DersId";
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            lookUpOgrenci.EditValue = null;
            lookUpDers.EditValue = null;
            spinVize.EditValue = 0;
            spinFinal.EditValue = 0;
            spinProje.EditValue = 0;
            spinButunleme.EditValue = 0;
            txtAciklama.Text = string.Empty;
            lookUpOgrenci.Focus();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (lookUpOgrenci.EditValue == null || lookUpDers.EditValue == null)
            {
                MessageHelper.UyariMesaji("Öğrenci ve ders seçmelisiniz!");
                return;
            }

            try
            {
                var not = new OgrenciNot
                {
                    OgrenciId = Convert.ToInt32(lookUpOgrenci.EditValue),
                    DersId = Convert.ToInt32(lookUpDers.EditValue),
                    Vize = spinVize.Value > 0 ? (decimal?)spinVize.Value : null,
                    Final = spinFinal.Value > 0 ? (decimal?)spinFinal.Value : null,
                    ProjeNotu = spinProje.Value > 0 ? (decimal?)spinProje.Value : null,
                    Butunleme = spinButunleme.Value > 0 ? (decimal?)spinButunleme.Value : null,
                    Aciklama = txtAciklama.Text.Trim(),
                    NotGirisTarihi = DateTime.Now
                };

                _context.OgrenciNotlari.Add(not);
                _context.SaveChanges();

                MessageHelper.BasariMesaji("Not başarıyla eklendi.");
                VeriYukle();
                btnYeni_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Kayıt sırasında hata oluştu:\n{ex.Message}\n\nDetay: {ex.InnerException?.Message}");
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
            {
                MessageHelper.UyariMesaji("Lütfen güncellenecek notu seçin!");
                return;
            }

            if (lookUpOgrenci.EditValue == null || lookUpDers.EditValue == null)
            {
                MessageHelper.UyariMesaji("Öğrenci ve ders seçmelisiniz!");
                return;
            }

            try
            {
                var selectedRow = gridView1.GetFocusedRow() as dynamic;
                int notId = selectedRow.NotId;

                // Context'i temizle ve fresh entity al
                _context.ChangeTracker.Clear();
                
                var not = _context.OgrenciNotlari.Find(notId);
                if (not != null)
                {
                    not.OgrenciId = Convert.ToInt32(lookUpOgrenci.EditValue);
                    not.DersId = Convert.ToInt32(lookUpDers.EditValue);
                    not.Vize = spinVize.Value > 0 ? (decimal?)spinVize.Value : null;
                    not.Final = spinFinal.Value > 0 ? (decimal?)spinFinal.Value : null;
                    not.ProjeNotu = spinProje.Value > 0 ? (decimal?)spinProje.Value : null;
                    not.Butunleme = spinButunleme.Value > 0 ? (decimal?)spinButunleme.Value : null;
                    not.Aciklama = txtAciklama.Text.Trim();

                    _context.SaveChanges();
                    MessageHelper.BasariMesaji("Not başarıyla güncellendi.");
                    VeriYukle();
                    btnYeni_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Güncelleme sırasında hata oluştu:\n{ex.Message}\n\nDetay: {ex.InnerException?.Message}");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
            {
                MessageHelper.UyariMesaji("Lütfen silinecek notu seçin!");
                return;
            }

            var selectedRow = gridView1.GetFocusedRow() as dynamic;
            int notId = selectedRow.NotId;

            MessageHelper.SilmeOnayMesaji(() =>
            {
                try
                {
                    _context.ChangeTracker.Clear();
                    var not = _context.OgrenciNotlari.Find(notId);
                    if (not != null)
                    {
                        _context.OgrenciNotlari.Remove(not);
                        _context.SaveChanges();
                        MessageHelper.BasariMesaji("Not başarıyla silindi.");
                        VeriYukle();
                        btnYeni_Click(null, null);
                    }
                }
                catch (Exception ex)
                {
                    MessageHelper.HataMesaji($"Silme sırasında hata oluştu:\n{ex.Message}\n\nDetay: {ex.InnerException?.Message}");
                }
            });
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.GetFocusedRow() == null) return;

            try
            {
                var selectedRow = gridView1.GetFocusedRow() as dynamic;
                int notId = selectedRow.NotId;

                // AsNoTracking kullanarak sadece okuma için al
                var not = _context.OgrenciNotlari.AsNoTracking().FirstOrDefault(n => n.NotId == notId);
                if (not != null)
                {
                    lookUpOgrenci.EditValue = not.OgrenciId;
                    lookUpDers.EditValue = not.DersId;
                    spinVize.EditValue = not.Vize ?? 0;
                    spinFinal.EditValue = not.Final ?? 0;
                    spinProje.EditValue = not.ProjeNotu ?? 0;
                    spinButunleme.EditValue = not.Butunleme ?? 0;
                    txtAciklama.Text = not.Aciklama ?? string.Empty;
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
