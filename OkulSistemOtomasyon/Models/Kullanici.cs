using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OkulSistemOtomasyon.Models
{
    /// <summary>
    /// Kullanıcı bilgilerini temsil eden model (Giriş için)
    /// OOP: Inheritance - BaseEntity'den türetildi
    /// </summary>
    public class Kullanici : BaseEntity
    {
        [NotMapped]
        public int KullaniciId => Id; // Geriye dönük uyumluluk için

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

        [NotMapped]
        public DateTime OlusturmaTarihi 
        {
            get => CreatedDate;
            set => CreatedDate = value;
        }

        public DateTime? SonGirisTarihi { get; set; }

        [NotMapped]
        public bool Aktif 
        {
            get => IsActive;
            set => IsActive = value;
        }

        [NotMapped]
        public string TamAd => $"{Ad} {Soyad}";
    }
}
