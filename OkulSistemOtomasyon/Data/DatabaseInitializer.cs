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

                // Zaten TEST öğrencisi var mı kontrol et
                if (context.Ogrenciler.Any(o => o.OgrenciNo != null && o.OgrenciNo.StartsWith("TEST")))
                {
                    return (0, 0, "TEST öğrencileri zaten mevcut! Önce silmeniz gerekiyor.");
                }

                var random = new Random();
                var testOgrenciler = new List<Models.Ogrenci>();
                
                // 8 test öğrencisi oluştur
                var ogrenciBilgileri = new[]
                {
                    ("Ahmet", "Test", "11111111111"),
                    ("Mehmet", "Deneme", "22222222222"),
                    ("Ayşe", "Örnek", "33333333333"),
                    ("Fatma", "Sınav", "44444444444"),
                    ("Ali", "Kontrol", "55555555555"),
                    ("Zeynep", "Demo", "66666666666"),
                    ("Mustafa", "Trial", "77777777777"),
                    ("Elif", "Sample", "88888888888")
                };

                for (int i = 0; i < 8; i++)
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
                    
                    int vize;
                    int? proje = null;

                    // Çeşitli vize notları (AI testi için farklı senaryolar)
                    switch (ogrenciIndex)
                    {
                        case 1: vize = 85; proje = 90; break;  // Yüksek
                        case 2: vize = 72; proje = 75; break;  // Orta-Yüksek
                        case 3: vize = 55; proje = 60; break;  // Orta
                        case 4: vize = 45; proje = 50; break;  // Orta-Düşük (Riskli)
                        case 5: vize = 35; proje = 40; break;  // Düşük (Yüksek Risk)
                        case 6: vize = 25; proje = null; break; // Çok düşük (Proje yok)
                        case 7: vize = 60; proje = null; break; // Orta (Proje yok)
                        case 8: vize = 90; proje = 95; break;  // Çok yüksek
                        default: vize = 50; break;
                    }

                    var not = new Models.OgrenciNot
                    {
                        OgrenciId = ogrenci.Id,
                        DersId = ders.Id,
                        Vize = vize,
                        Final = null, // Final henüz girilmedi (tahmin yapılacak)
                        ProjeNotu = proje,
                        NotGirisTarihi = DateTime.Now,
                        IsActive = true
                    };
                    context.OgrenciNotlari.Add(not);
                    notSayisi++;
                }

                context.SaveChanges();

                return (8, notSayisi, $"✅ 8 TEST öğrencisi '{ders.DersAdi}' dersine kaydedildi.\nÖğrenci No: TEST001 - TEST008");
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
