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
            
            try
            {
                // Kullanıcının AkademisyenId'si var mı kontrol et
                if (!kullanici.AkademisyenId.HasValue || kullanici.AkademisyenId.Value == 0)
                {
                    MessageHelper.HataMesaji("Bu kullanıcı için akademisyen kaydı bulunamadı!\n\n" +
                        $"Kullanıcı: {kullanici.KullaniciAdi}\n" +
                        $"AkademisyenId: {kullanici.AkademisyenId}");
                    this.Load += (s, e) => this.Close();
                    return;
                }
                
                // AkademisyenId'yi yerel değişkene ata (EF Core çeviri problemi için)
                int akademisyenId = kullanici.AkademisyenId.Value;
                
                // Akademisyen bilgilerini yükle (Include kullanmadan, ID property sorunu nedeniyle)
                _akademisyen = _context.Akademisyenler
                    .AsNoTracking()
                    .FirstOrDefault(a => a.Id == akademisyenId);

                if (_akademisyen == null)
                {
                    MessageHelper.HataMesaji($"Akademisyen bilgileri veritabanında bulunamadı!\n\n" +
                        $"Aranan ID: {akademisyenId}\n" +
                        $"Kullanıcı: {kullanici.KullaniciAdi}\n\n" +
                        "Lütfen veritabanını kontrol edin.");
                    this.Load += (s, e) => this.Close();
                    return;
                }

                this.Text = $"Akademisyen Paneli - {_akademisyen.Unvan} {_akademisyen.Ad} {_akademisyen.Soyad}";
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Akademisyen paneli açılırken hata oluştu:\n\n" +
                    $"Hata: {ex.Message}\n\n" +
                    $"Detay: {ex.InnerException?.Message}\n\n" +
                    $"Stack: {ex.StackTrace}");
                this.Load += (s, e) => this.Close();
            }
        }

        private void AkademisyenPanelForm_Load(object sender, EventArgs e)
        {
            if (_akademisyen == null)
            {
                this.Close();
                return;
            }

            AkademisyenBilgileriniGoster();
            VerdigiDersleriYukle();
            DanismanOgrencileriniYukle();
            DersKayitTalepleriniYukle();
        }

        private void AkademisyenBilgileriniGoster()
        {
            if (_akademisyen == null) return;

            lblHosgeldin.Text = $"Hoş Geldiniz, {_akademisyen.Unvan} {_akademisyen.Ad} {_akademisyen.Soyad}";
            lblEmail.Text = $"Email: {_akademisyen.Email}";
            lblUzmanlik.Text = $"Uzmanlık: {_akademisyen.UzmanlikAlani}";
        }

        private void VerdigiDersleriYukle()
        {
            if (_akademisyen == null) return;

            try
            {
                // Id property kullan (AkademisyenId yerine)
                int akademisyenId = _akademisyen.Id;
                
                // Önce veritabanından çek, sonra bellekte filtrele (Aktif NotMapped olduğu için)
                var dersler = _context.Dersler
                    .Include(d => d.Bolum)
                    .Where(d => d.AkademisyenId == akademisyenId)
                    .ToList() // Veritabanından çek
                    .Where(d => d.Aktif) // Bellekte filtrele
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
                MessageHelper.HataMesaji($"Dersler yüklenirken hata oluştu:\n{ex.Message}\n\nDetay: {ex.InnerException?.Message}");
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
                // SADECE seçili derse kayıtlı öğrencileri getir
                var ogrenciler = _context.OgrenciNotlari
                    .Include(n => n.Ogrenci)
                    .Where(n => n.DersId == dersId)
                    .Select(n => new
                    {
                        n.OgrenciId,
                        n.Ogrenci.OgrenciNo,
                        AdSoyad = n.Ogrenci.Ad + " " + n.Ogrenci.Soyad,
                        n.Ogrenci.Email,
                        n.Vize,
                        n.Final,
                        n.Butunleme,
                        n.ProjeNotu
                    })
                    .ToList();

                gridControlOgrenciler.DataSource = ogrenciler;
                gridViewOgrenciler.BestFitColumns();

                lblOgrenciSayisi.Text = $"Kayıtlı Öğrenci: {ogrenciler.Count}";
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Öğrenciler yüklenirken hata oluştu:\n{ex.Message}\n\nDetay: {ex.InnerException?.Message}");
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

        /// <summary>
        /// Danışman olduğu öğrencileri yükler
        /// NOT: Bu metod çağrılıyor ama henüz UI'da görünmüyor. 
        /// XtraTabControl eklendiğinde grid'e bağlanacak.
        /// </summary>
        private void DanismanOgrencileriniYukle()
        {
            try
            {
                // Akademisyen ID'sini al
                int akademisyenId = _akademisyen.Id;
                
                // Önce öğrencileri çek
                var ogrenciler = _context.Ogrenciler
                    .Include(o => o.Bolum)
                    .Where(o => o.DanismanId == akademisyenId)
                    .ToList(); // Veritabanından çek
                
                // Tüm notları da bellekte çek
                var tumNotlar = _context.OgrenciNotlari.ToList();
                
                // Sonra her öğrenci için ortalamayı hesapla (tamamen bellekte)
                var danismanOgrenciler = ogrenciler
                    .Select(o => new
                    {
                        o.OgrenciId,
                        o.OgrenciNo,
                        AdSoyad = o.Ad + " " + o.Soyad,
                        BolumAdi = o.Bolum != null ? o.Bolum.BolumAdi : "",
                        o.Sinif,
                        o.Email,
                        o.Telefon,
                        // Ortalama hesapla (tamamen bellekte)
                        Ortalama = tumNotlar
                            .Where(n => n.OgrenciId == o.Id)
                            .Select(n => n.Ortalama)
                            .DefaultIfEmpty(0)
                            .Average()
                    })
                    .ToList();

                gridControlDanismanOgrenciler.DataSource = danismanOgrenciler;
                gridViewDanismanOgrenciler.BestFitColumns();

                lblDanismanOgrenciSayisi.Text = $"Danışman Öğrenci Sayısı: {danismanOgrenciler.Count}";
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Danışman öğrencileri yüklenirken hata:\n{ex.Message}");
            }
        }

        private void DersKayitTalepleriniYukle()
        {
            try
            {
                // Danışman olduğu öğrencilerin bekleyen taleplerini göster
                int akademisyenId = _akademisyen.Id;

                var talepler = _context.DersKayitTalepleri
                    .Include(t => t.Ogrenci)
                    .Include(t => t.Ders)
                    .Where(t => t.Ogrenci.DanismanId == akademisyenId && t.Durum == DersKayitDurumu.Beklemede)
                    .OrderBy(t => t.TalepTarihi)
                    .Select(t => new
                    {
                        TalepId = t.Id,
                        OgrenciNo = t.Ogrenci.OgrenciNo,
                        OgrenciAd = t.Ogrenci.Ad + " " + t.Ogrenci.Soyad,
                        DersKodu = t.Ders.DersKodu,
                        DersAdi = t.Ders.DersAdi,
                        Kredi = t.Ders.Kredi,
                        TalepTarihi = t.TalepTarihi.ToString("dd.MM.yyyy HH:mm")
                    })
                    .ToList();

                gridControlTalepler.DataSource = talepler;
                gridViewTalepler.BestFitColumns();

                lblTalepSayisi.Text = $"Bekleyen Talep: {talepler.Count}";
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Talepler yüklenirken hata:\n{ex.Message}\n\nDetay: {ex.InnerException?.Message}");
            }
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            if (gridViewTalepler.GetFocusedRow() == null)
            {
                MessageHelper.UyariMesaji("Lütfen onaylamak istediğiniz talebi seçin!");
                return;
            }

            try
            {
                var selectedRow = gridViewTalepler.GetFocusedRow() as dynamic;
                int talepId = (int)selectedRow.TalepId;
                string ogrenciAd = selectedRow.OgrenciAd;
                string dersAdi = selectedRow.DersAdi;

                if (!MessageHelper.OnayMesaji($"Ders Kayıt Talebini Onayla?\n\n" +
                    $"Öğrenci: {ogrenciAd}\n" +
                    $"Ders: {dersAdi}\n\n" +
                    $"Onayladığınızda öğrenci bu derse otomatik olarak kayıt yapılacaktır."))
                {
                    return;
                }

                var talep = _context.DersKayitTalepleri.Find(talepId);
                if (talep == null)
                {
                    MessageHelper.HataMesaji("Talep bulunamadı!");
                    return;
                }

                // Talebi onayla
                talep.Durum = DersKayitDurumu.Onaylandi;
                talep.KararTarihi = DateTime.Now;

                // Öğrenci için OgrenciNot kaydı oluştur
                var ogrenciNot = new OgrenciNot
                {
                    OgrenciId = talep.OgrenciId,
                    DersId = talep.DersId
                    // Vize, Final vs. null olarak başlayacak
                };

                _context.OgrenciNotlari.Add(ogrenciNot);
                _context.SaveChanges();

                MessageHelper.BasariMesaji($"✅ Talep onaylandı!\n\n" +
                    $"Öğrenci: {ogrenciAd}\n" +
                    $"Ders: {dersAdi}\n\n" +
                    $"Öğrenci derse başarıyla kaydedildi.");

                DersKayitTalepleriniYukle();
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Talep onaylanırken hata:\n{ex.Message}");
            }
        }

        private void btnReddet_Click(object sender, EventArgs e)
        {
            if (gridViewTalepler.GetFocusedRow() == null)
            {
                MessageHelper.UyariMesaji("Lütfen reddetmek istediğiniz talebi seçin!");
                return;
            }

            try
            {
                var selectedRow = gridViewTalepler.GetFocusedRow() as dynamic;
                int talepId = (int)selectedRow.TalepId;
                string ogrenciAd = selectedRow.OgrenciAd;
                string dersAdi = selectedRow.DersAdi;

                // Ret nedeni sor
                string redNedeni = DevExpress.XtraEditors.XtraInputBox.Show(
                    "Ret nedeni (opsiyonel):",
                    "Talep Reddetme",
                    "") ?? "";

                if (!MessageHelper.OnayMesaji($"Ders Kayıt Talebini Reddet?\n\n" +
                    $"Öğrenci: {ogrenciAd}\n" +
                    $"Ders: {dersAdi}\n\n" +
                    $"Talebi reddetmek istediğinize emin misiniz?"))
                {
                    return;
                }

                var talep = _context.DersKayitTalepleri.Find(talepId);
                if (talep == null)
                {
                    MessageHelper.HataMesaji("Talep bulunamadı!");
                    return;
                }

                // Talebi reddet
                talep.Durum = DersKayitDurumu.Reddedildi;
                talep.KararTarihi = DateTime.Now;
                if (!string.IsNullOrWhiteSpace(redNedeni))
                {
                    talep.DanismanNotu = redNedeni;
                }

                _context.SaveChanges();

                MessageHelper.BilgiMesaji($"Talep reddedildi.\n\n" +
                    $"Öğrenci: {ogrenciAd}\n" +
                    $"Ders: {dersAdi}");

                DersKayitTalepleriniYukle();
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Talep reddedilirken hata:\n{ex.Message}");
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _context?.Dispose();
            base.OnFormClosing(e);
        }
    }
}
