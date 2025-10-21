using Microsoft.EntityFrameworkCore;
using OkulSistemOtomasyon.Data;
using OkulSistemOtomasyon.Models;

namespace OkulSistemOtomasyon.Repositories
{
    /// <summary>
    /// Bölüm Repository Interface
    /// </summary>
    public interface IBolumRepository : IRepository<Bolum>
    {
        Bolum? GetByBolumKodu(string bolumKodu);
        IEnumerable<Bolum> GetWithOgrenciler();
        IEnumerable<Bolum> GetWithDersler();
    }

    /// <summary>
    /// Bölüm Repository Implementation
    /// </summary>
    public class BolumRepository : GenericRepository<Bolum>, IBolumRepository
    {
        public BolumRepository(OkulDbContext context) : base(context)
        {
        }

        public Bolum? GetByBolumKodu(string bolumKodu)
        {
            return _dbSet.FirstOrDefault(b => b.BolumKodu == bolumKodu);
        }

        public IEnumerable<Bolum> GetWithOgrenciler()
        {
            return _dbSet
                .Where(b => b.IsActive)
                .Include(b => b.Ogrenciler)
                .ToList();
        }

        public IEnumerable<Bolum> GetWithDersler()
        {
            return _dbSet
                .Where(b => b.IsActive)
                .Include(b => b.Dersler)
                .ToList();
        }
    }
}
