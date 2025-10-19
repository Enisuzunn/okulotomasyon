using DevExpress.XtraEditors;
using Microsoft.EntityFrameworkCore;
using OkulSistemOtomasyon.Data;
using OkulSistemOtomasyon.Helpers;
using OkulSistemOtomasyon.Models;

namespace OkulSistemOtomasyon.Forms
{
    public partial class DersForm : XtraForm
    {
        private OkulDbContext _context;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.TextEdit txtDersAdi;
        private DevExpress.XtraEditors.TextEdit txtDersKodu;
        private DevExpress.XtraEditors.SpinEdit spinHaftalikSaat;
        private DevExpress.XtraEditors.LookUpEdit lookUpSinif;
        private DevExpress.XtraEditors.LookUpEdit lookUpOgretmen;
        private DevExpress.XtraEditors.ComboBoxEdit cmbDonem;
        private DevExpress.XtraEditors.CheckEdit checkAktif;
        private DevExpress.XtraEditors.SimpleButton btnYeni;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.SimpleButton btnGuncelle;
        private DevExpress.XtraEditors.SimpleButton btnSil;

        public DersForm()
        {
            InitializeComponent();
            _context = new OkulDbContext();
            this.Text = "Ders Yönetimi";
        }

        private void InitializeComponent()
        {
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtDersAdi = new DevExpress.XtraEditors.TextEdit();
            this.txtDersKodu = new DevExpress.XtraEditors.TextEdit();
            this.spinHaftalikSaat = new DevExpress.XtraEditors.SpinEdit();
            this.lookUpSinif = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpOgretmen = new DevExpress.XtraEditors.LookUpEdit();
            this.cmbDonem = new DevExpress.XtraEditors.ComboBoxEdit();
            this.checkAktif = new DevExpress.XtraEditors.CheckEdit();
            this.btnYeni = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.btnGuncelle = new DevExpress.XtraEditors.SimpleButton();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();

            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDersAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDersKodu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinHaftalikSaat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpSinif.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpOgretmen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDonem.Properties)).BeginInit();
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

            // Controls
            this.txtDersAdi.Location = new System.Drawing.Point(120, 20);
            this.txtDersAdi.Name = "txtDersAdi";
            this.txtDersAdi.Size = new System.Drawing.Size(250, 20);
            this.txtDersAdi.TabIndex = 1;

            this.txtDersKodu.Location = new System.Drawing.Point(120, 50);
            this.txtDersKodu.Name = "txtDersKodu";
            this.txtDersKodu.Size = new System.Drawing.Size(250, 20);
            this.txtDersKodu.TabIndex = 2;

            this.spinHaftalikSaat.Location = new System.Drawing.Point(120, 80);
            this.spinHaftalikSaat.Name = "spinHaftalikSaat";
            this.spinHaftalikSaat.Properties.MaxValue = new decimal(new int[] { 20, 0, 0, 0 });
            this.spinHaftalikSaat.Properties.MinValue = new decimal(new int[] { 1, 0, 0, 0 });
            this.spinHaftalikSaat.Size = new System.Drawing.Size(250, 20);
            this.spinHaftalikSaat.TabIndex = 3;

            this.lookUpSinif.Location = new System.Drawing.Point(120, 110);
            this.lookUpSinif.Name = "lookUpSinif";
            this.lookUpSinif.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpSinif.Properties.NullText = "Sınıf Seçiniz";
            this.lookUpSinif.Size = new System.Drawing.Size(250, 20);
            this.lookUpSinif.TabIndex = 4;

            this.lookUpOgretmen.Location = new System.Drawing.Point(500, 20);
            this.lookUpOgretmen.Name = "lookUpOgretmen";
            this.lookUpOgretmen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpOgretmen.Properties.NullText = "Öğretmen Seçiniz";
            this.lookUpOgretmen.Size = new System.Drawing.Size(250, 20);
            this.lookUpOgretmen.TabIndex = 5;

            this.cmbDonem.Location = new System.Drawing.Point(500, 50);
            this.cmbDonem.Name = "cmbDonem";
            this.cmbDonem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDonem.Properties.Items.AddRange(new object[] { "1. Dönem", "2. Dönem", "Yıllık" });
            this.cmbDonem.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbDonem.Size = new System.Drawing.Size(250, 20);
            this.cmbDonem.TabIndex = 6;

            this.checkAktif.Location = new System.Drawing.Point(500, 80);
            this.checkAktif.Name = "checkAktif";
            this.checkAktif.Properties.Caption = "Aktif";
            this.checkAktif.Size = new System.Drawing.Size(250, 20);
            this.checkAktif.TabIndex = 7;

            this.btnYeni.Location = new System.Drawing.Point(770, 20);
            this.btnYeni.Name = "btnYeni";
            this.btnYeni.Size = new System.Drawing.Size(100, 25);
            this.btnYeni.TabIndex = 8;
            this.btnYeni.Text = "Yeni";
            this.btnYeni.Click += new System.EventHandler(this.btnYeni_Click);

