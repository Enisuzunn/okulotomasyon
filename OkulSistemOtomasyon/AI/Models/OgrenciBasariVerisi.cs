using Microsoft.ML.Data;

namespace OkulSistemOtomasyon.AI.Models
{
    /// <summary>
    /// ML.NET eğitim verisi için kullanılan model
    /// Öğrencinin ders performans verilerini içerir
    /// </summary>
    public class OgrenciBasariVerisi
    {
        /// <summary>
        /// Öğrencinin vize notu (0-100)
        /// </summary>
        [LoadColumn(0)]
        public float VizeNotu { get; set; }

        /// <summary>
        /// Öğrencinin proje notu (0-100), yoksa 0
        /// </summary>
        [LoadColumn(1)]
        public float ProjeNotu { get; set; }

        /// <summary>
        /// Dersin kredi değeri
        /// </summary>
        [LoadColumn(2)]
        public float DersKredisi { get; set; }

        /// <summary>
        /// Öğrencinin final notu (Regression için hedef değişken)
        /// </summary>
        [LoadColumn(3)]
        public float FinalNotu { get; set; }

        /// <summary>
        /// Öğrenci dersi geçti mi? (Classification için hedef değişken)
        /// </summary>
        [LoadColumn(4)]
        [ColumnName("Label")]
        public bool Gecti { get; set; }
    }
}

