# Veritabanını Sil ve Yenile
Write-Host "🔄 Veritabanı Yenileme İşlemi Başlatılıyor..." -ForegroundColor Cyan

# Uygulama klasöründeki Data/universite.db dosyasını bul
$scriptPath = Split-Path -Parent $MyInvocation.MyCommand.Path
$dbPath = Join-Path $scriptPath "OkulSistemOtomasyon\bin\Debug\net9.0-windows\Data\universite.db"

Write-Host "📁 Veritabanı Konumu: $dbPath" -ForegroundColor Yellow

if (Test-Path $dbPath) {
    Write-Host "✅ Eski veritabanı bulundu!" -ForegroundColor Yellow
    
    try {
        Remove-Item $dbPath -Force
        Write-Host "✅ Veritabanı başarıyla silindi!" -ForegroundColor Green
        Write-Host "" 
        Write-Host "🚀 Şimdi uygulamayı çalıştırın. Yeni veritabanı otomatik oluşturulacak." -ForegroundColor Green
        Write-Host ""
        Write-Host "🔑 Test Kullanıcıları:" -ForegroundColor Cyan
        Write-Host "   Admin: admin / admin123" -ForegroundColor White
        Write-Host "   Akademisyen: ahmet.yilmaz / 12345" -ForegroundColor White
        Write-Host "   Öğrenci: 220201001 / 12345" -ForegroundColor White
    }
    catch {
        Write-Host "❌ Hata: Veritabanı silinemedi. Uygulamanın kapalı olduğundan emin olun!" -ForegroundColor Red
        Write-Host "   Hata Detayı: $_" -ForegroundColor Red
    }
}
else {
    Write-Host "ℹ️  Veritabanı bulunamadı. İlk çalıştırmada otomatik oluşturulacak." -ForegroundColor Yellow
    Write-Host "   Beklenen konum: $dbPath" -ForegroundColor Gray
}

Write-Host ""
Write-Host "Devam etmek için bir tuşa basın..." -ForegroundColor Gray
$null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
