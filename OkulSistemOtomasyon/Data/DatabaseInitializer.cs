using Microsoft.EntityFrameworkCore;
using System.IO;

namespace OkulSistemOtomasyon.Data
{
    /// <summary>
    /// Veritabanı başlatma ve migration işlemleri (İlkokul-Ortaokul-Lise Sistemi)
    /// </summary>
    public static class DatabaseInitializer
    {
        public static void Initialize()
        {
            using (var context = new OkulDbContext())
            {
                try
                {
                    // Veritabanını oluştur ve migration'ları uygula
                    context.Database.EnsureCreated();
                    
                    // Veya migration kullanmak isterseniz:
                    // context.Database.Migrate();
                    
                    // Örnek veriler yoksa ekle
                    SeedData(context);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Veritabanı başlatılamadı: {ex.Message}", ex);
                }
            }
        }

        private static void SeedData(OkulDbContext context)
        {
            // Eğer kullanıcı yoksa varsayılan admin ekle
            if (!context.Kullanicilar.Any())
            {
                context.Kullanicilar.Add(new Models.Kullanici
                {
                    KullaniciAdi = "admin",
                    Sifre = "admin123",
                    Ad = "Sistem",
                    Soyad = "Yöneticisi",
                    Email = "admin@okul.com",
                    Rol = "Admin",
                    Aktif = true
                });
                context.SaveChanges();
            }
        }

        public static string GetDatabasePath()
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "OkulSistem",
                "okulsistem.db"
            );
        }
    }
}
