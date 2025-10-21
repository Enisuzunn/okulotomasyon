using Microsoft.EntityFrameworkCore;
using OkulSistemOtomasyon.Data;
using OkulSistemOtomasyon.Models;

namespace OkulSistemOtomasyon.Repositories
{
    /// <summary>
    /// Öğrenci Repository Interface
    /// OOP: Interface Segregation Principle
    /// </summary>
    public interface IOgrenciRepository : IRepository<Ogrenci>
    {
        Ogrenci? GetByTC(string tc);
        Ogrenci? GetByOgrenciNo(string ogrenciNo);
        IEnumerable<Ogrenci> GetByBolumId(int bolumId);
        IEnumerable<Ogrenci> GetWithBolum();
    }

    /// <summary>
    /// Öğrenci Repository Implementation
    /// </summary>
    public class OgrenciRepository : GenericRepository<Ogrenci>, IOgrenciRepository
    {
        public OgrenciRepository(OkulDbContext context) : base(context)
        {
        }

        public Ogrenci? GetByTC(string tc)
        {
            return _dbSet.FirstOrDefault(o => o.TC == tc);
        }

        public Ogrenci? GetByOgrenciNo(string ogrenciNo)
        {
            return _dbSet.FirstOrDefault(o => o.OgrenciNo == ogrenciNo);
        }

        public IEnumerable<Ogrenci> GetByBolumId(int bolumId)
        {
            return _dbSet
                .Where(o => o.BolumId == bolumId && o.IsActive)
                .Include(o => o.Bolum)
                .ToList();
        }

        public IEnumerable<Ogrenci> GetWithBolum()
        {
            return _dbSet
                .Where(o => o.IsActive)
                .Include(o => o.Bolum)
                .ToList();
        }
    }
}
