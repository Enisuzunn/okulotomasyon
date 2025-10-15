using DevExpress.XtraEditors;
using Microsoft.EntityFrameworkCore;
using OkulSistemOtomasyon.Data;
using OkulSistemOtomasyon.Helpers;
using OkulSistemOtomasyon.Models;

namespace OkulSistemOtomasyon.Forms
{
    public partial class NotForm : XtraForm
    {
        private OkulDbContext _context;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LookUpEdit lookUpOgrenci;
        private DevExpress.XtraEditors.LookUpEdit lookUpDers;
        private DevExpress.XtraEditors.SpinEdit spinVize;
        private DevExpress.XtraEditors.SpinEdit spinFinal;
        private DevExpress.XtraEditors.SpinEdit spinProje;
        private DevExpress.XtraEditors.SpinEdit spinButunleme;
        private DevExpress.XtraEditors.MemoEdit txtAciklama;
        private DevExpress.XtraEditors.SimpleButton btnYeni;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.SimpleButton btnGuncelle;
        private DevExpress.XtraEditors.SimpleButton btnSil;

        public NotForm()
        {
            InitializeComponent();
            _context = new OkulDbContext();
            this.Text = "Not Girişi";
        }

        private void InitializeComponent()
        {
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lookUpOgrenci = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpDers = new DevExpress.XtraEditors.LookUpEdit();
            this.spinVize = new DevExpress.XtraEditors.SpinEdit();
            this.spinFinal = new DevExpress.XtraEditors.SpinEdit();
            this.spinProje = new DevExpress.XtraEditors.SpinEdit();
            this.spinButunleme = new DevExpress.XtraEditors.SpinEdit();
            this.txtAciklama = new DevExpress.XtraEditors.MemoEdit();
            this.btnYeni = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.btnGuncelle = new DevExpress.XtraEditors.SimpleButton();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();

            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpOgrenci.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpDers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinVize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinFinal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinProje.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinButunleme.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).BeginInit();
            this.SuspendLayout();

