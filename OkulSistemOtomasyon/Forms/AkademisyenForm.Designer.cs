using DevExpress.XtraEditors;

namespace OkulSistemOtomasyon.Forms
{
    partial class AkademisyenForm
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
            
            // Main Controls
            panelControl1 = new DevExpress.XtraEditors.PanelControl();
            groupControl1 = new DevExpress.XtraEditors.GroupControl();
            labelControl9 = new LabelControl();
            lookUpBolum = new LookUpEdit();
            labelControl8 = new LabelControl();
            checkAktif = new CheckEdit();
            labelControl7 = new LabelControl();
            txtTelefon = new TextEdit();
            labelControl6 = new LabelControl();
            txtEmail = new TextEdit();
            labelControl5 = new LabelControl();
            txtUzmanlikAlani = new TextEdit();
            labelControl4 = new LabelControl();
            cmbUnvan = new ComboBoxEdit();
            labelControl3 = new LabelControl();
            txtSoyad = new TextEdit();
            labelControl2 = new LabelControl();
            txtAd = new TextEdit();
            labelControl1 = new LabelControl();
            txtTC = new TextEdit();
            panelControl2 = new DevExpress.XtraEditors.PanelControl();
            btnSil = new SimpleButton();
            btnGuncelle = new SimpleButton();
            btnKaydet = new SimpleButton();
            btnYeni = new SimpleButton();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)panelControl1).BeginInit();
            panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lookUpBolum.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)checkAktif.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtTelefon.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEmail.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtUzmanlikAlani.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmbUnvan.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtSoyad.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAd.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtTC.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelControl2).BeginInit();
            panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            SuspendLayout();
            
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
            this.lblBaslik.Size = new System.Drawing.Size(300, 32);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "👨‍🏫 Akademisyen Yönetimi";
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
            this.lblAltBaslik.Text = "Akademisyen kayıtlarını yönetin ve düzenleyin";
            // 
            // panelControl1
            // 
            panelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            panelControl1.Appearance.Options.UseBackColor = true;
            panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panelControl1.Controls.Add(groupControl1);
            panelControl1.Controls.Add(panelControl2);
            panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            panelControl1.Location = new System.Drawing.Point(0, 80);
            panelControl1.Name = "panelControl1";
            panelControl1.Padding = new System.Windows.Forms.Padding(10);
            panelControl1.Size = new System.Drawing.Size(1100, 220);
            panelControl1.TabIndex = 0;
            // 
            // groupControl1
            // 
            groupControl1.Appearance.BackColor = System.Drawing.Color.White;
            groupControl1.Appearance.Options.UseBackColor = true;
            groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            groupControl1.AppearanceCaption.Options.UseFont = true;
            groupControl1.AppearanceCaption.Options.UseForeColor = true;
            groupControl1.Controls.Add(labelControl9);
            groupControl1.Controls.Add(lookUpBolum);
            groupControl1.Controls.Add(labelControl8);
            groupControl1.Controls.Add(checkAktif);
            groupControl1.Controls.Add(labelControl7);
            groupControl1.Controls.Add(txtTelefon);
            groupControl1.Controls.Add(labelControl6);
            groupControl1.Controls.Add(txtEmail);
            groupControl1.Controls.Add(labelControl5);
            groupControl1.Controls.Add(txtUzmanlikAlani);
            groupControl1.Controls.Add(labelControl4);
            groupControl1.Controls.Add(cmbUnvan);
            groupControl1.Controls.Add(labelControl3);
            groupControl1.Controls.Add(txtSoyad);
            groupControl1.Controls.Add(labelControl2);
            groupControl1.Controls.Add(txtAd);
            groupControl1.Controls.Add(labelControl1);
            groupControl1.Controls.Add(txtTC);
            groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupControl1.Location = new System.Drawing.Point(10, 10);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new System.Drawing.Size(910, 200);
            groupControl1.TabIndex = 1;
            groupControl1.Text = "📋 Akademisyen Bilgileri";
            // 
            // labelControl1
            // 
            labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Location = new System.Drawing.Point(20, 40);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new System.Drawing.Size(80, 17);
            labelControl1.TabIndex = 1;
            labelControl1.Text = "TC Kimlik No:";
            // 
            // txtTC
            // 
            txtTC.Location = new System.Drawing.Point(20, 62);
            txtTC.Name = "txtTC";
            txtTC.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtTC.Properties.Appearance.Options.UseFont = true;
            txtTC.Properties.MaxLength = 11;
            txtTC.Size = new System.Drawing.Size(180, 24);
            txtTC.TabIndex = 0;
            // 
            // labelControl2
            // 
            labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            labelControl2.Appearance.Options.UseFont = true;
            labelControl2.Location = new System.Drawing.Point(220, 40);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new System.Drawing.Size(22, 17);
            labelControl2.TabIndex = 3;
            labelControl2.Text = "Ad:";
            // 
            // txtAd
            // 
            txtAd.Location = new System.Drawing.Point(220, 62);
            txtAd.Name = "txtAd";
            txtAd.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtAd.Properties.Appearance.Options.UseFont = true;
            txtAd.Size = new System.Drawing.Size(180, 24);
            txtAd.TabIndex = 2;
            // 
            // labelControl3
            // 
            labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            labelControl3.Appearance.Options.UseFont = true;
            labelControl3.Location = new System.Drawing.Point(420, 40);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new System.Drawing.Size(44, 17);
            labelControl3.TabIndex = 5;
            labelControl3.Text = "Soyad:";
            // 
            // txtSoyad
            // 
            txtSoyad.Location = new System.Drawing.Point(420, 62);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtSoyad.Properties.Appearance.Options.UseFont = true;
            txtSoyad.Size = new System.Drawing.Size(180, 24);
            txtSoyad.TabIndex = 4;
            // 
            // labelControl4
            // 
            labelControl4.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            labelControl4.Appearance.Options.UseFont = true;
            labelControl4.Location = new System.Drawing.Point(620, 40);
            labelControl4.Name = "labelControl4";
            labelControl4.Size = new System.Drawing.Size(45, 17);
            labelControl4.TabIndex = 7;
            labelControl4.Text = "Ünvan:";
            // 
            // cmbUnvan
            // 
            cmbUnvan.Location = new System.Drawing.Point(620, 62);
            cmbUnvan.Name = "cmbUnvan";
            cmbUnvan.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            cmbUnvan.Properties.Appearance.Options.UseFont = true;
            cmbUnvan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbUnvan.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cmbUnvan.Size = new System.Drawing.Size(270, 24);
            cmbUnvan.TabIndex = 6;
            // 
            // labelControl9
            // 
            labelControl9.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            labelControl9.Appearance.Options.UseFont = true;
            labelControl9.Location = new System.Drawing.Point(20, 100);
            labelControl9.Name = "labelControl9";
            labelControl9.Size = new System.Drawing.Size(47, 17);
            labelControl9.TabIndex = 17;
            labelControl9.Text = "Bölüm:";
            // 
            // lookUpBolum
            // 
            lookUpBolum.Location = new System.Drawing.Point(20, 122);
            lookUpBolum.Name = "lookUpBolum";
            lookUpBolum.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            lookUpBolum.Properties.Appearance.Options.UseFont = true;
            lookUpBolum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lookUpBolum.Properties.NullText = "Bölüm Seçiniz";
            lookUpBolum.Size = new System.Drawing.Size(180, 24);
            lookUpBolum.TabIndex = 16;
            // 
            // labelControl5
            // 
            labelControl5.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            labelControl5.Appearance.Options.UseFont = true;
            labelControl5.Location = new System.Drawing.Point(220, 100);
            labelControl5.Name = "labelControl5";
            labelControl5.Size = new System.Drawing.Size(92, 17);
            labelControl5.TabIndex = 9;
            labelControl5.Text = "Uzmanlık Alanı:";
            // 
            // txtUzmanlikAlani
            // 
            txtUzmanlikAlani.Location = new System.Drawing.Point(220, 122);
            txtUzmanlikAlani.Name = "txtUzmanlikAlani";
            txtUzmanlikAlani.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtUzmanlikAlani.Properties.Appearance.Options.UseFont = true;
            txtUzmanlikAlani.Size = new System.Drawing.Size(180, 24);
            txtUzmanlikAlani.TabIndex = 8;
            // 
            // labelControl6
            // 
            labelControl6.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            labelControl6.Appearance.Options.UseFont = true;
            labelControl6.Location = new System.Drawing.Point(420, 100);
            labelControl6.Name = "labelControl6";
            labelControl6.Size = new System.Drawing.Size(39, 17);
            labelControl6.TabIndex = 11;
            labelControl6.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new System.Drawing.Point(420, 122);
            txtEmail.Name = "txtEmail";
            txtEmail.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtEmail.Properties.Appearance.Options.UseFont = true;
            txtEmail.Size = new System.Drawing.Size(180, 24);
            txtEmail.TabIndex = 10;
            // 
            // labelControl7
            // 
            labelControl7.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            labelControl7.Appearance.Options.UseFont = true;
            labelControl7.Location = new System.Drawing.Point(620, 100);
            labelControl7.Name = "labelControl7";
            labelControl7.Size = new System.Drawing.Size(51, 17);
            labelControl7.TabIndex = 13;
            labelControl7.Text = "Telefon:";
            // 
            // txtTelefon
            // 
            txtTelefon.Location = new System.Drawing.Point(620, 122);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtTelefon.Properties.Appearance.Options.UseFont = true;
            txtTelefon.Size = new System.Drawing.Size(140, 24);
            txtTelefon.TabIndex = 12;
            // 
            // labelControl8
            // 
            labelControl8.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            labelControl8.Appearance.Options.UseFont = true;
            labelControl8.Location = new System.Drawing.Point(780, 100);
            labelControl8.Name = "labelControl8";
            labelControl8.Size = new System.Drawing.Size(47, 17);
            labelControl8.TabIndex = 15;
            labelControl8.Text = "Durum:";
            // 
            // checkAktif
            // 
            checkAktif.Location = new System.Drawing.Point(780, 122);
            checkAktif.Name = "checkAktif";
            checkAktif.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            checkAktif.Properties.Appearance.Options.UseFont = true;
            checkAktif.Properties.Caption = "Aktif";
            checkAktif.Size = new System.Drawing.Size(100, 20);
            checkAktif.TabIndex = 14;
            // 
            // panelControl2
            // 
            panelControl2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            panelControl2.Appearance.Options.UseBackColor = true;
            panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panelControl2.Controls.Add(btnSil);
            panelControl2.Controls.Add(btnGuncelle);
            panelControl2.Controls.Add(btnKaydet);
            panelControl2.Controls.Add(btnYeni);
            panelControl2.Dock = System.Windows.Forms.DockStyle.Right;
            panelControl2.Location = new System.Drawing.Point(920, 10);
            panelControl2.Name = "panelControl2";
            panelControl2.Size = new System.Drawing.Size(170, 200);
            panelControl2.TabIndex = 0;
            // 
            // btnYeni
            // 
            btnYeni.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            btnYeni.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            btnYeni.Appearance.ForeColor = System.Drawing.Color.White;
            btnYeni.Appearance.Options.UseBackColor = true;
            btnYeni.Appearance.Options.UseFont = true;
            btnYeni.Appearance.Options.UseForeColor = true;
            btnYeni.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            btnYeni.AppearanceHovered.Options.UseBackColor = true;
            btnYeni.AppearancePressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            btnYeni.AppearancePressed.Options.UseBackColor = true;
            btnYeni.Location = new System.Drawing.Point(10, 5);
            btnYeni.Name = "btnYeni";
            btnYeni.Size = new System.Drawing.Size(150, 42);
            btnYeni.TabIndex = 0;
            btnYeni.Text = "➕ Yeni";
            btnYeni.Click += btnYeni_Click;
            // 
            // btnKaydet
            // 
            btnKaydet.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            btnKaydet.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            btnKaydet.Appearance.ForeColor = System.Drawing.Color.White;
            btnKaydet.Appearance.Options.UseBackColor = true;
            btnKaydet.Appearance.Options.UseFont = true;
            btnKaydet.Appearance.Options.UseForeColor = true;
            btnKaydet.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(132)))), ((int)(((byte)(73)))));
            btnKaydet.AppearanceHovered.Options.UseBackColor = true;
            btnKaydet.AppearancePressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            btnKaydet.AppearancePressed.Options.UseBackColor = true;
            btnKaydet.Location = new System.Drawing.Point(10, 52);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new System.Drawing.Size(150, 42);
            btnKaydet.TabIndex = 1;
            btnKaydet.Text = "💾 Kaydet";
            btnKaydet.Click += btnKaydet_Click;
            // 
            // btnGuncelle
            // 
            btnGuncelle.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            btnGuncelle.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            btnGuncelle.Appearance.ForeColor = System.Drawing.Color.White;
            btnGuncelle.Appearance.Options.UseBackColor = true;
            btnGuncelle.Appearance.Options.UseFont = true;
            btnGuncelle.Appearance.Options.UseForeColor = true;
            btnGuncelle.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            btnGuncelle.AppearanceHovered.Options.UseBackColor = true;
            btnGuncelle.AppearancePressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(74)))), ((int)(((byte)(0)))));
            btnGuncelle.AppearancePressed.Options.UseBackColor = true;
            btnGuncelle.Location = new System.Drawing.Point(10, 99);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new System.Drawing.Size(150, 42);
            btnGuncelle.TabIndex = 2;
            btnGuncelle.Text = "✏️ Güncelle";
            btnGuncelle.Click += btnGuncelle_Click;
            // 
            // btnSil
            // 
            btnSil.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            btnSil.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            btnSil.Appearance.ForeColor = System.Drawing.Color.White;
            btnSil.Appearance.Options.UseBackColor = true;
            btnSil.Appearance.Options.UseFont = true;
            btnSil.Appearance.Options.UseForeColor = true;
            btnSil.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            btnSil.AppearanceHovered.Options.UseBackColor = true;
            btnSil.AppearancePressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(50)))), ((int)(((byte)(38)))));
            btnSil.AppearancePressed.Options.UseBackColor = true;
            btnSil.Location = new System.Drawing.Point(10, 146);
            btnSil.Name = "btnSil";
            btnSil.Size = new System.Drawing.Size(150, 42);
            btnSil.TabIndex = 3;
            btnSil.Text = "🗑️ Sil";
            btnSil.Click += btnSil_Click;
            // 
            // gridControl1
            // 
            gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridControl1.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            gridControl1.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            gridControl1.Location = new System.Drawing.Point(0, 300);
            gridControl1.MainView = gridView1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new System.Drawing.Size(1100, 400);
            gridControl1.TabIndex = 2;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            gridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.White;
            gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridView1.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            gridView1.Appearance.Row.Options.UseFont = true;
            gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            gridView1.Appearance.OddRow.BackColor = System.Drawing.Color.White;
            gridView1.Appearance.OddRow.Options.UseBackColor = true;
            gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.EnableAppearanceEvenRow = true;
            gridView1.OptionsView.EnableAppearanceOddRow = true;
            gridView1.OptionsView.ShowAutoFilterRow = true;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.RowHeight = 30;
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            // 
            // AkademisyenForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1100, 700);
            Controls.Add(gridControl1);
            Controls.Add(panelControl1);
            Controls.Add(panelHeader);
            Name = "AkademisyenForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Akademisyen Yönetimi - Üniversite Yönetim Sistemi";
            Load += AkademisyenForm_Load;
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)panelControl1).EndInit();
            panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)lookUpBolum.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)checkAktif.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtTelefon.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEmail.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtUzmanlikAlani.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmbUnvan.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtSoyad.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAd.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtTC.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelControl2).EndInit();
            panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelHeader;
        private DevExpress.XtraEditors.LabelControl lblBaslik;
        private DevExpress.XtraEditors.LabelControl lblAltBaslik;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private LabelControl labelControl1;
        private TextEdit txtTC;
        private LabelControl labelControl2;
        private TextEdit txtAd;
        private LabelControl labelControl3;
        private TextEdit txtSoyad;
        private LabelControl labelControl4;
        private ComboBoxEdit cmbUnvan;
        private LabelControl labelControl5;
        private TextEdit txtUzmanlikAlani;
        private LabelControl labelControl6;
        private TextEdit txtEmail;
        private LabelControl labelControl7;
        private TextEdit txtTelefon;
        private LabelControl labelControl8;
        private CheckEdit checkAktif;
        private LabelControl labelControl9;
        private LookUpEdit lookUpBolum;
        private SimpleButton btnYeni;
        private SimpleButton btnKaydet;
        private SimpleButton btnGuncelle;
        private SimpleButton btnSil;
    }
}
