namespace OkulSistemOtomasyon.Forms
{
    partial class NotForm
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
            System.Windows.Forms.Label lblOgrenci;
            System.Windows.Forms.Label lblDers;
            System.Windows.Forms.Label lblVize;
            System.Windows.Forms.Label lblFinal;
            System.Windows.Forms.Label lblProje;
            System.Windows.Forms.Label lblButunleme;
            System.Windows.Forms.Label lblAciklama;
            System.Windows.Forms.Label lblNotBilgisi;

            panelTop = new System.Windows.Forms.Panel();
            lblOgrenci = new System.Windows.Forms.Label();
            lblDers = new System.Windows.Forms.Label();
            lblVize = new System.Windows.Forms.Label();
            lblFinal = new System.Windows.Forms.Label();
            lblProje = new System.Windows.Forms.Label();
            lblButunleme = new System.Windows.Forms.Label();
            lblAciklama = new System.Windows.Forms.Label();
            lblNotBilgisi = new System.Windows.Forms.Label();

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

            panelTop.SuspendLayout();
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

            // panelTop
            panelTop.Controls.Add(lblOgrenci);
            panelTop.Controls.Add(this.lookUpOgrenci);
            panelTop.Controls.Add(lblDers);
            panelTop.Controls.Add(this.lookUpDers);
            panelTop.Controls.Add(lblNotBilgisi);
            panelTop.Controls.Add(lblVize);
            panelTop.Controls.Add(this.spinVize);
            panelTop.Controls.Add(lblFinal);
            panelTop.Controls.Add(this.spinFinal);
            panelTop.Controls.Add(lblProje);
            panelTop.Controls.Add(this.spinProje);
            panelTop.Controls.Add(lblButunleme);
            panelTop.Controls.Add(this.spinButunleme);
            panelTop.Controls.Add(lblAciklama);
            panelTop.Controls.Add(this.txtAciklama);
            panelTop.Controls.Add(this.btnYeni);
            panelTop.Controls.Add(this.btnKaydet);
            panelTop.Controls.Add(this.btnGuncelle);
            panelTop.Controls.Add(this.btnSil);
            panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelTop.Location = new System.Drawing.Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new System.Drawing.Size(1100, 240);
            panelTop.TabIndex = 0;
            panelTop.BackColor = System.Drawing.Color.White;
            panelTop.Padding = new System.Windows.Forms.Padding(10);

            // lblOgrenci
            lblOgrenci.AutoSize = true;
            lblOgrenci.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblOgrenci.Location = new System.Drawing.Point(20, 25);
            lblOgrenci.Name = "lblOgrenci";
            lblOgrenci.Size = new System.Drawing.Size(80, 15);
            lblOgrenci.TabIndex = 0;
            lblOgrenci.Text = "Öğrenci:";

            // lookUpOgrenci
            this.lookUpOgrenci.Location = new System.Drawing.Point(120, 22);
            this.lookUpOgrenci.Name = "lookUpOgrenci";
            this.lookUpOgrenci.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpOgrenci.Properties.NullText = "Öğrenci Seçiniz";
            this.lookUpOgrenci.Size = new System.Drawing.Size(350, 20);
            this.lookUpOgrenci.TabIndex = 0;

            // lblDers
            lblDers.AutoSize = true;
            lblDers.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblDers.Location = new System.Drawing.Point(20, 55);
            lblDers.Name = "lblDers";
            lblDers.Size = new System.Drawing.Size(80, 15);
            lblDers.TabIndex = 1;
            lblDers.Text = "Ders:";

            // lookUpDers
            this.lookUpDers.Location = new System.Drawing.Point(120, 52);
            this.lookUpDers.Name = "lookUpDers";
            this.lookUpDers.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpDers.Properties.NullText = "Ders Seçiniz";
            this.lookUpDers.Size = new System.Drawing.Size(350, 20);
            this.lookUpDers.TabIndex = 1;

            // lblNotBilgisi
            lblNotBilgisi.AutoSize = true;
            lblNotBilgisi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblNotBilgisi.Location = new System.Drawing.Point(20, 90);
            lblNotBilgisi.Name = "lblNotBilgisi";
            lblNotBilgisi.Size = new System.Drawing.Size(200, 19);
            lblNotBilgisi.TabIndex = 2;
            lblNotBilgisi.Text = "Not Bilgileri (0-100 arası):";

            // lblVize
            lblVize.AutoSize = true;
            lblVize.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblVize.Location = new System.Drawing.Point(50, 125);
            lblVize.Name = "lblVize";
            lblVize.Size = new System.Drawing.Size(60, 15);
            lblVize.TabIndex = 3;
            lblVize.Text = "Vize (%40):";

            // spinVize
            this.spinVize.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            this.spinVize.Location = new System.Drawing.Point(120, 122);
            this.spinVize.Name = "spinVize";
            this.spinVize.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinVize.Properties.MaxValue = new decimal(new int[] { 100, 0, 0, 0 });
            this.spinVize.Properties.MinValue = new decimal(new int[] { 0, 0, 0, 0 });
            this.spinVize.Size = new System.Drawing.Size(120, 20);
            this.spinVize.TabIndex = 2;

