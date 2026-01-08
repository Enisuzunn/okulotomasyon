using Microsoft.EntityFrameworkCore;
using OkulSistemOtomasyon.Data;
using OkulSistemOtomasyon.Models;
using System.Linq.Expressions;

namespace OkulSistemOtomasyon.Repositories
{
    /// <summary>
    /// Kullanıcı Repository Interface
    /// Not: Kullanici BaseEntity'den türemediği için özel interface
    /// </summary>
    public interface IKullaniciRepository
    {
        Kullanici? GetById(int id);
        IEnumerable<Kullanici> GetAll();
        Kullanici? GetByKullaniciAdi(string kullaniciAdi);
        Kullanici? Login(string kullaniciAdi, string sifre);
        IEnumerable<Kullanici> GetByRole(KullaniciRolu rol);
        void Add(Kullanici entity);
        void Update(Kullanici entity);
        void Remove(Kullanici entity);
        int Count();
        bool Any(Expression<Func<Kullanici, bool>> predicate);
        IEnumerable<Kullanici> Find(Expression<Func<Kullanici, bool>> predicate);
    }

    /// <summary>
    /// Kullanıcı Repository Implementation
    /// Not: Kullanici BaseEntity'den türemediği için GenericRepository kullanılmıyor
    /// </summary>
    public class KullaniciRepository : IKullaniciRepository
    {
        protected readonly OkulDbContext _context;
        protected readonly DbSet<Kullanici> _dbSet;

        public KullaniciRepository(OkulDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<Kullanici>();
        }

        public Kullanici? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<Kullanici> GetAll()
        {
            return _dbSet.Where(k => k.Aktif).ToList();
        }

        public Kullanici? GetByKullaniciAdi(string kullaniciAdi)
        {
            return _dbSet.FirstOrDefault(k => k.KullaniciAdi == kullaniciAdi && k.Aktif);
        }

        public Kullanici? Login(string kullaniciAdi, string sifre)
        {
            return _dbSet.FirstOrDefault(k => 
                k.KullaniciAdi == kullaniciAdi && 
                k.Sifre == sifre && 
                k.Aktif);
        }

        public IEnumerable<Kullanici> GetByRole(KullaniciRolu rol)
        {
            return _dbSet
                .Where(k => k.Rol == rol && k.Aktif)
                .ToList();
        }

        public void Add(Kullanici entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.OlusturmaTarihi = DateTime.Now;
            entity.Aktif = true;
            _dbSet.Add(entity);
        }

        public void Update(Kullanici entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _dbSet.Update(entity);
        }

        public void Remove(Kullanici entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _dbSet.Remove(entity);
        }

        public int Count()
        {
            return _dbSet.Count(k => k.Aktif);
        }

        public bool Any(Expression<Func<Kullanici, bool>> predicate)
        {
            return _dbSet.Any(predicate);
        }

        public IEnumerable<Kullanici> Find(Expression<Func<Kullanici, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }
    }
}
