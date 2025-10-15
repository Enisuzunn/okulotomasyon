using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OkulSistemOtomasyon.Models
{
    /// <summary>
    /// Sınıf bilgilerini temsil eden model
    /// </summary>
    public class Sinif
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SinifId { get; set; }

        [Required]
        [StringLength(50)]
        public string SinifAdi { get; set; } = string.Empty;

        [Required]
        public int Seviye { get; set; } // 1-12 arası

        [StringLength(10)]
        public string? Sube { get; set; } // A, B, C vs.

        public int Kontenjan { get; set; } = 30;

        [StringLength(50)]
        public string? DersYili { get; set; } // 2024-2025

        public bool Aktif { get; set; } = true;

        // Navigation properties
        public virtual ICollection<Ogrenci> Ogrenciler { get; set; } = new List<Ogrenci>();
        public virtual ICollection<Ders> Dersler { get; set; } = new List<Ders>();

        [NotMapped]
        public int MevcutOgrenciSayisi => Ogrenciler?.Count(o => o.Aktif) ?? 0;
    }
}
