using DevExpress.XtraEditors;
using OkulSistemOtomasyon.Data;
using OkulSistemOtomasyon.Helpers;
using OkulSistemOtomasyon.Models;

namespace OkulSistemOtomasyon.Forms
{
    public partial class KullaniciForm : XtraForm
    {
        private OkulDbContext _context;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.TextEdit txtKullaniciAdi;
        private DevExpress.XtraEditors.TextEdit txtSifre;
        private DevExpress.XtraEditors.TextEdit txtAd;
        private DevExpress.XtraEditors.TextEdit txtSoyad;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.ComboBoxEdit cmbRol;
        private DevExpress.XtraEditors.CheckEdit checkAktif;
        private DevExpress.XtraEditors.SimpleButton btnYeni;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.SimpleButton btnGuncelle;
        private DevExpress.XtraEditors.SimpleButton btnSil;

        public KullaniciForm()
        {
            InitializeComponent();
            _context = new OkulDbContext();
            this.Text = "Kullanıcı Yönetimi";
        }

        private void InitializeComponent()
        {
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtKullaniciAdi = new DevExpress.XtraEditors.TextEdit();
            this.txtSifre = new DevExpress.XtraEditors.TextEdit();
            this.txtAd = new DevExpress.XtraEditors.TextEdit();
            this.txtSoyad = new DevExpress.XtraEditors.TextEdit();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.cmbRol = new DevExpress.XtraEditors.ComboBoxEdit();
            this.checkAktif = new DevExpress.XtraEditors.CheckEdit();
            this.btnYeni = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.btnGuncelle = new DevExpress.XtraEditors.SimpleButton();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();

            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoyad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRol.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkAktif.Properties)).BeginInit();
            this.SuspendLayout();

