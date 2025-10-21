using Microsoft.EntityFrameworkCore.Storage;
using OkulSistemOtomasyon.Data;

namespace OkulSistemOtomasyon.Repositories
{
    /// <summary>
    /// Unit of Work Implementation
    /// OOP: Transaction yönetimi ve repository koordinasyonu
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OkulDbContext _context;
        private IDbContextTransaction? _transaction;

        // Lazy initialization ile repository'leri sadece gerektiğinde oluştur
        private IOgrenciRepository? _ogrenciler;
        private IAkademisyenRepository? _akademisyenler;
        private IBolumRepository? _bolumler;
        private IDersRepository? _dersler;
        private IOgrenciNotRepository? _ogrenciNotlar;
        private IKullaniciRepository? _kullanicilar;

        public UnitOfWork(OkulDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // Lazy loading ile repository properties
        public IOgrenciRepository Ogrenciler => 
            _ogrenciler ??= new OgrenciRepository(_context);

        public IAkademisyenRepository Akademisyenler => 
            _akademisyenler ??= new AkademisyenRepository(_context);

        public IBolumRepository Bolumler => 
            _bolumler ??= new BolumRepository(_context);

        public IDersRepository Dersler => 
            _dersler ??= new DersRepository(_context);

        public IOgrenciNotRepository OgrenciNotlar => 
            _ogrenciNotlar ??= new OgrenciNotRepository(_context);

        public IKullaniciRepository Kullanicilar => 
            _kullanicilar ??= new KullaniciRepository(_context);

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _context.SaveChanges();
                _transaction?.Commit();
            }
            catch
            {
                _transaction?.Rollback();
                throw;
            }
            finally
            {
                _transaction?.Dispose();
                _transaction = null;
            }
        }

        public void Rollback()
        {
            _transaction?.Rollback();
            _transaction?.Dispose();
            _transaction = null;
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context?.Dispose();
        }
    }
}
