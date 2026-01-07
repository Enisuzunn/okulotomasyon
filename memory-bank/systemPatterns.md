# Sistem Desenleri

## Kullanılan Design Patterns

### 1. Repository Pattern
Her entity için ayrı repository sınıfı:
- `GenericRepository<T>` - Base repository
- `OgrenciRepository`, `AkademisyenRepository`, vb.

### 2. Unit of Work Pattern
`UnitOfWork.cs` ile transaction yönetimi ve repository erişimi.

### 3. Service Locator Pattern
`ServiceLocator.cs` ile servis instance'larına global erişim.

### 4. Session Management
`SessionManager.cs` ile oturum bilgisi yönetimi:
- Aktif kullanıcı
- Rol bilgisi
- Login durumu

## Kod Standartları

### Naming Convention
- **Classes:** PascalCase (`OgrenciService`)
- **Methods:** PascalCase (`GetAllOgrenciler`)
- **Variables:** camelCase (`ogrenciList`)
- **Private fields:** _camelCase (`_settings`)

### Entity Yapısı
```csharp
public class Entity : BaseEntity
{
    public int Id { get; set; }
    public bool Aktif { get; set; }
    public DateTime KayitTarihi { get; set; }
    // Navigation properties
}
```

### Form Yapısı
- `FormName.cs` - Logic
- `FormName.Designer.cs` - UI tanımları

## Not Hesaplama Formülü
```
Ortalama = (Vize × 0.30) + (Final × 0.50) + (Proje × 0.20)
```

## Harf Notu Dönüşümü
| Puan | Harf | Durum |
|------|------|-------|
| 90-100 | AA | Geçti |
| 85-89 | BA | Geçti |
| 80-84 | BB | Geçti |
| 75-79 | CB | Geçti |
| 70-74 | CC | Geçti |
| 65-69 | DC | Geçti |
| 60-64 | DD | Geçti |
| 50-59 | FD | Koşullu |
| 0-49 | FF | Kaldı |

## Validation Kuralları
- TC Kimlik No: 11 haneli, sadece rakam
- Email: Geçerli format kontrolü
- Zorunlu alanlar: null/empty kontrolü
