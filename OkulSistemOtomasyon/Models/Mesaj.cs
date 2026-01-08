using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OkulSistemOtomasyon.Models
{
    public class Mesaj : BaseEntity
    {
        public int GondericiId { get; set; }
        public int AliciId { get; set; }

        [Required]
        [StringLength(100)]
        public string Konu { get; set; }

        [Required]
        [StringLength(2000)]
        public string Icerik { get; set; }

        public bool Okundu { get; set; } = false;

        // Navigation Properties
        [ForeignKey("GondericiId")]
        public virtual Kullanici Gonderici { get; set; }

        [ForeignKey("AliciId")]
        public virtual Kullanici Alici { get; set; }
    }
}
