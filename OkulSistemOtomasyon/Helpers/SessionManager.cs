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
            return AktifKullanici?.Rol == KullaniciRolu.Admin;
        }

        public static bool AkademisyenMi()
        {
            return AktifKullanici?.Rol == KullaniciRolu.Akademisyen;
        }

        public static bool OgrenciMi()
        {
            return AktifKullanici?.Rol == KullaniciRolu.Ogrenci;
        }

        public static string? RolAdi()
        {
            return AktifKullanici?.RolAdi;
        }
    }
}
