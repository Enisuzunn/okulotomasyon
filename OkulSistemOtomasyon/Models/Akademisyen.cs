using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OkulSistemOtomasyon.Models
{
    /// <summary>
    /// Akademisyen/Öğretim üyesi bilgilerini temsil eden model
    /// OOP: Inheritance - BaseEntity'den türetildi
    /// </summary>
    public class Akademisyen : BaseEntity
    {
        // Kendi Id property'mizi tanımlıyoruz
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int Id { get; set; }
        
        [NotMapped]
        public int AkademisyenId => Id;

        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string TC { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Ad { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Soyad { get; set; } = string.Empty;

        /// <summary>
        /// Akademik unvan (Profesör, Doçent, Dr. Öğr. Üyesi, Öğr. Gör., Arş. Gör.)
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Unvan { get; set; } = "Öğr. Gör.";

        /// <summary>
        /// Uzmanlık alanı (Yazılım Mühendisliği, Veri Bilimi, İşletme Yönetimi vb.)
        /// </summary>
        [StringLength(100)]
        public string? UzmanlikAlani { get; set; }

        [StringLength(100)]
        public string? Email { get; set; }

        [StringLength(15)]
        public string? Telefon { get; set; }

        public DateTime? DogumTarihi { get; set; }

        public DateTime? IseGirisTarihi { get; set; }

        [StringLength(200)]
        public string? Adres { get; set; }

        [NotMapped]
        public bool Aktif 
        {
            get => IsActive;
            set => IsActive = value;
        }

        // Navigation Properties
        public virtual ICollection<Ders> Dersler { get; set; } = new List<Ders>();
    }
}
