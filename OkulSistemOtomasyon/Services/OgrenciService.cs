using OkulSistemOtomasyon.Helpers;
using OkulSistemOtomasyon.Models;
using OkulSistemOtomasyon.Repositories;

namespace OkulSistemOtomasyon.Services
{
    /// <summary>
    /// Öğrenci Service Interface
    /// </summary>
    public interface IOgrenciService
    {
        IEnumerable<Ogrenci> GetAll();
        Ogrenci? GetById(int id);
        Ogrenci? GetByTC(string tc);
        Ogrenci? GetByOgrenciNo(string ogrenciNo);
        IEnumerable<Ogrenci> GetByBolumId(int bolumId);
        bool Add(Ogrenci ogrenci, out string errorMessage);
        bool Update(Ogrenci ogrenci, out string errorMessage);
        bool Delete(int id, out string errorMessage);
        IEnumerable<Ogrenci> GetWithBolum();
        string GenerateOgrenciNo(int bolumId, int kayitYili);
    }

    /// <summary>
    /// Öğrenci Service Implementation
    /// </summary>
    public class OgrenciService : IOgrenciService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OgrenciService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public IEnumerable<Ogrenci> GetAll()
        {
            return _unitOfWork.Ogrenciler.GetAll();
        }

        public Ogrenci? GetById(int id)
        {
            return _unitOfWork.Ogrenciler.GetById(id);
        }

        public Ogrenci? GetByTC(string tc)
        {
            return _unitOfWork.Ogrenciler.GetByTC(tc);
        }

        public Ogrenci? GetByOgrenciNo(string ogrenciNo)
        {
            return _unitOfWork.Ogrenciler.GetByOgrenciNo(ogrenciNo);
        }

        public IEnumerable<Ogrenci> GetByBolumId(int bolumId)
        {
            return _unitOfWork.Ogrenciler.GetByBolumId(bolumId);
        }

        public IEnumerable<Ogrenci> GetWithBolum()
        {
            return _unitOfWork.Ogrenciler.GetWithBolum();
        }

        public string GenerateOgrenciNo(int bolumId, int kayitYili)
        {
            // Business logic: Öğrenci numarası oluşturma
            var bolum = _unitOfWork.Bolumler.GetById(bolumId);
            if (bolum == null) return string.Empty;

            var mevcutOgrenciler = _unitOfWork.Ogrenciler
                .Find(o => o.BolumId == bolumId && o.KayitYili == kayitYili)
                .Count();

            var siraNo = (mevcutOgrenciler + 1).ToString().PadLeft(3, '0');
            return $"{kayitYili.ToString().Substring(2)}{bolumId.ToString().PadLeft(2, '0')}{siraNo}";
        }

        public bool Add(Ogrenci ogrenci, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                // Validation
                if (!ValidationHelper.TCKimlikNoDogrula(ogrenci.TC))
                {
                    errorMessage = "Geçerli bir TC Kimlik No giriniz (11 hane)!";
                    return false;
                }

                if (string.IsNullOrWhiteSpace(ogrenci.Ad) || string.IsNullOrWhiteSpace(ogrenci.Soyad))
                {
                    errorMessage = "Ad ve soyad boş olamaz!";
                    return false;
                }

                // TC benzersizlik kontrolü
                var mevcutOgrenci = _unitOfWork.Ogrenciler.GetByTC(ogrenci.TC);
                if (mevcutOgrenci != null)
                {
                    errorMessage = "Bu TC Kimlik No ile kayıtlı öğrenci zaten var!";
                    return false;
                }

                // Öğrenci numarası oluştur
                if (string.IsNullOrEmpty(ogrenci.OgrenciNo))
                {
                    ogrenci.OgrenciNo = GenerateOgrenciNo(ogrenci.BolumId, ogrenci.KayitYili ?? DateTime.Now.Year);
                }

                _unitOfWork.Ogrenciler.Add(ogrenci);
                _unitOfWork.Complete();
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = $"Kayıt sırasında hata oluştu: {ex.Message}";
                return false;
            }
        }

        public bool Update(Ogrenci ogrenci, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                if (!ValidationHelper.TCKimlikNoDogrula(ogrenci.TC))
                {
                    errorMessage = "Geçerli bir TC Kimlik No giriniz!";
                    return false;
                }

                _unitOfWork.Ogrenciler.Update(ogrenci);
                _unitOfWork.Complete();
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = $"Güncelleme sırasında hata oluştu: {ex.Message}";
                return false;
            }
        }

        public bool Delete(int id, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                var ogrenci = _unitOfWork.Ogrenciler.GetById(id);
                if (ogrenci == null)
                {
                    errorMessage = "Öğrenci bulunamadı!";
                    return false;
                }

                _unitOfWork.Ogrenciler.Remove(ogrenci);
                _unitOfWork.Complete();
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = $"Silme sırasında hata oluştu: {ex.Message}";
                return false;
            }
        }
    }
}
