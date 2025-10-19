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
            System.Windows.Forms.Panel panelTop;
            System.Windows.Forms.Label lblDersAdi;
            System.Windows.Forms.Label lblDersKodu;
            System.Windows.Forms.Label lblHaftalikSaat;
            System.Windows.Forms.Label lblSinif;
            System.Windows.Forms.Label lblOgretmen;
            System.Windows.Forms.Label lblDonem;

            panelTop = new System.Windows.Forms.Panel();
            lblDersAdi = new System.Windows.Forms.Label();
            lblDersKodu = new System.Windows.Forms.Label();
            lblHaftalikSaat = new System.Windows.Forms.Label();
            lblSinif = new System.Windows.Forms.Label();
            lblOgretmen = new System.Windows.Forms.Label();
            lblDonem = new System.Windows.Forms.Label();

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

            panelTop.SuspendLayout();
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

            // panelTop
            panelTop.Controls.Add(lblDersAdi);
            panelTop.Controls.Add(this.txtDersAdi);
            panelTop.Controls.Add(lblDersKodu);
            panelTop.Controls.Add(this.txtDersKodu);
            panelTop.Controls.Add(lblHaftalikSaat);
            panelTop.Controls.Add(this.spinHaftalikSaat);
            panelTop.Controls.Add(lblSinif);
            panelTop.Controls.Add(this.lookUpSinif);
            panelTop.Controls.Add(lblOgretmen);
            panelTop.Controls.Add(this.lookUpOgretmen);
            panelTop.Controls.Add(lblDonem);
            panelTop.Controls.Add(this.cmbDonem);
            panelTop.Controls.Add(this.checkAktif);
            panelTop.Controls.Add(this.btnYeni);
            panelTop.Controls.Add(this.btnKaydet);
            panelTop.Controls.Add(this.btnGuncelle);
            panelTop.Controls.Add(this.btnSil);
            panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelTop.Location = new System.Drawing.Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new System.Drawing.Size(1000, 180);
            panelTop.TabIndex = 0;
            panelTop.BackColor = System.Drawing.Color.White;
            panelTop.Padding = new System.Windows.Forms.Padding(10);

            // lblDersAdi
            lblDersAdi.AutoSize = true;
            lblDersAdi.Location = new System.Drawing.Point(20, 25);
            lblDersAdi.Name = "lblDersAdi";
            lblDersAdi.Size = new System.Drawing.Size(80, 13);
            lblDersAdi.TabIndex = 0;
            lblDersAdi.Text = "Ders Adı:";

            // txtDersAdi
            this.txtDersAdi.Location = new System.Drawing.Point(120, 22);
            this.txtDersAdi.Name = "txtDersAdi";
            this.txtDersAdi.Size = new System.Drawing.Size(280, 20);
            this.txtDersAdi.TabIndex = 0;

            // lblDersKodu
            lblDersKodu.AutoSize = true;
            lblDersKodu.Location = new System.Drawing.Point(20, 55);
            lblDersKodu.Name = "lblDersKodu";
            lblDersKodu.Size = new System.Drawing.Size(80, 13);
            lblDersKodu.TabIndex = 1;
            lblDersKodu.Text = "Ders Kodu:";

            // txtDersKodu
            this.txtDersKodu.Location = new System.Drawing.Point(120, 52);
            this.txtDersKodu.Name = "txtDersKodu";
            this.txtDersKodu.Size = new System.Drawing.Size(280, 20);
            this.txtDersKodu.TabIndex = 1;

            // lblHaftalikSaat
            lblHaftalikSaat.AutoSize = true;
            lblHaftalikSaat.Location = new System.Drawing.Point(20, 85);
            lblHaftalikSaat.Name = "lblHaftalikSaat";
            lblHaftalikSaat.Size = new System.Drawing.Size(80, 13);
            lblHaftalikSaat.TabIndex = 2;
            lblHaftalikSaat.Text = "Haftalık Saat:";

            // spinHaftalikSaat
            this.spinHaftalikSaat.Location = new System.Drawing.Point(120, 82);
            this.spinHaftalikSaat.Name = "spinHaftalikSaat";
            this.spinHaftalikSaat.Properties.MaxValue = new decimal(new int[] { 20, 0, 0, 0 });
            this.spinHaftalikSaat.Properties.MinValue = new decimal(new int[] { 1, 0, 0, 0 });
            this.spinHaftalikSaat.Size = new System.Drawing.Size(280, 20);
            this.spinHaftalikSaat.TabIndex = 2;

            // lblSinif
            lblSinif.AutoSize = true;
            lblSinif.Location = new System.Drawing.Point(20, 115);
            lblSinif.Name = "lblSinif";
            lblSinif.Size = new System.Drawing.Size(80, 13);
            lblSinif.TabIndex = 3;
            lblSinif.Text = "Sınıf:";

            // lookUpSinif
            this.lookUpSinif.Location = new System.Drawing.Point(120, 112);
            this.lookUpSinif.Name = "lookUpSinif";
            this.lookUpSinif.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpSinif.Properties.NullText = "Sınıf Seçiniz";
            this.lookUpSinif.Size = new System.Drawing.Size(280, 20);
            this.lookUpSinif.TabIndex = 3;

            // lblOgretmen
            lblOgretmen.AutoSize = true;
            lblOgretmen.Location = new System.Drawing.Point(440, 25);
            lblOgretmen.Name = "lblOgretmen";
            lblOgretmen.Size = new System.Drawing.Size(80, 13);
            lblOgretmen.TabIndex = 4;
            lblOgretmen.Text = "Öğretmen:";

            // lookUpOgretmen
            this.lookUpOgretmen.Location = new System.Drawing.Point(540, 22);
            this.lookUpOgretmen.Name = "lookUpOgretmen";
            this.lookUpOgretmen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpOgretmen.Properties.NullText = "Öğretmen Seçiniz";
            this.lookUpOgretmen.Size = new System.Drawing.Size(280, 20);
            this.lookUpOgretmen.TabIndex = 4;

            // lblDonem
            lblDonem.AutoSize = true;
            lblDonem.Location = new System.Drawing.Point(440, 55);
            lblDonem.Name = "lblDonem";
            lblDonem.Size = new System.Drawing.Size(80, 13);
            lblDonem.TabIndex = 5;
            lblDonem.Text = "Dönem:";

            // cmbDonem
            this.cmbDonem.Location = new System.Drawing.Point(540, 52);
            this.cmbDonem.Name = "cmbDonem";
            this.cmbDonem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDonem.Properties.Items.AddRange(new object[] { "1. Dönem", "2. Dönem", "Yıllık" });
            this.cmbDonem.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbDonem.Size = new System.Drawing.Size(280, 20);
            this.cmbDonem.TabIndex = 5;

            // checkAktif
            this.checkAktif.Location = new System.Drawing.Point(540, 82);
            this.checkAktif.Name = "checkAktif";
            this.checkAktif.Properties.Caption = "Aktif";
            this.checkAktif.Size = new System.Drawing.Size(280, 20);
            this.checkAktif.TabIndex = 6;

            // btnYeni
            this.btnYeni.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnYeni.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnYeni.Appearance.Options.UseBackColor = true;
            this.btnYeni.Appearance.Options.UseForeColor = true;
            this.btnYeni.Location = new System.Drawing.Point(860, 20);
            this.btnYeni.Name = "btnYeni";
            this.btnYeni.Size = new System.Drawing.Size(120, 32);
            this.btnYeni.TabIndex = 7;
            this.btnYeni.Text = "Yeni";
            this.btnYeni.Click += new System.EventHandler(this.btnYeni_Click);

            // btnKaydet
            this.btnKaydet.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnKaydet.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnKaydet.Appearance.Options.UseBackColor = true;
            this.btnKaydet.Appearance.Options.UseForeColor = true;
            this.btnKaydet.Location = new System.Drawing.Point(860, 58);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(120, 32);
            this.btnKaydet.TabIndex = 8;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);

            // btnGuncelle
            this.btnGuncelle.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnGuncelle.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnGuncelle.Appearance.Options.UseBackColor = true;
            this.btnGuncelle.Appearance.Options.UseForeColor = true;
            this.btnGuncelle.Location = new System.Drawing.Point(860, 96);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(120, 32);
            this.btnGuncelle.TabIndex = 9;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);

            // btnSil
            this.btnSil.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnSil.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSil.Appearance.Options.UseBackColor = true;
            this.btnSil.Appearance.Options.UseForeColor = true;
            this.btnSil.Location = new System.Drawing.Point(860, 134);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(120, 32);
            this.btnSil.TabIndex = 10;
            this.btnSil.Text = "Sil";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);

            // gridControl1
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 180);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1000, 420);
            this.gridControl1.TabIndex = 11;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gridView1 });

            // gridView1
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);

            // DersForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(panelTop);
            this.Name = "DersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ders Yönetimi";
            this.Load += new System.EventHandler(this.DersForm_Load);

            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
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
