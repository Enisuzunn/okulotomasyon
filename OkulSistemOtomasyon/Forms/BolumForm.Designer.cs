using DevExpress.XtraEditors;

namespace OkulSistemOtomasyon.Forms
{
    partial class BolumForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelControl1 = new DevExpress.XtraEditors.PanelControl();
            labelControl7 = new LabelControl();
            checkAktif = new CheckEdit();
            labelControl6 = new LabelControl();
            txtAkademikYil = new TextEdit();
            labelControl5 = new LabelControl();
            spinKontenjan = new SpinEdit();
            labelControl4 = new LabelControl();
            cmbOgretimTuru = new ComboBoxEdit();
            labelControl3 = new LabelControl();
            txtFakulte = new TextEdit();
            labelControl2 = new LabelControl();
            txtBolumKodu = new TextEdit();
            labelControl1 = new LabelControl();
            txtBolumAdi = new TextEdit();
            panelControl2 = new DevExpress.XtraEditors.PanelControl();
            btnSil = new SimpleButton();
            btnGuncelle = new SimpleButton();
            btnKaydet = new SimpleButton();
            btnYeni = new SimpleButton();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)panelControl1).BeginInit();
            panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)checkAktif.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAkademikYil.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)spinKontenjan.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmbOgretimTuru.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtFakulte.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtBolumKodu.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtBolumAdi.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelControl2).BeginInit();
            panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            SuspendLayout();
            // 
            // panelControl1
            // 
            panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panelControl1.Controls.Add(labelControl7);
            panelControl1.Controls.Add(checkAktif);
            panelControl1.Controls.Add(labelControl6);
            panelControl1.Controls.Add(txtAkademikYil);
            panelControl1.Controls.Add(labelControl5);
            panelControl1.Controls.Add(spinKontenjan);
            panelControl1.Controls.Add(labelControl4);
            panelControl1.Controls.Add(cmbOgretimTuru);
            panelControl1.Controls.Add(labelControl3);
            panelControl1.Controls.Add(txtFakulte);
            panelControl1.Controls.Add(labelControl2);
            panelControl1.Controls.Add(txtBolumKodu);
            panelControl1.Controls.Add(labelControl1);
            panelControl1.Controls.Add(txtBolumAdi);
            panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            panelControl1.Location = new System.Drawing.Point(0, 0);
            panelControl1.Name = "panelControl1";
            panelControl1.Size = new System.Drawing.Size(1000, 160);
            panelControl1.TabIndex = 0;
            // 
            // labelControl7
            // 
            labelControl7.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            labelControl7.Appearance.Options.UseFont = true;
            labelControl7.Location = new System.Drawing.Point(680, 85);
            labelControl7.Name = "labelControl7";
            labelControl7.Size = new System.Drawing.Size(31, 15);
            labelControl7.TabIndex = 13;
            labelControl7.Text = "Aktif:";
            // 
            // checkAktif
            // 
            checkAktif.Location = new System.Drawing.Point(680, 106);
            checkAktif.Name = "checkAktif";
            checkAktif.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            checkAktif.Properties.Appearance.Options.UseFont = true;
            checkAktif.Properties.Caption = "Aktif";
            checkAktif.Size = new System.Drawing.Size(280, 20);
            checkAktif.TabIndex = 12;
            // 
            // labelControl6
            // 
            labelControl6.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            labelControl6.Appearance.Options.UseFont = true;
            labelControl6.Location = new System.Drawing.Point(680, 20);
            labelControl6.Name = "labelControl6";
            labelControl6.Size = new System.Drawing.Size(72, 15);
            labelControl6.TabIndex = 11;
            labelControl6.Text = "Akademik Yıl:";
            // 
            // txtAkademikYil
            // 
            txtAkademikYil.Location = new System.Drawing.Point(680, 41);
            txtAkademikYil.Name = "txtAkademikYil";
            txtAkademikYil.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            txtAkademikYil.Properties.Appearance.Options.UseFont = true;
            txtAkademikYil.Size = new System.Drawing.Size(280, 22);
            txtAkademikYil.TabIndex = 10;
            // 
            // labelControl5
            // 
            labelControl5.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            labelControl5.Appearance.Options.UseFont = true;
            labelControl5.Location = new System.Drawing.Point(350, 85);
            labelControl5.Name = "labelControl5";
            labelControl5.Size = new System.Drawing.Size(60, 15);
            labelControl5.TabIndex = 9;
            labelControl5.Text = "Kontenjan:";
            // 
            // spinKontenjan
            // 
            spinKontenjan.EditValue = new decimal(new int[] { 80, 0, 0, 0 });
            spinKontenjan.Location = new System.Drawing.Point(350, 106);
            spinKontenjan.Name = "spinKontenjan";
            spinKontenjan.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            spinKontenjan.Properties.Appearance.Options.UseFont = true;
            spinKontenjan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            spinKontenjan.Properties.MaxValue = new decimal(new int[] { 500, 0, 0, 0 });
            spinKontenjan.Properties.MinValue = new decimal(new int[] { 1, 0, 0, 0 });
            spinKontenjan.Size = new System.Drawing.Size(280, 22);
            spinKontenjan.TabIndex = 8;
            // 
            // labelControl4
            // 
            labelControl4.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            labelControl4.Appearance.Options.UseFont = true;
            labelControl4.Location = new System.Drawing.Point(350, 20);
            labelControl4.Name = "labelControl4";
            labelControl4.Size = new System.Drawing.Size(73, 15);
            labelControl4.TabIndex = 7;
            labelControl4.Text = "Öğretim Türü:";
            // 
            // cmbOgretimTuru
            // 
            cmbOgretimTuru.Location = new System.Drawing.Point(350, 41);
            cmbOgretimTuru.Name = "cmbOgretimTuru";
            cmbOgretimTuru.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            cmbOgretimTuru.Properties.Appearance.Options.UseFont = true;
            cmbOgretimTuru.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbOgretimTuru.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cmbOgretimTuru.Size = new System.Drawing.Size(280, 22);
            cmbOgretimTuru.TabIndex = 6;
            // 
            // labelControl3
            // 
            labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            labelControl3.Appearance.Options.UseFont = true;
            labelControl3.Location = new System.Drawing.Point(20, 85);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new System.Drawing.Size(43, 15);
            labelControl3.TabIndex = 5;
            labelControl3.Text = "Fakülte:";
            // 
            // txtFakulte
            // 
            txtFakulte.Location = new System.Drawing.Point(20, 106);
            txtFakulte.Name = "txtFakulte";
            txtFakulte.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            txtFakulte.Properties.Appearance.Options.UseFont = true;
            txtFakulte.Size = new System.Drawing.Size(280, 22);
            txtFakulte.TabIndex = 4;
            // 
            // labelControl2
            // 
            labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            labelControl2.Appearance.Options.UseFont = true;
            labelControl2.Location = new System.Drawing.Point(350, 20);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new System.Drawing.Size(73, 15);
            labelControl2.TabIndex = 3;
            labelControl2.Text = "Bölüm Kodu:";
            labelControl2.Visible = false;
            // 
            // txtBolumKodu
            // 
            txtBolumKodu.Location = new System.Drawing.Point(350, 41);
            txtBolumKodu.Name = "txtBolumKodu";
            txtBolumKodu.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            txtBolumKodu.Properties.Appearance.Options.UseFont = true;
            txtBolumKodu.Size = new System.Drawing.Size(280, 22);
            txtBolumKodu.TabIndex = 2;
            txtBolumKodu.Visible = false;
            // 
            // labelControl1
            // 
            labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Location = new System.Drawing.Point(20, 20);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new System.Drawing.Size(64, 15);
            labelControl1.TabIndex = 1;
            labelControl1.Text = "Bölüm Adı:";
            // 
            // txtBolumAdi
            // 
            txtBolumAdi.Location = new System.Drawing.Point(20, 41);
            txtBolumAdi.Name = "txtBolumAdi";
            txtBolumAdi.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            txtBolumAdi.Properties.Appearance.Options.UseFont = true;
            txtBolumAdi.Size = new System.Drawing.Size(280, 22);
            txtBolumAdi.TabIndex = 0;
            // 
            // panelControl2
            // 
            panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panelControl2.Controls.Add(btnSil);
            panelControl2.Controls.Add(btnGuncelle);
            panelControl2.Controls.Add(btnKaydet);
            panelControl2.Controls.Add(btnYeni);
            panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            panelControl2.Location = new System.Drawing.Point(0, 160);
            panelControl2.Name = "panelControl2";
            panelControl2.Size = new System.Drawing.Size(1000, 60);
            panelControl2.TabIndex = 1;
            // 
            // btnSil
            // 
            btnSil.Appearance.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            btnSil.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            btnSil.Appearance.ForeColor = System.Drawing.Color.White;
            btnSil.Appearance.Options.UseBackColor = true;
            btnSil.Appearance.Options.UseFont = true;
            btnSil.Appearance.Options.UseForeColor = true;
            btnSil.Location = new System.Drawing.Point(490, 10);
            btnSil.Name = "btnSil";
            btnSil.Size = new System.Drawing.Size(140, 40);
            btnSil.TabIndex = 3;
            btnSil.Text = "SİL";
            btnSil.Click += btnSil_Click;
            // 
            // btnGuncelle
            // 
            btnGuncelle.Appearance.BackColor = System.Drawing.Color.FromArgb(255, 193, 7);
            btnGuncelle.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            btnGuncelle.Appearance.ForeColor = System.Drawing.Color.White;
            btnGuncelle.Appearance.Options.UseBackColor = true;
            btnGuncelle.Appearance.Options.UseFont = true;
            btnGuncelle.Appearance.Options.UseForeColor = true;
            btnGuncelle.Location = new System.Drawing.Point(330, 10);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new System.Drawing.Size(140, 40);
            btnGuncelle.TabIndex = 2;
            btnGuncelle.Text = "GÜNCELLE";
            btnGuncelle.Click += btnGuncelle_Click;
            // 
            // btnKaydet
            // 
            btnKaydet.Appearance.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            btnKaydet.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            btnKaydet.Appearance.ForeColor = System.Drawing.Color.White;
            btnKaydet.Appearance.Options.UseBackColor = true;
            btnKaydet.Appearance.Options.UseFont = true;
            btnKaydet.Appearance.Options.UseForeColor = true;
            btnKaydet.Location = new System.Drawing.Point(170, 10);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new System.Drawing.Size(140, 40);
            btnKaydet.TabIndex = 1;
            btnKaydet.Text = "KAYDET";
            btnKaydet.Click += btnKaydet_Click;
            // 
            // btnYeni
            // 
            btnYeni.Appearance.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            btnYeni.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            btnYeni.Appearance.ForeColor = System.Drawing.Color.White;
            btnYeni.Appearance.Options.UseBackColor = true;
            btnYeni.Appearance.Options.UseFont = true;
            btnYeni.Appearance.Options.UseForeColor = true;
            btnYeni.Location = new System.Drawing.Point(10, 10);
            btnYeni.Name = "btnYeni";
            btnYeni.Size = new System.Drawing.Size(140, 40);
            btnYeni.TabIndex = 0;
            btnYeni.Text = "YENİ";
            btnYeni.Click += btnYeni_Click;
            // 
            // gridControl1
            // 
            gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridControl1.Location = new System.Drawing.Point(0, 220);
            gridControl1.MainView = gridView1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new System.Drawing.Size(1000, 380);
            gridControl1.TabIndex = 2;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            // 
            // BolumForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1000, 600);
            Controls.Add(gridControl1);
            Controls.Add(panelControl2);
            Controls.Add(panelControl1);
            Name = "BolumForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Bölüm Yönetimi";
            Load += BolumForm_Load;
            ((System.ComponentModel.ISupportInitialize)panelControl1).EndInit();
            panelControl1.ResumeLayout(false);
            panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)checkAktif.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAkademikYil.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)spinKontenjan.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmbOgretimTuru.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtFakulte.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtBolumKodu.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtBolumAdi.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelControl2).EndInit();
            panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private LabelControl labelControl1;
        private TextEdit txtBolumAdi;
        private LabelControl labelControl2;
        private TextEdit txtBolumKodu;
        private LabelControl labelControl3;
        private TextEdit txtFakulte;
        private LabelControl labelControl4;
        private ComboBoxEdit cmbOgretimTuru;
        private LabelControl labelControl5;
        private SpinEdit spinKontenjan;
        private LabelControl labelControl6;
        private TextEdit txtAkademikYil;
        private LabelControl labelControl7;
        private CheckEdit checkAktif;
        private SimpleButton btnYeni;
        private SimpleButton btnKaydet;
        private SimpleButton btnGuncelle;
        private SimpleButton btnSil;
    }
}
