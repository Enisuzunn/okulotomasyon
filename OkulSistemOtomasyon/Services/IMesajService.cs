using OkulSistemOtomasyon.Models;

namespace OkulSistemOtomasyon.Services
{
    public interface IMesajService
    {
        void MesajGonder(int gondericiId, int aliciId, string konu, string icerik);
        IEnumerable<Mesaj> GelenKutusuGetir(int kullaniciId);
        IEnumerable<Mesaj> GidenKutusuGetir(int kullaniciId);
        void OkunduIsaretle(int mesajId);
        int OkunmamisMesajSayisiGetir(int kullaniciId);
        IEnumerable<Kullanici> GonderilebilirKullanicilariGetir(int aktifKullaniciId);
    }
}
