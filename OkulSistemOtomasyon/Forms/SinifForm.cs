using DevExpress.XtraEditors;

namespace OkulSistemOtomasyon.Forms
{
    public partial class SinifForm : XtraForm
    {
        public SinifForm()
        {
            InitializeComponent();
            this.Text = "Sınıf Yönetimi";
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // SinifForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Name = "SinifForm";
            this.Text = "Sınıf Yönetimi";
            this.Load += new System.EventHandler(this.SinifForm_Load);
            this.ResumeLayout(false);
        }

        private void SinifForm_Load(object sender, EventArgs e)
        {
            // Form yükleme işlemleri
        }
    }
}
