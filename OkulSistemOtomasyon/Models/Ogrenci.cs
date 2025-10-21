using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OkulSistemOtomasyon.Models
{
    /// <summary>
    /// Üniversite öğrenci bilgilerini temsil eden model
    /// OOP: Inheritance - BaseEntity'den türetildi
    /// </summary>
    public class Ogrenci : BaseEntity
    {
        // BaseEntity'den Id, CreatedDate, UpdatedDate, IsActive miras alındı
        
        [NotMapped]
        public int OgrenciId => Id; // Geriye dönük uyumluluk için

        [Required]
        [StringLength(50)]
        public string Ad { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Soyad { get; set; } = string.Empty;

        [Required]
        [StringLength(11)]
        public string TC { get; set; } = string.Empty;

        /// <summary>
        /// Öğrenci numarası (örn: 220201001)
        /// </summary>
        [StringLength(20)]
        public string? OgrenciNo { get; set; }

        [Required]
        public DateTime DogumTarihi { get; set; }

        [StringLength(100)]
        public string? Adres { get; set; }

        [StringLength(15)]
        public string? Telefon { get; set; }

        [StringLength(100)]
        public string? Email { get; set; }

        /// <summary>
        /// Kayıt yılı (2020, 2021, 2022 vb.)
        /// </summary>
        public int? KayitYili { get; set; }

        /// <summary>
        /// Kaçıncı sınıf (1, 2, 3, 4, 5, 6, 7, 8)
        /// </summary>
        [Range(1, 8)]
        public int? Sinif { get; set; }

        [Required]
        public int BolumId { get; set; }

        [ForeignKey("BolumId")]
        public virtual Bolum? Bolum { get; set; }

        // BaseEntity'den miras alınan özellikler kullanılıyor
        // public DateTime CreatedDate { get; set; } = DateTime.Now;
        // public bool IsActive { get; set; } = true;
        
        [NotMapped]
        public DateTime KayitTarihi 
        {
            get => CreatedDate;
            set => CreatedDate = value;
        }
        
        [NotMapped]
        public bool Aktif 
        {
            get => IsActive;
            set => IsActive = value;
        }

        // Navigation property
        public virtual ICollection<OgrenciNot> Notlar { get; set; } = new List<OgrenciNot>();

        [NotMapped]
        public string TamAd => $"{Ad} {Soyad}";
    }
}
