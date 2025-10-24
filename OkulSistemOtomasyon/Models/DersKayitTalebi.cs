using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OkulSistemOtomasyon.Models
{
    /// <summary>
    /// Öğrencinin ders kayıt talebi
    /// Danışman onayladıktan sonra OgrenciNot'a dönüşür
    /// </summary>
    public class DersKayitTalebi : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TalepId { get; set; }

        /// <summary>
        /// Talebi gönderen öğrenci
        /// </summary>
        public int OgrenciId { get; set; }

        /// <summary>
        /// Kayıt olmak istenen ders
        /// </summary>
        public int DersId { get; set; }

        /// <summary>
        /// Talebin durumu
        /// </summary>
        public DersKayitDurumu Durum { get; set; } = DersKayitDurumu.Beklemede;

        /// <summary>
        /// Talep tarihi
        /// </summary>
        public DateTime TalepTarihi { get; set; } = DateTime.Now;

        /// <summary>
        /// Onay/Red tarihi
        /// </summary>
        public DateTime? KararTarihi { get; set; }

        /// <summary>
        /// Danışman notu (isteğe bağlı)
        /// </summary>
        [StringLength(500)]
        public string? DanismanNotu { get; set; }

        // Navigation Properties
        [ForeignKey("OgrenciId")]
        public virtual Ogrenci Ogrenci { get; set; }

        [ForeignKey("DersId")]
        public virtual Ders Ders { get; set; }
    }

    /// <summary>
    /// Ders kayıt talebinin durumu
    /// </summary>
    public enum DersKayitDurumu
    {
        Beklemede = 0,
        Onaylandi = 1,
        Reddedildi = 2
    }
}
