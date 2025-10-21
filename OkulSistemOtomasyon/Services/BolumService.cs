using OkulSistemOtomasyon.Models;
using OkulSistemOtomasyon.Repositories;

namespace OkulSistemOtomasyon.Services
{
    /// <summary>
    /// Bölüm Service Interface
    /// </summary>
    public interface IBolumService
    {
        IEnumerable<Bolum> GetAll();
        Bolum? GetById(int id);
        Bolum? GetByBolumKodu(string bolumKodu);
        bool Add(Bolum bolum, out string errorMessage);
        bool Update(Bolum bolum, out string errorMessage);
        bool Delete(int id, out string errorMessage);
        IEnumerable<Bolum> GetWithOgrenciler();
    }

    /// <summary>
    /// Bölüm Service Implementation
    /// </summary>
    public class BolumService : IBolumService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BolumService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public IEnumerable<Bolum> GetAll()
        {
            return _unitOfWork.Bolumler.GetAll();
        }

        public Bolum? GetById(int id)
        {
            return _unitOfWork.Bolumler.GetById(id);
        }

        public Bolum? GetByBolumKodu(string bolumKodu)
        {
            return _unitOfWork.Bolumler.GetByBolumKodu(bolumKodu);
        }

        public IEnumerable<Bolum> GetWithOgrenciler()
        {
            return _unitOfWork.Bolumler.GetWithOgrenciler();
        }

        public bool Add(Bolum bolum, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                if (string.IsNullOrWhiteSpace(bolum.BolumAdi))
                {
                    errorMessage = "Bölüm adı boş olamaz!";
                    return false;
                }

                // Bölüm kodu benzersizlik kontrolü
                if (!string.IsNullOrEmpty(bolum.BolumKodu))
                {
                    var mevcutBolum = _unitOfWork.Bolumler.GetByBolumKodu(bolum.BolumKodu);
                    if (mevcutBolum != null)
                    {
                        errorMessage = "Bu bölüm kodu ile kayıtlı bölüm zaten var!";
                        return false;
                    }
                }

                _unitOfWork.Bolumler.Add(bolum);
                _unitOfWork.Complete();
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = $"Kayıt sırasında hata oluştu: {ex.Message}";
                return false;
            }
        }

        public bool Update(Bolum bolum, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                if (string.IsNullOrWhiteSpace(bolum.BolumAdi))
                {
                    errorMessage = "Bölüm adı boş olamaz!";
                    return false;
                }

                _unitOfWork.Bolumler.Update(bolum);
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
                var bolum = _unitOfWork.Bolumler.GetById(id);
                if (bolum == null)
                {
                    errorMessage = "Bölüm bulunamadı!";
                    return false;
                }

                // Business rule: Öğrencisi olan bölüm silinemez
                if (bolum.Ogrenciler?.Any(o => o.IsActive) == true)
                {
                    errorMessage = "Bu bölümde aktif öğrenciler var, silinemez!";
                    return false;
                }

                _unitOfWork.Bolumler.Remove(bolum);
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
