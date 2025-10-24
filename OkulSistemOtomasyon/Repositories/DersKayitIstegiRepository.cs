using Microsoft.EntityFrameworkCore;
using OkulSistemOtomasyon.Data;
using OkulSistemOtomasyon.Models;

namespace OkulSistemOtomasyon.Repositories
{
    public class DersKayitIstegiRepository : GenericRepository<DersKayitIstegi>
    {
        public DersKayitIstegiRepository(OkulDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Öğrencinin tüm ders kayıt isteklerini getir
        /// </summary>
        public async Task<List<DersKayitIstegi>> GetByOgrenciIdAsync(int ogrenciId)
        {
            return await _context.DersKayitIstekleri
                .Include(d => d.Ders)
                    .ThenInclude(d => d.Akademisyen)
                .Include(d => d.Ogrenci)
                .Where(d => d.OgrenciId == ogrenciId)
                .OrderByDescending(d => d.IstekTarihi)
                .ToListAsync();
        }

        /// <summary>
        /// Danışmanın onay bekleyen ders kayıt isteklerini getir
        /// </summary>
        public async Task<List<DersKayitIstegi>> GetPendingByDanismanIdAsync(int akademisyenId)
        {
            return await _context.DersKayitIstekleri
                .Include(d => d.Ders)
                .Include(d => d.Ogrenci)
                    .ThenInclude(o => o.Bolum)
                .Where(d => d.Ogrenci.DanismanId == akademisyenId && d.Durum == DersKayitDurum.Beklemede)
                .OrderBy(d => d.IstekTarihi)
                .ToListAsync();
        }

        /// <summary>
        /// Öğrencinin belirli bir derse kayıt isteği olup olmadığını kontrol et
        /// </summary>
        public async Task<bool> HasPendingRequestAsync(int ogrenciId, int dersId)
        {
            return await _context.DersKayitIstekleri
                .AnyAsync(d => d.OgrenciId == ogrenciId && 
                              d.DersId == dersId && 
                              (d.Durum == DersKayitDurum.Beklemede || d.Durum == DersKayitDurum.Onaylandi));
        }

        /// <summary>
        /// Öğrencinin kayıtlı olduğu dersleri getir
        /// </summary>
        public async Task<List<int>> GetApprovedDersIdsAsync(int ogrenciId)
        {
            return await _context.DersKayitIstekleri
                .Where(d => d.OgrenciId == ogrenciId && d.Durum == DersKayitDurum.Onaylandi)
                .Select(d => d.DersId)
                .ToListAsync();
        }
    }
}
