# Üniversite Sistem Otomasyonu

## Proje Hakkında

Bu proje, üniversite yönetimi için geliştirilmiş kapsamlı bir masaüstü uygulamasıdır. Öğrenci, akademisyen, bölüm, ders ve not yönetimi gibi temel üniversite işlemlerini yönetmek için tasarlanmıştır.

## Kullanılan Teknolojiler

- **.NET 9.0** - Windows Forms
- **DevExpress v25.1** - UI Komponentleri
- **Entity Framework Core 9.0** - ORM
- **SQLite** - Veritabanı
- **Visual Studio 2022** - IDE

## Özellikler

### 👨‍🎓 Öğrenci Yönetimi

- Öğrenci ekleme, güncelleme, silme
- TC Kimlik No doğrulama (11 haneli)
- Öğrenci numarası otomatik oluşturma
- Bölüm ataması
- Detaylı öğrenci bilgileri (adres, telefon, email)
- Kayıt tarihi takibi

### 👨‍🏫 Akademisyen Yönetimi

- Akademisyen kayıt işlemleri
- Ünvan bilgileri (Prof. Dr., Doç. Dr., Dr. Öğr. Üyesi vb.)
- Uzmanlık alanı tanımlama
- İletişim bilgileri yönetimi
- TC Kimlik No doğrulama

### 🏫 Bölüm Yönetimi

- Bölüm oluşturma ve düzenleme
- Bölüm kodu ve adı tanımlama
- Aktif/Pasif durum yönetimi
- Bölüme bağlı öğrenci ve ders listeleme

### 📚 Ders Yönetimi

- Ders tanımlama ve düzenleme
- Ders kodu sistemi
- Akademisyen atama
- Bölüm bazlı ders yönetimi
- Kredi bilgileri
- Dönem ve zorunlu/seçmeli durum belirleme

### 📝 Not Yönetimi

- Vize ve final not girişi
- Bütünleme sınavı notu
- Proje/Ödev notu
- Otomatik ortalama hesaplama
- Harf notu dönüşümü (AA, BA, BB, CB, CC, DC, DD, FD, FF)
- Geçti/Kaldı durumu
- Öğrenci bazlı not sorgulama

### 🔐 Kullanıcı Yönetimi ve Rol Bazlı Paneller

- **Kullanıcı Rolleri:** Admin, Akademisyen, Öğrenci
- **Admin Paneli:** Tüm sistem yönetimi (öğrenci, akademisyen, bölüm, ders, not, kullanıcı)
- **Akademisyen Paneli:** 
  - Verdiği dersleri görüntüleme
  - Kayıtlı öğrencileri listeleme
  - Not girişi (Vize, Final, Bütünleme, Proje)
  - Öğrenci notlarını güncelleme
- **Öğrenci Paneli:**
  - Aldığı dersleri ve notlarını görüntüleme
  - **GNO Hesaplama:** Dönemlik ve genel başarı takibi
- **Yazdır/Dışa Aktar:** Transkript ve not çizelgelerini PDF/Excel formatında alma

### 🤖 Yapay Zeka (AI) Destekli Analizler

Akademisyen paneline entegre edilmiş Makine Öğrenmesi (ML) modülü sayesinde:
- **Final Notu Tahmini:** Vize ve proje notlarından yola çıkarak tahmini final başarısı öngörülür.
- **Akademik Risk Analizi:** Öğrencilerin dersten kalma riskleri (Düşük, Orta, Yüksek) anlık hesaplanır.
- **Eğitilebilir Model:** Akademisyenler, gelişen verilerle AI modelini panelden yeniden eğitebilir.
- Güvenli giriş sistemi
- Oturum yönetimi (SessionManager)
- Kullanıcı ekleme, düzenleme, silme
- Aktif/Pasif durum kontrolü

## Kurulum

### Gereksinimler

- Windows 10/11
- .NET 9.0 Runtime
- Visual Studio 2022 (geliştirme için)
- DevExpress Universal v25.1 lisansı

### Adımlar

