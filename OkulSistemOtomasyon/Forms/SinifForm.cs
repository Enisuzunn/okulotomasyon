using DevExpress.XtraEditors;
using OkulSistemOtomasyon.Data;
using OkulSistemOtomasyon.Helpers;
using OkulSistemOtomasyon.Models;

namespace OkulSistemOtomasyon.Forms
{
    public partial class SinifForm : XtraForm
    {
        private OkulDbContext _context;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.TextEdit txtSinifAdi;
        private DevExpress.XtraEditors.SpinEdit spinSeviye;
        private DevExpress.XtraEditors.TextEdit txtSube;
        private DevExpress.XtraEditors.SpinEdit spinKontenjan;
        private DevExpress.XtraEditors.TextEdit txtDersYili;
        private DevExpress.XtraEditors.CheckEdit checkAktif;
        private DevExpress.XtraEditors.SimpleButton btnYeni;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.SimpleButton btnGuncelle;
        private DevExpress.XtraEditors.SimpleButton btnSil;

        public SinifForm()
        {
            InitializeComponent();
            _context = new OkulDbContext();
            this.Text = "Sınıf Yönetimi";
        }

        private void InitializeComponent()
        {
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtSinifAdi = new DevExpress.XtraEditors.TextEdit();
            this.spinSeviye = new DevExpress.XtraEditors.SpinEdit();
            this.txtSube = new DevExpress.XtraEditors.TextEdit();
            this.spinKontenjan = new DevExpress.XtraEditors.SpinEdit();
            this.txtDersYili = new DevExpress.XtraEditors.TextEdit();
            this.checkAktif = new DevExpress.XtraEditors.CheckEdit();
            this.btnYeni = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.btnGuncelle = new DevExpress.XtraEditors.SimpleButton();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();

            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSinifAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinSeviye.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSube.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinKontenjan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDersYili.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkAktif.Properties)).BeginInit();
            this.SuspendLayout();

