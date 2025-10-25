using Microsoft.EntityFrameworkCore;
using OkulSistemOtomasyon.Data;
using OkulSistemOtomasyon.Models;

namespace OkulSistemOtomasyon.Repositories
{
    /// <summary>
    /// Ders Kayıt Talebi Repository Interface
    /// </summary>
    public interface IDersKayitTalebiRepository : IRepository<DersKayitTalebi>
    {
        IEnumerable<DersKayitTalebi> GetByOgrenciId(int ogrenciId);
        IEnumerable<DersKayitTalebi> GetByDanismanId(int akademisyenId);
        IEnumerable<DersKayitTalebi> GetBekleyenTalepler();
        IEnumerable<DersKayitTalebi> GetBekleyenTaleplerByDanisman(int akademisyenId);
        DersKayitTalebi? GetWithDetails(int talepId);
    }

    /// <summary>
    /// Ders Kayıt Talebi Repository Implementation
    /// </summary>
    public class DersKayitTalebiRepository : GenericRepository<DersKayitTalebi>, IDersKayitTalebiRepository
    {
        public DersKayitTalebiRepository(OkulDbContext context) : base(context)
        {
        }

        public IEnumerable<DersKayitTalebi> GetByOgrenciId(int ogrenciId)
        {
            return _dbSet
                .Include(t => t.Ogrenci)
                .Include(t => t.Ders)
                    .ThenInclude(d => d.Akademisyen)
                .Where(t => t.OgrenciId == ogrenciId)
                .OrderByDescending(t => t.TalepTarihi)
                .ToList();
        }

        public IEnumerable<DersKayitTalebi> GetByDanismanId(int akademisyenId)
        {
            return _dbSet
                .Include(t => t.Ogrenci)
                .Include(t => t.Ders)
                .Where(t => t.Ogrenci.DanismanId == akademisyenId)
                .OrderByDescending(t => t.TalepTarihi)
                .ToList();
        }

        public IEnumerable<DersKayitTalebi> GetBekleyenTalepler()
        {
            return _dbSet
                .Include(t => t.Ogrenci)
                .Include(t => t.Ders)
                .Where(t => t.Durum == DersKayitDurumu.Beklemede)
                .OrderBy(t => t.TalepTarihi)
                .ToList();
        }

        public IEnumerable<DersKayitTalebi> GetBekleyenTaleplerByDanisman(int akademisyenId)
        {
            return _dbSet
                .Include(t => t.Ogrenci)
                .Include(t => t.Ders)
                .Where(t => t.Ogrenci.DanismanId == akademisyenId && t.Durum == DersKayitDurumu.Beklemede)
                .OrderBy(t => t.TalepTarihi)
                .ToList();
        }

        public DersKayitTalebi? GetWithDetails(int talepId)
        {
            return _dbSet
                .Include(t => t.Ogrenci)
                    .ThenInclude(o => o.Bolum)
                .Include(t => t.Ders)
                    .ThenInclude(d => d.Akademisyen)
                .FirstOrDefault(t => t.Id == talepId);
        }
    }
}

