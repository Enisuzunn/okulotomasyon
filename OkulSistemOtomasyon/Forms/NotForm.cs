using DevExpress.XtraEditors;

namespace OkulSistemOtomasyon.Forms
{
    public partial class NotForm : XtraForm
    {
        public NotForm()
        {
            InitializeComponent();
            this.Text = "Not Girişi";
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // NotForm
            // 
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Name = "NotForm";
            this.Text = "Not Girişi";
            this.Load += new System.EventHandler(this.NotForm_Load);
            this.ResumeLayout(false);
        }

        private void NotForm_Load(object sender, EventArgs e)
        {
            // Form yükleme işlemleri
        }
    }
}
