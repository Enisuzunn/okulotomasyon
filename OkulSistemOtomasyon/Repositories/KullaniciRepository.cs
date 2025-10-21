using OkulSistemOtomasyon.Data;
using OkulSistemOtomasyon.Models;

namespace OkulSistemOtomasyon.Repositories
{
    /// <summary>
    /// Kullanıcı Repository Interface
    /// </summary>
    public interface IKullaniciRepository : IRepository<Kullanici>
    {
        Kullanici? GetByKullaniciAdi(string kullaniciAdi);
        Kullanici? Login(string kullaniciAdi, string sifre);
        IEnumerable<Kullanici> GetByRole(string rol);
    }

    /// <summary>
    /// Kullanıcı Repository Implementation
    /// </summary>
    public class KullaniciRepository : GenericRepository<Kullanici>, IKullaniciRepository
    {
        public KullaniciRepository(OkulDbContext context) : base(context)
        {
        }

        public Kullanici? GetByKullaniciAdi(string kullaniciAdi)
        {
            return _dbSet.FirstOrDefault(k => k.KullaniciAdi == kullaniciAdi);
        }

        public Kullanici? Login(string kullaniciAdi, string sifre)
        {
            return _dbSet.FirstOrDefault(k => 
                k.KullaniciAdi == kullaniciAdi && 
                k.Sifre == sifre && 
                k.IsActive);
        }

        public IEnumerable<Kullanici> GetByRole(string rol)
        {
            return _dbSet
                .Where(k => k.Rol == rol && k.IsActive)
                .ToList();
        }
    }
}
