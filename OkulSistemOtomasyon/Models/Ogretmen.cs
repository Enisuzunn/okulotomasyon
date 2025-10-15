using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OkulSistemOtomasyon.Models
{
    /// <summary>
    /// Öğretmen bilgilerini temsil eden model
    /// </summary>
    public class Ogretmen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OgretmenId { get; set; }

        [Required]
        [StringLength(50)]
        public string Ad { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Soyad { get; set; } = string.Empty;

        [Required]
        [StringLength(11)]
        public string TC { get; set; } = string.Empty;

        [Required]
        public DateTime DogumTarihi { get; set; }

        [StringLength(100)]
        public string? Adres { get; set; }

        [StringLength(15)]
        public string? Telefon { get; set; }

        [StringLength(100)]
        public string? Email { get; set; }

        [StringLength(50)]
        public string? Brans { get; set; }

        public DateTime IseGirisTarihi { get; set; } = DateTime.Now;

        public bool Aktif { get; set; } = true;

        // Navigation property
        public virtual ICollection<Ders> Dersler { get; set; } = new List<Ders>();

        [NotMapped]
        public string TamAd => $"{Ad} {Soyad}";
    }
}
