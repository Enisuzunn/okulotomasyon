using DevExpress.XtraEditors;
using OkulSistemOtomasyon.Data;
using OkulSistemOtomasyon.Helpers;
using OkulSistemOtomasyon.Models;

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
            _mevcutNot = _context.OgrenciNotlar
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

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (_mevcutNot == null)
                {
                    // Yeni not oluştur
                    _mevcutNot = new OgrenciNot
                    {
                        OgrenciId = _ogrenciId,
                        DersId = _dersId,
                        NotGirisTarihi = DateTime.Now
                    };
                    _context.OgrenciNotlar.Add(_mevcutNot);
                }

                // Notları güncelle
                _mevcutNot.Vize = spinVize.EditValue != null ? (decimal?)Convert.ToDecimal(spinVize.EditValue) : null;
                _mevcutNot.Final = spinFinal.EditValue != null ? (decimal?)Convert.ToDecimal(spinFinal.EditValue) : null;
                _mevcutNot.Butunleme = spinButunleme.EditValue != null ? (decimal?)Convert.ToDecimal(spinButunleme.EditValue) : null;
                _mevcutNot.ProjeNotu = spinProje.EditValue != null ? (decimal?)Convert.ToDecimal(spinProje.EditValue) : null;
                _mevcutNot.Aciklama = txtAciklama.Text.Trim();
                _mevcutNot.NotGirisTarihi = DateTime.Now;

                _context.SaveChanges();

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
