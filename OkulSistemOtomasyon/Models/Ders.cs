using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OkulSistemOtomasyon.Models
{
    /// <summary>
    /// Ders bilgilerini temsil eden model (İlkokul-Ortaokul-Lise için)
    /// </summary>
    public class Ders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DersId { get; set; }

        [Required]
        [StringLength(100)]
        public string DersAdi { get; set; } = string.Empty;

        [StringLength(20)]
        public string? DersKodu { get; set; }

        /// <summary>
        /// Haftalık ders saati sayısı (İlkokul-Ortaokul-Lise için)
        /// </summary>
        public int HaftalikDersSaati { get; set; } = 4;

        public int SinifId { get; set; }

        [ForeignKey("SinifId")]
        public virtual Sinif? Sinif { get; set; }

        public int? OgretmenId { get; set; }

        [ForeignKey("OgretmenId")]
        public virtual Ogretmen? Ogretmen { get; set; }

        [StringLength(50)]
        public string? DonemBilgisi { get; set; } // 1. Dönem, 2. Dönem

        public bool Aktif { get; set; } = true;

        // Navigation property
        public virtual ICollection<OgrenciNot> Notlar { get; set; } = new List<OgrenciNot>();
    }
}
