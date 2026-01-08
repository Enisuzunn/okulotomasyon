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

## 📸 Ekran Görüntüleri

<table border="0">
  <tr>
    <td><img src="https://github.com/user-attachments/assets/a8f03d85-5171-4b92-9d34-2fa6021dd45d" width="400" alt="Giriş Ekranı" /><br/><sub><i>Giriş Ekranı</i></sub></td>
    <td><img src="https://github.com/user-attachments/assets/99e0cbb5-3e5a-412a-87c2-1571f47be538" width="400" alt="Yönetici Paneli" /><br/><sub><i>Yönetici Paneli (Ribbon UI)</i></sub></td>
  </tr>
  <tr>
    <td><img src="https://github.com/user-attachments/assets/4677a138-af72-4171-b5b6-406eda65a2e0" width="400" alt="Akademisyen Paneli" /><br/><sub><i>Akademisyen Analiz Paneli</i></sub></td>
    <td><img src="https://github.com/user-attachments/assets/735f1251-7f71-4ec4-8172-0093cd544016" width="400" alt="Öğrenci Paneli" /><br/><sub><i>Öğrenci Başarı Takip Sistemi</i></sub></td>
  </tr>
  <tr>
    <td colspan="2" align="center"><img src="https://github.com/user-attachments/assets/bc27c455-d353-4ba8-a058-8f0926b97a71" width="800" alt="AI Tahmin Sistemi" /><br/><sub><i>Yapay Zeka Destekli Final Tahmini ve Risk Analiz Grafiği</i></sub></td>
  </tr>
</table>

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
