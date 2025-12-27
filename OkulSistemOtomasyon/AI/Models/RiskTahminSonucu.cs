using Microsoft.ML.Data;

namespace OkulSistemOtomasyon.AI.Models
{
    /// <summary>
    /// Risk analizi tahmin sonucu
    /// Binary Classification sonucu
    /// </summary>
    public class RiskTahminSonucu
    {
        /// <summary>
        /// Tahmin edilen sonuç (true = geçer, false = kalır)
        /// </summary>
        [ColumnName("PredictedLabel")]
        public bool TahminGecti { get; set; }

        /// <summary>
        /// Geçme olasılığı (0.0 - 1.0 arası)
        /// </summary>
        [ColumnName("Probability")]
        public float GecmeOlasiligi { get; set; }

        /// <summary>
        /// Model skoru
        /// </summary>
        [ColumnName("Score")]
        public float Skor { get; set; }

        /// <summary>
        /// Kalma riski yüzdesi (100 - GecmeOlasiligi * 100)
        /// </summary>
        public float KalmaRiskiYuzdesi => (1 - GecmeOlasiligi) * 100;

        /// <summary>
        /// Risk durumu açıklaması
        /// </summary>
        public string RiskDurumu
        {
            get
            {
                if (KalmaRiskiYuzdesi >= 60) return "🔴 Yüksek Risk";
                if (KalmaRiskiYuzdesi >= 30) return "🟡 Orta Risk";
                return "🟢 Düşük Risk";
            }
        }
    }

    /// <summary>
    /// Final notu tahmin sonucu
    /// Regression sonucu
    /// </summary>
    public class FinalTahminSonucu
    {
        /// <summary>
        /// Tahmin edilen final notu
        /// </summary>
        [ColumnName("Score")]
        public float TahminiFinalNotu { get; set; }
    }

    /// <summary>
    /// Final tahmini için giriş verisi
    /// </summary>
    public class FinalTahminGirisi
    {
        public float VizeNotu { get; set; }
        public float ProjeNotu { get; set; }
        public float DersKredisi { get; set; }
    }
}

