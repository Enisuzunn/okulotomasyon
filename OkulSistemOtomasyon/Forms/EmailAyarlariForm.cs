using DevExpress.XtraEditors;
using OkulSistemOtomasyon.Helpers;
using OkulSistemOtomasyon.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace OkulSistemOtomasyon.Forms
{
    /// <summary>
    /// E-posta ayarları formu
    /// </summary>
    public partial class EmailAyarlariForm : XtraForm
    {
        private EmailSettings _settings;

        // Form kontrolleri
        private TextEdit txtServer;
        private TextEdit txtPort;
        private TextEdit txtEmail;
        private TextEdit txtPassword;
        private TextEdit txtSenderName;
        private CheckEdit chkSsl;
        private CheckEdit chkEnabled;

        public EmailAyarlariForm()
        {
            InitializeComponent();
            _settings = EmailSettings.Load();
            LoadSettings();
        }

        private void InitializeComponent()
        {
            this.Text = "📧 E-Posta Ayarları";
            this.Size = new Size(520, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Ana Panel
            var mainPanel = new PanelControl
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(mainPanel);

            // Header
            var headerPanel = new PanelControl
            {
                Dock = DockStyle.Top,
                Height = 60
            };
            headerPanel.Appearance.BackColor = Color.FromArgb(41, 128, 185);
            headerPanel.Appearance.Options.UseBackColor = true;
            mainPanel.Controls.Add(headerPanel);

            var lblTitle = new LabelControl
            {
                Text = "📧 E-Posta Ayarları",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 15)
            };
            headerPanel.Controls.Add(lblTitle);

            // İçerik paneli
            int y = 80;
            int labelX = 20;
            int inputX = 170;
            int inputWidth = 300;

            // SMTP Server
            var lblServer = new LabelControl
            {
                Text = "SMTP Sunucu:",
                Location = new Point(labelX, y + 3),
                Font = new Font("Segoe UI", 10)
            };
            mainPanel.Controls.Add(lblServer);

            txtServer = new TextEdit
            {
                Location = new Point(inputX, y),
                Width = inputWidth
            };
            txtServer.Properties.Appearance.Font = new Font("Segoe UI", 10);
            mainPanel.Controls.Add(txtServer);
            y += 40;

            // Port
            var lblPort = new LabelControl
            {
                Text = "Port:",
                Location = new Point(labelX, y + 3),
                Font = new Font("Segoe UI", 10)
            };
            mainPanel.Controls.Add(lblPort);

            txtPort = new TextEdit
            {
                Location = new Point(inputX, y),
                Width = 100
            };
            txtPort.Properties.Appearance.Font = new Font("Segoe UI", 10);
            mainPanel.Controls.Add(txtPort);
            y += 40;

            // Email
            var lblEmail = new LabelControl
            {
                Text = "Gönderen E-Posta:",
                Location = new Point(labelX, y + 3),
                Font = new Font("Segoe UI", 10)
            };
            mainPanel.Controls.Add(lblEmail);

            txtEmail = new TextEdit
            {
                Location = new Point(inputX, y),
                Width = inputWidth
            };
            txtEmail.Properties.Appearance.Font = new Font("Segoe UI", 10);
            mainPanel.Controls.Add(txtEmail);
            y += 40;

            // Password
            var lblPassword = new LabelControl
            {
                Text = "Şifre / App Password:",
                Location = new Point(labelX, y + 3),
                Font = new Font("Segoe UI", 10)
            };
            mainPanel.Controls.Add(lblPassword);

            txtPassword = new TextEdit
            {
                Location = new Point(inputX, y),
                Width = inputWidth
            };
            txtPassword.Properties.Appearance.Font = new Font("Segoe UI", 10);
            txtPassword.Properties.PasswordChar = '●';
            mainPanel.Controls.Add(txtPassword);
            y += 40;

            // Sender Name
            var lblSenderName = new LabelControl
            {
                Text = "Gönderen Adı:",
                Location = new Point(labelX, y + 3),
                Font = new Font("Segoe UI", 10)
            };
            mainPanel.Controls.Add(lblSenderName);

            txtSenderName = new TextEdit
            {
                Location = new Point(inputX, y),
                Width = inputWidth
            };
            txtSenderName.Properties.Appearance.Font = new Font("Segoe UI", 10);
            mainPanel.Controls.Add(txtSenderName);
            y += 40;

            // SSL Checkbox
            chkSsl = new CheckEdit
            {
                Text = "SSL Kullan (Güvenli Bağlantı)",
                Location = new Point(inputX, y),
                Width = 250
            };
            chkSsl.Properties.Appearance.Font = new Font("Segoe UI", 10);
            mainPanel.Controls.Add(chkSsl);
            y += 35;

            // Bildirim Checkbox
            chkEnabled = new CheckEdit
            {
                Text = "E-Posta Bildirimlerini Etkinleştir",
                Location = new Point(inputX, y),
                Width = 250
            };
            chkEnabled.Properties.Appearance.Font = new Font("Segoe UI", 10);
            mainPanel.Controls.Add(chkEnabled);
            y += 45;

            // Bilgi notu
            var groupInfo = new GroupControl
            {
                Text = "💡 Bilgi",
                Location = new Point(20, y),
                Size = new Size(460, 80)
            };
            mainPanel.Controls.Add(groupInfo);

            var lblInfo = new LabelControl
            {
                Text = "Gmail kullanıyorsanız 'Uygulama Şifresi' oluşturmanız gerekir:\n" +
                       "Google Hesap → Güvenlik → 2 Adımlı Doğrulama → Uygulama Şifreleri",
                Location = new Point(10, 25),
                AutoSizeMode = LabelAutoSizeMode.None,
                Width = 440,
                Height = 45
            };
            lblInfo.Appearance.Font = new Font("Segoe UI", 9);
            groupInfo.Controls.Add(lblInfo);
            y += 100;

            // Butonlar
            var btnTest = new SimpleButton
            {
                Text = "📧 Test Maili Gönder",
                Location = new Point(20, y),
                Width = 150,
                Height = 40
            };
            btnTest.Appearance.Font = new Font("Segoe UI", 10);
            btnTest.Click += BtnTest_Click;
            mainPanel.Controls.Add(btnTest);

            var btnSave = new SimpleButton
            {
                Text = "💾 Kaydet",
                Location = new Point(180, y),
                Width = 120,
                Height = 40
            };
            btnSave.Appearance.Font = new Font("Segoe UI", 10);
            btnSave.Appearance.BackColor = Color.FromArgb(39, 174, 96);
            btnSave.Appearance.ForeColor = Color.White;
            btnSave.Appearance.Options.UseBackColor = true;
            btnSave.Appearance.Options.UseForeColor = true;
            btnSave.Click += BtnSave_Click;
            mainPanel.Controls.Add(btnSave);

            var btnCancel = new SimpleButton
            {
                Text = "İptal",
                Location = new Point(310, y),
                Width = 100,
                Height = 40
            };
            btnCancel.Appearance.Font = new Font("Segoe UI", 10);
            btnCancel.Click += (s, e) => this.Close();
            mainPanel.Controls.Add(btnCancel);
        }

        private void LoadSettings()
        {
            txtServer.Text = _settings.SmtpServer;
            txtPort.Text = _settings.SmtpPort.ToString();
            txtEmail.Text = _settings.SenderEmail;
            txtPassword.Text = _settings.SenderPassword;
            txtSenderName.Text = _settings.SenderName;
            chkSsl.Checked = _settings.EnableSsl;
            chkEnabled.Checked = _settings.EmailNotificationsEnabled;
        }

        private void SaveSettings()
        {
            _settings.SmtpServer = txtServer.Text.Trim();
            _settings.SmtpPort = int.TryParse(txtPort.Text, out int port) ? port : 587;
            _settings.SenderEmail = txtEmail.Text.Trim();
            _settings.SenderPassword = txtPassword.Text;
            _settings.SenderName = txtSenderName.Text.Trim();
            _settings.EnableSsl = chkSsl.Checked;
            _settings.EmailNotificationsEnabled = chkEnabled.Checked;

            _settings.Save();
        }

        private async void BtnTest_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                XtraMessageBox.Show("Lütfen e-posta adresini girin!", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Önce ayarları kaydet
            SaveSettings();

            var btn = sender as SimpleButton;
            btn.Enabled = false;
            btn.Text = "Gönderiliyor...";

            try
            {
                var emailService = new EmailService();
                var result = await emailService.SendEmailAsync(
                    txtEmail.Text,
                    "🧪 Test Maili - Üniversite Yönetim Sistemi",
                    @"<div style='font-family: Segoe UI, Arial; padding: 20px;'>
                        <h2 style='color: #28a745;'>✅ Test Başarılı!</h2>
                        <p>E-posta ayarlarınız doğru yapılandırılmış.</p>
                        <p>Artık sistem üzerinden otomatik mail bildirimleri gönderilecektir.</p>
                        <hr>
                        <p style='color: #666; font-size: 12px;'>Bu bir test mailidir.</p>
                      </div>",
                    true
                );

                if (result)
                {
                    XtraMessageBox.Show("✅ Test maili başarıyla gönderildi!\n\nLütfen gelen kutunuzu kontrol edin.", 
                        "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("❌ Mail gönderilemedi.\n\nLütfen ayarları kontrol edin:\n" +
                        "• SMTP sunucu adresi doğru mu?\n" +
                        "• Port numarası doğru mu?\n" +
                        "• E-posta ve şifre doğru mu?\n" +
                        "• Gmail için 'Uygulama Şifresi' kullandınız mı?",
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Hata: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btn.Enabled = true;
                btn.Text = "📧 Test Maili Gönder";
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
            XtraMessageBox.Show("✅ E-posta ayarları kaydedildi!", "Başarılı", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
