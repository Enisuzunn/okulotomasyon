namespace OkulSistemOtomasyon.Forms
{
    partial class NotGirisDialog
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
            this.lblOgrenciBilgi = new DevExpress.XtraEditors.LabelControl();
            this.lblDersBilgi = new DevExpress.XtraEditors.LabelControl();
            this.lblVize = new DevExpress.XtraEditors.LabelControl();
            this.spinVize = new DevExpress.XtraEditors.SpinEdit();
            this.lblFinal = new DevExpress.XtraEditors.LabelControl();
            this.spinFinal = new DevExpress.XtraEditors.SpinEdit();
            this.lblButunleme = new DevExpress.XtraEditors.LabelControl();
            this.spinButunleme = new DevExpress.XtraEditors.SpinEdit();
            this.lblProje = new DevExpress.XtraEditors.LabelControl();
            this.spinProje = new DevExpress.XtraEditors.SpinEdit();
            this.lblAciklama = new DevExpress.XtraEditors.LabelControl();
            this.txtAciklama = new DevExpress.XtraEditors.MemoEdit();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.btnIptal = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.spinVize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinFinal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinButunleme.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinProje.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOgrenciBilgi
            // 
            this.lblOgrenciBilgi.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblOgrenciBilgi.Appearance.Options.UseFont = true;
            this.lblOgrenciBilgi.Location = new System.Drawing.Point(20, 20);
            this.lblOgrenciBilgi.Name = "lblOgrenciBilgi";
            this.lblOgrenciBilgi.Size = new System.Drawing.Size(150, 20);
            this.lblOgrenciBilgi.TabIndex = 0;
            this.lblOgrenciBilgi.Text = "Öğrenci: -";
            // 
            // lblDersBilgi
            // 
            this.lblDersBilgi.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDersBilgi.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.lblDersBilgi.Appearance.Options.UseFont = true;
            this.lblDersBilgi.Appearance.Options.UseForeColor = true;
            this.lblDersBilgi.Location = new System.Drawing.Point(20, 45);
            this.lblDersBilgi.Name = "lblDersBilgi";
            this.lblDersBilgi.Size = new System.Drawing.Size(50, 19);
            this.lblDersBilgi.TabIndex = 1;
            this.lblDersBilgi.Text = "Ders: -";
            // 
            // lblVize
            // 
            this.lblVize.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblVize.Appearance.Options.UseFont = true;
            this.lblVize.Location = new System.Drawing.Point(20, 85);
            this.lblVize.Name = "lblVize";
            this.lblVize.Size = new System.Drawing.Size(70, 19);
            this.lblVize.TabIndex = 2;
            this.lblVize.Text = "Vize Notu:";
            // 
            // spinVize
            // 
            this.spinVize.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinVize.Location = new System.Drawing.Point(150, 82);
            this.spinVize.Name = "spinVize";
            this.spinVize.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.spinVize.Properties.Appearance.Options.UseFont = true;
            this.spinVize.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinVize.Properties.IsFloatValue = false;
            this.spinVize.Properties.MaskSettings.Set("mask", "N00");
            this.spinVize.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.spinVize.Size = new System.Drawing.Size(300, 26);
            this.spinVize.TabIndex = 3;
            // 
            // lblFinal
            // 
            this.lblFinal.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFinal.Appearance.Options.UseFont = true;
            this.lblFinal.Location = new System.Drawing.Point(20, 125);
            this.lblFinal.Name = "lblFinal";
            this.lblFinal.Size = new System.Drawing.Size(70, 19);
            this.lblFinal.TabIndex = 4;
            this.lblFinal.Text = "Final Notu:";
            // 
            // spinFinal
            // 
            this.spinFinal.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinFinal.Location = new System.Drawing.Point(150, 122);
            this.spinFinal.Name = "spinFinal";
            this.spinFinal.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.spinFinal.Properties.Appearance.Options.UseFont = true;
            this.spinFinal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinFinal.Properties.IsFloatValue = false;
            this.spinFinal.Properties.MaskSettings.Set("mask", "N00");
            this.spinFinal.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.spinFinal.Size = new System.Drawing.Size(300, 26);
            this.spinFinal.TabIndex = 5;
            // 
            // lblButunleme
            // 
            this.lblButunleme.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblButunleme.Appearance.Options.UseFont = true;
            this.lblButunleme.Location = new System.Drawing.Point(20, 165);
            this.lblButunleme.Name = "lblButunleme";
            this.lblButunleme.Size = new System.Drawing.Size(115, 19);
            this.lblButunleme.TabIndex = 6;
            this.lblButunleme.Text = "Bütünleme Notu:";
            // 
            // spinButunleme
            // 
            this.spinButunleme.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinButunleme.Location = new System.Drawing.Point(150, 162);
            this.spinButunleme.Name = "spinButunleme";
            this.spinButunleme.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.spinButunleme.Properties.Appearance.Options.UseFont = true;
            this.spinButunleme.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinButunleme.Properties.IsFloatValue = false;
            this.spinButunleme.Properties.MaskSettings.Set("mask", "N00");
            this.spinButunleme.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.spinButunleme.Size = new System.Drawing.Size(300, 26);
            this.spinButunleme.TabIndex = 7;
            // 
            // lblProje
            // 
            this.lblProje.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblProje.Appearance.Options.UseFont = true;
            this.lblProje.Location = new System.Drawing.Point(20, 205);
            this.lblProje.Name = "lblProje";
            this.lblProje.Size = new System.Drawing.Size(79, 19);
            this.lblProje.TabIndex = 8;
            this.lblProje.Text = "Proje Notu:";
            // 
            // spinProje
            // 
            this.spinProje.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinProje.Location = new System.Drawing.Point(150, 202);
            this.spinProje.Name = "spinProje";
            this.spinProje.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.spinProje.Properties.Appearance.Options.UseFont = true;
            this.spinProje.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinProje.Properties.IsFloatValue = false;
            this.spinProje.Properties.MaskSettings.Set("mask", "N00");
            this.spinProje.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.spinProje.Size = new System.Drawing.Size(300, 26);
            this.spinProje.TabIndex = 9;
            // 
            // lblAciklama
            // 
            this.lblAciklama.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAciklama.Appearance.Options.UseFont = true;
            this.lblAciklama.Location = new System.Drawing.Point(20, 245);
            this.lblAciklama.Name = "lblAciklama";
            this.lblAciklama.Size = new System.Drawing.Size(68, 19);
            this.lblAciklama.TabIndex = 10;
            this.lblAciklama.Text = "Açıklama:";
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(20, 270);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAciklama.Properties.Appearance.Options.UseFont = true;
            this.txtAciklama.Size = new System.Drawing.Size(430, 80);
            this.txtAciklama.TabIndex = 11;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnKaydet.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnKaydet.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnKaydet.Appearance.Options.UseBackColor = true;
            this.btnKaydet.Appearance.Options.UseFont = true;
            this.btnKaydet.Appearance.Options.UseForeColor = true;
            this.btnKaydet.Location = new System.Drawing.Point(20, 370);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(210, 40);
            this.btnKaydet.TabIndex = 12;
            this.btnKaydet.Text = "✅ Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnIptal.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnIptal.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnIptal.Appearance.Options.UseBackColor = true;
            this.btnIptal.Appearance.Options.UseFont = true;
            this.btnIptal.Appearance.Options.UseForeColor = true;
            this.btnIptal.Location = new System.Drawing.Point(240, 370);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(210, 40);
            this.btnIptal.TabIndex = 13;
            this.btnIptal.Text = "❌ İptal";
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // NotGirisDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 430);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.lblAciklama);
            this.Controls.Add(this.spinProje);
            this.Controls.Add(this.lblProje);
            this.Controls.Add(this.spinButunleme);
            this.Controls.Add(this.lblButunleme);
            this.Controls.Add(this.spinFinal);
            this.Controls.Add(this.lblFinal);
            this.Controls.Add(this.spinVize);
            this.Controls.Add(this.lblVize);
            this.Controls.Add(this.lblDersBilgi);
            this.Controls.Add(this.lblOgrenciBilgi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NotGirisDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Not Giriş / Güncelleme";
            this.Load += new System.EventHandler(this.NotGirisDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spinVize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinFinal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinButunleme.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinProje.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblOgrenciBilgi;
        private DevExpress.XtraEditors.LabelControl lblDersBilgi;
        private DevExpress.XtraEditors.LabelControl lblVize;
        private DevExpress.XtraEditors.SpinEdit spinVize;
        private DevExpress.XtraEditors.LabelControl lblFinal;
        private DevExpress.XtraEditors.SpinEdit spinFinal;
        private DevExpress.XtraEditors.LabelControl lblButunleme;
        private DevExpress.XtraEditors.SpinEdit spinButunleme;
        private DevExpress.XtraEditors.LabelControl lblProje;
        private DevExpress.XtraEditors.SpinEdit spinProje;
        private DevExpress.XtraEditors.LabelControl lblAciklama;
        private DevExpress.XtraEditors.MemoEdit txtAciklama;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.SimpleButton btnIptal;
    }
}
