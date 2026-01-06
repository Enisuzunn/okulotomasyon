using DevExpress.LookAndFeel;
using DevExpress.Skins;
using System.Configuration;
using System.IO;

namespace OkulSistemOtomasyon.Helpers
{
    /// <summary>
    /// Uygulama tema yönetimi için yardımcı sınıf
    /// </summary>
    public static class ThemeManager
    {
        // Tema sabitleri
        public const string LIGHT_THEME = "Office 2019 Colorful";
        public const string DARK_THEME = "Office 2019 Black";
        
        // Alternatif temalar
        public const string LIGHT_THEME_ALT = "Bezier";
        public const string DARK_THEME_ALT = "Visual Studio 2019 Dark";
        
        private static bool _isDarkMode = false;
        private static string _currentTheme = LIGHT_THEME;

        /// <summary>
        /// Koyu tema aktif mi?
        /// </summary>
        public static bool IsDarkMode
        {
            get => _isDarkMode;
            private set => _isDarkMode = value;
        }

        /// <summary>
        /// Mevcut tema adı
        /// </summary>
        public static string CurrentTheme
        {
            get => _currentTheme;
            private set => _currentTheme = value;
        }

        /// <summary>
        /// Uygulama başlangıcında tema ayarlarını yükler
        /// </summary>
        public static void Initialize()
        {
            // Kayıtlı tema tercihini yükle
            LoadSavedTheme();
            ApplyTheme();
        }

        /// <summary>
        /// Koyu temaya geçiş yapar
        /// </summary>
        public static void SetDarkTheme()
        {
            IsDarkMode = true;
            CurrentTheme = DARK_THEME;
            ApplyTheme();
            SaveThemePreference();
        }

        /// <summary>
        /// Açık temaya geçiş yapar
        /// </summary>
        public static void SetLightTheme()
        {
            IsDarkMode = false;
            CurrentTheme = LIGHT_THEME;
            ApplyTheme();
            SaveThemePreference();
        }

        /// <summary>
        /// Tema arasında geçiş yapar (toggle)
        /// </summary>
        public static void ToggleTheme()
        {
            if (IsDarkMode)
                SetLightTheme();
            else
                SetDarkTheme();
        }

        /// <summary>
        /// Belirli bir temayı uygular
        /// </summary>
        public static void SetTheme(string themeName)
        {
            CurrentTheme = themeName;
            IsDarkMode = themeName.Contains("Dark") || themeName.Contains("Black");
            ApplyTheme();
            SaveThemePreference();
        }

        /// <summary>
        /// Temayı uygular
        /// </summary>
        private static void ApplyTheme()
        {
            try
            {
                UserLookAndFeel.Default.SetSkinStyle(CurrentTheme);
            }
            catch
            {
                // Tema bulunamazsa varsayılan temayı kullan
                UserLookAndFeel.Default.SetSkinStyle(IsDarkMode ? DARK_THEME_ALT : LIGHT_THEME_ALT);
            }
        }

        /// <summary>
        /// Kayıtlı tema tercihini yükler
        /// </summary>
        private static void LoadSavedTheme()
        {
            try
            {
                string settingsPath = GetSettingsFilePath();
                if (File.Exists(settingsPath))
                {
                    string[] settings = File.ReadAllLines(settingsPath);
                    if (settings.Length > 0)
                    {
                        CurrentTheme = settings[0];
                        IsDarkMode = CurrentTheme.Contains("Dark") || CurrentTheme.Contains("Black");
                    }
                }
            }
            catch
            {
                // Hata durumunda varsayılan tema kullanılır
                CurrentTheme = LIGHT_THEME;
                IsDarkMode = false;
            }
        }

        /// <summary>
        /// Tema tercihini kaydeder
        /// </summary>
        private static void SaveThemePreference()
        {
            try
            {
                string settingsPath = GetSettingsFilePath();
                string? directory = Path.GetDirectoryName(settingsPath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                File.WriteAllText(settingsPath, CurrentTheme);
            }
            catch
            {
                // Kaydetme hatası göz ardı edilir
            }
        }

        /// <summary>
        /// Ayar dosyası yolunu döndürür
        /// </summary>
        private static string GetSettingsFilePath()
        {
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(appData, "OkulSistemOtomasyon", "theme.settings");
        }

        /// <summary>
        /// Kullanılabilir tüm temaları döndürür
        /// </summary>
        public static List<ThemeInfo> GetAvailableThemes()
        {
            return new List<ThemeInfo>
            {
                // Açık Temalar
                new ThemeInfo("Office 2019 Colorful", "Office 2019 Renkli", false),
                new ThemeInfo("Office 2019 White", "Office 2019 Beyaz", false),
                new ThemeInfo("Bezier", "Bezier", false),
                new ThemeInfo("WXI", "WXI Modern", false),
                new ThemeInfo("Basic", "Basic", false),
                
                // Koyu Temalar
                new ThemeInfo("Office 2019 Black", "Office 2019 Siyah", true),
                new ThemeInfo("Office 2019 Dark Gray", "Office 2019 Koyu Gri", true),
                new ThemeInfo("Visual Studio 2019 Dark", "VS 2019 Koyu", true),
                new ThemeInfo("The Bezier Dark", "Bezier Koyu", true),
                new ThemeInfo("WXI Dark", "WXI Koyu", true),
            };
        }
    }

    /// <summary>
    /// Tema bilgisi sınıfı
    /// </summary>
    public class ThemeInfo
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool IsDark { get; set; }

        public ThemeInfo(string name, string displayName, bool isDark)
        {
            Name = name;
            DisplayName = displayName;
            IsDark = isDark;
        }

        public override string ToString()
        {
            return $"{DisplayName} {(IsDark ? "🌙" : "☀️")}";
        }
    }
}
