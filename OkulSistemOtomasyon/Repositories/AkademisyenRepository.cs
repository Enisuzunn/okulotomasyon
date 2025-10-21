using Microsoft.EntityFrameworkCore;
using OkulSistemOtomasyon.Data;
using OkulSistemOtomasyon.Models;

namespace OkulSistemOtomasyon.Repositories
{
    /// <summary>
    /// Akademisyen Repository Interface
    /// </summary>
    public interface IAkademisyenRepository : IRepository<Akademisyen>
    {
        Akademisyen? GetByTC(string tc);
        IEnumerable<Akademisyen> GetByUnvan(string unvan);
        IEnumerable<Akademisyen> GetWithDersler();
    }

    /// <summary>
    /// Akademisyen Repository Implementation
    /// </summary>
    public class AkademisyenRepository : GenericRepository<Akademisyen>, IAkademisyenRepository
    {
        public AkademisyenRepository(OkulDbContext context) : base(context)
        {
        }

        public Akademisyen? GetByTC(string tc)
        {
            return _dbSet.FirstOrDefault(a => a.TC == tc);
        }

        public IEnumerable<Akademisyen> GetByUnvan(string unvan)
        {
            return _dbSet
                .Where(a => a.Unvan == unvan && a.IsActive)
                .ToList();
        }

        public IEnumerable<Akademisyen> GetWithDersler()
        {
            return _dbSet
                .Where(a => a.IsActive)
                .Include(a => a.Dersler)
                .ToList();
        }
    }
}