            // lblFinal
            lblFinal.AutoSize = true;
            lblFinal.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblFinal.Location = new System.Drawing.Point(270, 125);
            lblFinal.Name = "lblFinal";
            lblFinal.Size = new System.Drawing.Size(65, 15);
            lblFinal.TabIndex = 4;
            lblFinal.Text = "Final (%60):";

            // spinFinal
            this.spinFinal.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            this.spinFinal.Location = new System.Drawing.Point(350, 122);
            this.spinFinal.Name = "spinFinal";
            this.spinFinal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinFinal.Properties.MaxValue = new decimal(new int[] { 100, 0, 0, 0 });
            this.spinFinal.Properties.MinValue = new decimal(new int[] { 0, 0, 0, 0 });
            this.spinFinal.Size = new System.Drawing.Size(120, 20);
            this.spinFinal.TabIndex = 3;

            // lblProje
            lblProje.AutoSize = true;
            lblProje.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblProje.Location = new System.Drawing.Point(50, 155);
            lblProje.Name = "lblProje";
            lblProje.Size = new System.Drawing.Size(60, 15);
            lblProje.TabIndex = 5;
            lblProje.Text = "Proje:";

            // spinProje
            this.spinProje.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            this.spinProje.Location = new System.Drawing.Point(120, 152);
            this.spinProje.Name = "spinProje";
            this.spinProje.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinProje.Properties.MaxValue = new decimal(new int[] { 100, 0, 0, 0 });
            this.spinProje.Properties.MinValue = new decimal(new int[] { 0, 0, 0, 0 });
            this.spinProje.Size = new System.Drawing.Size(120, 20);
            this.spinProje.TabIndex = 4;

            // lblButunleme
            lblButunleme.AutoSize = true;
            lblButunleme.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblButunleme.Location = new System.Drawing.Point(270, 155);
            lblButunleme.Name = "lblButunleme";
            lblButunleme.Size = new System.Drawing.Size(75, 15);
            lblButunleme.TabIndex = 6;
            lblButunleme.Text = "Bütünleme:";

            // spinButunleme
            this.spinButunleme.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            this.spinButunleme.Location = new System.Drawing.Point(350, 152);
            this.spinButunleme.Name = "spinButunleme";
            this.spinButunleme.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinButunleme.Properties.MaxValue = new decimal(new int[] { 100, 0, 0, 0 });
            this.spinButunleme.Properties.MinValue = new decimal(new int[] { 0, 0, 0, 0 });
            this.spinButunleme.Size = new System.Drawing.Size(120, 20);
            this.spinButunleme.TabIndex = 5;

            // lblAciklama
            lblAciklama.AutoSize = true;
            lblAciklama.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblAciklama.Location = new System.Drawing.Point(20, 185);
            lblAciklama.Name = "lblAciklama";
            lblAciklama.Size = new System.Drawing.Size(65, 15);
            lblAciklama.TabIndex = 7;
            lblAciklama.Text = "Açıklama:";

            // txtAciklama
            this.txtAciklama.Location = new System.Drawing.Point(120, 182);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(350, 45);
            this.txtAciklama.TabIndex = 6;

            // btnYeni
            this.btnYeni.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnYeni.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnYeni.Appearance.Options.UseBackColor = true;
            this.btnYeni.Appearance.Options.UseForeColor = true;
            this.btnYeni.Location = new System.Drawing.Point(540, 20);
            this.btnYeni.Name = "btnYeni";
            this.btnYeni.Size = new System.Drawing.Size(140, 38);
            this.btnYeni.TabIndex = 7;
            this.btnYeni.Text = "Yeni";
            this.btnYeni.Click += new System.EventHandler(this.btnYeni_Click);

            // btnKaydet
            this.btnKaydet.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnKaydet.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnKaydet.Appearance.Options.UseBackColor = true;
            this.btnKaydet.Appearance.Options.UseForeColor = true;
            this.btnKaydet.Location = new System.Drawing.Point(540, 65);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(140, 38);
            this.btnKaydet.TabIndex = 8;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);

            // btnGuncelle
            this.btnGuncelle.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnGuncelle.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnGuncelle.Appearance.Options.UseBackColor = true;
            this.btnGuncelle.Appearance.Options.UseForeColor = true;
            this.btnGuncelle.Location = new System.Drawing.Point(540, 110);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(140, 38);
            this.btnGuncelle.TabIndex = 9;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);

            // btnSil
            this.btnSil.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnSil.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSil.Appearance.Options.UseBackColor = true;
            this.btnSil.Appearance.Options.UseForeColor = true;
            this.btnSil.Location = new System.Drawing.Point(540, 155);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(140, 38);
            this.btnSil.TabIndex = 10;
            this.btnSil.Text = "Sil";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);

            // gridControl1
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 240);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1100, 400);
            this.gridControl1.TabIndex = 11;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gridView1 });

            // gridView1
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);

            // NotForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 640);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(panelTop);
            this.Name = "NotForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Not Girişi";
            this.Load += new System.EventHandler(this.NotForm_Load);

            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
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

        #endregion

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
    }
}
