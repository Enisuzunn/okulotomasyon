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
                // random değişkeni yukarıda zaten tanımlı

                foreach (var ogrenci in testOgrenciler)
                {
                    ogrenciIndex++;
                    
                    int? vize = null;
                    int? final = null;
                    int? proje = null;

                    // 12 tane Vize+Final (eğitim), 4 tane sadece Vize (tahmin)
                    // RASTGELE NOTLAR
                    if (ogrenciIndex <= 6)
                    {
                        // Geçenler (yüksek notlar) - 6 öğrenci
                        vize = random.Next(55, 95);
                        final = random.Next(55, 95);
                        proje = random.Next(0, 10) > 3 ? random.Next(50, 95) : (int?)null;
                    }
                    else if (ogrenciIndex <= 12)
                    {
                        // Kalanlar (düşük notlar) - 6 öğrenci
                        vize = random.Next(20, 55);
                        final = random.Next(20, 55);
                        proje = random.Next(0, 10) > 5 ? random.Next(20, 60) : (int?)null;
                    }
                    else
                    {
                        // Sadece Vize (tahmin yapılacak) - 4 öğrenci
                        switch (ogrenciIndex)
                        {
                            case 13: vize = random.Next(75, 95); proje = random.Next(70, 95); break;  // Yüksek
                            case 14: vize = random.Next(50, 70); proje = random.Next(45, 70); break;  // Orta
                            case 15: vize = random.Next(35, 50); proje = random.Next(30, 55); break;  // Düşük
                            case 16: vize = random.Next(15, 35); proje = null; break;                  // Çok düşük
                        }
                        final = null; // Final yok - tahmin yapılacak
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
        /// Tüm bölümlere öğrenci ve ders ekler (Kapsamlı demo verisi)
        /// </summary>
        public static (int OgrenciSayisi, int DersSayisi, int AkademisyenSayisi, string Mesaj) TumBolumlereVeriEkle()
        {
            using (var context = new OkulDbContext())
            {
                var random = new Random();
                int toplamOgrenci = 0;
                int toplamDers = 0;
                int toplamAkademisyen = 0;

                // Bölümleri al
                var bolumler = context.Bolumler.ToList();
                if (!bolumler.Any())
                {
                    return (0, 0, 0, "Bölüm bulunamadı!");
                }

                // Her bölüm için akademisyen, ders ve öğrenci verileri
                var bolumVerileri = new Dictionary<string, (string[] Akademisyenler, string[] Dersler, string[] Ogrenciler)>
                {
                    ["BLM"] = (
                        new[] { "Prof. Dr. Ahmet Yılmaz", "Doç. Dr. Mehmet Demir", "Dr. Öğr. Üyesi Ayşe Kaya" },
                        new[] { 
                            "Algoritma ve Programlama|BLM101|4|6",
                            "Veri Yapıları|BLM201|4|6",
                            "Veritabanı Yönetimi|BLM301|3|5",
                            "Yapay Zeka|BLM401|3|5",
                            "Bilgisayar Ağları|BLM302|3|5"
                        },
                        new[] { 
                            "Enes Uzun|12345678901", "Burak Kılıç|12345678902", "Zeynep Yıldız|12345678903",
                            "Emre Çelik|12345678904", "Selin Aydın|12345678905", "Kaan Öztürk|12345678906",
                            "Elif Şahin|12345678907", "Can Arslan|12345678908"
                        }
                    ),
                    ["EEM"] = (
                        new[] { "Prof. Dr. Hasan Koç", "Doç. Dr. Fatma Güneş" },
                        new[] { 
                            "Devre Analizi|EEM101|4|6",
                            "Elektronik|EEM201|4|6",
                            "Sinyal İşleme|EEM301|3|5",
                            "Güç Elektroniği|EEM401|3|5"
                        },
                        new[] { 
                            "Mert Yılmaz|22345678901", "Deniz Kara|22345678902", "Ceren Ak|22345678903",
                            "Oğuz Polat|22345678904", "Buse Erdoğan|22345678905", "Alp Korkmaz|22345678906"
                        }
                    ),
                    ["ISL"] = (
                        new[] { "Prof. Dr. Ali Veli", "Dr. Öğr. Üyesi Sema Özkan" },
                        new[] { 
                            "Genel İşletme|ISL101|3|5",
                            "Pazarlama|ISL201|3|5",
                            "Muhasebe|ISL301|4|6",
                            "Finansal Yönetim|ISL401|3|5"
                        },
                        new[] { 
                            "Gökhan Tan|32345678901", "Melis Yurt|32345678902", "Serkan Bal|32345678903",
                            "Aylin Koç|32345678904", "Umut Yavuz|32345678905"
                        }
                    ),
                    ["MAK"] = (
                        new[] { "Prof. Dr. Kemal Ateş", "Doç. Dr. Sibel Tunç" },
                        new[] { 
                            "Statik|MAK101|4|6",
                            "Dinamik|MAK201|4|6",
                            "Termodinamik|MAK301|4|6",
                            "Makine Elemanları|MAK401|3|5"
                        },
                        new[] { 
                            "Yusuf Güler|42345678901", "Pınar Kurt|42345678902", "Onur Çakır|42345678903",
                            "Eda Sezer|42345678904", "Tolga Acar|42345678905", "Nil Ünal|42345678906"
                        }
                    ),
                    ["HUK"] = (
                        new[] { "Prof. Dr. Mustafa Eren", "Dr. Öğr. Üyesi Leyla Sarı" },
                        new[] { 
                            "Anayasa Hukuku|HUK101|4|6",
                            "Medeni Hukuk|HUK201|4|6",
                            "Ceza Hukuku|HUK301|4|6",
                            "Ticaret Hukuku|HUK401|3|5"
                        },
                        new[] { 
                            "Barış Şen|52345678901", "Dilara Kaplan|52345678902", "Cem Aslan|52345678903",
                            "İrem Doğan|52345678904", "Tuna Bozkurt|52345678905"
                        }
                    )
                };

                foreach (var bolum in bolumler)
                {
                    if (!bolumVerileri.ContainsKey(bolum.BolumKodu ?? ""))
                        continue;

                    var veri = bolumVerileri[bolum.BolumKodu!];

                    // 1. AKADEMİSYENLER EKLE
                    var eklenenAkademisyenler = new List<Models.Akademisyen>();
                    foreach (var akdStr in veri.Akademisyenler)
                    {
                        var parcalar = akdStr.Split(' ');
                        string unvan = string.Join(" ", parcalar.Take(parcalar.Length - 2));
                        string ad = parcalar[^2];
                        string soyad = parcalar[^1];
                        string email = $"{ad.ToLower().Replace("ı", "i").Replace("ğ", "g").Replace("ü", "u").Replace("ş", "s").Replace("ö", "o").Replace("ç", "c")}.{soyad.ToLower().Replace("ı", "i").Replace("ğ", "g").Replace("ü", "u").Replace("ş", "s").Replace("ö", "o").Replace("ç", "c")}@firat.edu.tr";
                        string kullaniciAdi = $"{ad.ToLower().Replace("ı", "i").Replace("ğ", "g").Replace("ü", "u").Replace("ş", "s").Replace("ö", "o").Replace("ç", "c")}.{soyad.ToLower().Replace("ı", "i").Replace("ğ", "g").Replace("ü", "u").Replace("ş", "s").Replace("ö", "o").Replace("ç", "c")}";

                        // Zaten varsa ekleme (Ad+Soyad veya Email kontrolü)
                        var mevcutAkademisyen = context.Akademisyenler
                            .FirstOrDefault(a => (a.Ad == ad && a.Soyad == soyad) || a.Email == email);
                        
                        if (mevcutAkademisyen != null)
                        {
                            eklenenAkademisyenler.Add(mevcutAkademisyen);
                            continue;
                        }

                        var akademisyen = new Models.Akademisyen
                        {
                            Ad = ad,
                            Soyad = soyad,
                            Unvan = unvan,
                            Email = email,
                            Telefon = $"0424 237 00 {random.Next(10, 99)}",
                            BolumId = bolum.BolumId,
                            IsActive = true,
                            CreatedDate = DateTime.Now
                        };
                        context.Akademisyenler.Add(akademisyen);
                        context.SaveChanges();
                        eklenenAkademisyenler.Add(akademisyen);
                        toplamAkademisyen++;
                    }

                    // Akademisyenler için kullanıcı oluştur
                    foreach (var akd in eklenenAkademisyenler)
                    {
                        string akdKullaniciAdi = $"{akd.Ad.ToLower().Replace("ı", "i").Replace("ğ", "g").Replace("ü", "u").Replace("ş", "s").Replace("ö", "o").Replace("ç", "c")}.{akd.Soyad.ToLower().Replace("ı", "i").Replace("ğ", "g").Replace("ü", "u").Replace("ş", "s").Replace("ö", "o").Replace("ç", "c")}";
                        
                        // Hem AkademisyenId hem KullaniciAdi kontrolü
                        if (!context.Kullanicilar.Any(k => k.AkademisyenId == akd.Id || k.KullaniciAdi == akdKullaniciAdi))
                        {
                            var kullanici = new Models.Kullanici
                            {
                                KullaniciAdi = akdKullaniciAdi,
                                Sifre = "123456",
                                Ad = akd.Ad,
                                Soyad = akd.Soyad,
                                Email = akd.Email,
                                Rol = Models.KullaniciRolu.Akademisyen,
                                AkademisyenId = akd.Id,
                                IlkGiris = true,
                                Aktif = true
                            };
                            context.Kullanicilar.Add(kullanici);
                        }
                    }
                    context.SaveChanges();

                    // 2. DERSLER EKLE
                    var eklenenDersler = new List<Models.Ders>();
                    int dersIndex = 0;
                    foreach (var dersStr in veri.Dersler)
                    {
                        var parcalar = dersStr.Split('|');
                        string dersAdi = parcalar[0];
                        string dersKodu = parcalar[1];
                        int kredi = int.Parse(parcalar[2]);
                        int akts = int.Parse(parcalar[3]);

                        // Zaten varsa ekleme
                        if (context.Dersler.Any(d => d.DersKodu == dersKodu))
                        {
                            var mevcut = context.Dersler.First(d => d.DersKodu == dersKodu);
                            eklenenDersler.Add(mevcut);
                            continue;
                        }

                        // Akademisyenleri sırayla ata
                        var atananAkademisyen = eklenenAkademisyenler[dersIndex % eklenenAkademisyenler.Count];

                        var ders = new Models.Ders
                        {
                            DersAdi = dersAdi,
                            DersKodu = dersKodu,
                            Kredi = kredi,
                            AKTS = akts,
                            BolumId = bolum.BolumId,
                            AkademisyenId = atananAkademisyen.Id,
                            DonemBilgisi = dersIndex % 2 == 0 ? "Güz Dönemi" : "Bahar Dönemi",
                            IsActive = true,
                            CreatedDate = DateTime.Now
                        };
                        context.Dersler.Add(ders);
                        eklenenDersler.Add(ders);
                        toplamDers++;
                        dersIndex++;
                    }
                    context.SaveChanges();

                    // 3. ÖĞRENCİLER EKLE
                    var eklenenOgrenciler = new List<Models.Ogrenci>();
                    int ogrenciNo = 1;
                    foreach (var ogrStr in veri.Ogrenciler)
                    {
                        var parcalar = ogrStr.Split('|');
                        string adSoyad = parcalar[0];
                        string tc = parcalar[1];
                        var adParcalar = adSoyad.Split(' ');
                        string ad = adParcalar[0];
                        string soyad = adParcalar[1];
                        string ogrenciNoStr = $"{bolum.BolumKodu}{DateTime.Now.Year % 100}{ogrenciNo:D3}";
                        string ogrEmail = $"{ad.ToLower().Replace("ı", "i").Replace("ğ", "g").Replace("ü", "u").Replace("ş", "s").Replace("ö", "o").Replace("ç", "c")}.{soyad.ToLower().Replace("ı", "i").Replace("ğ", "g").Replace("ü", "u").Replace("ş", "s").Replace("ö", "o").Replace("ç", "c")}@ogrenci.firat.edu.tr";

                        // Zaten varsa ekleme (TC, OgrenciNo veya Email kontrolü)
                        if (context.Ogrenciler.Any(o => o.TC == tc || o.OgrenciNo == ogrenciNoStr || o.Email == ogrEmail))
                        {
                            ogrenciNo++;
                            continue;
                        }

                        // İlk akademisyeni danışman olarak ata
                        var danisman = eklenenAkademisyenler.FirstOrDefault();

                        var ogrenci = new Models.Ogrenci
                        {
                            Ad = ad,
                            Soyad = soyad,
                            TC = tc,
                            OgrenciNo = ogrenciNoStr,
                            DogumTarihi = new DateTime(2000 + random.Next(0, 5), random.Next(1, 13), random.Next(1, 28)),
                            Email = ogrEmail,
                            Telefon = $"05{random.Next(30, 60)}000{random.Next(1000, 9999)}",
                            BolumId = bolum.BolumId,
                            DanismanId = danisman?.Id,
                            Sinif = random.Next(1, 5),
                            KayitYili = DateTime.Now.Year,
                            IsActive = true,
                            CreatedDate = DateTime.Now
                        };
                        context.Ogrenciler.Add(ogrenci);
                        eklenenOgrenciler.Add(ogrenci);
                        toplamOgrenci++;
                        ogrenciNo++;
                    }
                    context.SaveChanges();

                    // Öğrenciler için kullanıcı oluştur
                    foreach (var ogr in eklenenOgrenciler)
                    {
                        string ogrKullaniciAdi = ogr.OgrenciNo ?? $"{ogr.Ad.ToLower()}{ogr.Id}";
                        
                        // Hem OgrenciId hem KullaniciAdi kontrolü
                        if (!context.Kullanicilar.Any(k => k.OgrenciId == ogr.Id || k.KullaniciAdi == ogrKullaniciAdi))
                        {
                            var kullanici = new Models.Kullanici
                            {
                                KullaniciAdi = ogrKullaniciAdi,
                                Sifre = "123456",
                                Ad = ogr.Ad,
                                Soyad = ogr.Soyad,
                                Email = ogr.Email,
                                Rol = Models.KullaniciRolu.Ogrenci,
                                OgrenciId = ogr.Id,
                                IlkGiris = true,
                                Aktif = true
                            };
                            context.Kullanicilar.Add(kullanici);
                        }
                    }
                    context.SaveChanges();

                    // 4. NOTLAR EKLE (Her öğrenci için 2-3 derse not)
                    foreach (var ogrenci in eklenenOgrenciler)
                    {
                        // Rastgele 2-3 ders seç
                        var seciliDersler = eklenenDersler.OrderBy(x => random.Next()).Take(random.Next(2, 4)).ToList();
                        
                        foreach (var ders in seciliDersler)
                        {
                            // Zaten not varsa ekleme
                            if (context.OgrenciNotlari.Any(n => n.OgrenciId == ogrenci.Id && n.DersId == ders.Id))
                                continue;

                            int? vize = random.Next(30, 100);
                            int? final = random.Next(0, 10) > 2 ? random.Next(30, 100) : null; // %70 final var
                            int? proje = random.Next(0, 10) > 5 ? random.Next(40, 100) : null;

                            var not = new Models.OgrenciNot
                            {
                                OgrenciId = ogrenci.Id,
                                DersId = ders.Id,
                                Vize = vize,
                                Final = final,
                                ProjeNotu = proje,
                                NotGirisTarihi = DateTime.Now.AddDays(-random.Next(1, 60)),
                                IsActive = true
                            };
                            context.OgrenciNotlari.Add(not);
                        }
                    }
                    context.SaveChanges();
                }

                return (toplamOgrenci, toplamDers, toplamAkademisyen, 
                    $"✅ Veriler başarıyla eklendi!\n\n" +
                    $"👨‍🏫 {toplamAkademisyen} akademisyen\n" +
                    $"📚 {toplamDers} ders\n" +
                    $"👨‍🎓 {toplamOgrenci} öğrenci\n\n" +
                    $"📧 Tüm kullanıcı şifresi: 123456");
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
