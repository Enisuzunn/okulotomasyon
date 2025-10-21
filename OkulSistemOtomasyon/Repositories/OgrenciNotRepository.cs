using Microsoft.EntityFrameworkCore;
using OkulSistemOtomasyon.Data;
using OkulSistemOtomasyon.Models;

namespace OkulSistemOtomasyon.Repositories
{
    /// <summary>
    /// Öğrenci Not Repository Interface
    /// </summary>
    public interface IOgrenciNotRepository : IRepository<OgrenciNot>
    {
        IEnumerable<OgrenciNot> GetByOgrenciId(int ogrenciId);
        IEnumerable<OgrenciNot> GetByDersId(int dersId);
        OgrenciNot? GetByOgrenciAndDers(int ogrenciId, int dersId);
        IEnumerable<OgrenciNot> GetWithRelations();
    }

    /// <summary>
    /// Öğrenci Not Repository Implementation
    /// </summary>
    public class OgrenciNotRepository : GenericRepository<OgrenciNot>, IOgrenciNotRepository
    {
        public OgrenciNotRepository(OkulDbContext context) : base(context)
        {
        }

        public IEnumerable<OgrenciNot> GetByOgrenciId(int ogrenciId)
        {
            return _dbSet
                .Where(n => n.OgrenciId == ogrenciId)
                .Include(n => n.Ders)
                .Include(n => n.Ogrenci)
                .ToList();
        }

        public IEnumerable<OgrenciNot> GetByDersId(int dersId)
        {
            return _dbSet
                .Where(n => n.DersId == dersId)
                .Include(n => n.Ogrenci)
                .Include(n => n.Ders)
                .ToList();
        }

        public OgrenciNot? GetByOgrenciAndDers(int ogrenciId, int dersId)
        {
            return _dbSet
                .Include(n => n.Ogrenci)
                .Include(n => n.Ders)
                .FirstOrDefault(n => n.OgrenciId == ogrenciId && n.DersId == dersId);
        }

        public IEnumerable<OgrenciNot> GetWithRelations()
        {
            return _dbSet
                .Include(n => n.Ogrenci)
                .Include(n => n.Ders)
                .ToList();
        }
    }
}
