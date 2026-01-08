# 🎓 Üniversite Yönetim Sistemi (Okul Otomasyonu)

## 📋 Proje Hakkında

Bu proje, bir üniversitenin akademik ve idari süreçlerini dijitalleştirmek amacıyla geliştirilmiş, **Yapay Zeka (ML.NET)** destekli kapsamlı bir masaüstü otomasyon sistemidir. Sistem; yönetim, akademisyen ve öğrenci olmak üzere üç temel katmandan oluşur ve her rol için özelleştirilmiş paneller sunar.

## 🛠️ Kullanılan Teknolojiler

- **Framework:** .NET 9.0 (C#)
- **Arayüz:** DevExpress v25.1 (Premium Tasarım)
- **Yapay Zeka:** ML.NET (Makine Öğrenmesi ile Risk Analizi)
- **Veritabanı:** SQLite & Entity Framework Core 9.0
- **Mimari:** Unit of Work & Repository Pattern, Service Locator

## ✨ Temel Özellikler

### 🔐 Gelişmiş Güvenlik ve Rol Yönetimi
- **Rol Bazlı Erişim:** Admin, Akademisyen ve Öğrenci rolleri için dinamik yetkilendirme.
- **Profil Yönetimi:** Şifre değiştirme ve kullanıcı bilgilerini güncelleme imkanı.
- **Session Yönetimi:** Güvenli oturum takibi ve otomatik çıkış mekanizması.

### 🤖 Yapay Zeka Destekli Akademik Analiz (ML.NET)
- **Final Notu Tahmini:** Öğrencilerin vize ve proje notlarına dayalı olarak final sınavından alabilecekleri notu öngörür.
- **Akademik Risk Analizi:** Dersten kalma riski taşıyan öğrencileri (Düşük, Orta, Yüksek risk) sistem otomatik olarak belirler ve renk kodlarıyla raporlar.
- **Model Eğitimi:** Akademisyenler, güncel not verileriyle AI modelini panel üzerinden tek tıkla yeniden eğitebilir.

### 📝 Eğitim ve Not Yönetimi
- **Kapsamlı Not Sistemi:** Vize, Final, Bütünleme ve Proje notu girişleri.
- **Otomatik Hesaplama:** Ortalama ve Harf Notu (AA-FF) hesaplama motoru.
- **Transkript:** Öğrenciler için transkript görüntüleme ve PDF/Excel olarak dışa aktarma.

### 📋 Ders Kayıt ve Onay Sistemi
- **Öğrenci Talepleri:** Öğrenciler, bölümlerindeki dersler için kayıt talebi oluşturabilir.
- **Danışman Onayı:** Akademisyenler, kendilerine bağlı öğrencilerin ders taleplerini inceleyebilir, onaylayabilir veya ret notuyla reddedebilir.

### 📧 E-Posta Bildirim Sistemi
- **Otomatik Bildirimler:** Önemli güncellemelerde kullanıcılara e-posta gönderimi.
- **Esnek Yapılandırma:** Admin paneli üzerinden SMTP sunucu ve e-posta şablon ayarları.

## 📦 Proje Yapısı ve Formlar

### 🏢 Yönetim Formları (Admin)
- `OgrenciForm`: Detaylı öğrenci kayıt ve yönetim işlemleri.
- `AkademisyenForm`: Akademik personel atamaları ve unvan yönetimi.
- `BolumForm`: Fakülte ve bölüm yapılandırması.
- `DersForm`: Ders müfredatı ve hoca atamaları.
- `NotForm`: Üst düzey not müdahale ekranı.
- `KullaniciForm`: Sistem kullanıcıları ve yetki tanımları.
- `EmailAyarlariForm`: SMTP ve bildirim yapılandırması.

### 👨‍🏫 Akademik Paneller
- `AkademisyenPanelForm`: Ders yükü, öğrenci listeleri ve AI analizleri.
- `NotGirisDialog`: Hızlı ve güvenli not girişi pop-up arayüzü.

### 👨‍🎓 Öğrenci Panelleri
- `OgrenciPanelForm`: Ders notları, GNO takibi ve ders kayıt talebi ekranı.
- `SifreDegistirForm`: Kişisel hesap güvenliği ayarları.

## � Proje Mimarisi

```plaintext
OkulSistemOtomasyon/
├── 🤖 AI/                      # Yapay Zeka ve Makine Öğrenmesi Modülleri
│   ├── Models/                 # ML Veri Modelleri (Girdi/Çıktı)
│   ├── Services/               # MLModelService.cs (Tahmin Motoru)
│   └── TrainedModels/          # Eğitilmiş AI Modelleri (.zip)
├── 📊 Data/                    # Veritabanı Katmanı (EF Core)
│   ├── OkulDbContext.cs        # Veritabanı Bağlamı (Context)
│   └── DatabaseInitializer.cs  # DB Başlatma ve Seed Data
├── 📝 Models/                  # Veri Modelleri (Entities)
│   ├── Ogrenci.cs, Akademisyen.cs, Bolum.cs, Ders.cs, vb.
│   └── BaseEntity.cs           # Ortak Özellikler
├── 🏗️ Repositories/            # Veri Erişim Deseni (Unit of Work)
│   ├── IUnitOfWork.cs          # İş Birimi Arayüzü
│   └── UnitOfWork.cs           # Merkezi Repository Yönetimi
├── ⚙️ Services/                # İş Mantığı (Logic) Katmanı
│   ├── EmailService.cs         # E-Posta Bildirim Sistemi
│   ├── OgrenciService.cs, AkademisyenService.cs, vb.
│   └── DersKayitService.cs     # Kayıt ve Onay Mantığı
├── 🖥️ Forms/                    # Arayüz (UI) Katmanı (WinForms)
│   ├── MainForm.cs             # Ana Yönetim Paneli
│   ├── AkademisyenPanelForm.cs # Akademisyen İşlem Ekranı
│   ├── OgrenciPanelForm.cs     # Öğrenci Bilgi Ekranı
│   └── [CRUD Formları]         # Kayıt, Listeleme ve Düzenleme Ekranları
└── 🛠️ Helpers/                  # Yardımcı Sınıflar
    ├── SessionManager.cs       # Oturum ve Yetki Takibi
    ├── ServiceLocator.cs       # Bağımlılık Yönetimi (DI)
    └── ValidationHelper.cs     # Veri Doğrulama Motoru
```

## 📸 Ekran Görüntüleri
<img width="499" height="481" alt="Ekran Resmi 2026-01-07 18 25 37" src="https://github.com/user-attachments/assets/ec990434-f8e5-48a8-9346-f346d2a4c5ba" />
<img width="1411" height="796" alt="Ekran Resmi 2026-01-07 14 53 43" src="https://github.com/user-attachments/assets/c7ebcdcc-e272-4a7d-9ebc-d9718c13a114" />
<img width="1197" height="661" alt="Ekran Resmi 2026-01-07 14 48 02" src="https://github.com/user-attachments/assets/875a154c-1f34-4ee1-bcd9-d3a2943ffa55" />
<img width="1397" height="804" alt="Ekran Resmi 2026-01-07 18 19 06" src="https://github.com/user-attachments/assets/cd6e9565-aa55-4a38-9fe7-3d15f4ef4b83" />
<img width="602" height="887" alt="Ekran Resmi 2026-01-07 18 43 35" src="https://github.com/user-attachments/assets/233eab4b-0ab4-4925-af9f-5cc8dd8da7fa" />
## 🚀 Kurulum


1. Projeyi bilgisayarınıza klonlayın.
2. Visual Studio 2022 veya güncel bir IDE ile `.sln` dosyasını açın.
3. DevExpress v25.1 kütüphanelerinin kurulu olduğundan emin olun.
4. NuGet paketlerini geri yükleyin.
5. Projeyi derleyin; SQLite veritabanı ilk çalıştırmada otomatik olarak oluşturulacak ve örnek verilerle doldurulacaktır.

## 🔑 Varsayılan Girişler
- **Admin:** admin / admin123
- **Öğrenci:** 220201001 / 12345
- **Akademisyen:** ahmet.yilmaz / 12345

---
**Geliştirici:** Enis Uzun  
**Lisans:** Eğitim Amaçlı Üretilmiştir.