            // gridControl1
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 200);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Size = new System.Drawing.Size(900, 300);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gridView1 });

            // gridView1
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);

            // Controls
            this.txtKullaniciAdi.Location = new System.Drawing.Point(120, 20);
            this.txtKullaniciAdi.Size = new System.Drawing.Size(200, 20);

            this.txtSifre.Location = new System.Drawing.Point(120, 50);
            this.txtSifre.Properties.PasswordChar = '●';
            this.txtSifre.Size = new System.Drawing.Size(200, 20);

            this.txtAd.Location = new System.Drawing.Point(120, 80);
            this.txtAd.Size = new System.Drawing.Size(200, 20);

            this.txtSoyad.Location = new System.Drawing.Point(120, 110);
            this.txtSoyad.Size = new System.Drawing.Size(200, 20);

            this.txtEmail.Location = new System.Drawing.Point(450, 20);
            this.txtEmail.Size = new System.Drawing.Size(250, 20);

            this.cmbRol.Location = new System.Drawing.Point(450, 50);
            this.cmbRol.Properties.Items.AddRange(new object[] { "Admin", "Ogretmen", "Kullanici" });
            this.cmbRol.Size = new System.Drawing.Size(250, 20);

            this.checkAktif.Location = new System.Drawing.Point(450, 80);
            this.checkAktif.Properties.Caption = "Aktif";
            this.checkAktif.Size = new System.Drawing.Size(250, 20);

            this.btnYeni.Location = new System.Drawing.Point(750, 20);
            this.btnYeni.Size = new System.Drawing.Size(120, 25);
            this.btnYeni.Text = "Yeni";
            this.btnYeni.Click += new System.EventHandler(this.btnYeni_Click);

            this.btnKaydet.Location = new System.Drawing.Point(750, 50);
            this.btnKaydet.Size = new System.Drawing.Size(120, 25);
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);

            this.btnGuncelle.Location = new System.Drawing.Point(750, 80);
            this.btnGuncelle.Size = new System.Drawing.Size(120, 25);
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);

            this.btnSil.Location = new System.Drawing.Point(750, 110);
            this.btnSil.Size = new System.Drawing.Size(120, 25);
            this.btnSil.Text = "Sil";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);

            // KullaniciForm
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.txtKullaniciAdi);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.txtAd);
            this.Controls.Add(this.txtSoyad);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.cmbRol);
            this.Controls.Add(this.checkAktif);
            this.Controls.Add(this.btnYeni);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnSil);
            this.Name = "KullaniciForm";
            this.Text = "Kullanıcı Yönetimi";
            this.Load += new System.EventHandler(this.KullaniciForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoyad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRol.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkAktif.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        private void KullaniciForm_Load(object sender, EventArgs e)
        {
            VeriYukle();
            cmbRol.SelectedIndex = 2; // Kullanici
            checkAktif.Checked = true;
        }

        private void VeriYukle()
        {
            try
            {
                var kullanicilar = _context.Kullanicilar
                    .Select(k => new
                    {
                        k.KullaniciId,
                        k.KullaniciAdi,
                        k.Ad,
                        k.Soyad,
                        k.Email,
                        k.Rol,
                        k.OlusturmaTarihi,
                        k.SonGirisTarihi,
                        k.Aktif
                    })
                    .ToList();

                gridControl1.DataSource = kullanicilar;
                gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Veri yüklenirken hata oluştu:\n{ex.Message}");
            }
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            txtKullaniciAdi.Text = string.Empty;
            txtSifre.Text = string.Empty;
            txtAd.Text = string.Empty;
            txtSoyad.Text = string.Empty;
            txtEmail.Text = string.Empty;
            cmbRol.SelectedIndex = 2;
            checkAktif.Checked = true;
            txtKullaniciAdi.Focus();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) || string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                MessageHelper.UyariMesaji("Kullanıcı adı ve şifre boş olamaz!");
                return;
            }

            try
            {
                // Rol dönüşümü
                KullaniciRolu secilenRol = cmbRol.Text switch
                {
                    "Admin" => KullaniciRolu.Admin,
                    "Akademisyen" => KullaniciRolu.Akademisyen,
                    "Öğrenci" => KullaniciRolu.Ogrenci,
                    _ => KullaniciRolu.Ogrenci
                };

                var kullanici = new Kullanici
                {
                    KullaniciAdi = txtKullaniciAdi.Text.Trim(),
                    Sifre = txtSifre.Text, // Gerçek uygulamada hash'lenmiş olmalı
                    Ad = txtAd.Text.Trim(),
                    Soyad = txtSoyad.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Rol = secilenRol,
                    Aktif = checkAktif.Checked,
                    OlusturmaTarihi = DateTime.Now
                };

                _context.Kullanicilar.Add(kullanici);
                _context.SaveChanges();

                MessageHelper.BasariMesaji("Kullanıcı başarıyla eklendi.");
                VeriYukle();
                btnYeni_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Kayıt sırasında hata oluştu:\n{ex.Message}");
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
            {
                MessageHelper.UyariMesaji("Lütfen güncellenecek kullanıcıyı seçin!");
                return;
            }

            try
            {
                var selectedRow = gridView1.GetFocusedRow() as dynamic;
                int kullaniciId = selectedRow.KullaniciId;

                var kullanici = _context.Kullanicilar.Find(kullaniciId);
                if (kullanici != null)
                {
                    // Rol dönüşümü
                    KullaniciRolu secilenRol = cmbRol.Text switch
                    {
                        "Admin" => KullaniciRolu.Admin,
                        "Akademisyen" => KullaniciRolu.Akademisyen,
                        "Öğrenci" => KullaniciRolu.Ogrenci,
                        _ => KullaniciRolu.Ogrenci
                    };

                    kullanici.KullaniciAdi = txtKullaniciAdi.Text.Trim();
                    if (!string.IsNullOrWhiteSpace(txtSifre.Text))
                        kullanici.Sifre = txtSifre.Text;
                    kullanici.Ad = txtAd.Text.Trim();
                    kullanici.Soyad = txtSoyad.Text.Trim();
                    kullanici.Email = txtEmail.Text.Trim();
                    kullanici.Rol = secilenRol;
                    kullanici.Aktif = checkAktif.Checked;

                    _context.SaveChanges();
                    MessageHelper.BasariMesaji("Kullanıcı başarıyla güncellendi.");
                    VeriYukle();
                }
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Güncelleme sırasında hata oluştu:\n{ex.Message}");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
            {
                MessageHelper.UyariMesaji("Lütfen silinecek kullanıcıyı seçin!");
                return;
            }

            var selectedRow = gridView1.GetFocusedRow() as dynamic;
            int kullaniciId = selectedRow.KullaniciId;

            if (kullaniciId == 1)
            {
                MessageHelper.UyariMesaji("Varsayılan admin kullanıcısı silinemez!");
                return;
            }

            MessageHelper.SilmeOnayMesaji(() =>
            {
                var kullanici = _context.Kullanicilar.Find(kullaniciId);
                if (kullanici != null)
                {
                    _context.Kullanicilar.Remove(kullanici);
                    _context.SaveChanges();
                    VeriYukle();
                    btnYeni_Click(null, null);
                }
            });
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.GetFocusedRow() == null) return;

            try
            {
                var selectedRow = gridView1.GetFocusedRow() as dynamic;
                int kullaniciId = selectedRow.KullaniciId;

                var kullanici = _context.Kullanicilar.Find(kullaniciId);
                if (kullanici != null)
                {
                    txtKullaniciAdi.Text = kullanici.KullaniciAdi;
                    txtSifre.Text = string.Empty; // Güvenlik için şifreyi gösterme
                    txtAd.Text = kullanici.Ad;
                    txtSoyad.Text = kullanici.Soyad;
                    txtEmail.Text = kullanici.Email;
                    // Enum'u string'e çevir
                    cmbRol.Text = kullanici.Rol switch
                    {
                        KullaniciRolu.Admin => "Admin",
                        KullaniciRolu.Akademisyen => "Akademisyen",
                        KullaniciRolu.Ogrenci => "Öğrenci",
                        _ => "Öğrenci"
                    };
                    checkAktif.Checked = kullanici.Aktif;
                }
            }
            catch { }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _context?.Dispose();
            base.OnFormClosing(e);
        }
    }
}
