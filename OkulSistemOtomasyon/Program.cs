using OkulSistemOtomasyon.Data;
using OkulSistemOtomasyon.Forms;

namespace OkulSistemOtomasyon
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            try
            {
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
        }
    }
}
