using DevExpress.XtraEditors;
using Microsoft.EntityFrameworkCore;
using OkulSistemOtomasyon.Data;
using OkulSistemOtomasyon.Helpers;
using OkulSistemOtomasyon.Models;

namespace OkulSistemOtomasyon.Forms
{
    public partial class AkademisyenPanelForm : XtraForm
    {
        private readonly Kullanici _kullanici;
        private readonly Akademisyen _akademisyen;
        private readonly OkulDbContext _context;

        public AkademisyenPanelForm(Kullanici kullanici)
        {
            InitializeComponent();
            _kullanici = kullanici;
            _context = new OkulDbContext();
            
            // Akademisyen bilgilerini yükle
            _akademisyen = _context.Akademisyenler
                .Include(a => a.Dersler)
                .FirstOrDefault(a => a.AkademisyenId == kullanici.AkademisyenId);

            if (_akademisyen == null)
            {
                MessageHelper.HataMesaji("Akademisyen bilgileri bulunamadı!");
                this.Close();
                return;
            }

            this.Text = $"Akademisyen Paneli - {_akademisyen.Unvan} {_akademisyen.Ad} {_akademisyen.Soyad}";
        }

        private void AkademisyenPanelForm_Load(object sender, EventArgs e)
        {
            AkademisyenBilgileriniGoster();
            DersleriYukle();
        }

        private void AkademisyenBilgileriniGoster()
        {
            lblHosgeldin.Text = $"Hoş Geldiniz, {_akademisyen.Unvan} {_akademisyen.Ad} {_akademisyen.Soyad}";
            lblEmail.Text = $"Email: {_akademisyen.Email}";
            lblUzmanlik.Text = $"Uzmanlık: {_akademisyen.UzmanlikAlani}";
        }

        private void DersleriYukle()
        {
            try
            {
                var dersler = _context.Dersler
                    .Include(d => d.Bolum)
                    .Include(d => d.Notlar)
                    .Where(d => d.AkademisyenId == _akademisyen.AkademisyenId)
                    .ToList() // Önce ToList() çağır, sonra bellekte filtrele
                    .Where(d => d.Aktif) // Memory'de filtrele
                    .Select(d => new
                    {
                        d.DersId,
                        d.DersAdi,
                        d.DersKodu,
                        d.Kredi,
                        BolumAdi = d.Bolum?.BolumAdi ?? "-",
                        OgrenciSayisi = _context.OgrenciNotlari
                            .Where(n => n.DersId == d.DersId)
                            .Select(n => n.OgrenciId)
                            .Distinct()
                            .Count()
                    })
                    .ToList();

                gridControlDersler.DataSource = dersler;
                gridViewDersler.BestFitColumns();

                lblDersSayisi.Text = $"Toplam Ders: {dersler.Count}";
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Dersler yüklenirken hata oluştu:\n{ex.Message}");
            }
        }

        private void gridViewDersler_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridViewDersler.GetFocusedRow() == null) return;

            try
            {
                var selectedRow = gridViewDersler.GetFocusedRow() as dynamic;
                int dersId = selectedRow.DersId;

                OgrencileriYukle(dersId);
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Öğrenciler yüklenirken hata oluştu:\n{ex.Message}");
            }
        }

        private void OgrencileriYukle(int dersId)
        {
            try
            {
                // Derse kayıtlı tüm öğrencileri getir
                var ogrenciler = _context.Ogrenciler
                    .Where(o => o.Aktif)
                    .ToList()
                    .Select(o => new
                    {
                        o.OgrenciId,
                        o.OgrenciNo,
                        AdSoyad = o.Ad + " " + o.Soyad,
                        o.Email,
                        // Not bilgisini al
                        Not = _context.OgrenciNotlari
                            .FirstOrDefault(n => n.OgrenciId == o.OgrenciId && n.DersId == dersId),
                        Vize = _context.OgrenciNotlari
                            .Where(n => n.OgrenciId == o.OgrenciId && n.DersId == dersId)
                            .Select(n => n.Vize)
                            .FirstOrDefault(),
                        Final = _context.OgrenciNotlari
                            .Where(n => n.OgrenciId == o.OgrenciId && n.DersId == dersId)
                            .Select(n => n.Final)
                            .FirstOrDefault(),
                        Butunleme = _context.OgrenciNotlari
                            .Where(n => n.OgrenciId == o.OgrenciId && n.DersId == dersId)
                            .Select(n => n.Butunleme)
                            .FirstOrDefault(),
                        ProjeNotu = _context.OgrenciNotlari
                            .Where(n => n.OgrenciId == o.OgrenciId && n.DersId == dersId)
                            .Select(n => n.ProjeNotu)
                            .FirstOrDefault()
                    })
                    .ToList();

                gridControlOgrenciler.DataSource = ogrenciler;
                gridViewOgrenciler.BestFitColumns();

                lblOgrenciSayisi.Text = $"Kayıtlı Öğrenci: {ogrenciler.Count}";
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Öğrenciler yüklenirken hata oluştu:\n{ex.Message}");
            }
        }

        private void btnNotGir_Click(object sender, EventArgs e)
        {
            if (gridViewDersler.GetFocusedRow() == null)
            {
                MessageHelper.UyariMesaji("Lütfen ders seçin!");
                return;
            }

            if (gridViewOgrenciler.GetFocusedRow() == null)
            {
                MessageHelper.UyariMesaji("Lütfen öğrenci seçin!");
                return;
            }

            try
            {
                var selectedDers = gridViewDersler.GetFocusedRow() as dynamic;
                var selectedOgrenci = gridViewOgrenciler.GetFocusedRow() as dynamic;

                int dersId = selectedDers.DersId;
                int ogrenciId = selectedOgrenci.OgrenciId;

                // Not giriş formu aç
                using (var notGirisForm = new NotGirisDialog(ogrenciId, dersId))
                {
                    if (notGirisForm.ShowDialog() == DialogResult.OK)
                    {
                        // Listeyi yenile
                        OgrencileriYukle(dersId);
                        MessageHelper.BasariMesaji("Not başarıyla kaydedildi!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Not girişi sırasında hata oluştu:\n{ex.Message}");
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            SessionManager.CikisYap();
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _context?.Dispose();
            base.OnFormClosing(e);
        }
    }
}
