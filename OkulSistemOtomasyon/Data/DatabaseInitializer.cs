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
            // Örnek bölümler ekle (önce bölümler olmalı)
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

            // Örnek öğrenciler ekle
            if (!context.Ogrenciler.Any())
            {
                var ilkBolum = context.Bolumler.First();
                var ogrenciler = new[]
                {
                    new Models.Ogrenci
                    {
                        TC = "98765432101",
                        Ad = "Ali",
                        Soyad = "Veli",
                        OgrenciNo = "220201001",
                        DogumTarihi = new DateTime(2002, 5, 15),
                        Email = "ali.veli@ogrenci.universite.edu.tr",
                        Telefon = "5559876543",
                        BolumId = ilkBolum.Id, // BolumId değil, Id kullan
                        Sinif = 3,
                        KayitYili = 2022,
                        Aktif = true
                    },
                    new Models.Ogrenci
                    {
                        TC = "98765432102",
                        Ad = "Zeynep",
                        Soyad = "Yıldız",
                        OgrenciNo = "220201002",
                        DogumTarihi = new DateTime(2003, 8, 20),
                        Email = "zeynep.yildiz@ogrenci.universite.edu.tr",
                        Telefon = "5559876544",
                        BolumId = ilkBolum.Id, // BolumId değil, Id kullan
                        Sinif = 3,
                        KayitYili = 2022,
                        Aktif = true
                    }
                };
                context.Ogrenciler.AddRange(ogrenciler);
                context.SaveChanges();
            }

            // Kullanıcıları ekle (en son çünkü Akademisyen ve Öğrenci Id'lerine ihtiyaç var)
            if (!context.Kullanicilar.Any())
            {
                var ilkAkademisyen = context.Akademisyenler.First();
                var ilkOgrenci = context.Ogrenciler.First();
                var ikinciOgrenci = context.Ogrenciler.Skip(1).First(); // Zeynep

                var kullanicilar = new[]
                {
                    // Admin kullanıcısı
                    new Models.Kullanici
                    {
                        KullaniciAdi = "admin",
                        Sifre = "admin123",
                        Ad = "Sistem",
                        Soyad = "Yöneticisi",
                        Email = "admin@universite.edu.tr",
                        Rol = Models.KullaniciRolu.Admin,
                        Aktif = true
                    },
                    // Akademisyen kullanıcısı
                    new Models.Kullanici
                    {
                        KullaniciAdi = "ahmet.yilmaz",
                        Sifre = "12345",
                        Ad = "Ahmet",
                        Soyad = "Yılmaz",
                        Email = "ahmet.yilmaz@universite.edu.tr",
                        Rol = Models.KullaniciRolu.Akademisyen,
                        AkademisyenId = ilkAkademisyen.Id, // Id kullan (AkademisyenId değil)
                        Aktif = true
                    },
                    // Öğrenci kullanıcısı - Ali Veli
                    new Models.Kullanici
                    {
                        KullaniciAdi = "220201001",
                        Sifre = "12345",
                        Ad = "Ali",
                        Soyad = "Veli",
                        Email = "ali.veli@ogrenci.universite.edu.tr",
                        Rol = Models.KullaniciRolu.Ogrenci,
                        OgrenciId = ilkOgrenci.Id, // Id kullan (OgrenciId değil)
                        Aktif = true
                    },
                    // Öğrenci kullanıcısı - Zeynep Yıldız
                    new Models.Kullanici
                    {
                        KullaniciAdi = "220201002",
                        Sifre = "12345",
                        Ad = "Zeynep",
                        Soyad = "Yıldız",
                        Email = "zeynep.yildiz@ogrenci.universite.edu.tr",
                        Rol = Models.KullaniciRolu.Ogrenci,
                        OgrenciId = ikinciOgrenci.Id, // Id kullan (OgrenciId değil)
                        Aktif = true
                    }
                };
                context.Kullanicilar.AddRange(kullanicilar);
                context.SaveChanges();
            }

            // Örnek dersler ekle
            if (!context.Dersler.Any())
            {
                var blmBolum = context.Bolumler.First(b => b.BolumKodu == "BLM");
                var ahmetHoca = context.Akademisyenler.First(a => a.TC == "12345678901");

                var dersler = new[]
                {
                    new Models.Ders
                    {
                        DersAdi = "Veri Yapıları ve Algoritmalar",
                        DersKodu = "BLM301",
                        Kredi = 6,
                        BolumId = blmBolum.Id, // BolumId değil, Id kullan
                        AkademisyenId = ahmetHoca.Id, // AkademisyenId değil, Id kullan
                        Aktif = true
                    },
                    new Models.Ders
                    {
                        DersAdi = "Veritabanı Yönetim Sistemleri",
                        DersKodu = "BLM302",
                        Kredi = 5,
                        BolumId = blmBolum.Id,
                        AkademisyenId = ahmetHoca.Id,
                        Aktif = true
                    },
                    new Models.Ders
                    {
                        DersAdi = "Web Programlama",
                        DersKodu = "BLM303",
                        Kredi = 4,
                        BolumId = blmBolum.Id,
                        AkademisyenId = ahmetHoca.Id,
                        Aktif = true
                    }
                };
                context.Dersler.AddRange(dersler);
                context.SaveChanges();
            }

            // Örnek öğrenci notları ekle (akademisyenin derslerine öğrenci kaydet)
            if (!context.OgrenciNotlari.Any())
            {
                var tümDersler = context.Dersler.ToList();
                var tümOgrenciler = context.Ogrenciler.ToList();

                var notlar = new List<Models.OgrenciNot>();

                // Her ders için her öğrenciyi kaydet
                foreach (var ders in tümDersler)
                {
                    foreach (var ogrenci in tümOgrenciler)
                    {
                        notlar.Add(new Models.OgrenciNot
                        {
                            OgrenciId = ogrenci.Id, // OgrenciId değil, Id kullan
                            DersId = ders.Id,       // DersId değil, Id kullan
                            Vize = null,  // Henüz not girilmemiş
                            Final = null,
                            Butunleme = null,
                            ProjeNotu = null
                        });
                    }
                }

                context.OgrenciNotlari.AddRange(notlar);
                context.SaveChanges();
            }
        }

        public static string GetDatabasePath()
        {
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine(appPath, "Data", "universite.db");
        }
    }
}
