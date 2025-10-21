using Microsoft.EntityFrameworkCore;
using OkulSistemOtomasyon.Data;
using OkulSistemOtomasyon.Models;
using System.Linq.Expressions;

namespace OkulSistemOtomasyon.Repositories
{
    /// <summary>
    /// Generic Repository Implementation
    /// OOP: Abstraction, Encapsulation ve Polymorphism prensiplerine uygun
    /// </summary>
    /// <typeparam name="T">BaseEntity'den türeyen herhangi bir entity</typeparam>
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly OkulDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(OkulDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        public virtual T? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.Where(x => x.IsActive).ToList();
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public virtual T? FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public virtual void Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.CreatedDate = DateTime.Now;
            entity.IsActive = true;
            _dbSet.Add(entity);
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            foreach (var entity in entities)
            {
                entity.CreatedDate = DateTime.Now;
                entity.IsActive = true;
            }
            _dbSet.AddRange(entities);
        }

        public virtual void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.OnUpdate();
            _dbSet.Update(entity);
        }

        public virtual void Remove(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _dbSet.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            _dbSet.RemoveRange(entities);
        }

        public virtual void SoftDelete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.OnDelete();
            _dbSet.Update(entity);
        }

        public virtual int Count()
        {
            return _dbSet.Count(x => x.IsActive);
        }

        public virtual int Count(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Count(predicate);
        }

        public virtual bool Any(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Any(predicate);
        }
    }
}
