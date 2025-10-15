using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OkulSistemOtomasyon.Models
{
    /// <summary>
    /// Ders bilgilerini temsil eden model
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

        public int Kredi { get; set; } = 3;

        public int SinifId { get; set; }

        [ForeignKey("SinifId")]
        public virtual Sinif? Sinif { get; set; }

        public int? OgretmenId { get; set; }

        [ForeignKey("OgretmenId")]
        public virtual Ogretmen? Ogretmen { get; set; }

        [StringLength(50)]
        public string? DonemBilgisi { get; set; } // Güz, Bahar vs.

        public bool Aktif { get; set; } = true;

        // Navigation property
        public virtual ICollection<OgrenciNot> Notlar { get; set; } = new List<OgrenciNot>();
    }
}
