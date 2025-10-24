using Microsoft.EntityFrameworkCore;
using OkulSistemOtomasyon.Data;
using OkulSistemOtomasyon.Helpers;
using OkulSistemOtomasyon.Models;
using OkulSistemOtomasyon.Repositories;

namespace OkulSistemOtomasyon.Services
{
    public class DersKayitService
    {
        private readonly OkulDbContext _context;

        public DersKayitService()
        {
            _context = new OkulDbContext();
        }

        /// <summary>
        /// Öğrenci ders kayıt isteği oluşturur
        /// </summary>
        public async Task<(bool success, string message)> KayitIstegiOlusturAsync(int ogrenciId, int dersId)
        {
            try
            {
                // Öğrenci kontrolü
                var ogrenci = await _context.Ogrenciler
                    .Include(o => o.Bolum)
                    .FirstOrDefaultAsync(o => o.Id == ogrenciId);

                if (ogrenci == null)
                    return (false, "Öğrenci bulunamadı!");

                if (!ogrenci.DanismanId.HasValue)
                    return (false, "Ders kaydı için önce danışman ataması yapılmalıdır!");

                // Ders kontrolü
                var ders = await _context.Dersler
                    .Include(d => d.Bolum)
                    .FirstOrDefaultAsync(d => d.DersId == dersId);

                if (ders == null)
                    return (false, "Ders bulunamadı!");

                // Bölüm kontrolü
                if (ders.BolumId != ogrenci.BolumId)
                    return (false, "Bu ders sizin bölümünüze ait değil!");

                // Daha önce kayıt var mı kontrol et
                var mevcutKayit = await _context.DersKayitIstekleri
                    .AnyAsync(d => d.OgrenciId == ogrenciId && 
                                  d.DersId == dersId && 
                                  (d.Durum == DersKayitDurum.Beklemede || d.Durum == DersKayitDurum.Onaylandi));

                if (mevcutKayit)
                    return (false, "Bu ders için zaten bir kayıt isteğiniz var veya derse kayıtlısınız!");

                // Yeni kayıt isteği oluştur
                var yeniIstek = new DersKayitIstegi
                {
                    OgrenciId = ogrenciId,
                    DersId = dersId,
                    Durum = DersKayitDurum.Beklemede,
                    IstekTarihi = DateTime.Now
                };

                _context.DersKayitIstekleri.Add(yeniIstek);
                await _context.SaveChangesAsync();

                return (true, $"Ders kayıt isteğiniz başarıyla oluşturuldu!\nDers: {ders.DersAdi}\nDanışmanınızın onayı bekleniyor.");
            }
            catch (Exception ex)
            {
                return (false, $"Kayıt isteği oluşturulurken hata oluştu:\n{ex.Message}");
            }
        }

        /// <summary>
        /// Danışman ders kayıt isteğini onaylar
        /// </summary>
        public async Task<(bool success, string message)> IstekOnaylaAsync(int istekId, int akademisyenId, string? danismanNotu = null)
        {
            try
            {
                var istek = await _context.DersKayitIstekleri
                    .Include(i => i.Ogrenci)
                    .Include(i => i.Ders)
                    .FirstOrDefaultAsync(i => i.Id == istekId);

                if (istek == null)
                    return (false, "İstek bulunamadı!");

                // Danışman kontrolü
                if (istek.Ogrenci.DanismanId != akademisyenId)
                    return (false, "Bu öğrencinin danışmanı siz değilsiniz!");

                if (istek.Durum != DersKayitDurum.Beklemede)
                    return (false, "Bu istek zaten işleme alınmış!");

                // İsteği onayla
                istek.Durum = DersKayitDurum.Onaylandi;
                istek.OnayTarihi = DateTime.Now;
                istek.DanismanNotu = danismanNotu;

                // Öğrenciye ders kaydını oluştur (OgrenciNot tablosuna ekle)
                var mevcutNot = await _context.OgrenciNotlari
                    .FirstOrDefaultAsync(n => n.OgrenciId == istek.OgrenciId && n.DersId == istek.DersId);

                if (mevcutNot == null)
                {
                    var yeniNot = new OgrenciNot
                    {
                        OgrenciId = istek.OgrenciId,
                        DersId = istek.DersId,
                        // Notlar henüz girilmedi
                        Vize = null,
                        Final = null,
                        Butunleme = null,
                        ProjeNotu = null
                    };
                    _context.OgrenciNotlari.Add(yeniNot);
                }

                await _context.SaveChangesAsync();

                return (true, $"Ders kayıt isteği onaylandı!\nÖğrenci: {istek.Ogrenci.Ad} {istek.Ogrenci.Soyad}\nDers: {istek.Ders.DersAdi}");
            }
            catch (Exception ex)
            {
                return (false, $"İstek onaylanırken hata oluştu:\n{ex.Message}");
            }
        }

