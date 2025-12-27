using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OkulSistemOtomasyon.Models
{
    /// <summary>
    /// Öğrenci notlarını temsil eden model
    /// OOP: Inheritance - BaseEntity'den türetildi
    /// </summary>
    public class OgrenciNot : BaseEntity
    {
        // Kendi Id property'mizi tanımlıyoruz
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int Id { get; set; }
        
        [NotMapped]
        public int NotId => Id;

        [Required]
        public int OgrenciId { get; set; }

        [ForeignKey("OgrenciId")]
        public virtual Ogrenci? Ogrenci { get; set; }

        [Required]
        public int DersId { get; set; }

        [ForeignKey("DersId")]
        public virtual Ders? Ders { get; set; }

        [Range(0, 100)]
        public decimal? Vize { get; set; }

        [Range(0, 100)]
        public decimal? Final { get; set; }

        [Range(0, 100)]
        public decimal? Butunleme { get; set; }

        [Range(0, 100)]
        public decimal? ProjeNotu { get; set; }

        public DateTime? NotGirisTarihi { get; set; }

        [StringLength(500)]
        public string? Aciklama { get; set; }

        /// <summary>
        /// Genel Ortalama: Vize %40 + Final %60
        /// </summary>
        [NotMapped]
        public decimal? Ortalama
        {
            get
            {
                if (Vize.HasValue && Final.HasValue)
                {
                    // Ortalama = Vize * 0.40 + Final * 0.60
                    decimal ortalama = (Vize.Value * 0.4m) + (Final.Value * 0.6m);
                    return Math.Round(ortalama, 2);
                }
                return null;
            }
        }

        /// <summary>
        /// Harf Notu: 50 altı FF (kaldı), 50 ve üstü geçer notlar
        /// </summary>
        [NotMapped]
        public string? HarfNotu
        {
            get
            {
                if (!Ortalama.HasValue) return null;

                return Ortalama.Value switch
                {
                    >= 90 => "AA",  // 90-100: Pekiyi
                    >= 80 => "BA",  // 80-89: İyi-Pekiyi
                    >= 70 => "BB",  // 70-79: İyi
                    >= 60 => "CB",  // 60-69: Orta-İyi
                    >= 50 => "CC",  // 50-59: Orta (Geçer)
                    _ => "FF"       // 0-49: Başarısız (Kaldı)
                };
            }
        }

        /// <summary>
        /// Geçme durumu: 50 ve üstü geçer
        /// </summary>
        [NotMapped]
        public bool Gecti => Ortalama >= 50;
    }
}
