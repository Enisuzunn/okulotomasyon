using Microsoft.EntityFrameworkCore;

namespace OkulSistemOtomasyon.Data
{
    /// <summary>
    /// Veritabanı başlatma ve migration işlemleri
    /// </summary>
    public static class DatabaseInitializer
    {
        public static void Initialize()
        {
            using (var context = new OkulDbContext())
            {
                try
                {
                    // Veritabanını oluştur ve migration'ları uygula
                    context.Database.EnsureCreated();
                    
                    // Veya migration kullanmak isterseniz:
                    // context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Veritabanı başlatılamadı: {ex.Message}", ex);
                }
            }
        }

        public static string GetDatabasePath()
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "OkulSistem",
                "okulsistem.db"
            );
        }
    }
}
