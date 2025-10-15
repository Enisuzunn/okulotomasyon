using DevExpress.XtraEditors;

namespace OkulSistemOtomasyon.Forms
{
    public partial class DersForm : XtraForm
    {
        public DersForm()
        {
            InitializeComponent();
            this.Text = "Ders Yönetimi";
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DersForm
            // 
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.Name = "DersForm";
            this.Text = "Ders Yönetimi";
            this.Load += new System.EventHandler(this.DersForm_Load);
            this.ResumeLayout(false);
        }

        private void DersForm_Load(object sender, EventArgs e)
        {
            // Form yükleme işlemleri
        }
    }
}
