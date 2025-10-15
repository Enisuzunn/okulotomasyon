using DevExpress.XtraEditors;

namespace OkulSistemOtomasyon.Forms
{
    public partial class OgretmenForm : XtraForm
    {
        public OgretmenForm()
        {
            InitializeComponent();
            this.Text = "Öğretmen Yönetimi";
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // OgretmenForm
            // 
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Name = "OgretmenForm";
            this.Text = "Öğretmen Yönetimi";
            this.Load += new System.EventHandler(this.OgretmenForm_Load);
            this.ResumeLayout(false);
        }

        private void OgretmenForm_Load(object sender, EventArgs e)
        {
            // Form yükleme işlemleri
        }
    }
}
