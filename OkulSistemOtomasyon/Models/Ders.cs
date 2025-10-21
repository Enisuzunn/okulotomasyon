using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OkulSistemOtomasyon.Models
{
    /// <summary>
    /// Üniversite ders bilgilerini temsil eden model
    /// OOP: Inheritance - BaseEntity'den türetildi
    /// </summary>
    public class Ders : BaseEntity
    {
        // Kendi Id property'mizi tanımlıyoruz
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int Id { get; set; }
        
        [NotMapped]
        public int DersId => Id;

        [Required]
        [StringLength(100)]
        public string DersAdi { get; set; } = string.Empty;

        /// <summary>
        /// Ders kodu (BLM401, ISL201, HUK301 vb.)
        /// </summary>
        [StringLength(20)]
        public string? DersKodu { get; set; }

        /// <summary>
        /// Kredi değeri (2, 3, 4, 5 vb.)
        /// </summary>
        [Range(1, 10)]
        public int Kredi { get; set; } = 3;

        /// <summary>
        /// AKTS (Avrupa Kredi Transfer Sistemi)
        /// </summary>
        [Range(1, 15)]
        public int? AKTS { get; set; }

        /// <summary>
        /// Dönem bilgisi (Güz Dönemi, Bahar Dönemi, Yaz Okulu)
        /// </summary>
        [StringLength(50)]
        public string? DonemBilgisi { get; set; }

        [Required]
        public int BolumId { get; set; }

        [ForeignKey("BolumId")]
        public virtual Bolum? Bolum { get; set; }

        public int? AkademisyenId { get; set; }

        [ForeignKey("AkademisyenId")]
        public virtual Akademisyen? Akademisyen { get; set; }

        [NotMapped]
        public bool Aktif 
        {
            get => IsActive;
            set => IsActive = value;
        }

        // Navigation property
        public virtual ICollection<OgrenciNot> Notlar { get; set; } = new List<OgrenciNot>();
    }
}
