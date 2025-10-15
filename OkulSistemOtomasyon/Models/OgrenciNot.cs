using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OkulSistemOtomasyon.Models
{
    /// <summary>
    /// Öğrenci notlarını temsil eden model
    /// </summary>
    public class OgrenciNot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NotId { get; set; }

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

        [NotMapped]
        public decimal? Ortalama
        {
            get
            {
                if (Vize.HasValue && Final.HasValue)
                {
                    decimal ortalama = (Vize.Value * 0.4m) + (Final.Value * 0.6m);
                    
                    if (ProjeNotu.HasValue)
                    {
                        ortalama = (ortalama * 0.8m) + (ProjeNotu.Value * 0.2m);
                    }

                    return Math.Round(ortalama, 2);
                }
                return null;
            }
        }

        [NotMapped]
        public string? HarfNotu
        {
            get
            {
                if (!Ortalama.HasValue) return null;

                return Ortalama.Value switch
                {
                    >= 90 => "AA",
                    >= 85 => "BA",
                    >= 80 => "BB",
                    >= 75 => "CB",
                    >= 70 => "CC",
                    >= 65 => "DC",
                    >= 60 => "DD",
                    >= 50 => "FD",
                    _ => "FF"
                };
            }
        }

        [NotMapped]
        public bool Gecti => Ortalama >= 60;
    }
}