1. **Repository'yi Klonlayın**

   ```bash
   git clone https://github.com/Enisuzunn/okulotomasyon.git
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

### 👨‍💼 Admin (Yönetici)
**Kullanıcı Adı:** admin  
**Şifre:** admin123

### 👨‍🏫 Akademisyen
**Kullanıcı Adı:** ahmet.yilmaz  
**Şifre:** 12345

### 🎓 Öğrenci
**Kullanıcı Adı:** 220201001  
**Şifre:** 12345

## Veritabanı Konumu

Uygulama veritabanı varsayılan olarak şu konumda oluşturulur:

**Windows:**

```plaintext
C:\Users\[KullaniciAdi]\AppData\Local\OkulSistem\universite.db
```

**Kısa yol ile erişim:**

- Windows + R tuşlarına basın
- `%LocalAppData%\OkulSistem` yazıp Enter'a basın
- `universite.db` dosyasını göreceksiniz

**Not:** `AppData` klasörü gizli bir klasördür. Windows Gezgini'nde Görünüm → Gizli öğeler kutusunu işaretleyerek görebilirsiniz.

## Proje Yapısı

```plaintext
OkulSistemOtomasyon/
├── Data/                      # Veritabanı context ve initialization
│   ├── OkulDbContext.cs      # Entity Framework DbContext
│   └── DatabaseInitializer.cs # Veritabanı başlatma ve seed data
├── Models/                    # Entity modelleri
│   ├── Ogrenci.cs            # Öğrenci entity
│   ├── Akademisyen.cs        # Akademisyen entity
│   ├── Bolum.cs              # Bölüm entity
│   ├── Ders.cs               # Ders entity
│   ├── OgrenciNot.cs         # Not entity
│   └── Kullanici.cs          # Kullanıcı entity
├── Forms/                     # UI Formları (Windows Forms)
│   ├── LoginForm.cs          # Giriş formu (Rol bazlı yönlendirme)
│   ├── MainForm.cs           # Ana form - Admin paneli (Ribbon menü)
│   ├── AkademisyenPanelForm.cs # Akademisyen paneli (Not girişi)
│   ├── OgrenciPanelForm.cs   # Öğrenci paneli (Not görüntüleme)
│   ├── NotGirisDialog.cs     # Not giriş/güncelleme dialog
│   ├── OgrenciForm.cs        # Öğrenci yönetim formu
│   ├── AkademisyenForm.cs    # Akademisyen yönetim formu
│   ├── BolumForm.cs          # Bölüm yönetim formu
│   ├── DersForm.cs           # Ders yönetim formu
│   ├── NotForm.cs            # Not yönetim formu (Admin)
│   └── KullaniciForm.cs      # Kullanıcı yönetim formu
├── Helpers/                   # Yardımcı sınıflar
│   ├── SessionManager.cs     # Oturum yönetimi
│   ├── ValidationHelper.cs   # Doğrulama işlemleri
│   └── MessageHelper.cs      # Mesaj gösterimi
└── Properties/                # Uygulama kaynakları
    └── Resources.cs          # Kaynak dosyaları
