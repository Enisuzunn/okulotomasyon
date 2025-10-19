using Microsoft.EntityFrameworkCore;
using System.IO;

namespace OkulSistemOtomasyon.Data
{
    /// <summary>
    /// Veritabanı başlatma ve migration işlemleri (Üniversite Sistemi)
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
                    Email = "admin@universite.edu.tr",
                    Rol = "Admin",
                    Aktif = true
                });
                context.SaveChanges();
            }

            // Örnek bölümler ekle
            if (!context.Bolumler.Any())
            {
                var bolumler = new[]
                {
                    new Models.Bolum { BolumAdi = "Bilgisayar Mühendisliği", BolumKodu = "BLM", Aktif = true },
                    new Models.Bolum { BolumAdi = "Elektrik-Elektronik Mühendisliği", BolumKodu = "EEM", Aktif = true },
                    new Models.Bolum { BolumAdi = "İşletme", BolumKodu = "ISL", Aktif = true },
                    new Models.Bolum { BolumAdi = "Makine Mühendisliği", BolumKodu = "MAK", Aktif = true },
                    new Models.Bolum { BolumAdi = "Hukuk", BolumKodu = "HUK", Aktif = true }
                };
                context.Bolumler.AddRange(bolumler);
                context.SaveChanges();
            }

            // Örnek akademisyenler ekle
            if (!context.Akademisyenler.Any())
            {
                var akademisyenler = new[]
                {
                    new Models.Akademisyen 
                    { 
                        TC = "12345678901", 
                        Ad = "Ahmet", 
                        Soyad = "Yılmaz", 
                        Unvan = "Prof. Dr.",
                        UzmanlikAlani = "Yazılım Mühendisliği",
                        Email = "ahmet.yilmaz@universite.edu.tr",
                        Telefon = "5551234567",
                        Aktif = true 
                    },
                    new Models.Akademisyen 
                    { 
                        TC = "23456789012", 
                        Ad = "Ayşe", 
                        Soyad = "Demir", 
                        Unvan = "Doç. Dr.",
                        UzmanlikAlani = "Veri Bilimi",
                        Email = "ayse.demir@universite.edu.tr",
                        Telefon = "5552345678",
                        Aktif = true 
                    },
                    new Models.Akademisyen 
                    { 
                        TC = "34567890123", 
                        Ad = "Mehmet", 
                        Soyad = "Kaya", 
                        Unvan = "Dr. Öğr. Üyesi",
                        UzmanlikAlani = "İşletme Yönetimi",
                        Email = "mehmet.kaya@universite.edu.tr",
                        Telefon = "5553456789",
                        Aktif = true 
                    }
                };
                context.Akademisyenler.AddRange(akademisyenler);
                context.SaveChanges();
            }
        }

        public static string GetDatabasePath()
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "OkulSistem",
                "universite.db"
            );
        }
    }
}
