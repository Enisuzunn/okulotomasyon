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

                return (tumOgrenciler.Count, notSayisi);
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
        /// TEST amaçlı 8 öğrenci ekler (Algoritma Analizi dersine kayıtlı)
        /// Öğrenci numaraları "TEST" ile başlar, sonra kolayca silinebilir
        /// </summary>
        public static (int OgrenciSayisi, int NotSayisi, string Mesaj) TestOgrencileriEkle()
        {
            using (var context = new OkulDbContext())
            {
                // Algoritma Analizi dersini bul (veya benzeri)
                var ders = context.Dersler
                    .FirstOrDefault(d => d.DersAdi.Contains("Algoritma")) 
                    ?? context.Dersler.FirstOrDefault(d => d.IsActive);

                if (ders == null)
                {
                    return (0, 0, "Algoritma Analizi dersi bulunamadı! Önce ders ekleyin.");
                }

                // Bilgisayar Mühendisliği bölümünü bul
                var bolum = context.Bolumler.FirstOrDefault(b => b.BolumKodu == "BLM") 
                    ?? context.Bolumler.FirstOrDefault();

                if (bolum == null)
                {
                    return (0, 0, "Bölüm bulunamadı!");
                }

                // Danışman olarak herhangi bir akademisyen al
                var danisman = context.Akademisyenler.FirstOrDefault();

                // Zaten TEST öğrencisi varsa önce sil
                var mevcutTestOgrenciler = context.Ogrenciler
                    .Where(o => o.OgrenciNo != null && o.OgrenciNo.StartsWith("TEST"))
                    .ToList();
                
                if (mevcutTestOgrenciler.Any())
                {
                    // Önce notlarını sil
                    var mevcutIdler = mevcutTestOgrenciler.Select(o => o.Id).ToList();
                    var mevcutNotlar = context.OgrenciNotlari
                        .Where(n => mevcutIdler.Contains(n.OgrenciId))
                        .ToList();
                    context.OgrenciNotlari.RemoveRange(mevcutNotlar);
                    
                    // Sonra öğrencileri sil
                    context.Ogrenciler.RemoveRange(mevcutTestOgrenciler);
                    context.SaveChanges();
                }

                var random = new Random();
                var testOgrenciler = new List<Models.Ogrenci>();
                
                // 16 test öğrencisi oluştur
                // 12 tane Vize+Final (model eğitimi için)
                // 4 tane sadece Vize (final tahmini yapılacak)
                var ogrenciBilgileri = new[]
                {
                    // VİZE + FİNAL OLAN (12 öğrenci) - Model eğitimi için
                    ("Ahmet", "Yüksek", "11111111111"),    // Yüksek notlar - Geçti
                    ("Ayşe", "Başarılı", "22222222222"),   // Yüksek notlar - Geçti
                    ("Mehmet", "İyi", "33333333333"),      // İyi notlar - Geçti
                    ("Fatma", "Orta", "44444444444"),      // Orta notlar - Geçti
                    ("Ali", "Normal", "55555555555"),      // Orta notlar - Geçti
                    ("Zeynep", "Sınırda", "66666666666"),  // Sınır notlar - Geçti
                    ("Mustafa", "Zayıf", "77777777777"),   // Düşük notlar - Kaldı
                    ("Elif", "Düşük", "88888888888"),      // Düşük notlar - Kaldı
                    ("Can", "Başarısız", "99999999999"),   // Çok düşük - Kaldı
                    ("Ece", "Kötü", "12121212121"),        // Çok düşük - Kaldı
                    ("Burak", "Karışık", "13131313131"),   // Orta - Kaldı
                    ("Selin", "Değişken", "14141414141"),  // Orta - Geçti
                    
                    // SADECE VİZE OLAN (4 öğrenci) - Final tahmini yapılacak
                    ("Emre", "Bekleyen", "15151515151"),   // Yüksek vize
                    ("Deniz", "Merak", "16161616161"),     // Orta vize
                    ("Ceren", "Tahmin", "17171717171"),    // Düşük vize
                    ("Kaan", "Test", "18181818181")        // Çok düşük vize
                };

                for (int i = 0; i < 16; i++)
                {
                    var ogrenci = new Models.Ogrenci
                    {
                        Ad = ogrenciBilgileri[i].Item1,
                        Soyad = ogrenciBilgileri[i].Item2,
                        TC = ogrenciBilgileri[i].Item3,
                        OgrenciNo = $"TEST{(i + 1):D3}", // TEST001, TEST002, ...
                        DogumTarihi = new DateTime(2000 + random.Next(0, 5), random.Next(1, 13), random.Next(1, 28)),
                        Email = $"test{i + 1}@universite.edu.tr",
                        Telefon = $"555000000{i + 1}",
                        BolumId = bolum.BolumId,
                        DanismanId = danisman?.Id,
                        Sinif = random.Next(1, 5),
                        KayitYili = 2024,
                        IsActive = true,
                        CreatedDate = DateTime.Now
                    };
                    testOgrenciler.Add(ogrenci);
                }

                context.Ogrenciler.AddRange(testOgrenciler);
                context.SaveChanges();

                // Her öğrenci için Algoritma Analizi dersine not kaydı oluştur
                int notSayisi = 0;
                int ogrenciIndex = 0;

                foreach (var ogrenci in testOgrenciler)
                {
                    ogrenciIndex++;
                    
                    int? vize = null;
                    int? final = null;
                    int? proje = null;

                    // 12 tane Vize+Final (eğitim), 4 tane sadece Vize (tahmin)
                    switch (ogrenciIndex)
                    {
                        // VİZE + FİNAL (12 öğrenci) - Model eğitimi için
                        // Geçenler (çeşitli notlarla)
                        case 1: vize = 90; final = 95; proje = 92; break;  // Ort: 93 - Geçti
                        case 2: vize = 85; final = 88; proje = 86; break;  // Ort: 86.8 - Geçti
                        case 3: vize = 75; final = 80; proje = 78; break;  // Ort: 78 - Geçti
                        case 4: vize = 65; final = 70; proje = 68; break;  // Ort: 68 - Geçti
                        case 5: vize = 55; final = 65; proje = 60; break;  // Ort: 61 - Geçti
                        case 6: vize = 50; final = 55; proje = 52; break;  // Ort: 53 - Geçti
                        // Kalanlar (çeşitli notlarla)
                        case 7: vize = 45; final = 40; proje = 42; break;  // Ort: 42 - Kaldı
                        case 8: vize = 40; final = 45; proje = 43; break;  // Ort: 43 - Kaldı
                        case 9: vize = 35; final = 35; proje = 35; break;  // Ort: 35 - Kaldı
                        case 10: vize = 30; final = 40; proje = 35; break; // Ort: 36 - Kaldı
                        case 11: vize = 50; final = 45; proje = 48; break; // Ort: 47 - Kaldı
                        case 12: vize = 60; final = 55; proje = 58; break; // Ort: 57 - Geçti
                        
                        // SADECE VİZE (4 öğrenci) - Final tahmini yapılacak
                        case 13: vize = 85; proje = 88; break;  // Yüksek vize → Tahminen geçer
                        case 14: vize = 55; proje = 60; break;  // Orta vize → Belirsiz
                        case 15: vize = 40; proje = 45; break;  // Düşük vize → Tahminen kalır
                        case 16: vize = 25; proje = null; break; // Çok düşük → Büyük risk
                    }

                    var not = new Models.OgrenciNot
                    {
                        OgrenciId = ogrenci.Id,
                        DersId = ders.Id,
                        Vize = vize,
                        Final = final,
                        ProjeNotu = proje,
                        NotGirisTarihi = vize.HasValue ? DateTime.Now : (DateTime?)null,
                        IsActive = true
                    };
                    context.OgrenciNotlari.Add(not);
                    notSayisi++;
                }

                context.SaveChanges();

                return (16, notSayisi, $"✅ 16 TEST öğrencisi '{ders.DersAdi}' dersine kaydedildi.\n\n" +
                    "📚 Eğitim Verisi (Vize+Final): TEST001-TEST012 (12 kayıt)\n" +
                    "   - Geçenler: TEST001-TEST006, TEST012\n" +
                    "   - Kalanlar: TEST007-TEST011\n\n" +
                    "🔮 Tahmin Yapılacak (Sadece Vize): TEST013-TEST016 (4 kayıt)");
            }
        }

        /// <summary>
        /// TEST öğrencilerini ve notlarını siler
        /// </summary>
        public static (int SilinenOgrenci, int SilinenNot) TestOgrencileriSil()
        {
            using (var context = new OkulDbContext())
            {
                // TEST ile başlayan öğrencileri bul
                var testOgrenciler = context.Ogrenciler
                    .Where(o => o.OgrenciNo != null && o.OgrenciNo.StartsWith("TEST"))
                    .ToList();

                if (!testOgrenciler.Any())
                    return (0, 0);

                // Önce notlarını sil
                var ogrenciIdler = testOgrenciler.Select(o => o.Id).ToList();
                var notlar = context.OgrenciNotlari
                    .Where(n => ogrenciIdler.Contains(n.OgrenciId))
                    .ToList();
                
                int silinenNot = notlar.Count;
                context.OgrenciNotlari.RemoveRange(notlar);

                // Sonra öğrencileri sil
                context.Ogrenciler.RemoveRange(testOgrenciler);
                context.SaveChanges();

                return (testOgrenciler.Count, silinenNot);
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
