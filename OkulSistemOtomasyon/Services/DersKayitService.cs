using OkulSistemOtomasyon.Data;
using OkulSistemOtomasyon.Helpers;
using OkulSistemOtomasyon.Models;
using OkulSistemOtomasyon.Repositories;

namespace OkulSistemOtomasyon.Services
{
    /// <summary>
    /// Ders Kayıt Service Interface
    /// </summary>
    public interface IDersKayitService
    {
        bool TalepOlustur(int ogrenciId, int dersId, out string errorMessage);
        bool TalebiOnayla(int talepId, string? danismanNotu, out string errorMessage);
        bool TalebiReddet(int talepId, string? danismanNotu, out string errorMessage);
        IEnumerable<DersKayitTalebi> GetOgrenciTalepleri(int ogrenciId);
        IEnumerable<DersKayitTalebi> GetDanismanTalepleri(int akademisyenId);
        IEnumerable<DersKayitTalebi> GetBekleyenTalepler();
        DersKayitTalebi? GetTalepById(int talepId);
    }

    /// <summary>
    /// Ders Kayıt Service Implementation
    /// İş mantığı: Öğrenci ders kayıt talebinde bulunur, danışman onaylar/reddeder
    /// </summary>
    public class DersKayitService : IDersKayitService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DersKayitService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public bool TalepOlustur(int ogrenciId, int dersId, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                // Öğrenci var mı kontrolü
                var ogrenci = _unitOfWork.Ogrenciler.GetById(ogrenciId);
                if (ogrenci == null)
                {
                    errorMessage = "Öğrenci bulunamadı!";
                    return false;
                }

                // Ders var mı kontrolü
                var ders = _unitOfWork.Dersler.GetById(dersId);
                if (ders == null)
                {
                    errorMessage = "Ders bulunamadı!";
                    return false;
                }

                // Öğrencinin danışmanı var mı kontrolü
                if (ogrenci.DanismanId == null)
                {
                    errorMessage = "Öğrenciye danışman atanmamış! Lütfen öğrenci işlerine başvurun.";
                    return false;
                }

                // Daha önce aynı ders için bekleyen talep var mı?
                var mevcutTalep = _unitOfWork.DersKayitTalepleri
                    .FirstOrDefault(t => t.OgrenciId == ogrenciId && 
                                        t.DersId == dersId && 
                                        t.Durum == DersKayitDurumu.Beklemede);

                if (mevcutTalep != null)
                {
                    errorMessage = "Bu ders için zaten bekleyen bir talebiniz var!";
                    return false;
                }

                // Öğrenci bu dersi zaten almış mı? (Notu var mı?)
                var mevcutNot = _unitOfWork.OgrenciNotlar
                    .FirstOrDefault(n => n.OgrenciId == ogrenciId && n.DersId == dersId);

                if (mevcutNot != null)
                {
                    errorMessage = "Bu dersi zaten almaktasınız!";
                    return false;
                }

                // Talebi oluştur
                var talep = new DersKayitTalebi
                {
                    OgrenciId = ogrenciId,
                    DersId = dersId,
                    Durum = DersKayitDurumu.Beklemede,
                    TalepTarihi = DateTime.Now
                };

                _unitOfWork.DersKayitTalepleri.Add(talep);
                _unitOfWork.Complete();

                return true;
            }
            catch (Exception ex)
            {
                errorMessage = $"Talep oluşturulurken hata: {ex.Message}";
                return false;
            }
        }

        public bool TalebiOnayla(int talepId, string? danismanNotu, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                _unitOfWork.BeginTransaction();

                // Talebi bul
                var talep = _unitOfWork.DersKayitTalepleri.GetWithDetails(talepId);
                if (talep == null)
                {
                    errorMessage = "Talep bulunamadı!";
                    return false;
                }

                if (talep.Durum != DersKayitDurumu.Beklemede)
                {
                    errorMessage = "Bu talep zaten işleme alınmış!";
                    return false;
                }

                // Talebi onayla
                talep.Durum = DersKayitDurumu.Onaylandi;
                talep.KararTarihi = DateTime.Now;
                talep.DanismanNotu = danismanNotu;

                _unitOfWork.DersKayitTalepleri.Update(talep);

                // Öğrenci için not kaydı oluştur (boş notlarla)
                var ogrenciNot = new OgrenciNot
                {
                    OgrenciId = talep.OgrenciId,
                    DersId = talep.DersId,
                    NotGirisTarihi = DateTime.Now
                };

                _unitOfWork.OgrenciNotlar.Add(ogrenciNot);
                
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                errorMessage = $"Talep onaylanırken hata: {ex.Message}";
                return false;
            }
        }

        public bool TalebiReddet(int talepId, string? danismanNotu, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                // Talebi bul
                var talep = _unitOfWork.DersKayitTalepleri.GetById(talepId);
                if (talep == null)
                {
                    errorMessage = "Talep bulunamadı!";
                    return false;
                }

                if (talep.Durum != DersKayitDurumu.Beklemede)
                {
                    errorMessage = "Bu talep zaten işleme alınmış!";
                    return false;
                }

                // Talebi reddet
                talep.Durum = DersKayitDurumu.Reddedildi;
                talep.KararTarihi = DateTime.Now;
                talep.DanismanNotu = danismanNotu;

                _unitOfWork.DersKayitTalepleri.Update(talep);
                _unitOfWork.Complete();

                return true;
            }
            catch (Exception ex)
            {
                errorMessage = $"Talep reddedilirken hata: {ex.Message}";
                return false;
            }
        }

        public IEnumerable<DersKayitTalebi> GetOgrenciTalepleri(int ogrenciId)
        {
            return _unitOfWork.DersKayitTalepleri.GetByOgrenciId(ogrenciId);
        }

        public IEnumerable<DersKayitTalebi> GetDanismanTalepleri(int akademisyenId)
        {
            return _unitOfWork.DersKayitTalepleri.GetByDanismanId(akademisyenId);
        }

        public IEnumerable<DersKayitTalebi> GetBekleyenTalepler()
        {
            return _unitOfWork.DersKayitTalepleri.GetBekleyenTalepler();
        }

        public DersKayitTalebi? GetTalepById(int talepId)
        {
            return _unitOfWork.DersKayitTalepleri.GetWithDetails(talepId);
        }
    }
}

