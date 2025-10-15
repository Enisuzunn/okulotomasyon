using OkulSistemOtomasyon.Models;

namespace OkulSistemOtomasyon.Helpers
{
    /// <summary>
    /// Oturum yönetimi için static sınıf
    /// </summary>
    public static class SessionManager
    {
        public static Kullanici? AktifKullanici { get; private set; }

        public static bool GirisYap(Kullanici kullanici)
        {
            if (kullanici != null && kullanici.Aktif)
            {
                AktifKullanici = kullanici;
                return true;
            }
            return false;
        }

        public static void CikisYap()
        {
            AktifKullanici = null;
        }

        public static bool OturumAcikMi()
        {
            return AktifKullanici != null;
        }

        public static bool AdminMi()
        {
            return AktifKullanici?.Rol == "Admin";
        }

        public static bool OgretmenMi()
        {
            return AktifKullanici?.Rol == "Ogretmen";
        }
    }
}
