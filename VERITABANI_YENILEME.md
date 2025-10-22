# 🔄 Veritabanı Yenileme Talimatları

## ⚠️ ÖNEMLİ

Veritabanı konumu değiştirildi! Artık **tüm kullanıcılar aynı veritabanını** kullanacak.

## 🗄️ YENİ Veritabanı Konumu

### Windows (YENİ):
```
OkulSistemOtomasyon\bin\Debug\net9.0-windows\Data\universite.db
```

### Eski Konum (ARTIK KULLANILMIYOR):
~~`C:\Users\[KullaniciAdi]\AppData\Local\OkulSistem\universite.db`~~

### macOS:
```
OkulSistemOtomasyon/bin/Debug/net9.0-windows/Data/universite.db
```

## 🔧 Nasıl Silinir?

### Windows (Otomatik - Önerilen):
1. `veritabani_sil.ps1` dosyasına **sağ tıklayın**
2. **"PowerShell ile Çalıştır"** seçeneğini seçin
3. Veritabanı otomatik silinecek

### Windows (Manuel):
1. Projeyi Visual Studio'da aç
2. `OkulSistemOtomasyon\bin\Debug\net9.0-windows\Data\universite.db` dosyasını sil
3. Uygulamayı yeniden çalıştır

### macOS/Linux:
```bash
rm -f "OkulSistemOtomasyon/bin/Debug/net9.0-windows/Data/universite.db"
```

## ✨ İlk Çalıştırma

Uygulamayı çalıştırdığınızda:
- ✅ Yeni veritabanı otomatik oluşturulacak
- ✅ 5 bölüm eklenecek
- ✅ 3 akademisyen eklenecek
- ✅ 2 öğrenci eklenecek
- ✅ 3 test kullanıcısı oluşturulacak

## 🔑 Test Kullanıcıları

### 👨‍💼 Yönetici (Admin)
- **Kullanıcı Adı:** admin
- **Şifre:** admin123
- **Yetkiler:** Tüm sistem yönetimi

### 👨‍🏫 Akademisyen
- **Kullanıcı Adı:** ahmet.yilmaz
- **Şifre:** 12345
- **Yetkiler:** Not girişi, ders yönetimi

### 🎓 Öğrenci
- **Kullanıcı Adı:** 220201001
- **Şifre:** 12345
- **Yetkiler:** Not görüntüleme

## 📝 Değişiklikler

### Kullanici Tablosu
- ✅ `Rol` enum olarak değiştirildi (Admin, Akademisyen, Ogrenci)
- ✅ `AkademisyenId` ilişkisi eklendi
- ✅ `OgrenciId` ilişkisi eklendi
- ✅ Role göre yetkilendirme sistemi

### Yeni Özellikler
- ✅ Role göre giriş yönlendirmesi
- ✅ Akademisyen için kişiselleştirilmiş panel (yakında)
- ✅ Öğrenci için not görüntüleme paneli (yakında)

---

**Not:** Veritabanını silmeden uygulamayı çalıştırırsanız hata alabilirsiniz!
