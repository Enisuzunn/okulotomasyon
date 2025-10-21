using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OkulSistemOtomasyon.Models
{
    /// <summary>
    /// Tüm entity sınıfları için temel soyut sınıf
    /// OOP: Inheritance (Kalıtım) ve Abstraction (Soyutlama) prensiplerine uygun
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Benzersiz kimlik
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Kayıt oluşturulma tarihi
        /// </summary>
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Son güncellenme tarihi
        /// </summary>
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// Aktif/Pasif durum
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Entity güncellendiğinde çağrılır
        /// </summary>
        public virtual void OnUpdate()
        {
            UpdatedDate = DateTime.Now;
        }

        /// <summary>
        /// Entity silindiğinde çağrılır (Soft Delete)
        /// </summary>
        public virtual void OnDelete()
        {
            IsActive = false;
            UpdatedDate = DateTime.Now;
        }
    }
}
