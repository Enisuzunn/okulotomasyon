using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.EntityFrameworkCore;
using OkulSistemOtomasyon.Data;
using OkulSistemOtomasyon.Helpers;
using System.Data;

namespace OkulSistemOtomasyon.Forms
{
    public partial class OgrenciPanelForm : XtraForm
    {
        private int _ogrenciId;

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
        }

        private void OgrenciBilgileriniYukle()
        {
            try
            {
                using (var context = new OkulDbContext())
                {
                    var ogrenci = context.Ogrenciler
                        .Include(o => o.Bolum)
                        .FirstOrDefault(o => o.OgrenciId == _ogrenciId);

                    if (ogrenci != null)
                    {
                        lblOgrenciAd.Text = $"{ogrenci.Ad} {ogrenci.Soyad}";
                        lblOgrenciNo.Text = $"Öğrenci No: {ogrenci.OgrenciNo}";
                        lblBolum.Text = $"Bölüm: {ogrenci.Bolum?.BolumAdi ?? "Belirtilmemiş"}";
                        lblSinif.Text = $"Sınıf: {ogrenci.Sinif}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Öğrenci bilgileri yüklenirken hata oluştu:\n{ex.Message}");
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
                            durum = ort >= 60 ? "✅ Geçti" : "❌ Kaldı";

                            // GNO hesabı için
                            if (ort >= 60)
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

        private string HarfNotuHesapla(double ortalama)
        {
            if (ortalama >= 90) return "AA";
            if (ortalama >= 85) return "BA";
            if (ortalama >= 80) return "BB";
            if (ortalama >= 75) return "CB";
            if (ortalama >= 70) return "CC";
            if (ortalama >= 65) return "DC";
            if (ortalama >= 60) return "DD";
            if (ortalama >= 50) return "FD";
            return "FF";
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            NotlariYukle();
            MessageHelper.BilgiMesaji("Notlar başarıyla yenilendi!");
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
