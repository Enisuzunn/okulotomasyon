using OkulSistemOtomasyon.Models;
using System.Linq.Expressions;

namespace OkulSistemOtomasyon.Repositories
{
    /// <summary>
    /// Generic Repository Interface
    /// OOP: Abstraction (Soyutlama) ve Polymorphism (Çok Biçimlilik) prensiplerine uygun
    /// </summary>
    /// <typeparam name="T">BaseEntity'den türeyen herhangi bir entity</typeparam>
    public interface IRepository<T> where T : BaseEntity
    {
        // Temel CRUD operasyonları
        T? GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        T? FirstOrDefault(Expression<Func<T, bool>> predicate);
        
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        
        void Update(T entity);
        
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        
        // Soft Delete
        void SoftDelete(T entity);
        
        // Sayım işlemleri
        int Count();
        int Count(Expression<Func<T, bool>> predicate);
        
        // Varlık kontrolü
        bool Any(Expression<Func<T, bool>> predicate);
    }
}
