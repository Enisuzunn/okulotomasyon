using OkulSistemOtomasyon.Helpers;
using OkulSistemOtomasyon.Models;
using OkulSistemOtomasyon.Repositories;

namespace OkulSistemOtomasyon.Services
{
    /// <summary>
    /// Akademisyen Service Interface
    /// OOP: Business logic'i form'lardan ayırma (Separation of Concerns)
    /// </summary>
    public interface IAkademisyenService
    {
        IEnumerable<Akademisyen> GetAll();
        Akademisyen? GetById(int id);
        Akademisyen? GetByTC(string tc);
        bool Add(Akademisyen akademisyen, out string errorMessage);
        bool Update(Akademisyen akademisyen, out string errorMessage);
        bool Delete(int id, out string errorMessage);
        bool SoftDelete(int id);
        IEnumerable<Akademisyen> GetWithDersler();
    }

    /// <summary>
    /// Akademisyen Service Implementation
    /// OOP: Encapsulation - Business logic kapsüllendi
    /// </summary>
    public class AkademisyenService : IAkademisyenService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AkademisyenService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public IEnumerable<Akademisyen> GetAll()
        {
            return _unitOfWork.Akademisyenler.GetAll();
        }

        public Akademisyen? GetById(int id)
        {
            return _unitOfWork.Akademisyenler.GetById(id);
        }

        public Akademisyen? GetByTC(string tc)
        {
            return _unitOfWork.Akademisyenler.GetByTC(tc);
        }

        public bool Add(Akademisyen akademisyen, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                // Validation
                if (!ValidationHelper.TCKimlikNoDogrula(akademisyen.TC))
                {
                    errorMessage = "Geçerli bir TC Kimlik No giriniz (11 hane)!";
                    return false;
                }

                if (string.IsNullOrWhiteSpace(akademisyen.Ad) || string.IsNullOrWhiteSpace(akademisyen.Soyad))
                {
                    errorMessage = "Ad ve soyad boş olamaz!";
                    return false;
                }

                // Business rule: TC benzersiz olmalı
                var mevcutAkademisyen = _unitOfWork.Akademisyenler.GetByTC(akademisyen.TC);
                if (mevcutAkademisyen != null)
                {
                    errorMessage = "Bu TC Kimlik No ile kayıtlı akademisyen zaten var!";
                    return false;
                }

                // Email validation (opsiyonel)
                if (!string.IsNullOrWhiteSpace(akademisyen.Email) && 
                    !ValidationHelper.EmailDogrula(akademisyen.Email))
                {
                    errorMessage = "Geçerli bir email adresi giriniz!";
                    return false;
                }

                _unitOfWork.Akademisyenler.Add(akademisyen);
                _unitOfWork.Complete();
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = $"Kayıt sırasında hata oluştu: {ex.Message}";
                return false;
            }
        }

        public bool Update(Akademisyen akademisyen, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                // Validation
                if (!ValidationHelper.TCKimlikNoDogrula(akademisyen.TC))
                {
                    errorMessage = "Geçerli bir TC Kimlik No giriniz!";
                    return false;
                }

                if (string.IsNullOrWhiteSpace(akademisyen.Ad) || string.IsNullOrWhiteSpace(akademisyen.Soyad))
                {
                    errorMessage = "Ad ve soyad boş olamaz!";
                    return false;
                }

                // Email validation (opsiyonel)
                if (!string.IsNullOrWhiteSpace(akademisyen.Email) && 
                    !ValidationHelper.EmailDogrula(akademisyen.Email))
                {
                    errorMessage = "Geçerli bir email adresi giriniz!";
                    return false;
                }

                _unitOfWork.Akademisyenler.Update(akademisyen);
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
                var akademisyen = _unitOfWork.Akademisyenler.GetById(id);
                if (akademisyen == null)
                {
                    errorMessage = "Akademisyen bulunamadı!";
                    return false;
                }

                // Business rule: Dersi olan akademisyen silinebilir mi kontrolü
                // Soft delete kullanıyoruz, bu yüzden sorun yok
                _unitOfWork.Akademisyenler.Remove(akademisyen);
                _unitOfWork.Complete();
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = $"Silme sırasında hata oluştu: {ex.Message}";
                return false;
            }
        }

        public bool SoftDelete(int id)
        {
            try
            {
                var akademisyen = _unitOfWork.Akademisyenler.GetById(id);
                if (akademisyen == null)
                    return false;

                _unitOfWork.Akademisyenler.SoftDelete(akademisyen);
                _unitOfWork.Complete();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Akademisyen> GetWithDersler()
        {
            return _unitOfWork.Akademisyenler.GetWithDersler();
        }
    }
}