            this.btnKaydet.Location = new System.Drawing.Point(770, 50);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(100, 25);
            this.btnKaydet.TabIndex = 9;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);

            this.btnGuncelle.Location = new System.Drawing.Point(770, 80);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(100, 25);
            this.btnGuncelle.TabIndex = 10;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);

            this.btnSil.Location = new System.Drawing.Point(770, 110);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(100, 25);
            this.btnSil.TabIndex = 11;
            this.btnSil.Text = "Sil";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);

            // DersForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.txtDersAdi);
            this.Controls.Add(this.txtDersKodu);
            this.Controls.Add(this.spinHaftalikSaat);
            this.Controls.Add(this.lookUpSinif);
            this.Controls.Add(this.lookUpOgretmen);
            this.Controls.Add(this.cmbDonem);
            this.Controls.Add(this.checkAktif);
            this.Controls.Add(this.btnYeni);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnSil);
            this.Name = "DersForm";
            this.Text = "Ders Yönetimi";
            this.Load += new System.EventHandler(this.DersForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDersAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDersKodu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinHaftalikSaat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpSinif.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpOgretmen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDonem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkAktif.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        private void DersForm_Load(object sender, EventArgs e)
        {
            VeriYukle();
            LookUpDoldur();
            spinHaftalikSaat.EditValue = 4;
            cmbDonem.SelectedIndex = 0; // "1. Dönem"
            checkAktif.Checked = true;
        }

        private void VeriYukle()
        {
            try
            {
                var dersler = _context.Dersler
                    .Include(d => d.Sinif)
                    .Include(d => d.Ogretmen)
                    .Select(d => new
                    {
                        d.DersId,
                        d.DersAdi,
                        d.DersKodu,
                        HaftalikSaat = d.HaftalikDersSaati,
                        SinifAdi = d.Sinif != null ? d.Sinif.SinifAdi : "",
                        OgretmenAdi = d.Ogretmen != null ? d.Ogretmen.Ad + " " + d.Ogretmen.Soyad : "",
                        Donem = d.DonemBilgisi,
                        d.Aktif
                    })
                    .ToList();

                gridControl1.DataSource = dersler;
                gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Veri yüklenirken hata oluştu:\n{ex.Message}");
            }
        }

        private void LookUpDoldur()
        {
            var siniflar = _context.Siniflar.Where(s => s.Aktif).Select(s => new { s.SinifId, s.SinifAdi }).ToList();
            lookUpSinif.Properties.DataSource = siniflar;
            lookUpSinif.Properties.DisplayMember = "SinifAdi";
            lookUpSinif.Properties.ValueMember = "SinifId";

            var ogretmenler = _context.Ogretmenler.Where(o => o.Aktif).Select(o => new { o.OgretmenId, TamAd = o.Ad + " " + o.Soyad }).ToList();
            lookUpOgretmen.Properties.DataSource = ogretmenler;
            lookUpOgretmen.Properties.DisplayMember = "TamAd";
            lookUpOgretmen.Properties.ValueMember = "OgretmenId";
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            txtDersAdi.Text = string.Empty;
            txtDersKodu.Text = string.Empty;
            spinHaftalikSaat.EditValue = 4;
            lookUpSinif.EditValue = null;
            lookUpOgretmen.EditValue = null;
            cmbDonem.SelectedIndex = 0;
            checkAktif.Checked = true;
            txtDersAdi.Focus();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDersAdi.Text))
            {
                MessageHelper.UyariMesaji("Ders adı boş olamaz!");
                return;
            }

            if (lookUpSinif.EditValue == null)
            {
                MessageHelper.UyariMesaji("Sınıf seçmelisiniz!");
                return;
            }

            try
            {
                var ders = new Ders
                {
                    DersAdi = txtDersAdi.Text.Trim(),
                    DersKodu = txtDersKodu.Text.Trim(),
                    HaftalikDersSaati = Convert.ToInt32(spinHaftalikSaat.EditValue),
                    SinifId = Convert.ToInt32(lookUpSinif.EditValue),
                    OgretmenId = lookUpOgretmen.EditValue != null ? Convert.ToInt32(lookUpOgretmen.EditValue) : (int?)null,
                    DonemBilgisi = cmbDonem.Text,
                    Aktif = checkAktif.Checked
                };

                _context.Dersler.Add(ders);
                _context.SaveChanges();

                MessageHelper.BasariMesaji("Ders başarıyla eklendi.");
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
                MessageHelper.UyariMesaji("Lütfen güncellenecek dersi seçin!");
                return;
            }

            try
            {
                var selectedRow = gridView1.GetFocusedRow() as dynamic;
                int dersId = selectedRow.DersId;

                var ders = _context.Dersler.Find(dersId);
                if (ders != null)
                {
                    ders.DersAdi = txtDersAdi.Text.Trim();
                    ders.DersKodu = txtDersKodu.Text.Trim();
                    ders.HaftalikDersSaati = Convert.ToInt32(spinHaftalikSaat.EditValue);
                    ders.SinifId = Convert.ToInt32(lookUpSinif.EditValue);
                    ders.OgretmenId = lookUpOgretmen.EditValue != null ? Convert.ToInt32(lookUpOgretmen.EditValue) : (int?)null;
                    ders.DonemBilgisi = cmbDonem.Text;
                    ders.Aktif = checkAktif.Checked;

                    _context.SaveChanges();
                    MessageHelper.BasariMesaji("Ders başarıyla güncellendi.");
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
                MessageHelper.UyariMesaji("Lütfen silinecek dersi seçin!");
                return;
            }

            var selectedRow = gridView1.GetFocusedRow() as dynamic;
            int dersId = selectedRow.DersId;

            MessageHelper.SilmeOnayMesaji(() =>
            {
                var ders = _context.Dersler.Find(dersId);
                if (ders != null)
                {
                    _context.Dersler.Remove(ders);
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
                int dersId = selectedRow.DersId;

                var ders = _context.Dersler.Find(dersId);
                if (ders != null)
                {
                    txtDersAdi.Text = ders.DersAdi;
                    txtDersKodu.Text = ders.DersKodu;
                    spinHaftalikSaat.EditValue = ders.HaftalikDersSaati;
                    lookUpSinif.EditValue = ders.SinifId;
                    lookUpOgretmen.EditValue = ders.OgretmenId;
                    cmbDonem.Text = ders.DonemBilgisi;
                    checkAktif.Checked = ders.Aktif;
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
