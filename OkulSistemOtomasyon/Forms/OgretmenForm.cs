using DevExpress.XtraEditors;
using Microsoft.EntityFrameworkCore;
using OkulSistemOtomasyon.Data;
using OkulSistemOtomasyon.Helpers;
using OkulSistemOtomasyon.Models;

namespace OkulSistemOtomasyon.Forms
{
    public partial class OgretmenForm : XtraForm
    {
        private OkulDbContext _context;

        public OgretmenForm()
        {
            InitializeComponent();
            _context = new OkulDbContext();
            this.Text = "Öğretmen Yönetimi";
        }

        private void InitializeComponent()
        {
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtAd = new DevExpress.XtraEditors.TextEdit();
            this.txtSoyad = new DevExpress.XtraEditors.TextEdit();
            this.txtTC = new DevExpress.XtraEditors.TextEdit();
            this.dateDogumTarihi = new DevExpress.XtraEditors.DateEdit();
            this.txtTelefon = new DevExpress.XtraEditors.TextEdit();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.txtBrans = new DevExpress.XtraEditors.TextEdit();
            this.dateIseGiris = new DevExpress.XtraEditors.DateEdit();
            this.txtAdres = new DevExpress.XtraEditors.MemoEdit();
            this.checkAktif = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnYeni = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.btnGuncelle = new DevExpress.XtraEditors.SimpleButton();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoyad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDogumTarihi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDogumTarihi.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBrans.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateIseGiris.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateIseGiris.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdres.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkAktif.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();

            // gridControl1
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 250);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1000, 350);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gridView1});

            // gridView1
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);

            // panelControl1
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1000, 250);
            this.panelControl1.TabIndex = 0;

            // groupControl1
            this.groupControl1.Controls.Add(this.layoutControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(2, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(846, 246);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Öğretmen Bilgileri";

            // layoutControl1
            this.layoutControl1.Controls.Add(this.txtAd);
            this.layoutControl1.Controls.Add(this.txtSoyad);
            this.layoutControl1.Controls.Add(this.txtTC);
            this.layoutControl1.Controls.Add(this.dateDogumTarihi);
            this.layoutControl1.Controls.Add(this.txtTelefon);
            this.layoutControl1.Controls.Add(this.txtEmail);
            this.layoutControl1.Controls.Add(this.txtBrans);
            this.layoutControl1.Controls.Add(this.dateIseGiris);
            this.layoutControl1.Controls.Add(this.txtAdres);
            this.layoutControl1.Controls.Add(this.checkAktif);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 23);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(842, 221);
            this.layoutControl1.TabIndex = 0;

            // txtAd
            this.txtAd.Location = new System.Drawing.Point(97, 12);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(733, 20);
            this.txtAd.StyleController = this.layoutControl1;
            this.txtAd.TabIndex = 4;

            // txtSoyad
            this.txtSoyad.Location = new System.Drawing.Point(97, 36);
            this.txtSoyad.Name = "txtSoyad";
            this.txtSoyad.Size = new System.Drawing.Size(303, 20);
            this.txtSoyad.StyleController = this.layoutControl1;
            this.txtSoyad.TabIndex = 5;

            // txtTC
            this.txtTC.Location = new System.Drawing.Point(97, 60);
            this.txtTC.Name = "txtTC";
            this.txtTC.Properties.MaxLength = 11;
            this.txtTC.Size = new System.Drawing.Size(303, 20);
            this.txtTC.StyleController = this.layoutControl1;
            this.txtTC.TabIndex = 6;

            // dateDogumTarihi
            this.dateDogumTarihi.EditValue = null;
            this.dateDogumTarihi.Location = new System.Drawing.Point(97, 84);
            this.dateDogumTarihi.Name = "dateDogumTarihi";
            this.dateDogumTarihi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateDogumTarihi.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateDogumTarihi.Size = new System.Drawing.Size(303, 20);
            this.dateDogumTarihi.StyleController = this.layoutControl1;
            this.dateDogumTarihi.TabIndex = 7;

            // txtTelefon
            this.txtTelefon.Location = new System.Drawing.Point(489, 36);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(341, 20);
            this.txtTelefon.StyleController = this.layoutControl1;
            this.txtTelefon.TabIndex = 8;

            // txtEmail
            this.txtEmail.Location = new System.Drawing.Point(489, 60);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(341, 20);
            this.txtEmail.StyleController = this.layoutControl1;
            this.txtEmail.TabIndex = 9;

            // txtBrans
            this.txtBrans.Location = new System.Drawing.Point(489, 84);
            this.txtBrans.Name = "txtBrans";
            this.txtBrans.Size = new System.Drawing.Size(341, 20);
            this.txtBrans.StyleController = this.layoutControl1;
            this.txtBrans.TabIndex = 10;

            // dateIseGiris
            this.dateIseGiris.EditValue = null;
            this.dateIseGiris.Location = new System.Drawing.Point(97, 108);
            this.dateIseGiris.Name = "dateIseGiris";
            this.dateIseGiris.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateIseGiris.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateIseGiris.Size = new System.Drawing.Size(303, 20);
            this.dateIseGiris.StyleController = this.layoutControl1;
            this.dateIseGiris.TabIndex = 11;

            // txtAdres
            this.txtAdres.Location = new System.Drawing.Point(97, 132);
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.Size = new System.Drawing.Size(733, 50);
            this.txtAdres.StyleController = this.layoutControl1;
            this.txtAdres.TabIndex = 12;

            // checkAktif
            this.checkAktif.Location = new System.Drawing.Point(489, 108);
            this.checkAktif.Name = "checkAktif";
            this.checkAktif.Properties.Caption = "Aktif";
            this.checkAktif.Size = new System.Drawing.Size(341, 20);
            this.checkAktif.StyleController = this.layoutControl1;
            this.checkAktif.TabIndex = 13;

            // layoutControlGroup1
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem3, this.layoutControlItem4,
            this.layoutControlItem5, this.layoutControlItem6, this.layoutControlItem7, this.layoutControlItem8,
            this.layoutControlItem9, this.layoutControlItem10});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(842, 194);
            this.layoutControlGroup1.TextVisible = false;

            // layoutControlItem1 - Ad
            this.layoutControlItem1.Control = this.txtAd;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(822, 24);
            this.layoutControlItem1.Text = "Ad:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(73, 13);

            // layoutControlItem2 - Soyad
            this.layoutControlItem2.Control = this.txtSoyad;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(392, 24);
            this.layoutControlItem2.Text = "Soyad:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(73, 13);

            // layoutControlItem3 - TC
            this.layoutControlItem3.Control = this.txtTC;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(392, 24);
            this.layoutControlItem3.Text = "TC Kimlik No:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(73, 13);

            // layoutControlItem4 - Doğum Tarihi
            this.layoutControlItem4.Control = this.dateDogumTarihi;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(392, 24);
            this.layoutControlItem4.Text = "Doğum Tarihi:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(73, 13);

            // layoutControlItem5 - Telefon
            this.layoutControlItem5.Control = this.txtTelefon;
            this.layoutControlItem5.Location = new System.Drawing.Point(392, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(430, 24);
            this.layoutControlItem5.Text = "Telefon:";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(73, 13);

            // layoutControlItem6 - Email
            this.layoutControlItem6.Control = this.txtEmail;
            this.layoutControlItem6.Location = new System.Drawing.Point(392, 48);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(430, 24);
            this.layoutControlItem6.Text = "E-mail:";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(73, 13);

            // layoutControlItem7 - Branş
            this.layoutControlItem7.Control = this.txtBrans;
            this.layoutControlItem7.Location = new System.Drawing.Point(392, 72);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(430, 24);
            this.layoutControlItem7.Text = "Branş:";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(73, 13);

            // layoutControlItem8 - İşe Giriş Tarihi
            this.layoutControlItem8.Control = this.dateIseGiris;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(392, 24);
            this.layoutControlItem8.Text = "İşe Giriş:";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(73, 13);

            // layoutControlItem9 - Adres
            this.layoutControlItem9.Control = this.txtAdres;
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(822, 54);
            this.layoutControlItem9.Text = "Adres:";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(73, 13);

            // layoutControlItem10 - Aktif
            this.layoutControlItem10.Control = this.checkAktif;
            this.layoutControlItem10.Location = new System.Drawing.Point(392, 96);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(430, 24);
            this.layoutControlItem10.Text = "Durum:";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(73, 13);

            // panelControl2 - Buttons
            this.panelControl2.Controls.Add(this.btnYeni);
            this.panelControl2.Controls.Add(this.btnKaydet);
            this.panelControl2.Controls.Add(this.btnGuncelle);
            this.panelControl2.Controls.Add(this.btnSil);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl2.Location = new System.Drawing.Point(848, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(150, 246);
            this.panelControl2.TabIndex = 0;

            // btnYeni
            this.btnYeni.Location = new System.Drawing.Point(5, 5);
            this.btnYeni.Name = "btnYeni";
            this.btnYeni.Size = new System.Drawing.Size(140, 40);
            this.btnYeni.TabIndex = 0;
            this.btnYeni.Text = "Yeni";
            this.btnYeni.Click += new System.EventHandler(this.btnYeni_Click);

            // btnKaydet
            this.btnKaydet.Location = new System.Drawing.Point(5, 50);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(140, 40);
            this.btnKaydet.TabIndex = 1;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);

            // btnGuncelle
            this.btnGuncelle.Location = new System.Drawing.Point(5, 95);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(140, 40);
            this.btnGuncelle.TabIndex = 2;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);

            // btnSil
            this.btnSil.Location = new System.Drawing.Point(5, 140);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(140, 40);
            this.btnSil.TabIndex = 3;
            this.btnSil.Text = "Sil";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);

            // OgretmenForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "OgretmenForm";
            this.Text = "Öğretmen Yönetimi";
            this.Load += new System.EventHandler(this.OgretmenForm_Load);
            
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtAd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoyad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDogumTarihi.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDogumTarihi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBrans.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateIseGiris.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateIseGiris.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdres.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkAktif.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtAd;
        private DevExpress.XtraEditors.TextEdit txtSoyad;
        private DevExpress.XtraEditors.TextEdit txtTC;
        private DevExpress.XtraEditors.DateEdit dateDogumTarihi;
        private DevExpress.XtraEditors.TextEdit txtTelefon;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.TextEdit txtBrans;
        private DevExpress.XtraEditors.DateEdit dateIseGiris;
        private DevExpress.XtraEditors.MemoEdit txtAdres;
        private DevExpress.XtraEditors.CheckEdit checkAktif;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnYeni;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.SimpleButton btnGuncelle;
        private DevExpress.XtraEditors.SimpleButton btnSil;

        private void OgretmenForm_Load(object sender, EventArgs e)
        {
            VeriYukle();
        }

        private void VeriYukle()
        {
            try
            {
                var ogretmenler = _context.Ogretmenler
                    .Select(o => new
                    {
                        o.OgretmenId,
                        o.Ad,
                        o.Soyad,
                        o.TC,
                        o.DogumTarihi,
                        o.Telefon,
                        o.Email,
                        o.Brans,
                        o.IseGirisTarihi,
                        o.Aktif
                    })
                    .ToList();

                gridControl1.DataSource = ogretmenler;
                gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Veri yüklenirken hata oluştu:\n{ex.Message}");
            }
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            TemizleFormlar();
            txtAd.Focus();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (!FormuDogrula()) return;

            try
            {
                var ogretmen = new Ogretmen
                {
                    Ad = txtAd.Text.Trim(),
                    Soyad = txtSoyad.Text.Trim(),
                    TC = txtTC.Text.Trim(),
                    DogumTarihi = dateDogumTarihi.DateTime,
                    Telefon = txtTelefon.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Adres = txtAdres.Text.Trim(),
                    Brans = txtBrans.Text.Trim(),
                    IseGirisTarihi = dateIseGiris.DateTime,
                    Aktif = checkAktif.Checked
                };

                _context.Ogretmenler.Add(ogretmen);
                _context.SaveChanges();

                MessageHelper.BasariMesaji("Öğretmen başarıyla eklendi.");
                VeriYukle();
                TemizleFormlar();
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
                MessageHelper.UyariMesaji("Lütfen güncellenecek öğretmeni seçin!");
                return;
            }

            if (!FormuDogrula()) return;

            try
            {
                var selectedRow = gridView1.GetFocusedRow() as dynamic;
                int ogretmenId = selectedRow.OgretmenId;

                var ogretmen = _context.Ogretmenler.Find(ogretmenId);
                if (ogretmen != null)
                {
                    ogretmen.Ad = txtAd.Text.Trim();
                    ogretmen.Soyad = txtSoyad.Text.Trim();
                    ogretmen.TC = txtTC.Text.Trim();
                    ogretmen.DogumTarihi = dateDogumTarihi.DateTime;
                    ogretmen.Telefon = txtTelefon.Text.Trim();
                    ogretmen.Email = txtEmail.Text.Trim();
                    ogretmen.Adres = txtAdres.Text.Trim();
                    ogretmen.Brans = txtBrans.Text.Trim();
                    ogretmen.IseGirisTarihi = dateIseGiris.DateTime;
                    ogretmen.Aktif = checkAktif.Checked;

                    _context.SaveChanges();

                    MessageHelper.BasariMesaji("Öğretmen başarıyla güncellendi.");
                    VeriYukle();
                    TemizleFormlar();
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
                MessageHelper.UyariMesaji("Lütfen silinecek öğretmeni seçin!");
                return;
            }

            var selectedRow = gridView1.GetFocusedRow() as dynamic;
            int ogretmenId = selectedRow.OgretmenId;

            MessageHelper.SilmeOnayMesaji(() =>
            {
                var ogretmen = _context.Ogretmenler.Find(ogretmenId);
                if (ogretmen != null)
                {
                    _context.Ogretmenler.Remove(ogretmen);
                    _context.SaveChanges();
                    VeriYukle();
                    TemizleFormlar();
                }
            });
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.GetFocusedRow() == null) return;

            try
            {
                var selectedRow = gridView1.GetFocusedRow() as dynamic;
                int ogretmenId = selectedRow.OgretmenId;

                var ogretmen = _context.Ogretmenler.Find(ogretmenId);
                if (ogretmen != null)
                {
                    txtAd.Text = ogretmen.Ad;
                    txtSoyad.Text = ogretmen.Soyad;
                    txtTC.Text = ogretmen.TC;
                    dateDogumTarihi.DateTime = ogretmen.DogumTarihi;
                    txtTelefon.Text = ogretmen.Telefon;
                    txtEmail.Text = ogretmen.Email;
                    txtAdres.Text = ogretmen.Adres;
                    txtBrans.Text = ogretmen.Brans;
                    dateIseGiris.DateTime = ogretmen.IseGirisTarihi;
                    checkAktif.Checked = ogretmen.Aktif;
                }
            }
            catch (Exception ex)
            {
                MessageHelper.HataMesaji($"Veri okuma hatası:\n{ex.Message}");
            }
        }

        private bool FormuDogrula()
        {
            if (string.IsNullOrWhiteSpace(txtAd.Text))
            {
                MessageHelper.UyariMesaji("Ad alanı boş bırakılamaz!");
                txtAd.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSoyad.Text))
            {
                MessageHelper.UyariMesaji("Soyad alanı boş bırakılamaz!");
                txtSoyad.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTC.Text))
            {
                MessageHelper.UyariMesaji("TC Kimlik No boş bırakılamaz!");
                txtTC.Focus();
                return false;
            }

            if (!ValidationHelper.TCKimlikNoDogrula(txtTC.Text))
            {
                MessageHelper.UyariMesaji("Geçersiz TC Kimlik No!");
                txtTC.Focus();
                return false;
            }

            if (!string.IsNullOrEmpty(txtEmail.Text) && !ValidationHelper.EmailDogrula(txtEmail.Text))
            {
                MessageHelper.UyariMesaji("Geçersiz email adresi!");
                txtEmail.Focus();
                return false;
            }

            return true;
        }

        private void TemizleFormlar()
        {
            txtAd.Text = string.Empty;
            txtSoyad.Text = string.Empty;
            txtTC.Text = string.Empty;
            dateDogumTarihi.DateTime = DateTime.Now.AddYears(-30);
            txtTelefon.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAdres.Text = string.Empty;
            txtBrans.Text = string.Empty;
            dateIseGiris.DateTime = DateTime.Now;
            checkAktif.Checked = true;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _context?.Dispose();
            base.OnFormClosing(e);
        }
    }
}
