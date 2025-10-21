# 🐛 LINQ Translation Hatası - Çözüm

## Sorun

Eğer şu hatayı alıyorsanız:
```
The LINQ expression 'DbSet<Kullanici>()
.Where(k => k.KullaniciId == ... && k.IsActive)'
could not be translated.
```

## ✅ Çözüm

Veritabanını silip yeniden oluşturun. Eski veritabanı yapısı yeni kodla uyumlu değil.

### Windows'ta:

**Otomatik Yöntem:**
1. `TemizleVeritabani.bat` dosyasını çalıştırın (projenin ana klasöründe)
2. Uygulamayı yeniden başlatın

**Manuel Yöntem:**
1. `Windows + R` tuşlarına basın
2. `%LOCALAPPDATA%\OkulSistem` yazıp Enter
3. `universite.db` dosyasını silin
4. Uygulamayı yeniden başlatın

### macOS/Linux'ta:

```bash
rm -f "$HOME/Library/Application Support/OkulSistem/universite.db"
```

## 🔧 Neden Bu Gerekli?

- Model yapısı değişti (BaseEntity'den Id inheritance)
- Eski veritabanı eski yapıda
- Entity Framework yeni yapıyla eski veritabanını eşleştiremez
- Yeni veritabanı yeni yapıyla otomatik oluşturulacak

## 📝 Not

- Tüm veriler silinecek
- Varsayılan admin kullanıcısı otomatik oluşturulacak
- Örnek bölümler ve akademisyenler otomatik eklenecek

**Admin Bilgileri:**
- Kullanıcı Adı: `admin`
- Şifre: `admin123`
