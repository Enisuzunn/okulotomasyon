using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OkulSistemOtomasyon.Models
{
    /// <summary>
    /// Kullanıcı rolleri enum
    /// </summary>
    public enum KullaniciRolu
    {
        Admin = 1,
        Akademisyen = 2,
        Ogrenci = 3
    }

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

        /// <summary>
        /// Kullanıcının rolü (Admin, Akademisyen, Ogrenci)
        /// </summary>
        [Required]
        public KullaniciRolu Rol { get; set; } = KullaniciRolu.Ogrenci;

        /// <summary>
        /// Akademisyen ise, ilişkili akademisyen Id
        /// </summary>
        public int? AkademisyenId { get; set; }

        [ForeignKey("AkademisyenId")]
        public virtual Akademisyen? Akademisyen { get; set; }

        /// <summary>
        /// Öğrenci ise, ilişkili öğrenci Id
        /// </summary>
        public int? OgrenciId { get; set; }

        [ForeignKey("OgrenciId")]
        public virtual Ogrenci? Ogrenci { get; set; }

        public DateTime OlusturmaTarihi { get; set; } = DateTime.Now;

        public DateTime? SonGirisTarihi { get; set; }

        /// <summary>
        /// İlk giriş mi? (Şifre değiştirme zorunluluğu için)
        /// </summary>
        public bool IlkGiris { get; set; } = true;

        /// <summary>
        /// Son şifre değiştirme tarihi
        /// </summary>
        public DateTime? SonSifreDegistirmeTarihi { get; set; }

        public bool Aktif { get; set; } = true;

        [NotMapped]
        public string TamAd => $"{Ad} {Soyad}";

        [NotMapped]
        public string RolAdi => Rol switch
        {
            KullaniciRolu.Admin => "Yönetici",
            KullaniciRolu.Akademisyen => "Akademisyen",
            KullaniciRolu.Ogrenci => "Öğrenci",
            _ => "Bilinmeyen"
        };
    }
}
