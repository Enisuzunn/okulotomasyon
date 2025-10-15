using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OkulSistemOtomasyon.Models
{
    /// <summary>
    /// Öğrenci bilgilerini temsil eden model
    /// </summary>
    public class Ogrenci
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OgrenciId { get; set; }

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

        [Required]
        public int SinifId { get; set; }

        [ForeignKey("SinifId")]
        public virtual Sinif? Sinif { get; set; }

        public DateTime KayitTarihi { get; set; } = DateTime.Now;

        public bool Aktif { get; set; } = true;

        // Navigation property
        public virtual ICollection<OgrenciNot> Notlar { get; set; } = new List<OgrenciNot>();

        [NotMapped]
        public string TamAd => $"{Ad} {Soyad}";
    }
}
