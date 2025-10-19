namespace OkulSistemOtomasyon.Forms
{
    partial class DersForm
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

            // txtDersAdi
            this.txtDersAdi.Location = new System.Drawing.Point(120, 20);
            this.txtDersAdi.Name = "txtDersAdi";
            this.txtDersAdi.Size = new System.Drawing.Size(250, 20);
            this.txtDersAdi.TabIndex = 1;

            // txtDersKodu
            this.txtDersKodu.Location = new System.Drawing.Point(120, 50);
            this.txtDersKodu.Name = "txtDersKodu";
            this.txtDersKodu.Size = new System.Drawing.Size(250, 20);
            this.txtDersKodu.TabIndex = 2;

            // spinHaftalikSaat
            this.spinHaftalikSaat.Location = new System.Drawing.Point(120, 80);
            this.spinHaftalikSaat.Name = "spinHaftalikSaat";
            this.spinHaftalikSaat.Properties.MaxValue = new decimal(new int[] { 20, 0, 0, 0 });
            this.spinHaftalikSaat.Properties.MinValue = new decimal(new int[] { 1, 0, 0, 0 });
            this.spinHaftalikSaat.Size = new System.Drawing.Size(250, 20);
            this.spinHaftalikSaat.TabIndex = 3;

            // lookUpSinif
            this.lookUpSinif.Location = new System.Drawing.Point(120, 110);
            this.lookUpSinif.Name = "lookUpSinif";
            this.lookUpSinif.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpSinif.Properties.NullText = "Sınıf Seçiniz";
            this.lookUpSinif.Size = new System.Drawing.Size(250, 20);
            this.lookUpSinif.TabIndex = 4;

            // lookUpOgretmen
            this.lookUpOgretmen.Location = new System.Drawing.Point(500, 20);
            this.lookUpOgretmen.Name = "lookUpOgretmen";
            this.lookUpOgretmen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpOgretmen.Properties.NullText = "Öğretmen Seçiniz";
            this.lookUpOgretmen.Size = new System.Drawing.Size(250, 20);
            this.lookUpOgretmen.TabIndex = 5;

            // cmbDonem
            this.cmbDonem.Location = new System.Drawing.Point(500, 50);
            this.cmbDonem.Name = "cmbDonem";
            this.cmbDonem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDonem.Properties.Items.AddRange(new object[] { "1. Dönem", "2. Dönem", "Yıllık" });
            this.cmbDonem.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbDonem.Size = new System.Drawing.Size(250, 20);
            this.cmbDonem.TabIndex = 6;

            // checkAktif
            this.checkAktif.Location = new System.Drawing.Point(500, 80);
            this.checkAktif.Name = "checkAktif";
            this.checkAktif.Properties.Caption = "Aktif";
            this.checkAktif.Size = new System.Drawing.Size(250, 20);
            this.checkAktif.TabIndex = 7;

            // btnYeni
            this.btnYeni.Location = new System.Drawing.Point(770, 20);
            this.btnYeni.Name = "btnYeni";
            this.btnYeni.Size = new System.Drawing.Size(100, 25);
            this.btnYeni.TabIndex = 8;
            this.btnYeni.Text = "Yeni";
            this.btnYeni.Click += new System.EventHandler(this.btnYeni_Click);

            // btnKaydet
            this.btnKaydet.Location = new System.Drawing.Point(770, 50);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(100, 25);
            this.btnKaydet.TabIndex = 9;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);

            // btnGuncelle
            this.btnGuncelle.Location = new System.Drawing.Point(770, 80);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(100, 25);
            this.btnGuncelle.TabIndex = 10;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);

            // btnSil
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
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.btnYeni);
            this.Controls.Add(this.checkAktif);
            this.Controls.Add(this.cmbDonem);
            this.Controls.Add(this.lookUpOgretmen);
            this.Controls.Add(this.lookUpSinif);
            this.Controls.Add(this.spinHaftalikSaat);
            this.Controls.Add(this.txtDersKodu);
            this.Controls.Add(this.txtDersAdi);
            this.Controls.Add(this.gridControl1);
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

        #endregion

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
    }
}
