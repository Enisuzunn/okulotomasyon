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
            System.Windows.Forms.Label lblKredi;
            System.Windows.Forms.Label lblAKTS;
            System.Windows.Forms.Label lblBolum;
            System.Windows.Forms.Label lblAkademisyen;
            System.Windows.Forms.Label lblDonem;

            panelTop = new System.Windows.Forms.Panel();
            lblDersAdi = new System.Windows.Forms.Label();
            lblDersKodu = new System.Windows.Forms.Label();
            lblKredi = new System.Windows.Forms.Label();
            lblAKTS = new System.Windows.Forms.Label();
            lblBolum = new System.Windows.Forms.Label();
            lblAkademisyen = new System.Windows.Forms.Label();
            lblDonem = new System.Windows.Forms.Label();

            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtDersAdi = new DevExpress.XtraEditors.TextEdit();
            this.txtDersKodu = new DevExpress.XtraEditors.TextEdit();
            this.spinKredi = new DevExpress.XtraEditors.SpinEdit();
            this.spinAKTS = new DevExpress.XtraEditors.SpinEdit();
            this.lookUpBolum = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpAkademisyen = new DevExpress.XtraEditors.LookUpEdit();
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
            ((System.ComponentModel.ISupportInitialize)(this.spinKredi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinAKTS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpBolum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpAkademisyen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDonem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkAktif.Properties)).BeginInit();
            this.SuspendLayout();

            // panelTop
            panelTop.Controls.Add(lblDersAdi);
            panelTop.Controls.Add(this.txtDersAdi);
            panelTop.Controls.Add(lblDersKodu);
            panelTop.Controls.Add(this.txtDersKodu);
            panelTop.Controls.Add(lblKredi);
            panelTop.Controls.Add(this.spinKredi);
            panelTop.Controls.Add(lblAKTS);
            panelTop.Controls.Add(this.spinAKTS);
            panelTop.Controls.Add(lblBolum);
            panelTop.Controls.Add(this.lookUpBolum);
            panelTop.Controls.Add(lblAkademisyen);
            panelTop.Controls.Add(this.lookUpAkademisyen);
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

            // lblKredi
            lblKredi.AutoSize = true;
            lblKredi.Location = new System.Drawing.Point(20, 85);
            lblKredi.Name = "lblKredi";
            lblKredi.Size = new System.Drawing.Size(80, 13);
            lblKredi.TabIndex = 2;
            lblKredi.Text = "Kredi:";

            // spinKredi
            this.spinKredi.Location = new System.Drawing.Point(120, 82);
            this.spinKredi.Name = "spinKredi";
            this.spinKredi.Properties.MaxValue = new decimal(new int[] { 10, 0, 0, 0 });
            this.spinKredi.Properties.MinValue = new decimal(new int[] { 1, 0, 0, 0 });
            this.spinKredi.Size = new System.Drawing.Size(280, 20);
            this.spinKredi.TabIndex = 2;

            // lblAKTS
            lblAKTS.AutoSize = true;
            lblAKTS.Location = new System.Drawing.Point(440, 85);
            lblAKTS.Name = "lblAKTS";
            lblAKTS.Size = new System.Drawing.Size(80, 13);
            lblAKTS.TabIndex = 7;
            lblAKTS.Text = "AKTS:";

            // spinAKTS
            this.spinAKTS.Location = new System.Drawing.Point(540, 82);
            this.spinAKTS.Name = "spinAKTS";
            this.spinAKTS.Properties.MaxValue = new decimal(new int[] { 15, 0, 0, 0 });
            this.spinAKTS.Properties.MinValue = new decimal(new int[] { 1, 0, 0, 0 });
            this.spinAKTS.Size = new System.Drawing.Size(280, 20);
            this.spinAKTS.TabIndex = 6;

            // lblBolum
            lblBolum.AutoSize = true;
            lblBolum.Location = new System.Drawing.Point(20, 115);
            lblBolum.Name = "lblBolum";
            lblBolum.Size = new System.Drawing.Size(80, 13);
            lblBolum.TabIndex = 3;
            lblBolum.Text = "Bölüm:";

            // lookUpBolum
            this.lookUpBolum.Location = new System.Drawing.Point(120, 112);
            this.lookUpBolum.Name = "lookUpBolum";
            this.lookUpBolum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpBolum.Properties.NullText = "Bölüm Seçiniz";
            this.lookUpBolum.Size = new System.Drawing.Size(280, 20);
            this.lookUpBolum.TabIndex = 3;
            this.lookUpBolum.EditValueChanged += new System.EventHandler(this.lookUpBolum_EditValueChanged);

            // lblAkademisyen
            lblAkademisyen.AutoSize = true;
            lblAkademisyen.Location = new System.Drawing.Point(440, 25);
            lblAkademisyen.Name = "lblAkademisyen";
            lblAkademisyen.Size = new System.Drawing.Size(80, 13);
            lblAkademisyen.TabIndex = 4;
            lblAkademisyen.Text = "Akademisyen:";

            // lookUpAkademisyen
            this.lookUpAkademisyen.Location = new System.Drawing.Point(540, 22);
            this.lookUpAkademisyen.Name = "lookUpAkademisyen";
            this.lookUpAkademisyen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpAkademisyen.Properties.NullText = "Akademisyen Seçiniz";
            this.lookUpAkademisyen.Size = new System.Drawing.Size(280, 20);
            this.lookUpAkademisyen.TabIndex = 4;

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
            this.cmbDonem.Properties.Items.AddRange(new object[] { "Güz Dönemi", "Bahar Dönemi", "Yaz Okulu" });
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
            ((System.ComponentModel.ISupportInitialize)(this.spinKredi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinAKTS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpBolum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpAkademisyen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDonem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkAktif.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.TextEdit txtDersAdi;
        private DevExpress.XtraEditors.TextEdit txtDersKodu;
        private DevExpress.XtraEditors.SpinEdit spinKredi;
        private DevExpress.XtraEditors.SpinEdit spinAKTS;
        private DevExpress.XtraEditors.LookUpEdit lookUpBolum;
        private DevExpress.XtraEditors.LookUpEdit lookUpAkademisyen;
        private DevExpress.XtraEditors.ComboBoxEdit cmbDonem;
        private DevExpress.XtraEditors.CheckEdit checkAktif;
        private DevExpress.XtraEditors.SimpleButton btnYeni;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.SimpleButton btnGuncelle;
        private DevExpress.XtraEditors.SimpleButton btnSil;
    }
}
