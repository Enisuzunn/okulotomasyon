# Okul Sistem Otomasyonu

## Proje Hakkında

Bu proje, okul yönetimi için geliştirilmiş bir masaüstü uygulamasıdır. Öğrenci, öğretmen, sınıf, ders ve not yönetimi gibi temel okul işlemlerini yönetmek için tasarlanmıştır.

## Kullanılan Teknolojiler

- **.NET 9.0** - Windows Forms
- **DevExpress v25.1** - UI Komponentleri
- **Entity Framework Core 9.0** - ORM
- **SQLite** - Veritabanı
- **Visual Studio 2022** - IDE

## Özellikler

### 👨‍🎓 Öğrenci Yönetimi
- Öğrenci ekleme, güncelleme, silme
- TC Kimlik No doğrulama
- Sınıf ataması
- Detaylı öğrenci bilgileri (adres, telefon, email)

### 👨‍🏫 Öğretmen Yönetimi
- Öğretmen kayıt işlemleri
- Branş bilgileri
- İletişim bilgileri yönetimi

### 🏫 Sınıf Yönetimi
- Sınıf oluşturma ve düzenleme
- Seviye ve şube yönetimi
- Kontenjan takibi
- Ders yılı belirleme

### 📚 Ders Yönetimi
- Ders tanımlama
- Öğretmen atama
- Kredi ve dönem bilgileri

### 📝 Not Yönetimi
- Vize ve final not girişi
- Bütünleme sınavı
- Proje notu
- Otomatik ortalama hesaplama
- Harf notu dönüşümü

### 🔐 Kullanıcı Yönetimi
- Kullanıcı rolleri (Admin, Öğretmen, Kullanıcı)
- Güvenli giriş sistemi
- Oturum yönetimi

## Kurulum

### Gereksinimler
- Windows 10/11
- .NET 9.0 Runtime
- Visual Studio 2022 (geliştirme için)
- DevExpress Universal v25.1 lisansı

### Adımlar

1. **Repository'yi Klonlayın**
   ```bash
   git clone <repository-url>
   cd okulsistemotomasyon
   ```

2. **Solution'ı Açın**
   - Visual Studio 2022'de `OkulSistemOtomasyon.sln` dosyasını açın

3. **NuGet Paketlerini Yükleyin**
   - Visual Studio otomatik olarak gerekli paketleri yükleyecektir
   - Manuel yükleme için: `Tools > NuGet Package Manager > Restore NuGet Packages`

4. **Projeyi Derleyin ve Çalıştırın**
   - `F5` veya `Ctrl+F5` ile uygulamayı başlatın
   - İlk çalıştırmada veritabanı otomatik olarak oluşturulacaktır

## Varsayılan Giriş Bilgileri

**Kullanıcı Adı:** admin  
**Şifre:** admin123

## Veritabanı Konumu

Uygulama veritabanı varsayılan olarak şu konumda oluşturulur:
```
%LocalAppData%\OkulSistem\okulsistem.db
```

Windows'ta genellikle:
```
C:\Users\[KullaniciAdi]\AppData\Local\OkulSistem\okulsistem.db
```

## Proje Yapısı

```
OkulSistemOtomasyon/
├── Data/                  # Veritabanı context ve migrations
│   ├── OkulDbContext.cs
│   └── DatabaseInitializer.cs
├── Models/                # Entity modelleri
│   ├── Ogrenci.cs
│   ├── Ogretmen.cs
│   ├── Sinif.cs
│   ├── Ders.cs
│   ├── OgrenciNot.cs
│   └── Kullanici.cs
├── Forms/                 # UI Formları
│   ├── LoginForm.cs
│   ├── MainForm.cs
│   ├── OgrenciForm.cs
│   ├── OgretmenForm.cs
│   ├── SinifForm.cs
│   ├── DersForm.cs
│   ├── NotForm.cs
│   └── KullaniciForm.cs
├── Helpers/              # Yardımcı sınıflar
│   ├── SessionManager.cs
│   ├── ValidationHelper.cs
│   └── MessageHelper.cs
└── Properties/           # Uygulama kaynakları
    └── Resources.cs
```

## Veritabanı Şeması

### Tablolar
- **Ogrenciler** - Öğrenci bilgileri
- **Ogretmenler** - Öğretmen bilgileri
- **Siniflar** - Sınıf tanımları
- **Dersler** - Ders bilgileri
- **OgrenciNotlar** - Not kayıtları
- **Kullanicilar** - Sistem kullanıcıları

## Geliştirme Notları

### DevExpress Komponentleri
Projede kullanılan ana DevExpress komponentleri:
- **GridControl** - Veri listeleme
- **LayoutControl** - Form düzeni
- **LookUpEdit** - Dropdown seçim
- **RibbonControl** - Ana menü
- **SimpleButton** - Butonlar

### Entity Framework Core
- Code-First yaklaşımı kullanılmıştır
- Migration yerine `EnsureCreated()` kullanılmıştır (geliştirme aşaması)
- Lazy loading kapalıdır, `Include()` ile eager loading kullanılmaktadır

## Katkıda Bulunma

Bu proje bir okul ödevi olarak geliştirilmiştir. Önerileriniz için issue açabilirsiniz.

## Lisans

Bu proje eğitim amaçlı geliştirilmiştir.

## İletişim

Proje Sahibi: [Adınız]
Email: [Email adresiniz]

## Ekran Görüntüleri

*(Uygulamayı çalıştırdıktan sonra ekran görüntüleri eklenebilir)*

## Sürüm Geçmişi

### v1.0.0 (2024)
- İlk sürüm
- Temel CRUD işlemleri
- Öğrenci, öğretmen, sınıf, ders ve not yönetimi
- Kullanıcı giriş sistemi

## Bilinen Sorunlar

- Form designer dosyaları minimal düzeyde tutulmuştur
- SVG ikonlar için DevExpress kaynakları gereklidir
- Şifre hashleme henüz eklenmemiştir (üretim ortamında mutlaka eklenmelidir)

## Gelecek Geliştirmeler

- [ ] Şifre hashleme (BCrypt/SHA256)
- [ ] Rapor modülü
- [ ] Excel export/import
- [ ] Öğrenci devam takibi
- [ ] Veli bilgileri yönetimi
- [ ] Dashboard ve istatistikler
- [ ] Email bildirimleri
- [ ] Yedekleme/Geri yükleme

---

**Not:** Bu uygulama .NET 9.0 ve DevExpress v25.1 ile geliştirilmiştir. Çalıştırmak için bu teknolojilerin kurulu olması gerekmektedir.
