@echo off
echo Veritabani temizleniyor...
del "%LOCALAPPDATA%\OkulSistem\universite.db" 2>nul
echo Veritabani silindi!
echo Uygulamayi yeniden baslattiginizda yeni veritabani olusturulacak.
pause
