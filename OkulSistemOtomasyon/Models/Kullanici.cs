using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OkulSistemOtomasyon.Models
{
    /// <summary>
    /// Kullanıcı bilgilerini temsil eden model (Giriş için)
    /// </summary>
    public class Kullanici
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KullaniciId { get; set; }

        [Required]
        [StringLength(50)]
        public string KullaniciAdi { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Sifre { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Ad { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Soyad { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Email { get; set; }

        [Required]
        [StringLength(20)]
        public string Rol { get; set; } = "Kullanici"; // Admin, Ogretmen, Kullanici

        public DateTime OlusturmaTarihi { get; set; } = DateTime.Now;

        public DateTime? SonGirisTarihi { get; set; }

        public bool Aktif { get; set; } = true;

        [NotMapped]
        public string TamAd => $"{Ad} {Soyad}";
    }
}
