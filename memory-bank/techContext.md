# Teknik Bağlam

## Teknoloji Stack

| Katman | Teknoloji | Versiyon |
|--------|-----------|----------|
| Framework | .NET | 9.0 |
| UI | Windows Forms | - |
| UI Components | DevExpress | v25.1 |
| ORM | Entity Framework Core | 9.0 |
| Database | SQLite | - |
| IDE | Visual Studio | 2022 |

## NuGet Paketleri
- `Microsoft.EntityFrameworkCore` v9.0.0
- `Microsoft.EntityFrameworkCore.Sqlite` v9.0.0
- `Microsoft.EntityFrameworkCore.Tools` v9.0.0
- `DevExpress.Win.Grid` v25.1
- `DevExpress.Win.Layout` v25.1
- `DevExpress.Win.Ribbon` v25.1

## Mimari Yapı
```
Presentation Layer (Forms)
        ↓
Service Layer (Services)
        ↓
Repository Layer (Repositories)
        ↓
Data Layer (DbContext)
        ↓
SQLite Database
```

## Veritabanı Konumu
```
Windows: %LocalAppData%\OkulSistem\universite.db
```

## Email Servisi
- SMTP protokolü (Gmail)
- Port: 587 (TLS)
- Timeout: 30 saniye
- HTML şablon destekli

## Önemli Konfigürasyonlar
- Code-First yaklaşımı
- Lazy loading kapalı
- Eager loading (`Include()`)
- Cascade delete aktif
