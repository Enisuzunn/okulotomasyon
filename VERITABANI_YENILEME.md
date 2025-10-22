# 🔄 Veritabanı Yenileme Talimatları

## ⚠️ ÖNEMLİ

Kullanıcı rol sistemi eklendiği için **eski veritabanı uyumlu değildir**.
İlk çalıştırmadan önce veritabanını silmelisiniz.

## 🗄️ Veritabanı Konumu

### Windows:
```
C:\Users\[KullaniciAdi]\AppData\Local\OkulSistem\universite.db
```

### macOS:
```
~/Library/Application Support/OkulSistem/universite.db
```

## 🔧 Nasıl Silinir?

### Windows:
1. **Windows + R** tuşlarına basın
2. `%LocalAppData%\OkulSistem` yazıp Enter
3. `universite.db` dosyasını silin

### macOS/Linux:
```bash
rm -f "$HOME/Library/Application Support/OkulSistem/universite.db"
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
