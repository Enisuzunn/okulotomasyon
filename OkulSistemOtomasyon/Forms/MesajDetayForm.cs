using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace OkulSistemOtomasyon.Forms
{
    public partial class MesajDetayForm : XtraForm
    {
        private TextEdit txtKim;
        private TextEdit txtTarih;
        private TextEdit txtKonu;
        private MemoEdit txtIcerik;
        private SimpleButton btnKapat;

        public MesajDetayForm(string kim, string tarih, string konu, string icerik)
        {
            InitializeComponent();
            UIArayuzunuOlustur(kim, tarih, konu, icerik);
        }

        private void UIArayuzunuOlustur(string kim, string tarih, string konu, string icerik)
        {
            this.Text = "📄 Mesaj Detayı";
            this.Size = new Size(600, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            var layout = new LayoutControl { Dock = DockStyle.Fill };
            this.Controls.Add(layout);

            // Controls
            txtKim = new TextEdit { ReadOnly = true };
            txtKim.Text = kim;
            
            txtTarih = new TextEdit { ReadOnly = true };
            txtTarih.Text = tarih;

            txtKonu = new TextEdit { ReadOnly = true };
            txtKonu.Text = konu;
            txtKonu.Properties.Appearance.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            txtIcerik = new MemoEdit { ReadOnly = true };
            txtIcerik.Text = icerik;
            txtIcerik.Properties.ScrollBars = ScrollBars.Vertical;

            btnKapat = new SimpleButton { Text = "Kapat", Height = 40 };
            btnKapat.Click += (s, e) => this.Close();

            // Layout Items
            layout.AddItem("Tarih:", txtTarih);
            layout.AddItem("Kim:", txtKim);
            layout.AddItem("Konu:", txtKonu);
            
            LayoutControlItem itemIcerik = layout.AddItem("Mesaj:", txtIcerik);
            itemIcerik.TextLocation = DevExpress.Utils.Locations.Top;
            
            // Buton sağ alt köşe veya alt orta
            layout.AddItem(" ", btnKapat);
        }
    }
}
