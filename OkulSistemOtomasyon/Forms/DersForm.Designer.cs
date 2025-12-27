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
            // Header Panel
            this.panelHeader = new DevExpress.XtraEditors.PanelControl();
            this.lblBaslik = new DevExpress.XtraEditors.LabelControl();
            this.lblAltBaslik = new DevExpress.XtraEditors.LabelControl();
            
            // Main Content
            this.panelMain = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.panelButtons = new DevExpress.XtraEditors.PanelControl();
            
            // Labels
            this.lblDersAdi = new DevExpress.XtraEditors.LabelControl();
            this.lblDersKodu = new DevExpress.XtraEditors.LabelControl();
            this.lblKredi = new DevExpress.XtraEditors.LabelControl();
            this.lblAKTS = new DevExpress.XtraEditors.LabelControl();
            this.lblBolum = new DevExpress.XtraEditors.LabelControl();
            this.lblAkademisyen = new DevExpress.XtraEditors.LabelControl();
            this.lblDonem = new DevExpress.XtraEditors.LabelControl();
            this.lblDurum = new DevExpress.XtraEditors.LabelControl();

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
            ((System.ComponentModel.ISupportInitialize)(this.txtDersAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDersKodu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinKredi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinAKTS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpBolum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpAkademisyen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDonem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkAktif.Properties)).BeginInit();
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
            this.lblBaslik.Size = new System.Drawing.Size(220, 32);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "📚 Ders Yönetimi";
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
            this.lblAltBaslik.Text = "Ders kayıtlarını yönetin ve düzenleyin";
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
            this.panelMain.Size = new System.Drawing.Size(1100, 220);
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
            this.groupControl1.Controls.Add(this.lblDersAdi);
            this.groupControl1.Controls.Add(this.txtDersAdi);
            this.groupControl1.Controls.Add(this.lblDersKodu);
            this.groupControl1.Controls.Add(this.txtDersKodu);
            this.groupControl1.Controls.Add(this.lblKredi);
            this.groupControl1.Controls.Add(this.spinKredi);
            this.groupControl1.Controls.Add(this.lblAKTS);
            this.groupControl1.Controls.Add(this.spinAKTS);
            this.groupControl1.Controls.Add(this.lblBolum);
            this.groupControl1.Controls.Add(this.lookUpBolum);
            this.groupControl1.Controls.Add(this.lblAkademisyen);
            this.groupControl1.Controls.Add(this.lookUpAkademisyen);
            this.groupControl1.Controls.Add(this.lblDonem);
            this.groupControl1.Controls.Add(this.cmbDonem);
            this.groupControl1.Controls.Add(this.lblDurum);
            this.groupControl1.Controls.Add(this.checkAktif);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(10, 10);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(910, 200);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "📋 Ders Bilgileri";
            // 
            // lblDersAdi
            // 
            this.lblDersAdi.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblDersAdi.Appearance.Options.UseFont = true;
            this.lblDersAdi.Location = new System.Drawing.Point(20, 40);
            this.lblDersAdi.Name = "lblDersAdi";
            this.lblDersAdi.Size = new System.Drawing.Size(54, 17);
            this.lblDersAdi.TabIndex = 0;
            this.lblDersAdi.Text = "Ders Adı:";
            // 
            // txtDersAdi
            // 
            this.txtDersAdi.Location = new System.Drawing.Point(20, 62);
            this.txtDersAdi.Name = "txtDersAdi";
            this.txtDersAdi.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDersAdi.Properties.Appearance.Options.UseFont = true;
            this.txtDersAdi.Size = new System.Drawing.Size(280, 24);
            this.txtDersAdi.TabIndex = 0;
            // 
            // lblDersKodu
            // 
            this.lblDersKodu.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblDersKodu.Appearance.Options.UseFont = true;
            this.lblDersKodu.Location = new System.Drawing.Point(320, 40);
            this.lblDersKodu.Name = "lblDersKodu";
            this.lblDersKodu.Size = new System.Drawing.Size(66, 17);
            this.lblDersKodu.TabIndex = 1;
            this.lblDersKodu.Text = "Ders Kodu:";
            // 
            // txtDersKodu
            // 
            this.txtDersKodu.Location = new System.Drawing.Point(320, 62);
            this.txtDersKodu.Name = "txtDersKodu";
            this.txtDersKodu.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDersKodu.Properties.Appearance.Options.UseFont = true;
            this.txtDersKodu.Size = new System.Drawing.Size(280, 24);
            this.txtDersKodu.TabIndex = 1;
            // 
            // lblKredi
            // 
            this.lblKredi.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblKredi.Appearance.Options.UseFont = true;
            this.lblKredi.Location = new System.Drawing.Point(620, 40);
            this.lblKredi.Name = "lblKredi";
            this.lblKredi.Size = new System.Drawing.Size(35, 17);
            this.lblKredi.TabIndex = 2;
            this.lblKredi.Text = "Kredi:";
            // 
            // spinKredi
            // 
            this.spinKredi.EditValue = new decimal(new int[] { 3, 0, 0, 0 });
            this.spinKredi.Location = new System.Drawing.Point(620, 62);
            this.spinKredi.Name = "spinKredi";
            this.spinKredi.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.spinKredi.Properties.Appearance.Options.UseFont = true;
            this.spinKredi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinKredi.Properties.MaxValue = new decimal(new int[] { 10, 0, 0, 0 });
            this.spinKredi.Properties.MinValue = new decimal(new int[] { 1, 0, 0, 0 });
            this.spinKredi.Size = new System.Drawing.Size(120, 24);
            this.spinKredi.TabIndex = 2;
            // 
            // lblAKTS
            // 
            this.lblAKTS.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblAKTS.Appearance.Options.UseFont = true;
            this.lblAKTS.Location = new System.Drawing.Point(760, 40);
            this.lblAKTS.Name = "lblAKTS";
            this.lblAKTS.Size = new System.Drawing.Size(35, 17);
            this.lblAKTS.TabIndex = 7;
            this.lblAKTS.Text = "AKTS:";
            // 
            // spinAKTS
            // 
            this.spinAKTS.EditValue = new decimal(new int[] { 5, 0, 0, 0 });
            this.spinAKTS.Location = new System.Drawing.Point(760, 62);
            this.spinAKTS.Name = "spinAKTS";
            this.spinAKTS.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.spinAKTS.Properties.Appearance.Options.UseFont = true;
            this.spinAKTS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinAKTS.Properties.MaxValue = new decimal(new int[] { 15, 0, 0, 0 });
            this.spinAKTS.Properties.MinValue = new decimal(new int[] { 1, 0, 0, 0 });
            this.spinAKTS.Size = new System.Drawing.Size(120, 24);
            this.spinAKTS.TabIndex = 6;
            // 
            // lblBolum
            // 
            this.lblBolum.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblBolum.Appearance.Options.UseFont = true;
            this.lblBolum.Location = new System.Drawing.Point(20, 100);
            this.lblBolum.Name = "lblBolum";
            this.lblBolum.Size = new System.Drawing.Size(47, 17);
            this.lblBolum.TabIndex = 3;
            this.lblBolum.Text = "Bölüm:";
            // 
            // lookUpBolum
            // 
            this.lookUpBolum.Location = new System.Drawing.Point(20, 122);
            this.lookUpBolum.Name = "lookUpBolum";
            this.lookUpBolum.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lookUpBolum.Properties.Appearance.Options.UseFont = true;
            this.lookUpBolum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpBolum.Properties.NullText = "Bölüm Seçiniz";
            this.lookUpBolum.Size = new System.Drawing.Size(280, 24);
            this.lookUpBolum.TabIndex = 3;
            this.lookUpBolum.EditValueChanged += new System.EventHandler(this.lookUpBolum_EditValueChanged);
            // 
            // lblAkademisyen
            // 
            this.lblAkademisyen.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblAkademisyen.Appearance.Options.UseFont = true;
            this.lblAkademisyen.Location = new System.Drawing.Point(320, 100);
            this.lblAkademisyen.Name = "lblAkademisyen";
            this.lblAkademisyen.Size = new System.Drawing.Size(78, 17);
            this.lblAkademisyen.TabIndex = 4;
            this.lblAkademisyen.Text = "Akademisyen:";
            // 
            // lookUpAkademisyen
            // 
            this.lookUpAkademisyen.Location = new System.Drawing.Point(320, 122);
            this.lookUpAkademisyen.Name = "lookUpAkademisyen";
            this.lookUpAkademisyen.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lookUpAkademisyen.Properties.Appearance.Options.UseFont = true;
            this.lookUpAkademisyen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpAkademisyen.Properties.NullText = "Önce bölüm seçiniz";
            this.lookUpAkademisyen.Size = new System.Drawing.Size(280, 24);
            this.lookUpAkademisyen.TabIndex = 4;
            // 
            // lblDonem
            // 
            this.lblDonem.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblDonem.Appearance.Options.UseFont = true;
            this.lblDonem.Location = new System.Drawing.Point(620, 100);
            this.lblDonem.Name = "lblDonem";
            this.lblDonem.Size = new System.Drawing.Size(48, 17);
            this.lblDonem.TabIndex = 5;
            this.lblDonem.Text = "Dönem:";
            // 
            // cmbDonem
            // 
            this.cmbDonem.Location = new System.Drawing.Point(620, 122);
            this.cmbDonem.Name = "cmbDonem";
            this.cmbDonem.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbDonem.Properties.Appearance.Options.UseFont = true;
            this.cmbDonem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDonem.Properties.Items.AddRange(new object[] { "Güz Dönemi", "Bahar Dönemi", "Yaz Okulu" });
            this.cmbDonem.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbDonem.Size = new System.Drawing.Size(150, 24);
            this.cmbDonem.TabIndex = 5;
            // 
            // lblDurum
            // 
            this.lblDurum.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblDurum.Appearance.Options.UseFont = true;
            this.lblDurum.Location = new System.Drawing.Point(790, 100);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(47, 17);
            this.lblDurum.TabIndex = 8;
            this.lblDurum.Text = "Durum:";
            // 
            // checkAktif
            // 
            this.checkAktif.Location = new System.Drawing.Point(790, 122);
            this.checkAktif.Name = "checkAktif";
            this.checkAktif.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkAktif.Properties.Appearance.Options.UseFont = true;
            this.checkAktif.Properties.Caption = "Aktif";
            this.checkAktif.Size = new System.Drawing.Size(80, 20);
            this.checkAktif.TabIndex = 6;
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
            this.panelButtons.Size = new System.Drawing.Size(170, 200);
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
            this.btnYeni.Size = new System.Drawing.Size(150, 42);
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
            this.btnKaydet.Location = new System.Drawing.Point(10, 52);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(150, 42);
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
            this.btnGuncelle.Location = new System.Drawing.Point(10, 99);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(150, 42);
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
            this.btnSil.Location = new System.Drawing.Point(10, 146);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(150, 42);
            this.btnSil.TabIndex = 10;
            this.btnSil.Text = "🗑️ Sil";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.gridControl1.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.gridControl1.Location = new System.Drawing.Point(0, 300);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1100, 400);
            this.gridControl1.TabIndex = 11;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gridView1 });
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
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
            this.gridView1.ColumnPanelRowHeight = 35;
            this.gridView1.RowHeight = 30;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // DersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelHeader);
            this.Name = "DersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ders Yönetimi - Üniversite Yönetim Sistemi";
            this.Load += new System.EventHandler(this.DersForm_Load);

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

        private DevExpress.XtraEditors.PanelControl panelHeader;
        private DevExpress.XtraEditors.LabelControl lblBaslik;
        private DevExpress.XtraEditors.LabelControl lblAltBaslik;
        private DevExpress.XtraEditors.PanelControl panelMain;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PanelControl panelButtons;
        private DevExpress.XtraEditors.LabelControl lblDersAdi;
        private DevExpress.XtraEditors.LabelControl lblDersKodu;
        private DevExpress.XtraEditors.LabelControl lblKredi;
        private DevExpress.XtraEditors.LabelControl lblAKTS;
        private DevExpress.XtraEditors.LabelControl lblBolum;
        private DevExpress.XtraEditors.LabelControl lblAkademisyen;
        private DevExpress.XtraEditors.LabelControl lblDonem;
        private DevExpress.XtraEditors.LabelControl lblDurum;
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
