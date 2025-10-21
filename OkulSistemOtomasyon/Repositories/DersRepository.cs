using Microsoft.EntityFrameworkCore;
using OkulSistemOtomasyon.Data;
using OkulSistemOtomasyon.Models;

namespace OkulSistemOtomasyon.Repositories
{
    /// <summary>
    /// Ders Repository Interface
    /// </summary>
    public interface IDersRepository : IRepository<Ders>
    {
        Ders? GetByDersKodu(string dersKodu);
        IEnumerable<Ders> GetByBolumId(int bolumId);
        IEnumerable<Ders> GetByAkademisyenId(int akademisyenId);
        IEnumerable<Ders> GetWithRelations();
    }

    /// <summary>
    /// Ders Repository Implementation
    /// </summary>
    public class DersRepository : GenericRepository<Ders>, IDersRepository
    {
        public DersRepository(OkulDbContext context) : base(context)
        {
        }

        public Ders? GetByDersKodu(string dersKodu)
        {
            return _dbSet.FirstOrDefault(d => d.DersKodu == dersKodu);
        }

        public IEnumerable<Ders> GetByBolumId(int bolumId)
        {
            return _dbSet
                .Where(d => d.BolumId == bolumId && d.IsActive)
                .Include(d => d.Bolum)
                .Include(d => d.Akademisyen)
                .ToList();
        }

        public IEnumerable<Ders> GetByAkademisyenId(int akademisyenId)
        {
            return _dbSet
                .Where(d => d.AkademisyenId == akademisyenId && d.IsActive)
                .Include(d => d.Bolum)
                .ToList();
        }

        public IEnumerable<Ders> GetWithRelations()
        {
            return _dbSet
                .Where(d => d.IsActive)
                .Include(d => d.Bolum)
                .Include(d => d.Akademisyen)
                .ToList();
        }
    }
}
