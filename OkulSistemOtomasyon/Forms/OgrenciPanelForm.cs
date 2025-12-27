using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.EntityFrameworkCore;
using OkulSistemOtomasyon.Data;
using OkulSistemOtomasyon.Helpers;
using OkulSistemOtomasyon.Models;
using System.Data;

namespace OkulSistemOtomasyon.Forms
{
    public partial class OgrenciPanelForm : XtraForm
    {
        private int _ogrenciId;
        private Ogrenci _ogrenci;

        public OgrenciPanelForm()
        {
            InitializeComponent();
            
            if (SessionManager.AktifKullanici?.OgrenciId != null)
            {
                _ogrenciId = SessionManager.AktifKullanici.OgrenciId.Value;
            }
            else
            {
                MessageHelper.HataMesaji("Öğrenci bilgisi bulunamadı! Lütfen öğrenci kullanıcısı olarak giriş yapın.");
                this.Load += (s, e) => this.Close(); // Form yüklendikten sonra kapat
                return;
            }
        }

        private void OgrenciPanelForm_Load(object sender, EventArgs e)
        {
            OgrenciBilgileriniYukle();
            NotlariYukle();
            DersleriYukle();
            TalepleriYukle();
        }

        private void OgrenciBilgileriniYukle()
        {
            try
            {
                using (var context = new OkulDbContext())
                {
                    // Id property kullan (OgrenciId NotMapped olduğu için)
                    _ogrenci = context.Ogrenciler
                        .Include(o => o.Bolum)
                        .Include(o => o.Danisman)
                        .FirstOrDefault(o => o.Id == _ogrenciId);

                    if (_ogrenci != null)
                    {
                        lblOgrenciAd.Text = $"{_ogrenci.Ad} {_ogrenci.Soyad}";
                        lblOgrenciNo.Text = $"Öğrenci No: {_ogrenci.OgrenciNo}";
                        lblBolum.Text = $"Bölüm: {_ogrenci.Bolum?.BolumAdi ?? "Belirtilmemiş"}";
                        lblSinif.Text = $"Sınıf: {_ogrenci.Sinif}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Öğrenci bilgileri yüklenirken hata oluştu:\n{ex.Message}\n\nDetay: {ex.InnerException?.Message}");
            }
        }

        private void NotlariYukle()
        {
            try
            {
                using (var context = new OkulDbContext())
                {
                    var notlar = context.OgrenciNotlari
                        .Include(n => n.Ders)
                            .ThenInclude(d => d.Akademisyen)
                        .Where(n => n.OgrenciId == _ogrenciId)
                        .ToList();

                    // DataTable oluştur
                    var dt = new DataTable();
                    dt.Columns.Add("DersKodu", typeof(string));
                    dt.Columns.Add("DersAdi", typeof(string));
                    dt.Columns.Add("Akademisyen", typeof(string));
                    dt.Columns.Add("Kredi", typeof(int));
                    dt.Columns.Add("Vize", typeof(string));
                    dt.Columns.Add("Final", typeof(string));
                    dt.Columns.Add("Butunleme", typeof(string));
                    dt.Columns.Add("Proje", typeof(string));
                    dt.Columns.Add("Ortalama", typeof(string));
                    dt.Columns.Add("HarfNotu", typeof(string));
                    dt.Columns.Add("Durum", typeof(string));

                    double toplamKredi = 0;
                    double agirlikliToplam = 0;

                    foreach (var not in notlar)
                    {
                        if (not.Ders == null) continue;

                        var vize = not.Vize?.ToString() ?? "-";
                        var final = not.Final?.ToString() ?? "-";
                        var butunleme = not.Butunleme?.ToString() ?? "-";
                        var proje = not.ProjeNotu?.ToString() ?? "-";

                        // Ortalama hesapla
                        string ortalama = "-";
                        string harfNotu = "-";
                        string durum = "Devam Ediyor";

                        if (not.Final.HasValue && not.Vize.HasValue)
                        {
                            double ort = ((double)not.Vize.Value * 0.4) + ((double)not.Final.Value * 0.6);
                            
                            // Bütünleme varsa onu kullan
                            if (not.Butunleme.HasValue && not.Butunleme.Value > not.Final.Value)
                            {
                                ort = ((double)not.Vize.Value * 0.4) + ((double)not.Butunleme.Value * 0.6);
                            }

                            // Proje notu varsa %20 ekle
                            if (not.ProjeNotu.HasValue)
                            {
                                ort = (ort * 0.8) + ((double)not.ProjeNotu.Value * 0.2);
                            }

                            ortalama = ort.ToString("F2");
                            harfNotu = HarfNotuHesapla(ort);
                            durum = ort >= 50 ? "✅ Geçti" : "❌ Kaldı";

                            // GNO hesabı için (50 ve üstü geçer)
                            if (ort >= 50)
                            {
                                toplamKredi += not.Ders.Kredi;
                                agirlikliToplam += (ort * not.Ders.Kredi);
                            }
                        }

                        dt.Rows.Add(
                            not.Ders.DersKodu,
                            not.Ders.DersAdi,
                            not.Ders.Akademisyen != null 
                                ? $"{not.Ders.Akademisyen.Unvan} {not.Ders.Akademisyen.Ad} {not.Ders.Akademisyen.Soyad}"
                                : "-",
                            not.Ders.Kredi,
                            vize,
                            final,
                            butunleme,
                            proje,
                            ortalama,
                            harfNotu,
                            durum
                        );
                    }

                    gridNotlar.DataSource = dt;

                    // Sütun genişliklerini ayarla
                    var view = gridViewNotlar;
                    view.BestFitColumns();

                    // Durum sütununu renklendir
                    view.RowCellStyle += (s, e) =>
                    {
                        if (e.Column.FieldName == "Durum")
                        {
                            string durum = e.CellValue?.ToString() ?? "";
                            if (durum.Contains("Geçti"))
                            {
                                e.Appearance.ForeColor = Color.Green;
                                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                            }
                            else if (durum.Contains("Kaldı"))
                            {
                                e.Appearance.ForeColor = Color.Red;
                                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                            }
                        }
                    };

                    // GNO hesapla ve göster
                    if (toplamKredi > 0)
                    {
                        double gno = agirlikliToplam / toplamKredi;
                        lblGNO.Text = $"Genel Not Ortalaması: {gno:F2} / 100";
                        
                        // GNO rengini ayarla
                        if (gno >= 85)
                            lblGNO.ForeColor = Color.DarkGreen;
                        else if (gno >= 70)
                            lblGNO.ForeColor = Color.Green;
                        else if (gno >= 60)
                            lblGNO.ForeColor = Color.Orange;
                        else
                            lblGNO.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblGNO.Text = "Genel Not Ortalaması: Henüz not girilmemiş";
                        lblGNO.ForeColor = Color.Gray;
                    }

                    lblToplamDers.Text = $"Toplam Ders Sayısı: {notlar.Count}";
                    lblAlinanKredi.Text = $"Alınan Kredi: {toplamKredi:F0}";
                }
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Notlar yüklenirken hata oluştu:\n{ex.Message}");
            }
        }

        /// <summary>
        /// Harf Notu: 50 altı FF (kaldı), 50 ve üstü geçer notlar
        /// </summary>
        private string HarfNotuHesapla(double ortalama)
        {
            if (ortalama >= 90) return "AA";  // 90-100: Pekiyi
            if (ortalama >= 80) return "BA";  // 80-89: İyi-Pekiyi
            if (ortalama >= 70) return "BB";  // 70-79: İyi
            if (ortalama >= 60) return "CB";  // 60-69: Orta-İyi
            if (ortalama >= 50) return "CC";  // 50-59: Orta (Geçer)
            return "FF";                       // 0-49: Başarısız (Kaldı)
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            NotlariYukle();
            DersleriYukle();
            TalepleriYukle();
            MessageHelper.BilgiMesaji("Tüm bilgiler başarıyla yenilendi!");
        }

        private void DersleriYukle()
        {
            try
            {
                if (_ogrenci == null) return;

                using (var context = new OkulDbContext())
                {
                    // Öğrencinin bölümündeki aktif dersleri göster
                    var dersler = context.Dersler
                        .Include(d => d.Akademisyen)
                        .Where(d => d.BolumId == _ogrenci.BolumId && d.IsActive)
                        .Select(d => new
                        {
                            d.DersId,
                            d.DersKodu,
                            d.DersAdi,
                            d.Kredi,
                            Akademisyen = d.Akademisyen != null 
                                ? $"{d.Akademisyen.Unvan} {d.Akademisyen.Ad} {d.Akademisyen.Soyad}" 
                                : "-",
                            d.DonemBilgisi
                        })
                        .ToList();

                    gridDersler.DataSource = dersler;
                    gridViewDersler.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Dersler yüklenirken hata: {ex.Message}");
            }
        }

        private void TalepleriYukle()
        {
            try
            {
                using (var context = new OkulDbContext())
                {
                    var talepler = context.DersKayitTalepleri
                        .Include(t => t.Ders)
                        .Where(t => t.OgrenciId == _ogrenciId)
                        .OrderByDescending(t => t.TalepTarihi)
                        .Select(t => new
                        {
                            TalepId = t.Id,
                            t.Ders.DersKodu,
                            t.Ders.DersAdi,
                            Durum = t.Durum == DersKayitDurumu.Beklemede ? "⏳ Beklemede" :
                                    t.Durum == DersKayitDurumu.Onaylandi ? "✅ Onaylandı" : "❌ Reddedildi",
                            TalepTarihi = t.TalepTarihi.ToString("dd.MM.yyyy HH:mm"),
                            KararTarihi = t.KararTarihi.HasValue ? t.KararTarihi.Value.ToString("dd.MM.yyyy HH:mm") : "-",
                            t.DanismanNotu
                        })
                        .ToList();

                    gridTalepler.DataSource = talepler;
                    gridViewTalepler.BestFitColumns();

                    // Durum sütununu renklendir
                    gridViewTalepler.RowCellStyle += (s, e) =>
                    {
                        if (e.Column.FieldName == "Durum")
                        {
                            string durum = e.CellValue?.ToString() ?? "";
                            if (durum.Contains("Onaylandı"))
                            {
                                e.Appearance.ForeColor = Color.Green;
                                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                            }
                            else if (durum.Contains("Reddedildi"))
                            {
                                e.Appearance.ForeColor = Color.Red;
                                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                            }
                            else if (durum.Contains("Beklemede"))
                            {
                                e.Appearance.ForeColor = Color.Orange;
                                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                            }
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Talepler yüklenirken hata: {ex.Message}");
            }
        }

        private void btnDersKayitTalebi_Click(object sender, EventArgs e)
        {
            if (gridViewDersler.GetFocusedRow() == null)
            {
                MessageHelper.UyariMesaji("Lütfen kayıt olmak istediğiniz dersi seçin!");
                return;
            }

            if (_ogrenci.DanismanId == null)
            {
                MessageHelper.UyariMesaji("Danışman öğretmeniniz atanmamış!\nDers kayıt talebi göndermek için danışman ataması yapılmalıdır.");
                return;
            }

            try
            {
                var selectedRow = gridViewDersler.GetFocusedRow() as dynamic;
                int dersId = selectedRow.DersId;
                string dersAdi = selectedRow.DersAdi;

                using (var context = new OkulDbContext())
                {
                    // Zaten kayıtlı mı kontrol et
                    var mevcutKayit = context.OgrenciNotlari
                        .Any(n => n.OgrenciId == _ogrenciId && n.DersId == dersId);

                    if (mevcutKayit)
                    {
                        MessageHelper.UyariMesaji($"'{dersAdi}' dersine zaten kayıtlısınız!");
                        return;
                    }

                    // Bekleyen talep var mı kontrol et
                    var bekleyenTalep = context.DersKayitTalepleri
                        .Any(t => t.OgrenciId == _ogrenciId && t.DersId == dersId && t.Durum == DersKayitDurumu.Beklemede);

                    if (bekleyenTalep)
                    {
                        MessageHelper.UyariMesaji($"'{dersAdi}' dersi için zaten bekleyen bir talebiniz var!");
                        return;
                    }

                    // Kullanıcıdan onay al
                    if (!MessageHelper.OnayMesaji($"'{dersAdi}' dersi için kayıt talebi göndermek istediğinize emin misiniz?\n\nTalep danışman öğretmeninize iletilecektir."))
                    {
                        return;
                    }

                    // Yeni talep oluştur
                    var talep = new DersKayitTalebi
                    {
                        OgrenciId = _ogrenciId,
                        DersId = dersId,
                        Durum = DersKayitDurumu.Beklemede,
                        TalepTarihi = DateTime.Now
                    };

                    context.DersKayitTalepleri.Add(talep);
                    context.SaveChanges();

                    MessageHelper.BasariMesaji($"✅ Ders kayıt talebiniz başarıyla gönderildi!\n\n" +
                        $"Ders: {dersAdi}\n" +
                        $"Durum: Danışman onayı bekleniyor\n\n" +
                        $"Danışman öğretmeniniz onayladığında derse otomatik olarak kayıt yapılacaktır.");
                    
                    TalepleriYukle();
                    
                    // Taleplerim sekmesine geç
                    xtraTabControl.SelectedTabPage = tabTaleplerim;
                }
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Talep gönderilirken hata: {ex.Message}");
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageHelper.OnayMesaji("Çıkış yapmak istediğinize emin misiniz?"))
            {
                SessionManager.CikisYap();
                this.Close();
            }
        }

        private void btnNotYazdir_Click(object sender, EventArgs e)
        {
            try
            {
                // Grid'i yazdır
                gridViewNotlar.ShowPrintPreview();
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Yazdırma işlemi sırasında hata oluştu:\n{ex.Message}");
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Excel Dosyası (*.xlsx)|*.xlsx|PDF Dosyası (*.pdf)|*.pdf";
                    sfd.FileName = $"NotListesi_{DateTime.Now:yyyyMMdd_HHmmss}";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        if (sfd.FilterIndex == 1) // Excel
                        {
                            gridViewNotlar.ExportToXlsx(sfd.FileName);
                            MessageHelper.BilgiMesaji("Notlar Excel dosyasına aktarıldı!");
                        }
                        else // PDF
                        {
                            gridViewNotlar.ExportToPdf(sfd.FileName);
                            MessageHelper.BilgiMesaji("Notlar PDF dosyasına aktarıldı!");
                        }

                        // Dosyayı aç
                        if (MessageHelper.OnayMesaji("Dosya açılsın mı?"))
                        {
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = sfd.FileName,
                                UseShellExecute = true
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Dışa aktarma sırasında hata oluştu:\n{ex.Message}");
            }
        }
    }
}
