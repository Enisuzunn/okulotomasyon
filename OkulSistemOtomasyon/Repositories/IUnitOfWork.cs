using OkulSistemOtomasyon.Data;

namespace OkulSistemOtomasyon.Repositories
{
    /// <summary>
    /// Unit of Work Interface
    /// OOP: Transaction yönetimi için abstraction
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        // Repository properties
        IOgrenciRepository Ogrenciler { get; }
        IAkademisyenRepository Akademisyenler { get; }
        IBolumRepository Bolumler { get; }
        IDersRepository Dersler { get; }
        IOgrenciNotRepository OgrenciNotlar { get; }
        IKullaniciRepository Kullanicilar { get; }
        DersKayitIstegiRepository DersKayitIstekleri { get; }

        // Transaction methods
        int Complete();
        Task<int> CompleteAsync();
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
