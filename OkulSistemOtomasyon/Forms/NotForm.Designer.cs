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
            // Header Panel
            this.panelHeader = new DevExpress.XtraEditors.PanelControl();
            this.lblBaslik = new DevExpress.XtraEditors.LabelControl();
            this.lblAltBaslik = new DevExpress.XtraEditors.LabelControl();
            
            // Main Content
            this.panelMain = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.panelButtons = new DevExpress.XtraEditors.PanelControl();
            
            // Labels
            this.lblOgrenci = new DevExpress.XtraEditors.LabelControl();
            this.lblDers = new DevExpress.XtraEditors.LabelControl();
            this.lblNotBilgisi = new DevExpress.XtraEditors.LabelControl();
            this.lblVize = new DevExpress.XtraEditors.LabelControl();
            this.lblFinal = new DevExpress.XtraEditors.LabelControl();
            this.lblProje = new DevExpress.XtraEditors.LabelControl();
            this.lblButunleme = new DevExpress.XtraEditors.LabelControl();
            this.lblAciklama = new DevExpress.XtraEditors.LabelControl();

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

            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).BeginInit();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelButtons)).BeginInit();
            this.panelButtons.SuspendLayout();
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

            // 
            // panelHeader
            // 
            this.panelHeader.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelHeader.Appearance.Options.UseBackColor = true;
            this.panelHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelHeader.Controls.Add(this.lblBaslik);
            this.panelHeader.Controls.Add(this.lblAltBaslik);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1100, 80);
            this.panelHeader.TabIndex = 10;
            // 
            // lblBaslik
            // 
            this.lblBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Appearance.Options.UseFont = true;
            this.lblBaslik.Appearance.Options.UseForeColor = true;
            this.lblBaslik.Location = new System.Drawing.Point(20, 15);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(180, 32);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "📝 Not Girişi";
            // 
            // lblAltBaslik
            // 
            this.lblAltBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAltBaslik.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.lblAltBaslik.Appearance.Options.UseFont = true;
            this.lblAltBaslik.Appearance.Options.UseForeColor = true;
            this.lblAltBaslik.Location = new System.Drawing.Point(20, 50);
            this.lblAltBaslik.Name = "lblAltBaslik";
            this.lblAltBaslik.Size = new System.Drawing.Size(350, 19);
            this.lblAltBaslik.TabIndex = 1;
            this.lblAltBaslik.Text = "Öğrenci notlarını girin ve düzenleyin";
            // 
            // panelMain
            // 
            this.panelMain.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.panelMain.Appearance.Options.UseBackColor = true;
            this.panelMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelMain.Controls.Add(this.groupControl1);
            this.panelMain.Controls.Add(this.panelButtons);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMain.Location = new System.Drawing.Point(0, 80);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(10);
            this.panelMain.Size = new System.Drawing.Size(1100, 280);
            this.panelMain.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.Controls.Add(this.lblOgrenci);
            this.groupControl1.Controls.Add(this.lookUpOgrenci);
            this.groupControl1.Controls.Add(this.lblDers);
            this.groupControl1.Controls.Add(this.lookUpDers);
            this.groupControl1.Controls.Add(this.lblNotBilgisi);
            this.groupControl1.Controls.Add(this.lblVize);
            this.groupControl1.Controls.Add(this.spinVize);
            this.groupControl1.Controls.Add(this.lblFinal);
            this.groupControl1.Controls.Add(this.spinFinal);
            this.groupControl1.Controls.Add(this.lblProje);
            this.groupControl1.Controls.Add(this.spinProje);
            this.groupControl1.Controls.Add(this.lblButunleme);
            this.groupControl1.Controls.Add(this.spinButunleme);
            this.groupControl1.Controls.Add(this.lblAciklama);
            this.groupControl1.Controls.Add(this.txtAciklama);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(10, 10);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(910, 260);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "📋 Not Bilgileri";
            // 
            // lblOgrenci
            // 
            this.lblOgrenci.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblOgrenci.Appearance.Options.UseFont = true;
            this.lblOgrenci.Location = new System.Drawing.Point(20, 40);
            this.lblOgrenci.Name = "lblOgrenci";
            this.lblOgrenci.Size = new System.Drawing.Size(54, 17);
            this.lblOgrenci.TabIndex = 0;
            this.lblOgrenci.Text = "Öğrenci:";
            // 
            // lookUpOgrenci
            // 
            this.lookUpOgrenci.Location = new System.Drawing.Point(20, 62);
            this.lookUpOgrenci.Name = "lookUpOgrenci";
            this.lookUpOgrenci.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lookUpOgrenci.Properties.Appearance.Options.UseFont = true;
            this.lookUpOgrenci.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpOgrenci.Properties.NullText = "Öğrenci Seçiniz";
            this.lookUpOgrenci.Size = new System.Drawing.Size(400, 24);
            this.lookUpOgrenci.TabIndex = 0;
            // 
            // lblDers
            // 
            this.lblDers.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblDers.Appearance.Options.UseFont = true;
            this.lblDers.Location = new System.Drawing.Point(450, 40);
            this.lblDers.Name = "lblDers";
            this.lblDers.Size = new System.Drawing.Size(32, 17);
            this.lblDers.TabIndex = 1;
            this.lblDers.Text = "Ders:";
            // 
            // lookUpDers
            // 
            this.lookUpDers.Location = new System.Drawing.Point(450, 62);
            this.lookUpDers.Name = "lookUpDers";
            this.lookUpDers.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lookUpDers.Properties.Appearance.Options.UseFont = true;
            this.lookUpDers.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpDers.Properties.NullText = "Ders Seçiniz";
            this.lookUpDers.Size = new System.Drawing.Size(430, 24);
            this.lookUpDers.TabIndex = 1;
            // 
            // lblNotBilgisi
            // 
            this.lblNotBilgisi.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblNotBilgisi.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblNotBilgisi.Appearance.Options.UseFont = true;
            this.lblNotBilgisi.Appearance.Options.UseForeColor = true;
            this.lblNotBilgisi.Location = new System.Drawing.Point(20, 100);
            this.lblNotBilgisi.Name = "lblNotBilgisi";
            this.lblNotBilgisi.Size = new System.Drawing.Size(186, 19);
            this.lblNotBilgisi.TabIndex = 2;
            this.lblNotBilgisi.Text = "📊 Not Bilgileri (0-100 arası):";
            // 
            // lblVize
            // 
            this.lblVize.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblVize.Appearance.Options.UseFont = true;
            this.lblVize.Location = new System.Drawing.Point(20, 130);
            this.lblVize.Name = "lblVize";
            this.lblVize.Size = new System.Drawing.Size(68, 17);
            this.lblVize.TabIndex = 3;
            this.lblVize.Text = "Vize (%40):";
            // 
            // spinVize
            // 
            this.spinVize.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            this.spinVize.Location = new System.Drawing.Point(20, 152);
            this.spinVize.Name = "spinVize";
            this.spinVize.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.spinVize.Properties.Appearance.Options.UseFont = true;
            this.spinVize.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinVize.Properties.MaxValue = new decimal(new int[] { 100, 0, 0, 0 });
            this.spinVize.Properties.MinValue = new decimal(new int[] { 0, 0, 0, 0 });
            this.spinVize.Size = new System.Drawing.Size(150, 24);
            this.spinVize.TabIndex = 2;
            // 
            // lblFinal
            // 
            this.lblFinal.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblFinal.Appearance.Options.UseFont = true;
            this.lblFinal.Location = new System.Drawing.Point(200, 130);
            this.lblFinal.Name = "lblFinal";
            this.lblFinal.Size = new System.Drawing.Size(73, 17);
            this.lblFinal.TabIndex = 4;
            this.lblFinal.Text = "Final (%60):";
            // 
            // spinFinal
            // 
            this.spinFinal.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            this.spinFinal.Location = new System.Drawing.Point(200, 152);
            this.spinFinal.Name = "spinFinal";
            this.spinFinal.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.spinFinal.Properties.Appearance.Options.UseFont = true;
            this.spinFinal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinFinal.Properties.MaxValue = new decimal(new int[] { 100, 0, 0, 0 });
            this.spinFinal.Properties.MinValue = new decimal(new int[] { 0, 0, 0, 0 });
            this.spinFinal.Size = new System.Drawing.Size(150, 24);
            this.spinFinal.TabIndex = 3;
            // 
            // lblProje
            // 
            this.lblProje.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblProje.Appearance.Options.UseFont = true;
            this.lblProje.Location = new System.Drawing.Point(380, 130);
            this.lblProje.Name = "lblProje";
            this.lblProje.Size = new System.Drawing.Size(67, 17);
            this.lblProje.TabIndex = 5;
            this.lblProje.Text = "Proje Notu:";
            // 
            // spinProje
            // 
            this.spinProje.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            this.spinProje.Location = new System.Drawing.Point(380, 152);
            this.spinProje.Name = "spinProje";
            this.spinProje.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.spinProje.Properties.Appearance.Options.UseFont = true;
            this.spinProje.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinProje.Properties.MaxValue = new decimal(new int[] { 100, 0, 0, 0 });
            this.spinProje.Properties.MinValue = new decimal(new int[] { 0, 0, 0, 0 });
            this.spinProje.Size = new System.Drawing.Size(150, 24);
            this.spinProje.TabIndex = 4;
            // 
            // lblButunleme
            // 
            this.lblButunleme.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblButunleme.Appearance.Options.UseFont = true;
            this.lblButunleme.Location = new System.Drawing.Point(560, 130);
            this.lblButunleme.Name = "lblButunleme";
            this.lblButunleme.Size = new System.Drawing.Size(68, 17);
            this.lblButunleme.TabIndex = 6;
            this.lblButunleme.Text = "Bütünleme:";
            // 
            // spinButunleme
            // 
            this.spinButunleme.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            this.spinButunleme.Location = new System.Drawing.Point(560, 152);
            this.spinButunleme.Name = "spinButunleme";
            this.spinButunleme.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.spinButunleme.Properties.Appearance.Options.UseFont = true;
            this.spinButunleme.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinButunleme.Properties.MaxValue = new decimal(new int[] { 100, 0, 0, 0 });
            this.spinButunleme.Properties.MinValue = new decimal(new int[] { 0, 0, 0, 0 });
            this.spinButunleme.Size = new System.Drawing.Size(150, 24);
            this.spinButunleme.TabIndex = 5;
            // 
            // lblAciklama
            // 
            this.lblAciklama.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblAciklama.Appearance.Options.UseFont = true;
            this.lblAciklama.Location = new System.Drawing.Point(20, 190);
            this.lblAciklama.Name = "lblAciklama";
            this.lblAciklama.Size = new System.Drawing.Size(58, 17);
            this.lblAciklama.TabIndex = 7;
            this.lblAciklama.Text = "Açıklama:";
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(20, 212);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAciklama.Properties.Appearance.Options.UseFont = true;
            this.txtAciklama.Size = new System.Drawing.Size(860, 35);
            this.txtAciklama.TabIndex = 6;
            // 
            // panelButtons
            // 
            this.panelButtons.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.panelButtons.Appearance.Options.UseBackColor = true;
            this.panelButtons.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelButtons.Controls.Add(this.btnSil);
            this.panelButtons.Controls.Add(this.btnGuncelle);
            this.panelButtons.Controls.Add(this.btnKaydet);
            this.panelButtons.Controls.Add(this.btnYeni);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelButtons.Location = new System.Drawing.Point(920, 10);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(170, 260);
            this.panelButtons.TabIndex = 0;
            // 
            // btnYeni
            // 
            this.btnYeni.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnYeni.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnYeni.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnYeni.Appearance.Options.UseBackColor = true;
            this.btnYeni.Appearance.Options.UseFont = true;
            this.btnYeni.Appearance.Options.UseForeColor = true;
            this.btnYeni.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnYeni.AppearanceHovered.Options.UseBackColor = true;
            this.btnYeni.AppearancePressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            this.btnYeni.AppearancePressed.Options.UseBackColor = true;
            this.btnYeni.Location = new System.Drawing.Point(10, 5);
            this.btnYeni.Name = "btnYeni";
            this.btnYeni.Size = new System.Drawing.Size(150, 50);
            this.btnYeni.TabIndex = 7;
            this.btnYeni.Text = "➕ Yeni";
            this.btnYeni.Click += new System.EventHandler(this.btnYeni_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnKaydet.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnKaydet.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnKaydet.Appearance.Options.UseBackColor = true;
            this.btnKaydet.Appearance.Options.UseFont = true;
            this.btnKaydet.Appearance.Options.UseForeColor = true;
            this.btnKaydet.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(132)))), ((int)(((byte)(73)))));
            this.btnKaydet.AppearanceHovered.Options.UseBackColor = true;
            this.btnKaydet.AppearancePressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.btnKaydet.AppearancePressed.Options.UseBackColor = true;
            this.btnKaydet.Location = new System.Drawing.Point(10, 60);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(150, 50);
            this.btnKaydet.TabIndex = 8;
            this.btnKaydet.Text = "💾 Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnGuncelle.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnGuncelle.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnGuncelle.Appearance.Options.UseBackColor = true;
            this.btnGuncelle.Appearance.Options.UseFont = true;
            this.btnGuncelle.Appearance.Options.UseForeColor = true;
            this.btnGuncelle.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            this.btnGuncelle.AppearanceHovered.Options.UseBackColor = true;
            this.btnGuncelle.AppearancePressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(74)))), ((int)(((byte)(0)))));
            this.btnGuncelle.AppearancePressed.Options.UseBackColor = true;
            this.btnGuncelle.Location = new System.Drawing.Point(10, 115);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(150, 50);
            this.btnGuncelle.TabIndex = 9;
            this.btnGuncelle.Text = "✏️ Güncelle";
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnSil.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnSil.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSil.Appearance.Options.UseBackColor = true;
            this.btnSil.Appearance.Options.UseFont = true;
            this.btnSil.Appearance.Options.UseForeColor = true;
            this.btnSil.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnSil.AppearanceHovered.Options.UseBackColor = true;
            this.btnSil.AppearancePressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(50)))), ((int)(((byte)(38)))));
            this.btnSil.AppearancePressed.Options.UseBackColor = true;
            this.btnSil.Location = new System.Drawing.Point(10, 170);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(150, 50);
            this.btnSil.TabIndex = 10;
            this.btnSil.Text = "🗑️ Sil";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.gridControl1.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.gridControl1.Location = new System.Drawing.Point(0, 360);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1100, 340);
            this.gridControl1.TabIndex = 11;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gridView1 });
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.PaintStyleName = "Flat";
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.ColumnPanelRowHeight = 40;
            this.gridView1.RowHeight = 30;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // NotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelHeader);
            this.Name = "NotForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Not Girişi - Üniversite Yönetim Sistemi";
            this.Load += new System.EventHandler(this.NotForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).EndInit();
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelButtons)).EndInit();
            this.panelButtons.ResumeLayout(false);
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

        private DevExpress.XtraEditors.PanelControl panelHeader;
        private DevExpress.XtraEditors.LabelControl lblBaslik;
        private DevExpress.XtraEditors.LabelControl lblAltBaslik;
        private DevExpress.XtraEditors.PanelControl panelMain;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PanelControl panelButtons;
        private DevExpress.XtraEditors.LabelControl lblOgrenci;
        private DevExpress.XtraEditors.LabelControl lblDers;
        private DevExpress.XtraEditors.LabelControl lblNotBilgisi;
        private DevExpress.XtraEditors.LabelControl lblVize;
        private DevExpress.XtraEditors.LabelControl lblFinal;
        private DevExpress.XtraEditors.LabelControl lblProje;
        private DevExpress.XtraEditors.LabelControl lblButunleme;
        private DevExpress.XtraEditors.LabelControl lblAciklama;
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
