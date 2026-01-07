# Aktif Çalışma Durumu

## Son Güncelleme
7 Ocak 2026

## Şu An Üzerinde Çalışılan
- AI risk analizi güncellendi ✅

## Aktif Dosyalar
- `Forms/AkademisyenPanelForm.cs` - AI entegrasyonu
- `AI/Services/MLModelService.cs` - ML.NET servisi

## Son Yapılan Değişiklikler
1. Risk analizi AI modeline bağlandı
   - Model hazırsa: ML.NET tahmini kullanılır
   - Model yoksa: Matematiksel formül (fallback)
2. `RiskDurumuBelirle()` helper metodu eklendi

## AI Sistemi Nasıl Çalışıyor

### Model Eğitimi (Manuel)
- Akademisyen "AI Eğit" butonuna basar
- En az 10 not kaydı gerekli
- 2 model eğitilir: Risk + Final Tahmin

### Tahminler (Otomatik)
| Özellik | Model Yokken | Model Varken |
|---------|--------------|--------------|
| Final Tahmini | `vize×0.9 + proje×0.1` | ML.NET Regression |
| Risk Analizi | Matematiksel formül | ML.NET Classification |

## Bekleyen İşler
- (Yok)

## Bilinen Sorunlar
- SVG ikonlar için DevExpress kaynakları gerekli
