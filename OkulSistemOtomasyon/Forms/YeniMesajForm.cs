using OkulSistemOtomasyon.Models;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using OkulSistemOtomasyon.Helpers;

namespace OkulSistemOtomasyon.Forms
{
    public partial class YeniMesajForm : XtraForm
    {
        private readonly Kullanici _aktifKullanici;
        private LookUpEdit cmbKime;
        private TextEdit txtKonu;
        private MemoEdit txtIcerik;
        private SimpleButton btnGonder;
        private SimpleButton btnIptal;
        
        public YeniMesajForm(Kullanici aktifKullanici)
        {
            InitializeComponent();
            _aktifKullanici = aktifKullanici;
            UIArayuzunuOlustur();
            KullanicilariYukle();
        }

        private void UIArayuzunuOlustur()
        {
            this.Text = "Yeni Mesaj";
            this.Size = new Size(500, 450);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            var layout = new LayoutControl { Dock = DockStyle.Fill };
            this.Controls.Add(layout);

            cmbKime = new LookUpEdit();
            cmbKime.Properties.NullText = "Kişi Seçiniz...";
            
            txtKonu = new TextEdit();
            txtIcerik = new MemoEdit();
            
            btnGonder = new SimpleButton { Text = "Gönder", Height = 40 };
            btnGonder.Appearance.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnGonder.Appearance.BackColor = Color.FromArgb(46, 204, 113);
            btnGonder.Click += BtnGonder_Click;

            btnIptal = new SimpleButton { Text = "İptal", Height = 40 };
            btnIptal.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            layout.AddItem("Kime:", cmbKime);
            layout.AddItem("Konu:", txtKonu);
            LayoutControlItem itemIcerik = layout.AddItem("Mesaj:", txtIcerik);
            itemIcerik.TextLocation = DevExpress.Utils.Locations.Top;
            
            // Buton grubu
            var groupButonlar = layout.AddGroup();
            groupButonlar.GroupBordersVisible = false;
            groupButonlar.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            
            // Yan yana 2 buton
            layout.AddItem(" ", btnGonder);
            layout.AddItem(" ", btnIptal); 
        }

        private void KullanicilariYukle()
        {
            var service = ServiceLocator.GetMesajService();
            var kullanicilar = service.GonderilebilirKullanicilariGetir(_aktifKullanici.KullaniciId);
            
            cmbKime.Properties.DataSource = kullanicilar;
            cmbKime.Properties.DisplayMember = "TamAd";
            cmbKime.Properties.ValueMember = "KullaniciId";
            
            cmbKime.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TamAd", "Ad Soyad"));
            cmbKime.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RolAdi", "Rol"));
        }

        private void BtnGonder_Click(object sender, EventArgs e)
        {
            if (cmbKime.EditValue == null)
            {
                MessageBox.Show("Lütfen alıcı seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (string.IsNullOrWhiteSpace(txtKonu.Text) || string.IsNullOrWhiteSpace(txtIcerik.Text))
            {
                MessageBox.Show("Konu ve içerik boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int aliciId = (int)cmbKime.EditValue;
                var service = ServiceLocator.GetMesajService();
                service.MesajGonder(_aktifKullanici.KullaniciId, aliciId, txtKonu.Text, txtIcerik.Text);
                
                MessageBox.Show("Mesaj başarıyla gönderildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
