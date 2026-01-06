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
                    // Veritabanı yoksa oluştur
                    context.Database.EnsureCreated();
                    
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

            // Mevcut akademisyenlere bölüm ata (eğer BolumId null ise)
            var akademisyenlerBolumsuz = context.Akademisyenler.Where(a => a.BolumId == null).ToList();
            if (akademisyenlerBolumsuz.Any())
            {
                var ilkBolum = context.Bolumler.FirstOrDefault(b => b.IsActive);
                if (ilkBolum != null)
                {
                    foreach (var akademisyen in akademisyenlerBolumsuz)
                    {
                        akademisyen.BolumId = ilkBolum.BolumId;
                    }
                    context.SaveChanges();
                }
            }

            // Sadece Admin kullanıcısı ekle
            if (!context.Kullanicilar.Any())
            {
                var adminKullanici = new Models.Kullanici
                {
                    KullaniciAdi = "admin",
                    Sifre = "admin123",
                    Ad = "Sistem",
                    Soyad = "Yöneticisi",
                    Email = "admin@universite.edu.tr",
                    Rol = Models.KullaniciRolu.Admin,
                    IlkGiris = false,  // Admin ilk giriş zorunluluğu YOK
                    Aktif = true
                };
                context.Kullanicilar.Add(adminKullanici);
                context.SaveChanges();
            }
        }

        public static string GetDatabasePath()
        {
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine(appPath, "Data", "universite.db");
        }

        /// <summary>
        /// Veritabanını tamamen siler ve sıfırdan oluşturur (TEHLİKELİ - TÜM VERİLER SİLİNİR!)
        /// Sadece geliştirme/test için kullan
        /// </summary>
        public static void ResetDatabase()
        {
            using (var context = new OkulDbContext())
            {
                context.Database.EnsureDeleted();  // Sil
                context.Database.EnsureCreated();  // Yeniden oluştur
                SeedData(context);                 // Örnek verileri yükle
            }
        }

        /// <summary>
        /// AI eğitimi için örnek öğrenci ve not verisi ekler
        /// </summary>
        public static (int OgrenciSayisi, int NotSayisi) AIEgitimVerisiEkle()
        {
            using (var context = new OkulDbContext())
            {
                // Erkan Tanyıldız akademisyenini bul
                var akademisyen = context.Akademisyenler
                    .FirstOrDefault(a => a.Ad.Contains("Erkan") || a.Soyad.Contains("Tanyıldız"));

                if (akademisyen == null)
                {
                    // Herhangi bir akademisyen al
                    akademisyen = context.Akademisyenler.FirstOrDefault();
                }

                // Bilgisayar Mühendisliği bölümünü bul
                var bolum = context.Bolumler.FirstOrDefault(b => b.BolumKodu == "BLM") 
                    ?? context.Bolumler.FirstOrDefault();

                if (bolum == null || akademisyen == null)
                {
                    return (0, 0);
                }

                int akademisyenId = akademisyen.Id;
                int bolumId = bolum.BolumId;

                // Akademisyenin verdiği dersleri bul veya oluştur
                var dersler = context.Dersler.Where(d => d.AkademisyenId == akademisyenId).ToList();
                
                if (!dersler.Any())
                {
                    // Örnek dersler oluştur
                    var yeniDersler = new[]
                    {
                        new Models.Ders { DersAdi = "Algoritma ve Programlama", DersKodu = "BLM101", Kredi = 4, AKTS = 6, BolumId = bolumId, AkademisyenId = akademisyenId, DonemBilgisi = "Güz Dönemi", IsActive = true },
                        new Models.Ders { DersAdi = "Veri Yapıları", DersKodu = "BLM201", Kredi = 4, AKTS = 6, BolumId = bolumId, AkademisyenId = akademisyenId, DonemBilgisi = "Bahar Dönemi", IsActive = true },
                        new Models.Ders { DersAdi = "Veritabanı Yönetimi", DersKodu = "BLM301", Kredi = 3, AKTS = 5, BolumId = bolumId, AkademisyenId = akademisyenId, DonemBilgisi = "Güz Dönemi", IsActive = true }
                    };
                    context.Dersler.AddRange(yeniDersler);
                    context.SaveChanges();
                    dersler = yeniDersler.ToList();
                }

                // Mevcut öğrencileri al (kullanıcı tarafından eklenen)
                var tumOgrenciler = context.Ogrenciler.Where(o => o.BolumId == bolumId).ToList();
                
                if (!tumOgrenciler.Any())
                {
                    return (0, 0); // Öğrenci yoksa not eklenemez
                }

                // AI eğitimi için çeşitli not verileri oluştur
                // ÖNEMLİ: Hem geçen hem kalan öğrenci olmalı (Binary Classification için)
                var random = new Random();
                int notSayisi = 0;
                int ogrenciIndex = 0;

                // Her öğrenci için her derse not ekle
                foreach (var ogrenci in tumOgrenciler)
                {
                    ogrenciIndex++;
                    
                    foreach (var ders in dersler)
                    {
                        // Bu öğrenci-ders kombinasyonu zaten varsa atla
                        if (context.OgrenciNotlari.Any(n => n.OgrenciId == ogrenci.Id && n.DersId == ders.Id))
                            continue;

                        int vize, final;
                        int? proje = null;

                        // Çeşitli senaryolar oluştur (AI eğitimi için kritik!)
                        // Her 3 öğrenciden 1'i kalsın
                        if (ogrenciIndex % 3 == 0)
                        {
                            // KALAN ÖĞRENCİ - düşük notlar
                            vize = random.Next(20, 45);
                            final = random.Next(15, 50);
                            proje = random.Next(0, 10) > 5 ? random.Next(30, 60) : null;
                        }
                        else if (ogrenciIndex % 3 == 1)
                        {
                            // GEÇEN ÖĞRENCİ - yüksek notlar
                            vize = random.Next(65, 95);
                            final = random.Next(60, 95);
                            proje = random.Next(0, 10) > 3 ? random.Next(70, 100) : null;
                        }
                        else
                        {
                            // SINIRDA ÖĞRENCİ - orta notlar (bazıları geçer, bazıları kalır)
                            vize = random.Next(45, 70);
                            final = random.Next(40, 75);
                            proje = random.Next(0, 10) > 4 ? random.Next(50, 80) : null;
                        }

                        var not = new Models.OgrenciNot
                        {
                            OgrenciId = ogrenci.Id,
                            DersId = ders.Id,
                            Vize = vize,
                            Final = final,
                            ProjeNotu = proje,
                            NotGirisTarihi = DateTime.Now.AddDays(-random.Next(1, 30)),
                            IsActive = true
                        };
                        context.OgrenciNotlari.Add(not);
                        notSayisi++;
                    }
                }
                context.SaveChanges();

                return (eklenenOgrenciler.Count, notSayisi);
            }
        }

        /// <summary>
        /// Otomatik eklenen örnek öğrencileri siler (2024001-2024010 arası)
        /// </summary>
        public static int OrnekOgrencileriSil()
        {
            using (var context = new OkulDbContext())
            {
                // 2024 ile başlayan öğrenci numaralarını bul (örnek veriler)
                var ornekOgrenciler = context.Ogrenciler
                    .Where(o => o.OgrenciNo != null && o.OgrenciNo.StartsWith("2024"))
                    .ToList();

                if (!ornekOgrenciler.Any())
                    return 0;

                // Önce bu öğrencilerin notlarını sil
                var ornekOgrenciIdler = ornekOgrenciler.Select(o => o.Id).ToList();
                var notlar = context.OgrenciNotlari
                    .Where(n => ornekOgrenciIdler.Contains(n.OgrenciId))
                    .ToList();
                context.OgrenciNotlari.RemoveRange(notlar);

                // Sonra öğrencileri sil
                context.Ogrenciler.RemoveRange(ornekOgrenciler);
                context.SaveChanges();

                return ornekOgrenciler.Count;
            }
        }

        /// <summary>
        /// Mevcut notları siler ve AI eğitimi için yeni çeşitli notlar oluşturur
        /// </summary>
        public static int NotlariYenile()
        {
            using (var context = new OkulDbContext())
            {
                // Tüm notları sil
                var mevcutNotlar = context.OgrenciNotlari.ToList();
                context.OgrenciNotlari.RemoveRange(mevcutNotlar);
                context.SaveChanges();

                // Tüm öğrencileri ve dersleri al
                var ogrenciler = context.Ogrenciler.ToList();
                var dersler = context.Dersler.Where(d => d.IsActive).ToList();

                if (!ogrenciler.Any() || !dersler.Any())
                    return 0;

                var random = new Random();
                int notSayisi = 0;
                int ogrenciIndex = 0;

                foreach (var ogrenci in ogrenciler)
                {
                    ogrenciIndex++;
                    
                    foreach (var ders in dersler)
                    {
                        int vize, final;
                        int? proje = null;

                        // Çeşitli senaryolar (hem geçen hem kalan)
                        if (ogrenciIndex % 3 == 0)
                        {
                            // KALAN - düşük notlar
                            vize = random.Next(20, 45);
                            final = random.Next(15, 50);
                            proje = random.Next(0, 10) > 5 ? random.Next(30, 60) : null;
                        }
                        else if (ogrenciIndex % 3 == 1)
                        {
                            // GEÇEN - yüksek notlar
                            vize = random.Next(65, 95);
                            final = random.Next(60, 95);
                            proje = random.Next(0, 10) > 3 ? random.Next(70, 100) : null;
                        }
                        else
                        {
                            // SINIRDA - orta notlar
                            vize = random.Next(45, 70);
                            final = random.Next(40, 75);
                            proje = random.Next(0, 10) > 4 ? random.Next(50, 80) : null;
                        }

                        var not = new Models.OgrenciNot
                        {
                            OgrenciId = ogrenci.Id,
                            DersId = ders.Id,
                            Vize = vize,
                            Final = final,
                            ProjeNotu = proje,
                            NotGirisTarihi = DateTime.Now.AddDays(-random.Next(1, 30)),
                            IsActive = true
                        };
                        context.OgrenciNotlari.Add(not);
                        notSayisi++;
                    }
                }
                context.SaveChanges();
                return notSayisi;
            }
        }
    }
}