            // gridControl1
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 200);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(900, 350);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gridView1 });

            // gridView1
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);

            // Form controls layout
            this.txtSinifAdi.Location = new System.Drawing.Point(120, 20);
            this.txtSinifAdi.Name = "txtSinifAdi";
            this.txtSinifAdi.Size = new System.Drawing.Size(200, 20);
            this.txtSinifAdi.TabIndex = 1;

            this.spinSeviye.Location = new System.Drawing.Point(120, 50);
            this.spinSeviye.Name = "spinSeviye";
            this.spinSeviye.Properties.MaxValue = new decimal(new int[] { 12, 0, 0, 0 });
            this.spinSeviye.Properties.MinValue = new decimal(new int[] { 1, 0, 0, 0 });
            this.spinSeviye.Size = new System.Drawing.Size(200, 20);
            this.spinSeviye.TabIndex = 2;

            this.txtSube.Location = new System.Drawing.Point(120, 80);
            this.txtSube.Name = "txtSube";
            this.txtSube.Properties.MaxLength = 10;
            this.txtSube.Size = new System.Drawing.Size(200, 20);
            this.txtSube.TabIndex = 3;

            this.spinKontenjan.Location = new System.Drawing.Point(120, 110);
            this.spinKontenjan.Name = "spinKontenjan";
            this.spinKontenjan.Properties.MaxValue = new decimal(new int[] { 50, 0, 0, 0 });
            this.spinKontenjan.Properties.MinValue = new decimal(new int[] { 10, 0, 0, 0 });
            this.spinKontenjan.Size = new System.Drawing.Size(200, 20);
            this.spinKontenjan.TabIndex = 4;

            this.txtDersYili.Location = new System.Drawing.Point(500, 20);
            this.txtDersYili.Name = "txtDersYili";
            this.txtDersYili.Size = new System.Drawing.Size(200, 20);
            this.txtDersYili.TabIndex = 5;

            this.checkAktif.Location = new System.Drawing.Point(500, 50);
            this.checkAktif.Name = "checkAktif";
            this.checkAktif.Properties.Caption = "Aktif";
            this.checkAktif.Size = new System.Drawing.Size(200, 20);
            this.checkAktif.TabIndex = 6;

            this.btnYeni.Location = new System.Drawing.Point(750, 20);
            this.btnYeni.Name = "btnYeni";
            this.btnYeni.Size = new System.Drawing.Size(120, 30);
            this.btnYeni.TabIndex = 7;
            this.btnYeni.Text = "Yeni";
            this.btnYeni.Click += new System.EventHandler(this.btnYeni_Click);

            this.btnKaydet.Location = new System.Drawing.Point(750, 55);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(120, 30);
            this.btnKaydet.TabIndex = 8;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);

            this.btnGuncelle.Location = new System.Drawing.Point(750, 90);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(120, 30);
            this.btnGuncelle.TabIndex = 9;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);

            this.btnSil.Location = new System.Drawing.Point(750, 125);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(120, 30);
            this.btnSil.TabIndex = 10;
            this.btnSil.Text = "Sil";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);

            // SinifForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.txtSinifAdi);
            this.Controls.Add(this.spinSeviye);
            this.Controls.Add(this.txtSube);
            this.Controls.Add(this.spinKontenjan);
            this.Controls.Add(this.txtDersYili);
            this.Controls.Add(this.checkAktif);
            this.Controls.Add(this.btnYeni);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnSil);
            this.Name = "SinifForm";
            this.Text = "Sınıf Yönetimi";
            this.Load += new System.EventHandler(this.SinifForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSinifAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinSeviye.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSube.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinKontenjan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDersYili.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkAktif.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        private void SinifForm_Load(object sender, EventArgs e)
        {
            VeriYukle();
            spinSeviye.EditValue = 9;
            spinKontenjan.EditValue = 30;
            txtDersYili.Text = "2024-2025";
            checkAktif.Checked = true;
        }

        private void VeriYukle()
        {
            try
            {
                var siniflar = _context.Siniflar
                    .Select(s => new
                    {
                        s.SinifId,
                        s.SinifAdi,
                        s.Seviye,
                        s.Sube,
                        s.Kontenjan,
                        s.DersYili,
                        s.Aktif,
                        OgrenciSayisi = s.Ogrenciler.Count(o => o.Aktif)
                    })
                    .ToList();

                gridControl1.DataSource = siniflar;
                gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Veri yüklenirken hata oluştu:\n{ex.Message}");
            }
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            txtSinifAdi.Text = string.Empty;
            spinSeviye.EditValue = 9;
            txtSube.Text = string.Empty;
            spinKontenjan.EditValue = 30;
            txtDersYili.Text = "2024-2025";
            checkAktif.Checked = true;
            txtSinifAdi.Focus();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSinifAdi.Text))
            {
                MessageHelper.UyariMesaji("Sınıf adı boş olamaz!");
                return;
            }

            try
            {
                var sinif = new Sinif
                {
                    SinifAdi = txtSinifAdi.Text.Trim(),
                    Seviye = Convert.ToInt32(spinSeviye.EditValue),
                    Sube = txtSube.Text.Trim(),
                    Kontenjan = Convert.ToInt32(spinKontenjan.EditValue),
                    DersYili = txtDersYili.Text.Trim(),
                    Aktif = checkAktif.Checked
                };

                _context.Siniflar.Add(sinif);
                _context.SaveChanges();

                MessageHelper.BasariMesaji("Sınıf başarıyla eklendi.");
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
                MessageHelper.UyariMesaji("Lütfen güncellenecek sınıfı seçin!");
                return;
            }

            try
            {
                var selectedRow = gridView1.GetFocusedRow() as dynamic;
                int sinifId = selectedRow.SinifId;

                var sinif = _context.Siniflar.Find(sinifId);
                if (sinif != null)
                {
                    sinif.SinifAdi = txtSinifAdi.Text.Trim();
                    sinif.Seviye = Convert.ToInt32(spinSeviye.EditValue);
                    sinif.Sube = txtSube.Text.Trim();
                    sinif.Kontenjan = Convert.ToInt32(spinKontenjan.EditValue);
                    sinif.DersYili = txtDersYili.Text.Trim();
                    sinif.Aktif = checkAktif.Checked;

                    _context.SaveChanges();
                    MessageHelper.BasariMesaji("Sınıf başarıyla güncellendi.");
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
                MessageHelper.UyariMesaji("Lütfen silinecek sınıfı seçin!");
                return;
            }

            var selectedRow = gridView1.GetFocusedRow() as dynamic;
            int sinifId = selectedRow.SinifId;

            MessageHelper.SilmeOnayMesaji(() =>
            {
                var sinif = _context.Siniflar.Find(sinifId);
                if (sinif != null)
                {
                    _context.Siniflar.Remove(sinif);
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
                int sinifId = selectedRow.SinifId;

                var sinif = _context.Siniflar.Find(sinifId);
                if (sinif != null)
                {
                    txtSinifAdi.Text = sinif.SinifAdi;
                    spinSeviye.EditValue = sinif.Seviye;
                    txtSube.Text = sinif.Sube;
                    spinKontenjan.EditValue = sinif.Kontenjan;
                    txtDersYili.Text = sinif.DersYili;
                    checkAktif.Checked = sinif.Aktif;
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
