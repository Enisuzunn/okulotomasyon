using OkulSistemOtomasyon.Data;
using OkulSistemOtomasyon.Forms;
using OkulSistemOtomasyon.Helpers;

namespace OkulSistemOtomasyon
{
    /// <summary>
    /// Ana program sınıfı
    /// OOP: Uygulama başlangıcında Dependency Injection başlatılıyor
    /// </summary>
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            try
            {
                // OOP: Dependency Injection Container'ı başlat
                ServiceLocator.Initialize();
                
                // Veritabanını başlat
                DatabaseInitializer.Initialize();

                // Örnek öğrencileri sil (bir kerelik temizlik)
                int silinenSayisi = DatabaseInitializer.OrnekOgrencileriSil();
                if (silinenSayisi > 0)
                {
                    System.Diagnostics.Debug.WriteLine($"Örnek öğrenciler silindi: {silinenSayisi} kayıt");
                }

                // Login formunu göster
                using (var loginForm = new LoginForm())
                {
                    if (loginForm.ShowDialog() == DialogResult.OK)
                    {
                        // Kullanıcı rolüne göre uygun formu başlat
                        var aktifKullanici = SessionManager.AktifKullanici;
                        
                        if (aktifKullanici != null)
                        {
                            switch (aktifKullanici.Rol)
                            {
                                case OkulSistemOtomasyon.Models.KullaniciRolu.Admin:
                                    Application.Run(new MainForm());
                                    break;

                                case OkulSistemOtomasyon.Models.KullaniciRolu.Akademisyen:
                                    Application.Run(new AkademisyenPanelForm(aktifKullanici));
                                    break;

                                case OkulSistemOtomasyon.Models.KullaniciRolu.Ogrenci:
                                    Application.Run(new OgrenciPanelForm());
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Uygulama başlatılırken hata oluştu:\n{ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // OOP: Uygulama kapanırken kaynakları temizle
                ServiceLocator.Dispose();
            }
        }
    }
}
