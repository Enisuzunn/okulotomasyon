@echo off
echo Proje temizleniyor...

REM Visual Studio cache temizleme
if exist ".vs" rmdir /s /q ".vs"
if exist "OkulSistemOtomasyon\bin" rmdir /s /q "OkulSistemOtomasyon\bin"
if exist "OkulSistemOtomasyon\obj" rmdir /s /q "OkulSistemOtomasyon\obj"

REM Veritabanı dosyaları temizleme
del /s /q "universite.db*" 2>nul

echo.
echo Temizlik tamamlandi!
echo.
echo Simdi Visual Studio'yu acin ve Rebuild Solution yapin.
echo.
pause
