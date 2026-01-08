using OkulSistemOtomasyon.Models;

namespace OkulSistemOtomasyon.Repositories
{
    public interface IMesajRepository : IRepository<Mesaj>
    {
        IEnumerable<Mesaj> GetGelenKutusu(int aliciId);
        IEnumerable<Mesaj> GetGidenKutusu(int gondericiId);
        int GetOkunmamisMesajSayisi(int aliciId);
    }
}
