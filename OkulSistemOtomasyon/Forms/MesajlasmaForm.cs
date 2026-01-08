using OkulSistemOtomasyon.Models;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using OkulSistemOtomasyon.Helpers;
using DevExpress.XtraLayout;
using OkulSistemOtomasyon.Services;

namespace OkulSistemOtomasyon.Forms
{
    public partial class MesajlasmaForm : XtraForm
    {
        private readonly Kullanici _aktifKullanici;
        private GridControl gridMesajlar;
        private GridView gridViewMesajlar;
        private SimpleButton btnYeniMesaj;
        private SimpleButton btnGelenKutusu;
        private SimpleButton btnGidenKutusu;
        private SimpleButton btnYenile;
        private LayoutControl layoutControl;
        
        private bool _gelenKutusuAktif = true;

        public MesajlasmaForm(Kullanici aktifKullanici)
        {
            InitializeComponent();
            _aktifKullanici = aktifKullanici;
            
            UIArayuzunuOlustur();
            VerileriYukle();
        }

        private void UIArayuzunuOlustur()
        {
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "✉️ Mesajlar - " + _aktifKullanici.TamAd;

            layoutControl = new LayoutControl { Dock = DockStyle.Fill };
            this.Controls.Add(layoutControl);

            // Butonlar
            btnYeniMesaj = new SimpleButton { Text = "✏️ Yeni Mesaj", Height = 40 };
            btnYeniMesaj.Appearance.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnYeniMesaj.Appearance.BackColor = Color.FromArgb(46, 204, 113);
            btnYeniMesaj.Click += BtnYeniMesaj_Click;

            btnGelenKutusu = new SimpleButton { Text = "📥 Gelen Kutusu", Height = 40 };
            btnGelenKutusu.Appearance.Font = new Font("Segoe UI", 10);
            btnGelenKutusu.Click += (s, e) => { _gelenKutusuAktif = true; VerileriYukle(); };

            btnGidenKutusu = new SimpleButton { Text = "📤 Giden Kutusu", Height = 40 };
            btnGidenKutusu.Appearance.Font = new Font("Segoe UI", 10);
            btnGidenKutusu.Click += (s, e) => { _gelenKutusuAktif = false; VerileriYukle(); };
            
            btnYenile = new SimpleButton { Text = "🔄 Yenile", Height = 40 };
            btnYenile.Click += (s, e) => VerileriYukle();

            // Grid
            gridMesajlar = new GridControl();
            gridViewMesajlar = new GridView(gridMesajlar);
            gridMesajlar.MainView = gridViewMesajlar;
            
            gridViewMesajlar.OptionsBehavior.Editable = false;
            gridViewMesajlar.OptionsView.ShowGroupPanel = false;
            gridViewMesajlar.RowClick += GridViewMesajlar_RowClick;
            gridViewMesajlar.RowStyle += GridViewMesajlar_RowStyle;

            // Layout
            layoutControl.AddItem(" ", btnYeniMesaj).TextVisible = false;
            
            var groupKutu = layoutControl.AddGroup();
            groupKutu.Text = "Kutular";
            groupKutu.GroupBordersVisible = false;
            groupKutu.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            
            layoutControl.AddItem(" ", btnGelenKutusu).TextVisible = false;
            layoutControl.AddItem(" ", btnGidenKutusu).TextVisible = false;
            layoutControl.AddItem(" ", btnYenile).TextVisible = false;
            
            LayoutControlItem itemGrid = layoutControl.AddItem(" ", gridMesajlar);
            itemGrid.TextVisible = false;
        }

        private void VerileriYukle()
        {
            var service = ServiceLocator.GetMesajService();
            IEnumerable<Mesaj> veri;

            if (_gelenKutusuAktif)
            {
                veri = service.GelenKutusuGetir(_aktifKullanici.KullaniciId);
                this.Text = "✉️ Gelen Kutusu - " + _aktifKullanici.TamAd;
                btnGelenKutusu.Appearance.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                btnGidenKutusu.Appearance.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            }
            else
            {
                veri = service.GidenKutusuGetir(_aktifKullanici.KullaniciId);
                this.Text = "📤 Giden Kutusu - " + _aktifKullanici.TamAd;
                btnGidenKutusu.Appearance.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                btnGelenKutusu.Appearance.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            }

            gridMesajlar.DataSource = veri.Select(m => new 
            {
                m.Id,
                Tarih = m.CreatedDate,
                kimden = m.Gonderici != null ? m.Gonderici.TamAd : "Bilinmiyor",
                kime = m.Alici != null ? m.Alici.TamAd : "Bilinmiyor",
                Konu = m.Konu,
                Icerik = m.Icerik,
                Okundu = m.Okundu
            }).ToList();
            
            gridViewMesajlar.Columns["Id"].Visible = false;
            gridViewMesajlar.Columns["Okundu"].Visible = false;
            gridViewMesajlar.Columns["Icerik"].Visible = false; // Detayda gösterelim
        }

        private void BtnYeniMesaj_Click(object sender, EventArgs e)
        {
            var form = new YeniMesajForm(_aktifKullanici);
            if (form.ShowDialog() == DialogResult.OK)
            {
                VerileriYukle();
            }
        }

        private void GridViewMesajlar_RowClick(object sender, RowClickEventArgs e)
        {
            // Mesaj detayını göster
            if (e.Clicks == 2) // Çift tıkla
            {
                var id = (int)gridViewMesajlar.GetRowCellValue(e.RowHandle, "Id");
                var service = ServiceLocator.GetMesajService();
                
                // Mesajı bul (repository'den tekrar çekmek gerekebilir detaylar için ama grid'de her şey var gibi)
                // Yine de Okundu yapmak için servise gitmek lazım
                if (_gelenKutusuAktif)
                {
                    service.OkunduIsaretle(id);
                }
                
                var konu = gridViewMesajlar.GetRowCellValue(e.RowHandle, "Konu").ToString();
                var icerik = gridViewMesajlar.GetRowCellValue(e.RowHandle, "Icerik").ToString();
                var kim = _gelenKutusuAktif ? 
                          "Kimden: " + gridViewMesajlar.GetRowCellValue(e.RowHandle, "kimden") : 
                          "Kime: " + gridViewMesajlar.GetRowCellValue(e.RowHandle, "kime");

                MessageBox.Show($"{kim}\n\nKonu: {konu}\n\nMesaj:\n{icerik}", "Mesaj Detayı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                if (_gelenKutusuAktif) VerileriYukle(); // Okundu bilgisi güncellensin
            }
        }

        private void GridViewMesajlar_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (_gelenKutusuAktif && e.RowHandle >= 0)
            {
                var okundu = (bool)gridViewMesajlar.GetRowCellValue(e.RowHandle, "Okundu");
                if (!okundu)
                {
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                    e.Appearance.BackColor = Color.FromArgb(236, 240, 241); // Hafif gri
                }
            }
        }
    }
}
