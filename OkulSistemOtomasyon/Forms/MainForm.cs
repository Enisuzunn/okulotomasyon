using DevExpress.XtraBars.Ribbon;
using OkulSistemOtomasyon.Helpers;

namespace OkulSistemOtomasyon.Forms
{
    public partial class MainForm : RibbonForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (SessionManager.AktifKullanici != null)
            {
                barStaticItemKullanici.Caption = $"{SessionManager.AktifKullanici.TamAd} ({SessionManager.AktifKullanici.Rol})";
            }

            // Admin değilse kullanıcı yönetimini gizle
            if (!SessionManager.AdminMi())
            {
                btnKullaniciYonetim.Enabled = false;
            }
        }

        private void AcForm<T>() where T : Form, new()
        {
            // Aynı tipte form açıksa onu getir
            foreach (Form childForm in MdiChildren)
            {
                if (childForm is T)
                {
                    childForm.Activate();
                    return;
                }
            }

            // Yoksa yeni form aç
            T form = new T();
            form.MdiParent = this;
            form.Show();
        }

        private void btnOgrenciYonetim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AcForm<OgrenciForm>();
        }

        private void btnAkademisyenYonetim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AcForm<AkademisyenForm>();
        }

        private void btnBolumYonetim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AcForm<BolumForm>();
        }

        private void btnDersYonetim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AcForm<DersForm>();
        }

        private void btnNotYonetim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AcForm<NotForm>();
        }

        private void btnKullaniciYonetim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AcForm<KullaniciForm>();
        }

        private void btnCikis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageHelper.OnayMesaji("Programdan çıkmak istediğinize emin misiniz?", "Çıkış"))
            {
                Application.Exit();
            }
        }
    }
}