```

## Veritabanı Şeması

### Tablolar

- **Ogrenciler** - Öğrenci bilgileri (TC, Ad, Soyad, OgrenciNo, BolumId, vb.)
- **Akademisyenler** - Akademisyen bilgileri (TC, Ad, Soyad, Unvan, UzmanlikAlani, vb.)
- **Bolumler** - Bölüm tanımları (BolumAdi, BolumKodu, Aktif)
- **Dersler** - Ders bilgileri (DersAdi, DersKodu, Kredi, BolumId, AkademisyenId, vb.)
- **OgrenciNotlar** - Not kayıtları (OgrenciId, DersId, Vize, Final, Butunleme, Proje, vb.)
- **Kullanicilar** - Sistem kullanıcıları (KullaniciAdi, Sifre, Rol, Email, vb.)

### İlişkiler

- Öğrenci → Bölüm (Many-to-One)
- Ders → Bölüm (Many-to-One)
- Ders → Akademisyen (Many-to-One)
- OgrenciNot → Öğrenci (Many-to-One, Cascade Delete)
- OgrenciNot → Ders (Many-to-One, Cascade Delete)

## Geliştirme Notları

### DevExpress Komponentleri

Projede kullanılan ana DevExpress komponentleri:

- **GridControl** - Veri listeleme ve tablo görünümü
- **LayoutControl** - Form düzeni ve otomatik yerleşim
- **LookUpEdit** - Dropdown seçim kutuları
- **RibbonControl** - Ana menü ve araç çubukları
- **SimpleButton** - Butonlar ve eylem kontrolleri

### Entity Framework Core

- Code-First yaklaşımı kullanılmıştır
- `EnsureCreated()` ile veritabanı otomatik oluşturulur
- Lazy loading kapalıdır, `Include()` ile eager loading kullanılmaktadır
- SQLite veritabanı kullanılmaktadır
- Seed data ile örnek bölümler ve akademisyenler otomatik eklenir

## Katkıda Bulunma

Bu proje bir üniversite projesi olarak geliştirilmiştir. Önerileriniz için issue açabilirsiniz.

## Lisans

Bu proje eğitim amaçlı geliştirilmiştir.

## İletişim

Proje Sahibi: Enis Uzun  
GitHub: [@Enisuzunn](https://github.com/Enisuzunn)

## 📸 Ekran Görüntüleri

Buraya uygulamanın ekran görüntülerini ekleyebilirsiniz. `screenshots/` klasörüne ilgili isimlerle görsel eklediğinizde burada görünecektir.

<table border="0">
  <tr>
    <td><img src="screenshots/login.png" width="400" alt="Giriş Ekranı" /><br/><sub><i>Giriş Ekranı</i></sub></td>
    <td><img src="screenshots/admin_panel.png" width="400" alt="Yönetici Paneli" /><br/><sub><i>Yönetici Paneli</i></sub></td>
  </tr>
  <tr>
    <td><img src="screenshots/academic_panel.png" width="400" alt="Akademisyen Paneli" /><br/><sub><i>Akademisyen Paneli</i></sub></td>
    <td><img src="screenshots/student_panel.png" width="400" alt="Öğrenci Paneli" /><br/><sub><i>Öğrenci Paneli</i></sub></td>
  </tr>
  <tr>
    <td colspan="2" align="center"><img src="screenshots/ai_analysis.png" width="800" alt="AI Tahmin Sistemi" /><br/><sub><i>Yapay Zeka Destekli Risk Analizi ve Tahmin Modülü</i></sub></td>
  </tr>
</table>

## Sürüm Geçmişi

### v1.0.0 (Ekim 2025)

- ✅ İlk sürüm
- ✅ Temel CRUD işlemleri
- ✅ Öğrenci, akademisyen, bölüm, ders ve not yönetimi
- ✅ Kullanıcı giriş sistemi ve oturum yönetimi
- ✅ **Rol Bazlı Panel Sistemi:**
  - Admin Paneli: Tam sistem erişimi
  - Akademisyen Paneli: Not girişi ve öğrenci yönetimi
  - Öğrenci Paneli: Not görüntüleme ve GNO takibi
- ✅ DevExpress UI komponentleri entegrasyonu
- ✅ SQLite veritabanı entegrasyonu
- ✅ Otomatik harf notu hesaplama sistemi
- ✅ Not yazdırma ve dışa aktarma (Excel/PDF)

## Bilinen Sorunlar

- Şifre hashleme henüz eklenmemiştir (üretim ortamında mutlaka eklenmelidir)
- Form designer dosyaları minimal düzeyde tutulmuştur
- SVG ikonlar için DevExpress kaynakları gereklidir

## Gelecek Geliştirmeler

- [ ] Şifre hashleme (BCrypt/SHA256)
- [ ] Dönemlik ders kayıt sistemi
- [ ] Akademik danışman atama sistemi
- [ ] Öğrenci devam takibi
- [ ] Dashboard ve istatistikler
- [x] Email bildirimleri ✅
- [ ] Yedekleme/Geri yükleme
- [ ] Akademik takvim yönetimi
- [ ] Sınav tarihleri ve planlaması

## Teknik Detaylar

### Kullanılan NuGet Paketleri

- `Microsoft.EntityFrameworkCore` v9.0.0
- `Microsoft.EntityFrameworkCore.Sqlite` v9.0.0
- `Microsoft.EntityFrameworkCore.Tools` v9.0.0
- `DevExpress.Win.Grid` v25.1
- `DevExpress.Win.Layout` v25.1
- `DevExpress.Win.Ribbon` v25.1

### Önemli Notlar

- .NET 9.0 framework kullanılmaktadır
- Windows Forms teknolojisi kullanılmaktadır
- Veritabanı otomatik olarak oluşturulur ve seed data ile doldurulur
- TC Kimlik No 11 haneli olmalıdır
- Öğrenci numarası otomatik üretilir
- Not ortalaması: `(Vize * 0.3) + (Final * 0.5) + (Proje * 0.2)`
- Harf notu dönüşümü: AA(90-100), BA(85-89), BB(80-84), CB(75-79), CC(70-74), DC(65-69), DD(60-64), FD(50-59), FF(0-49)

---

**Not:** Bu uygulama .NET 9.0 ve DevExpress v25.1 ile geliştirilmiştir. Çalıştırmak için bu teknolojilerin kurulu olması gerekmektedir.