        /// <summary>
        /// Danışman ders kayıt isteğini reddeder
        /// </summary>
        public async Task<(bool success, string message)> IstekReddetAsync(int istekId, int akademisyenId, string? danismanNotu = null)
        {
            try
            {
                var istek = await _context.DersKayitIstekleri
                    .Include(i => i.Ogrenci)
                    .Include(i => i.Ders)
                    .FirstOrDefaultAsync(i => i.Id == istekId);

                if (istek == null)
                    return (false, "İstek bulunamadı!");

                // Danışman kontrolü
                if (istek.Ogrenci.DanismanId != akademisyenId)
                    return (false, "Bu öğrencinin danışmanı siz değilsiniz!");

                if (istek.Durum != DersKayitDurum.Beklemede)
                    return (false, "Bu istek zaten işleme alınmış!");

                // İsteği reddet
                istek.Durum = DersKayitDurum.Reddedildi;
                istek.OnayTarihi = DateTime.Now;
                istek.DanismanNotu = danismanNotu;

                await _context.SaveChangesAsync();

                return (true, $"Ders kayıt isteği reddedildi.\nÖğrenci: {istek.Ogrenci.Ad} {istek.Ogrenci.Soyad}\nDers: {istek.Ders.DersAdi}");
            }
            catch (Exception ex)
            {
                return (false, $"İstek reddedilirken hata oluştu:\n{ex.Message}");
            }
        }

        /// <summary>
        /// Öğrencinin kayıt olabileceği dersleri getir
        /// </summary>
        public async Task<List<Ders>> GetKayitYapilabilirDerslerAsync(int ogrenciId)
        {
            try
            {
                var ogrenci = await _context.Ogrenciler
                    .FirstOrDefaultAsync(o => o.Id == ogrenciId);

                if (ogrenci == null)
                    return new List<Ders>();

                // Öğrencinin bölümündeki tüm dersler
                var tumDersler = await _context.Dersler
                    .Include(d => d.Akademisyen)
                    .Include(d => d.Bolum)
                    .Where(d => d.BolumId == ogrenci.BolumId && d.IsActive)
                    .ToListAsync();

                // Öğrencinin kayıtlı olduğu veya bekleyen isteği olan dersler
                var kayitliDersIds = await _context.DersKayitIstekleri
                    .Where(d => d.OgrenciId == ogrenciId && 
                               (d.Durum == DersKayitDurum.Beklemede || d.Durum == DersKayitDurum.Onaylandi))
                    .Select(d => d.DersId)
                    .ToListAsync();

                // Kayıtlı olmadığı dersleri döndür
                return tumDersler.Where(d => !kayitliDersIds.Contains(d.DersId)).ToList();
            }
            catch
            {
                return new List<Ders>();
            }
        }

        /// <summary>
        /// Öğrencinin tüm ders kayıt isteklerini getir
        /// </summary>
        public async Task<List<DersKayitIstegi>> GetOgrenciIstekleriAsync(int ogrenciId)
        {
            try
            {
                return await _context.DersKayitIstekleri
                    .Include(d => d.Ders)
                        .ThenInclude(d => d.Akademisyen)
                    .Include(d => d.Ogrenci)
                    .Where(d => d.OgrenciId == ogrenciId)
                    .OrderByDescending(d => d.IstekTarihi)
                    .ToListAsync();
            }
            catch
            {
                return new List<DersKayitIstegi>();
            }
        }

        /// <summary>
        /// Danışmanın onay bekleyen isteklerini getir
        /// </summary>
        public async Task<List<DersKayitIstegi>> GetDanismanPendingIstekleriAsync(int akademisyenId)
        {
            try
            {
                return await _context.DersKayitIstekleri
                    .Include(d => d.Ders)
                    .Include(d => d.Ogrenci)
                        .ThenInclude(o => o.Bolum)
                    .Where(d => d.Ogrenci.DanismanId == akademisyenId && d.Durum == DersKayitDurum.Beklemede)
                    .OrderBy(d => d.IstekTarihi)
                    .ToListAsync();
            }
            catch
            {
                return new List<DersKayitIstegi>();
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
