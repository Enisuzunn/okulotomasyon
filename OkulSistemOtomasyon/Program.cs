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

                // Login formunu göster
                using (var loginForm = new LoginForm())
                {
                    if (loginForm.ShowDialog() == DialogResult.OK)
                    {
                        // Ana formu başlat
                        Application.Run(new MainForm());
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
