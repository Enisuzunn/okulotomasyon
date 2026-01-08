using OkulSistemOtomasyon.Models;
using OkulSistemOtomasyon.Repositories;

namespace OkulSistemOtomasyon.Services
{
    public class MesajService : IMesajService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MesajService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void MesajGonder(int gondericiId, int aliciId, string konu, string icerik)
        {
            var mesaj = new Mesaj
            {
                GondericiId = gondericiId,
                AliciId = aliciId,
                Konu = konu,
                Icerik = icerik,
                CreatedDate = DateTime.Now,
                IsActive = true,
                Okundu = false
            };

            _unitOfWork.Mesajlar.Add(mesaj);
            _unitOfWork.Complete();
        }

        public IEnumerable<Mesaj> GelenKutusuGetir(int kullaniciId)
        {
            return _unitOfWork.Mesajlar.GetGelenKutusu(kullaniciId);
        }

        public IEnumerable<Mesaj> GidenKutusuGetir(int kullaniciId)
        {
            return _unitOfWork.Mesajlar.GetGidenKutusu(kullaniciId);
        }

        public void OkunduIsaretle(int mesajId)
        {
            var mesaj = _unitOfWork.Mesajlar.GetById(mesajId);
            if (mesaj != null && !mesaj.Okundu)
            {
                mesaj.Okundu = true;
                _unitOfWork.Mesajlar.Update(mesaj);
                _unitOfWork.Complete();
            }
        }

        public int OkunmamisMesajSayisiGetir(int kullaniciId)
        {
            return _unitOfWork.Mesajlar.GetOkunmamisMesajSayisi(kullaniciId);
        }

        public IEnumerable<Kullanici> GonderilebilirKullanicilariGetir(int aktifKullaniciId)
        {
            var aktifKullanici = _unitOfWork.Kullanicilar.GetById(aktifKullaniciId);
            if (aktifKullanici == null) return new List<Kullanici>();

            var kullanicilar = new List<Kullanici>();

            if (aktifKullanici.Rol == KullaniciRolu.Ogrenci && aktifKullanici.OgrenciId.HasValue)
            {
                var ogrenci = _unitOfWork.Ogrenciler.GetById(aktifKullanici.OgrenciId.Value);
                if (ogrenci != null)
                {
                    // Bölümündeki Akademisyenler ve Danışmanı (Danışman zaten genelde aynı bölümdedir ama emin olmak için ID ile de çekiyoruz)
                    // Önce bölüm ID'yi alalım
                    int bolumId = ogrenci.BolumId;
                    int? danismanId = ogrenci.DanismanId;

                    // Bu akademisyenlerin 'AkademisyenId'lerini bulalım
                    var hedefAkademisyenIds = _unitOfWork.Akademisyenler
                        .Find(a => (a.BolumId == bolumId || (danismanId.HasValue && a.Id == danismanId.Value)) && a.IsActive)
                        .Select(a => a.Id)
                        .ToList();

                    // Öğrenci için ders aldığı hocaları da ekle
                    var alinanDersIds = _unitOfWork.OgrenciNotlari
                        .Find(n => n.OgrenciId == ogrenci.Id && n.IsActive)
                        .Select(n => n.DersId)
                        .Distinct()
                        .ToList();

                    if (alinanDersIds.Any())
                    {
                        var dersHocalari = _unitOfWork.Dersler
                            .Find(d => alinanDersIds.Contains(d.Id) && d.AkademisyenId.HasValue && d.IsActive)
                            .Select(d => d.AkademisyenId.Value)
                            .Distinct()
                            .ToList();

                        hedefAkademisyenIds.AddRange(dersHocalari);
                    }

                    hedefAkademisyenIds = hedefAkademisyenIds.Distinct().ToList();

                    // Şimdi bu akademisyen ID'lerine sahip AKTİF Kullanıcıları bulalım
                    if (hedefAkademisyenIds.Any())
                    {
                        var hedefKullanicilar = _unitOfWork.Kullanicilar
                            .Find(k => k.AkademisyenId.HasValue && hedefAkademisyenIds.Contains(k.AkademisyenId.Value) && k.Aktif);
                        
                        kullanicilar.AddRange(hedefKullanicilar);
                    }
                }
            }
            else if (aktifKullanici.Rol == KullaniciRolu.Akademisyen && aktifKullanici.AkademisyenId.HasValue)
            {
                var akademisyen = _unitOfWork.Akademisyenler.GetById(aktifKullanici.AkademisyenId.Value);
                if (akademisyen != null)
                {
                   // Bölümündeki öğrenciler ve Danışmanı olduğu öğrenciler
                   int bolumId = akademisyen.BolumId ?? 0; // Bölümü null ise 0 al (eşleşmez)
                   int akdId = akademisyen.Id;

                   var hedefOgrenciIds = _unitOfWork.Ogrenciler
                        .Find(o => (o.BolumId == bolumId || o.DanismanId == akdId) && o.IsActive)
                        .Select(o => o.Id)
                        .ToList();

                   if (hedefOgrenciIds.Any())
                   {
                        var hedefKullanicilar = _unitOfWork.Kullanicilar
                            .Find(k => k.OgrenciId.HasValue && hedefOgrenciIds.Contains(k.OgrenciId.Value) && k.Aktif);
                        
                        kullanicilar.AddRange(hedefKullanicilar);
                   }
                }
            }
            else if (aktifKullanici.Rol == KullaniciRolu.Admin)
            {
                // Admin herkese atabilsin, kendisi hariç
                kullanicilar.AddRange(_unitOfWork.Kullanicilar.Find(k => k.KullaniciId != aktifKullaniciId && k.Aktif));
            }

            return kullanicilar.OrderBy(k => k.Ad).ThenBy(k => k.Soyad).ToList();
        }
    }
}
