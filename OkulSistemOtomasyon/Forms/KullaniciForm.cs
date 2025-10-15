using DevExpress.XtraEditors;

namespace OkulSistemOtomasyon.Forms
{
    public partial class KullaniciForm : XtraForm
    {
        public KullaniciForm()
        {
            InitializeComponent();
            this.Text = "Kullanıcı Yönetimi";
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // KullaniciForm
            // 
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Name = "KullaniciForm";
            this.Text = "Kullanıcı Yönetimi";
            this.Load += new System.EventHandler(this.KullaniciForm_Load);
            this.ResumeLayout(false);
        }

        private void KullaniciForm_Load(object sender, EventArgs e)
        {
            // Form yükleme işlemleri
        }
    }
}
