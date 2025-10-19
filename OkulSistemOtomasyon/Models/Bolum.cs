using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OkulSistemOtomasyon.Models
{
    /// <summary>
    /// Üniversite bölüm/program bilgilerini temsil eden model
    /// </summary>
    public class Bolum
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BolumId { get; set; }

        [Required]
        [StringLength(100)]
        public string BolumAdi { get; set; } = string.Empty;

        [StringLength(20)]
        public string? BolumKodu { get; set; }

        /// <summary>
        /// Hangi fakülteye bağlı (Mühendislik Fakültesi, İktisadi ve İdari Bilimler vb.)
        /// </summary>
        [StringLength(100)]
        public string? Fakulte { get; set; }

        /// <summary>
        /// Öğretim türü (Normal Öğretim, İkinci Öğretim, Uzaktan Eğitim)
        /// </summary>
        [StringLength(50)]
        public string? OgretimTuru { get; set; }

        /// <summary>
        /// Bölüm kontenjanı
        /// </summary>
        public int Kontenjan { get; set; }

        /// <summary>
        /// Akademik yıl (2024-2025)
        /// </summary>
        [StringLength(20)]
        public string? AkademikYil { get; set; }

        public bool Aktif { get; set; } = true;

        // Navigation Properties
        public virtual ICollection<Ogrenci> Ogrenciler { get; set; } = new List<Ogrenci>();
        public virtual ICollection<Ders> Dersler { get; set; } = new List<Ders>();

        [NotMapped]
        public int MevcutOgrenciSayisi => Ogrenciler?.Count(o => o.Aktif) ?? 0;
    }
}
