using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using OkulSistemOtomasyon.Helpers;

namespace OkulSistemOtomasyon.Services
{
    /// <summary>
    /// E-posta gönderme servisi
    /// </summary>
    public class EmailService
    {
        private readonly EmailSettings _settings;

        public EmailService()
        {
            _settings = EmailSettings.Load();
        }

        /// <summary>
        /// Genel mail gönderme metodu
        /// </summary>
        public async Task<bool> SendEmailAsync(string toEmail, string subject, string body, bool isHtml = true)
        {
            if (!_settings.EmailNotificationsEnabled)
            {
                return false;
            }

            if (string.IsNullOrEmpty(_settings.SenderEmail) || string.IsNullOrEmpty(_settings.SenderPassword))
            {
                return false;
            }

            try
            {
                using (var client = new SmtpClient(_settings.SmtpServer, _settings.SmtpPort))
                {
                    client.EnableSsl = _settings.EnableSsl;
                    client.Credentials = new NetworkCredential(_settings.SenderEmail, _settings.SenderPassword);
                    client.Timeout = 30000; // 30 saniye timeout

                    var message = new MailMessage
                    {
                        From = new MailAddress(_settings.SenderEmail, _settings.SenderName),
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = isHtml
                    };
                    message.To.Add(toEmail);

                    await client.SendMailAsync(message);
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Mail gönderme hatası: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Not bildirimi maili gönder
        /// </summary>
        public async Task<bool> SendGradeNotificationAsync(
            string studentEmail,
            string studentName,
            string courseName,
            string examType,
            decimal grade,
            string academicianName)
        {
            string subject = $"📝 Not Bildirimi - {courseName}";

            string gradeStatus = grade >= 50 ? "✅ Geçer" : "❌ Kalır";
            string gradeColor = grade >= 50 ? "#28a745" : "#dc3545";

            string body = $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='UTF-8'>
    <style>
        body {{ font-family: 'Segoe UI', Arial, sans-serif; background-color: #f5f5f5; margin: 0; padding: 20px; }}
        .container {{ max-width: 600px; margin: 0 auto; background-color: #ffffff; border-radius: 10px; box-shadow: 0 2px 10px rgba(0,0,0,0.1); overflow: hidden; }}
        .header {{ background: linear-gradient(135deg, #667eea 0%, #764ba2 100%); color: white; padding: 30px; text-align: center; }}
        .header h1 {{ margin: 0; font-size: 24px; }}
        .content {{ padding: 30px; }}
        .grade-box {{ background-color: #f8f9fa; border-radius: 10px; padding: 20px; text-align: center; margin: 20px 0; }}
        .grade {{ font-size: 48px; font-weight: bold; color: {gradeColor}; }}
        .status {{ font-size: 18px; color: {gradeColor}; margin-top: 10px; }}
        .info-table {{ width: 100%; border-collapse: collapse; margin: 20px 0; }}
        .info-table td {{ padding: 12px; border-bottom: 1px solid #eee; }}
        .info-table td:first-child {{ font-weight: bold; color: #666; width: 40%; }}
        .footer {{ background-color: #f8f9fa; padding: 20px; text-align: center; color: #666; font-size: 12px; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>🎓 Fırat Üniversitesi</h1>
            <p>Öğrenci Bilgi Sistemi - Not Bildirimi</p>
        </div>
        <div class='content'>
            <p>Sayın <strong>{studentName}</strong>,</p>
            <p>Aşağıdaki ders için notunuz girilmiştir:</p>
            
            <div class='grade-box'>
                <div class='grade'>{grade:F0}</div>
                <div class='status'>{gradeStatus}</div>
            </div>
            
            <table class='info-table'>
                <tr>
                    <td>📚 Ders Adı:</td>
                    <td>{courseName}</td>
                </tr>
                <tr>
                    <td>📝 Sınav Türü:</td>
                    <td>{examType}</td>
                </tr>
                <tr>
                    <td>👨‍🏫 Öğretim Üyesi:</td>
                    <td>{academicianName}</td>
                </tr>
                <tr>
                    <td>📅 Tarih:</td>
                    <td>{DateTime.Now:dd MMMM yyyy, HH:mm}</td>
                </tr>
            </table>
            
            <p>Başarılar dileriz!</p>
        </div>
        <div class='footer'>
            <p>Bu mail otomatik olarak gönderilmiştir. Lütfen yanıtlamayınız.</p>
            <p>© {DateTime.Now.Year} Fırat Üniversitesi - Öğrenci Bilgi Sistemi</p>
        </div>
    </div>
</body>
</html>";

            return await SendEmailAsync(studentEmail, subject, body);
        }

        /// <summary>
        /// Tüm notları tek mail içinde gönder (Vize, Final, Ortalama)
        /// </summary>
        public async Task<bool> SendAllGradesNotificationAsync(
            string studentEmail,
            string studentName,
            string courseName,
            decimal? vize,
            decimal? final,
            decimal? proje,
            decimal? butunleme,
            string academicianName,
            string aciklama = null)
        {
            string subject = $"📝 Not Bildirimi - {courseName}";

            // Ortalama hesapla (Vize %40 + Final %60)
            decimal? ortalama = null;
            if (vize.HasValue && final.HasValue)
            {
                ortalama = (vize.Value * 0.4m) + (final.Value * 0.6m);
            }

            // Geçme durumu (ortalamaya göre, yoksa girilen nota göre)
            decimal kontrolNotu = ortalama ?? final ?? vize ?? 0;
            string gradeStatus = kontrolNotu >= 50 ? "✅ Geçer" : "❌ Kalır";
            string gradeColor = kontrolNotu >= 50 ? "#28a745" : "#dc3545";

            // Not satırlarını oluştur
            string notSatirlari = "";
            
            if (vize.HasValue)
            {
                notSatirlari += $@"
                <tr>
                    <td>📝 Vize Notu:</td>
                    <td><strong>{vize.Value:F0}</strong></td>
                </tr>";
            }
            
            if (final.HasValue)
            {
                notSatirlari += $@"
                <tr>
                    <td>📝 Final Notu:</td>
                    <td><strong>{final.Value:F0}</strong></td>
                </tr>";
            }
            
            if (proje.HasValue)
            {
                notSatirlari += $@"
                <tr>
                    <td>📝 Proje Notu:</td>
                    <td><strong>{proje.Value:F0}</strong></td>
                </tr>";
            }
            
            if (butunleme.HasValue)
            {
                notSatirlari += $@"
                <tr>
                    <td>📝 Bütünleme Notu:</td>
                    <td><strong>{butunleme.Value:F0}</strong></td>
                </tr>";
            }

            // Ortalama satırı (sadece hem vize hem final varsa)
            string ortalamaSatiri = "";
            if (ortalama.HasValue)
            {
                ortalamaSatiri = $@"
                <tr style='background-color: #f8f9fa; border-top: 2px solid #ddd;'>
                    <td>📊 Ortalama:</td>
                    <td><strong style='color: {gradeColor}; font-size: 18px;'>{ortalama.Value:F0}</strong>
                        <small style='color: #666;'>(Vize %40 + Final %60)</small>
                    </td>
                </tr>";
            }

            // Açıklama bölümü (varsa)
            string aciklamaBolumu = "";
            if (!string.IsNullOrWhiteSpace(aciklama))
            {
                aciklamaBolumu = $@"
            <div style='background-color: #fff3cd; border-left: 4px solid #ffc107; border-radius: 5px; padding: 15px; margin: 20px 0;'>
                <p style='margin: 0; color: #856404;'><strong>📌 Öğretim Üyesinden Not:</strong></p>
                <p style='margin: 10px 0 0 0; color: #333;'>{aciklama}</p>
            </div>";
            }

            string body = $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='UTF-8'>
    <style>
        body {{ font-family: 'Segoe UI', Arial, sans-serif; background-color: #f5f5f5; margin: 0; padding: 20px; }}
        .container {{ max-width: 600px; margin: 0 auto; background-color: #ffffff; border-radius: 10px; box-shadow: 0 2px 10px rgba(0,0,0,0.1); overflow: hidden; }}
        .header {{ background: linear-gradient(135deg, #667eea 0%, #764ba2 100%); color: white; padding: 30px; text-align: center; }}
        .header h1 {{ margin: 0; font-size: 24px; }}
        .content {{ padding: 30px; }}
        .status-box {{ background-color: #f8f9fa; border-radius: 10px; padding: 20px; text-align: center; margin: 20px 0; border-left: 5px solid {gradeColor}; }}
        .status {{ font-size: 24px; font-weight: bold; color: {gradeColor}; }}
        .info-table {{ width: 100%; border-collapse: collapse; margin: 20px 0; }}
        .info-table td {{ padding: 12px; border-bottom: 1px solid #eee; }}
        .info-table td:first-child {{ font-weight: bold; color: #666; width: 40%; }}
        .footer {{ background-color: #f8f9fa; padding: 20px; text-align: center; color: #666; font-size: 12px; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>🎓 Fırat Üniversitesi</h1>
            <p>Öğrenci Bilgi Sistemi - Not Bildirimi</p>
        </div>
        <div class='content'>
            <p>Sayın <strong>{studentName}</strong>,</p>
            <p>Aşağıdaki ders için notlarınız girilmiştir:</p>
            
            <table class='info-table'>
                <tr>
                    <td>📚 Ders Adı:</td>
                    <td><strong>{courseName}</strong></td>
                </tr>
                {notSatirlari}
                {ortalamaSatiri}
            </table>
            
            <div class='status-box'>
                <div class='status'>{gradeStatus}</div>
            </div>
            
            {aciklamaBolumu}
            
            <table class='info-table'>
                <tr>
                    <td>👨‍🏫 Öğretim Üyesi:</td>
                    <td>{academicianName}</td>
                </tr>
                <tr>
                    <td>📅 Tarih:</td>
                    <td>{DateTime.Now:dd MMMM yyyy, HH:mm}</td>
                </tr>
            </table>
            
            <p>Başarılar dileriz!</p>
        </div>
        <div class='footer'>
            <p>Bu mail otomatik olarak gönderilmiştir. Lütfen yanıtlamayınız.</p>
            <p>© {DateTime.Now.Year} Fırat Üniversitesi - Öğrenci Bilgi Sistemi</p>
        </div>
    </div>
</body>
</html>";

            return await SendEmailAsync(studentEmail, subject, body);
        }

        /// <summary>
        /// Devamsızlık uyarısı maili gönder
        /// </summary>
        public async Task<bool> SendAbsenceWarningAsync(
            string studentEmail,
            string studentName,
            string courseName,
            int currentAbsence,
            int maxAbsence)
        {
            string subject = $"⚠️ Devamsızlık Uyarısı - {courseName}";

            int remaining = maxAbsence - currentAbsence;
            string warningLevel = remaining <= 2 ? "#dc3545" : "#ffc107";

            string body = $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='UTF-8'>
    <style>
        body {{ font-family: 'Segoe UI', Arial, sans-serif; background-color: #f5f5f5; margin: 0; padding: 20px; }}
        .container {{ max-width: 600px; margin: 0 auto; background-color: #ffffff; border-radius: 10px; box-shadow: 0 2px 10px rgba(0,0,0,0.1); overflow: hidden; }}
        .header {{ background: linear-gradient(135deg, #f093fb 0%, #f5576c 100%); color: white; padding: 30px; text-align: center; }}
        .header h1 {{ margin: 0; font-size: 24px; }}
        .content {{ padding: 30px; }}
        .warning-box {{ background-color: #fff3cd; border: 2px solid {warningLevel}; border-radius: 10px; padding: 20px; text-align: center; margin: 20px 0; }}
        .absence-count {{ font-size: 36px; font-weight: bold; color: {warningLevel}; }}
        .footer {{ background-color: #f8f9fa; padding: 20px; text-align: center; color: #666; font-size: 12px; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>⚠️ Devamsızlık Uyarısı</h1>
        </div>
        <div class='content'>
            <p>Sayın <strong>{studentName}</strong>,</p>
            <p><strong>{courseName}</strong> dersindeki devamsızlık durumunuz hakkında bilgilendirme:</p>
            
            <div class='warning-box'>
                <p>Mevcut Devamsızlık</p>
                <div class='absence-count'>{currentAbsence} / {maxAbsence}</div>
                <p>Kalan hakkınız: <strong>{remaining}</strong> gün</p>
            </div>
            
            <p style='color: #dc3545;'><strong>Dikkat:</strong> Devamsızlık limitini aşmanız durumunda dersten kalacaksınız!</p>
            
            <p>Lütfen derslerinize düzenli olarak katılım sağlayınız.</p>
        </div>
        <div class='footer'>
            <p>Bu mail otomatik olarak gönderilmiştir.</p>
            <p>© {DateTime.Now.Year} Fırat Üniversitesi - Öğrenci Bilgi Sistemi</p>
        </div>
    </div>
</body>
</html>";

            return await SendEmailAsync(studentEmail, subject, body);
        }

        /// <summary>
        /// Genel duyuru maili gönder
        /// </summary>
        public async Task<bool> SendAnnouncementAsync(
            string studentEmail,
            string studentName,
            string announcementTitle,
            string announcementContent)
        {
            string subject = $"📢 Duyuru - {announcementTitle}";

            string body = $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='UTF-8'>
    <style>
        body {{ font-family: 'Segoe UI', Arial, sans-serif; background-color: #f5f5f5; margin: 0; padding: 20px; }}
        .container {{ max-width: 600px; margin: 0 auto; background-color: #ffffff; border-radius: 10px; box-shadow: 0 2px 10px rgba(0,0,0,0.1); overflow: hidden; }}
        .header {{ background: linear-gradient(135deg, #11998e 0%, #38ef7d 100%); color: white; padding: 30px; text-align: center; }}
        .header h1 {{ margin: 0; font-size: 24px; }}
        .content {{ padding: 30px; }}
        .announcement-box {{ background-color: #e8f5e9; border-left: 4px solid #28a745; padding: 20px; margin: 20px 0; }}
        .footer {{ background-color: #f8f9fa; padding: 20px; text-align: center; color: #666; font-size: 12px; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>📢 {announcementTitle}</h1>
        </div>
        <div class='content'>
            <p>Sayın <strong>{studentName}</strong>,</p>
            
            <div class='announcement-box'>
                {announcementContent}
            </div>
            
            <p>Bilgilerinize sunarız.</p>
        </div>
        <div class='footer'>
            <p>Bu mail otomatik olarak gönderilmiştir.</p>
            <p>© {DateTime.Now.Year} Fırat Üniversitesi - Öğrenci Bilgi Sistemi</p>
        </div>
    </div>
</body>
</html>";

            return await SendEmailAsync(studentEmail, subject, body);
        }

        /// <summary>
        /// Hoş geldin maili gönder (yeni kayıt)
        /// </summary>
        public async Task<bool> SendWelcomeEmailAsync(
            string studentEmail,
            string studentName,
            string studentNo,
            string departmentName)
        {
            string subject = "🎉 Fırat Üniversitesi'ne Hoş Geldiniz!";

            string body = $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='UTF-8'>
    <style>
        body {{ font-family: 'Segoe UI', Arial, sans-serif; background-color: #f5f5f5; margin: 0; padding: 20px; }}
        .container {{ max-width: 600px; margin: 0 auto; background-color: #ffffff; border-radius: 10px; box-shadow: 0 2px 10px rgba(0,0,0,0.1); overflow: hidden; }}
        .header {{ background: linear-gradient(135deg, #667eea 0%, #764ba2 100%); color: white; padding: 40px; text-align: center; }}
        .header h1 {{ margin: 0; font-size: 28px; }}
        .content {{ padding: 30px; }}
        .info-card {{ background: linear-gradient(135deg, #f5f7fa 0%, #c3cfe2 100%); border-radius: 10px; padding: 20px; margin: 20px 0; }}
        .footer {{ background-color: #f8f9fa; padding: 20px; text-align: center; color: #666; font-size: 12px; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>🎓 Hoş Geldiniz!</h1>
            <p>Fırat Üniversitesi ailesine katıldığınız için mutluyuz</p>
        </div>
        <div class='content'>
            <p>Sayın <strong>{studentName}</strong>,</p>
            <p>Fırat Üniversitesi'ne kaydınız başarıyla tamamlanmıştır. Bilgileriniz aşağıdadır:</p>
            
            <div class='info-card'>
                <p><strong>👤 Ad Soyad:</strong> {studentName}</p>
                <p><strong>🔢 Öğrenci No:</strong> {studentNo}</p>
                <p><strong>🏛️ Bölüm:</strong> {departmentName}</p>
                <p><strong>📅 Kayıt Tarihi:</strong> {DateTime.Now:dd MMMM yyyy}</p>
            </div>
            
            <p>Eğitim hayatınızda başarılar dileriz!</p>
        </div>
        <div class='footer'>
            <p>© {DateTime.Now.Year} Fırat Üniversitesi - Öğrenci Bilgi Sistemi</p>
        </div>
    </div>
</body>
</html>";

            return await SendEmailAsync(studentEmail, subject, body);
        }
    }
}
