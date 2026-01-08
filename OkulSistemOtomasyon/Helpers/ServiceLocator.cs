using OkulSistemOtomasyon.Data;
using OkulSistemOtomasyon.Repositories;
using OkulSistemOtomasyon.Services;

namespace OkulSistemOtomasyon.Helpers
{
    /// <summary>
    /// Service Locator Pattern - Dependency Injection için
    /// OOP: Dependency Inversion Principle (SOLID)
    /// Windows Forms için basit DI container
    /// </summary>
    public static class ServiceLocator
    {
        private static OkulDbContext? _context;
        private static IUnitOfWork? _unitOfWork;
        
        // Service instances
        private static IAkademisyenService? _akademisyenService;
        private static IOgrenciService? _ogrenciService;
        private static IBolumService? _bolumService;
        private static IDersKayitService? _dersKayitService;
        private static IMesajService? _mesajService;

        /// <summary>
        /// Servisleri başlat
        /// </summary>
        public static void Initialize()
        {
            _context = new OkulDbContext();
            _unitOfWork = new UnitOfWork(_context);
            
            // Servisleri oluştur
            _akademisyenService = new AkademisyenService(_unitOfWork);
            _ogrenciService = new OgrenciService(_unitOfWork);
            _bolumService = new BolumService(_unitOfWork);
            _dersKayitService = new DersKayitService(_unitOfWork);
            _mesajService = new MesajService(_unitOfWork);
        }

        /// <summary>
        /// Tüm servisleri ve context'i temizle
        /// </summary>
        public static void Dispose()
        {
            _unitOfWork?.Dispose();
            _context?.Dispose();
            
            _akademisyenService = null;
            _ogrenciService = null;
            _bolumService = null;
            _dersKayitService = null;
            _mesajService = null;
            _unitOfWork = null;
            _context = null;
        }

        /// <summary>
        /// Context'i yeniden oluştur (ihtiyaç durumunda)
        /// </summary>
        public static void Refresh()
        {
            Dispose();
            Initialize();
        }

        // Service Getters - Lazy loading ile
        public static IAkademisyenService GetAkademisyenService()
        {
            if (_akademisyenService == null)
                Initialize();
            return _akademisyenService!;
        }

        public static IOgrenciService GetOgrenciService()
        {
            if (_ogrenciService == null)
                Initialize();
            return _ogrenciService!;
        }

        public static IBolumService GetBolumService()
        {
            if (_bolumService == null)
                Initialize();
            return _bolumService!;
        }

        public static IDersKayitService GetDersKayitService()
        {
            if (_dersKayitService == null)
                Initialize();
            return _dersKayitService!;
        }

        public static IMesajService GetMesajService()
        {
            if (_mesajService == null)
                Initialize();
            return _mesajService!;
        }

        public static IUnitOfWork GetUnitOfWork()
        {
            if (_unitOfWork == null)
                Initialize();
            return _unitOfWork!;
        }
    }
}
