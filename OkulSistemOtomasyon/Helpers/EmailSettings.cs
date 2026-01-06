using System;
using System.IO;
using System.Text.Json;

namespace OkulSistemOtomasyon.Helpers
{
    /// <summary>
    /// E-posta ayarları yönetimi
    /// </summary>
    public class EmailSettings
    {
        public string SmtpServer { get; set; } = "smtp.gmail.com";
        public int SmtpPort { get; set; } = 587;
        public string SenderEmail { get; set; } = "";
        public string SenderPassword { get; set; } = "";
        public string SenderName { get; set; } = "Üniversite Yönetim Sistemi";
        public bool EnableSsl { get; set; } = true;
        public bool EmailNotificationsEnabled { get; set; } = true;

        private static readonly string SettingsPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "OkulOtomasyon",
            "email_settings.json"
        );

        /// <summary>
        /// Ayarları dosyadan yükle
        /// </summary>
        public static EmailSettings Load()
        {
            try
            {
                if (File.Exists(SettingsPath))
                {
                    string json = File.ReadAllText(SettingsPath);
                    return JsonSerializer.Deserialize<EmailSettings>(json) ?? new EmailSettings();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Email ayarları yüklenirken hata: {ex.Message}");
            }

            return new EmailSettings();
        }

        /// <summary>
        /// Ayarları dosyaya kaydet
        /// </summary>
        public void Save()
        {
            try
            {
                string? directory = Path.GetDirectoryName(SettingsPath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(this, options);
                File.WriteAllText(SettingsPath, json);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Email ayarları kaydedilirken hata: {ex.Message}");
            }
        }

        /// <summary>
        /// Ayarların geçerli olup olmadığını kontrol et
        /// </summary>
        public bool IsValid()
        {
            return !string.IsNullOrEmpty(SmtpServer) &&
                   SmtpPort > 0 &&
                   !string.IsNullOrEmpty(SenderEmail) &&
                   !string.IsNullOrEmpty(SenderPassword);
        }
    }
}
