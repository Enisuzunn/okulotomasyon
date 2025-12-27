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

                // Örnek öğrenciler (10 adet)
                var ogrenciVerileri = new[]
                {
                    new { Ad = "Ahmet", Soyad = "Yılmaz", TC = "11111111111", No = "2024001" },
                    new { Ad = "Ayşe", Soyad = "Kaya", TC = "22222222222", No = "2024002" },
                    new { Ad = "Mehmet", Soyad = "Demir", TC = "33333333333", No = "2024003" },
                    new { Ad = "Fatma", Soyad = "Çelik", TC = "44444444444", No = "2024004" },
                    new { Ad = "Ali", Soyad = "Şahin", TC = "55555555555", No = "2024005" },
                    new { Ad = "Zeynep", Soyad = "Yıldız", TC = "66666666666", No = "2024006" },
                    new { Ad = "Mustafa", Soyad = "Özkan", TC = "77777777777", No = "2024007" },
                    new { Ad = "Elif", Soyad = "Arslan", TC = "88888888888", No = "2024008" },
                    new { Ad = "Emre", Soyad = "Koç", TC = "99999999999", No = "2024009" },
                    new { Ad = "Selin", Soyad = "Aydın", TC = "10101010101", No = "2024010" }
                };

                var eklenenOgrenciler = new List<Models.Ogrenci>();
                foreach (var veri in ogrenciVerileri)
                {
                    // TC zaten varsa atla
                    if (context.Ogrenciler.Any(o => o.TC == veri.TC))
                        continue;

                    var ogrenci = new Models.Ogrenci
                    {
                        Ad = veri.Ad,
                        Soyad = veri.Soyad,
                        TC = veri.TC,
                        OgrenciNo = veri.No,
                        DogumTarihi = new DateTime(2002, 1, 1).AddDays(new Random().Next(0, 1000)),
                        BolumId = bolumId,
                        DanismanId = akademisyenId,
                        KayitYili = 2024,
                        Sinif = 1,
                        Email = $"{veri.Ad.ToLower()}.{veri.Soyad.ToLower()}@universite.edu.tr",
                        Telefon = "555" + new Random().Next(1000000, 9999999).ToString(),
                        IsActive = true
                    };
                    context.Ogrenciler.Add(ogrenci);
                    eklenenOgrenciler.Add(ogrenci);
                }
                context.SaveChanges();

                // Tüm öğrencileri al (yeni ve eskiler)
                var tumOgrenciler = context.Ogrenciler.Where(o => o.BolumId == bolumId).ToList();

                // AI eğitimi için çeşitli not verileri oluştur
                var random = new Random(42); // Sabit seed, tutarlı sonuçlar için
                int notSayisi = 0;

                // Her öğrenci için her derse not ekle
                foreach (var ogrenci in tumOgrenciler)
                {
                    foreach (var ders in dersler)
                    {
                        // Bu öğrenci-ders kombinasyonu zaten varsa atla
                        if (context.OgrenciNotlari.Any(n => n.OgrenciId == ogrenci.Id && n.DersId == ders.Id))
                            continue;

                        // Rastgele ama gerçekçi notlar
                        int vize = random.Next(25, 95);  // 25-95 arası vize
                        int final;
                        
                        // Vize notuna göre final tahmini (gerçekçi korelasyon)
                        if (vize >= 70)
                            final = random.Next(60, 95);  // İyi öğrenci
                        else if (vize >= 50)
                            final = random.Next(40, 80);  // Orta öğrenci
                        else
                            final = random.Next(20, 60);  // Zayıf öğrenci

                        int? proje = random.Next(0, 10) > 3 ? random.Next(50, 100) : null; // %70 proje var

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
    }
}
