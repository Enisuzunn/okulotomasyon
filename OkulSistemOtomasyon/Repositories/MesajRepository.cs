using Microsoft.EntityFrameworkCore;
using OkulSistemOtomasyon.Data;
using OkulSistemOtomasyon.Models;

namespace OkulSistemOtomasyon.Repositories
{
    public class MesajRepository : GenericRepository<Mesaj>, IMesajRepository
    {
        public MesajRepository(OkulDbContext context) : base(context)
        {
        }

        public IEnumerable<Mesaj> GetGelenKutusu(int aliciId)
        {
            return _dbSet
                .Include(m => m.Gonderici)
                .Where(m => m.AliciId == aliciId && m.IsActive)
                .OrderByDescending(m => m.CreatedDate)
                .ToList();
        }

        public IEnumerable<Mesaj> GetGidenKutusu(int gondericiId)
        {
            return _dbSet
                .Include(m => m.Alici)
                .Where(m => m.GondericiId == gondericiId && m.IsActive)
                .OrderByDescending(m => m.CreatedDate)
                .ToList();
        }

        public int GetOkunmamisMesajSayisi(int aliciId)
        {
            return _dbSet.Count(m => m.AliciId == aliciId && !m.Okundu && m.IsActive);
        }
    }
}
