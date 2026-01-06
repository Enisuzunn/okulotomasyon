using DevExpress.XtraEditors;
using Microsoft.EntityFrameworkCore;
using OkulSistemOtomasyon.Data;
using OkulSistemOtomasyon.Helpers;
using OkulSistemOtomasyon.Models;
using OkulSistemOtomasyon.Services;

namespace OkulSistemOtomasyon.Forms
{
    public partial class NotGirisDialog : XtraForm
    {
        private readonly int _ogrenciId;
        private readonly int _dersId;
        private readonly OkulDbContext _context;
        private OgrenciNot _mevcutNot;

        public NotGirisDialog(int ogrenciId, int dersId)
        {
            InitializeComponent();
            _ogrenciId = ogrenciId;
            _dersId = dersId;
            _context = new OkulDbContext();

            this.Text = "Not Giriş / Güncelleme";
        }

        private void NotGirisDialog_Load(object sender, EventArgs e)
        {
            // Öğrenci ve ders bilgilerini göster
            var ogrenci = _context.Ogrenciler.Find(_ogrenciId);
            var ders = _context.Dersler.Find(_dersId);

            lblOgrenciBilgi.Text = $"Öğrenci: {ogrenci?.Ad} {ogrenci?.Soyad} ({ogrenci?.OgrenciNo})";
            lblDersBilgi.Text = $"Ders: {ders?.DersAdi} ({ders?.DersKodu})";

            // Mevcut notu yükle
            _mevcutNot = _context.OgrenciNotlari
                .FirstOrDefault(n => n.OgrenciId == _ogrenciId && n.DersId == _dersId);

            if (_mevcutNot != null)
            {
                spinVize.EditValue = _mevcutNot.Vize;
                spinFinal.EditValue = _mevcutNot.Final;
                spinButunleme.EditValue = _mevcutNot.Butunleme;
                spinProje.EditValue = _mevcutNot.ProjeNotu;
                txtAciklama.Text = _mevcutNot.Aciklama;
            }
        }

        private async void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                // Öğrenci ve ders bilgilerini al (mail için)
                var ogrenci = _context.Ogrenciler.Find(_ogrenciId);
                var ders = _context.Dersler.Include(d => d.Akademisyen).FirstOrDefault(d => d.DersId == _dersId);

                bool yeniNot = _mevcutNot == null;
                decimal? eskiVize = _mevcutNot?.Vize;
                decimal? eskiFinal = _mevcutNot?.Final;

                if (_mevcutNot == null)
                {
                    // Yeni not oluştur
                    _mevcutNot = new OgrenciNot
                    {
                        OgrenciId = _ogrenciId,
                        DersId = _dersId,
                        NotGirisTarihi = DateTime.Now
                    };
                    _context.OgrenciNotlari.Add(_mevcutNot);
                }

                // Notları güncelle
                _mevcutNot.Vize = spinVize.EditValue != null ? (decimal?)Convert.ToDecimal(spinVize.EditValue) : null;
                _mevcutNot.Final = spinFinal.EditValue != null ? (decimal?)Convert.ToDecimal(spinFinal.EditValue) : null;
                _mevcutNot.Butunleme = spinButunleme.EditValue != null ? (decimal?)Convert.ToDecimal(spinButunleme.EditValue) : null;
                _mevcutNot.ProjeNotu = spinProje.EditValue != null ? (decimal?)Convert.ToDecimal(spinProje.EditValue) : null;
                _mevcutNot.Aciklama = txtAciklama.Text.Trim();
                _mevcutNot.NotGirisTarihi = DateTime.Now;

                _context.SaveChanges();

                // 📧 Mail gönder (not değiştiyse veya yeni not ise)
                if (ogrenci != null && !string.IsNullOrEmpty(ogrenci.Email) && ders != null)
                {
                    var emailService = new EmailService();
                    string akademisyenAdi = ders.Akademisyen != null 
                        ? $"{ders.Akademisyen.Unvan} {ders.Akademisyen.Ad} {ders.Akademisyen.Soyad}"
                        : "Belirtilmemiş";

                    // Vize notu değiştiyse mail gönder
                    if (_mevcutNot.Vize.HasValue && (yeniNot || eskiVize != _mevcutNot.Vize))
                    {
                        await emailService.SendGradeNotificationAsync(
                            ogrenci.Email,
                            $"{ogrenci.Ad} {ogrenci.Soyad}",
                            ders.DersAdi,
                            "Vize",
                            _mevcutNot.Vize.Value,
                            akademisyenAdi
                        );
                    }

                    // Final notu değiştiyse mail gönder
                    if (_mevcutNot.Final.HasValue && (yeniNot || eskiFinal != _mevcutNot.Final))
                    {
                        await emailService.SendGradeNotificationAsync(
                            ogrenci.Email,
                            $"{ogrenci.Ad} {ogrenci.Soyad}",
                            ders.DersAdi,
                            "Final",
                            _mevcutNot.Final.Value,
                            akademisyenAdi
                        );
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Not kaydedilirken hata oluştu:\n{ex.Message}");
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _context?.Dispose();
            base.OnFormClosing(e);
        }
    }
}