            // gridControl1
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 220);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Size = new System.Drawing.Size(1000, 380);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gridView1 });

            // gridView1
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);

            // Controls
            this.lookUpOgrenci.Location = new System.Drawing.Point(120, 20);
            this.lookUpOgrenci.Name = "lookUpOgrenci";
            this.lookUpOgrenci.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpOgrenci.Properties.NullText = "Öğrenci Seçiniz";
            this.lookUpOgrenci.Size = new System.Drawing.Size(300, 20);
            this.lookUpOgrenci.TabIndex = 1;

            this.lookUpDers.Location = new System.Drawing.Point(120, 50);
            this.lookUpDers.Name = "lookUpDers";
            this.lookUpDers.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpDers.Properties.NullText = "Ders Seçiniz";
            this.lookUpDers.Size = new System.Drawing.Size(300, 20);
            this.lookUpDers.TabIndex = 2;

            this.spinVize.Location = new System.Drawing.Point(120, 80);
            this.spinVize.Name = "spinVize";
            this.spinVize.Properties.MaxValue = new decimal(new int[] { 100, 0, 0, 0 });
            this.spinVize.Properties.MinValue = new decimal(new int[] { 0, 0, 0, 0 });
            this.spinVize.Size = new System.Drawing.Size(100, 20);
            this.spinVize.TabIndex = 3;

            this.spinFinal.Location = new System.Drawing.Point(320, 80);
            this.spinFinal.Name = "spinFinal";
            this.spinFinal.Properties.MaxValue = new decimal(new int[] { 100, 0, 0, 0 });
            this.spinFinal.Properties.MinValue = new decimal(new int[] { 0, 0, 0, 0 });
            this.spinFinal.Size = new System.Drawing.Size(100, 20);
            this.spinFinal.TabIndex = 4;

            this.spinProje.Location = new System.Drawing.Point(120, 110);
            this.spinProje.Name = "spinProje";
            this.spinProje.Properties.MaxValue = new decimal(new int[] { 100, 0, 0, 0 });
            this.spinProje.Properties.MinValue = new decimal(new int[] { 0, 0, 0, 0 });
            this.spinProje.Size = new System.Drawing.Size(100, 20);
            this.spinProje.TabIndex = 5;

            this.spinButunleme.Location = new System.Drawing.Point(320, 110);
            this.spinButunleme.Name = "spinButunleme";
            this.spinButunleme.Properties.MaxValue = new decimal(new int[] { 100, 0, 0, 0 });
            this.spinButunleme.Properties.MinValue = new decimal(new int[] { 0, 0, 0, 0 });
            this.spinButunleme.Size = new System.Drawing.Size(100, 20);
            this.spinButunleme.TabIndex = 6;

            this.txtAciklama.Location = new System.Drawing.Point(120, 140);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(300, 60);
            this.txtAciklama.TabIndex = 7;

            this.btnYeni.Location = new System.Drawing.Point(500, 20);
            this.btnYeni.Size = new System.Drawing.Size(120, 30);
            this.btnYeni.Text = "Yeni";
            this.btnYeni.Click += new System.EventHandler(this.btnYeni_Click);

            this.btnKaydet.Location = new System.Drawing.Point(500, 55);
            this.btnKaydet.Size = new System.Drawing.Size(120, 30);
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);

            this.btnGuncelle.Location = new System.Drawing.Point(500, 90);
            this.btnGuncelle.Size = new System.Drawing.Size(120, 30);
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);

            this.btnSil.Location = new System.Drawing.Point(500, 125);
            this.btnSil.Size = new System.Drawing.Size(120, 30);
            this.btnSil.Text = "Sil";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);

            // NotForm
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.lookUpOgrenci);
            this.Controls.Add(this.lookUpDers);
            this.Controls.Add(this.spinVize);
            this.Controls.Add(this.spinFinal);
            this.Controls.Add(this.spinProje);
            this.Controls.Add(this.spinButunleme);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.btnYeni);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnSil);
            this.Name = "NotForm";
            this.Text = "Not Girişi";
            this.Load += new System.EventHandler(this.NotForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpOgrenci.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpDers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinVize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinFinal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinProje.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinButunleme.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        private void NotForm_Load(object sender, EventArgs e)
        {
            VeriYukle();
            LookUpDoldur();
        }

        private void VeriYukle()
        {
            try
            {
                var notlar = _context.OgrenciNotlar
                    .Include(n => n.Ogrenci)
                    .Include(n => n.Ders)
                    .Select(n => new
                    {
                        n.NotId,
                        OgrenciAdi = n.Ogrenci != null ? n.Ogrenci.Ad + " " + n.Ogrenci.Soyad : "",
                        DersAdi = n.Ders != null ? n.Ders.DersAdi : "",
                        n.Vize,
                        n.Final,
                        n.ProjeNotu,
                        n.Butunleme,
                        Ortalama = n.Ortalama,
                        HarfNotu = n.HarfNotu,
                        n.NotGirisTarihi
                    })
                    .ToList();

                gridControl1.DataSource = notlar;
                gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Veri yüklenirken hata oluştu:\n{ex.Message}");
            }
        }

        private void LookUpDoldur()
        {
            var ogrenciler = _context.Ogrenciler.Where(o => o.Aktif)
                .Select(o => new { o.OgrenciId, TamAd = o.Ad + " " + o.Soyad + " - " + o.Sinif.SinifAdi }).ToList();
            lookUpOgrenci.Properties.DataSource = ogrenciler;
            lookUpOgrenci.Properties.DisplayMember = "TamAd";
            lookUpOgrenci.Properties.ValueMember = "OgrenciId";

            var dersler = _context.Dersler.Where(d => d.Aktif).Select(d => new { d.DersId, d.DersAdi }).ToList();
            lookUpDers.Properties.DataSource = dersler;
            lookUpDers.Properties.DisplayMember = "DersAdi";
            lookUpDers.Properties.ValueMember = "DersId";
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            lookUpOgrenci.EditValue = null;
            lookUpDers.EditValue = null;
            spinVize.EditValue = 0;
            spinFinal.EditValue = 0;
            spinProje.EditValue = 0;
            spinButunleme.EditValue = 0;
            txtAciklama.Text = string.Empty;
            lookUpOgrenci.Focus();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (lookUpOgrenci.EditValue == null || lookUpDers.EditValue == null)
            {
                MessageHelper.UyariMesaji("Öğrenci ve ders seçmelisiniz!");
                return;
            }

            try
            {
                var not = new OgrenciNot
                {
                    OgrenciId = Convert.ToInt32(lookUpOgrenci.EditValue),
                    DersId = Convert.ToInt32(lookUpDers.EditValue),
                    Vize = spinVize.Value > 0 ? spinVize.Value : null,
                    Final = spinFinal.Value > 0 ? spinFinal.Value : null,
                    ProjeNotu = spinProje.Value > 0 ? spinProje.Value : null,
                    Butunleme = spinButunleme.Value > 0 ? spinButunleme.Value : null,
                    Aciklama = txtAciklama.Text.Trim(),
                    NotGirisTarihi = DateTime.Now
                };

                _context.OgrenciNotlar.Add(not);
                _context.SaveChanges();

                MessageHelper.BasariMesaji("Not başarıyla eklendi.");
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
                MessageHelper.UyariMesaji("Lütfen güncellenecek notu seçin!");
                return;
            }

            try
            {
                var selectedRow = gridView1.GetFocusedRow() as dynamic;
                int notId = selectedRow.NotId;

                var not = _context.OgrenciNotlar.Find(notId);
                if (not != null)
                {
                    not.OgrenciId = Convert.ToInt32(lookUpOgrenci.EditValue);
                    not.DersId = Convert.ToInt32(lookUpDers.EditValue);
                    not.Vize = spinVize.Value > 0 ? spinVize.Value : null;
                    not.Final = spinFinal.Value > 0 ? spinFinal.Value : null;
                    not.ProjeNotu = spinProje.Value > 0 ? spinProje.Value : null;
                    not.Butunleme = spinButunleme.Value > 0 ? spinButunleme.Value : null;
                    not.Aciklama = txtAciklama.Text.Trim();

                    _context.SaveChanges();
                    MessageHelper.BasariMesaji("Not başarıyla güncellendi.");
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
                MessageHelper.UyariMesaji("Lütfen silinecek notu seçin!");
                return;
            }

            var selectedRow = gridView1.GetFocusedRow() as dynamic;
            int notId = selectedRow.NotId;

            MessageHelper.SilmeOnayMesaji(() =>
            {
                var not = _context.OgrenciNotlar.Find(notId);
                if (not != null)
                {
                    _context.OgrenciNotlar.Remove(not);
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
                int notId = selectedRow.NotId;

                var not = _context.OgrenciNotlar.Find(notId);
                if (not != null)
                {
                    lookUpOgrenci.EditValue = not.OgrenciId;
                    lookUpDers.EditValue = not.DersId;
                    spinVize.EditValue = not.Vize ?? 0;
                    spinFinal.EditValue = not.Final ?? 0;
                    spinProje.EditValue = not.ProjeNotu ?? 0;
                    spinButunleme.EditValue = not.Butunleme ?? 0;
                    txtAciklama.Text = not.Aciklama;
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
