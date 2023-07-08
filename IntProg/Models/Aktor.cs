using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IntProg.Models
{
    [Table("Aktor")]
    public partial class Aktor
    {
        [Key]
        public int AktorId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? AktorAd { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? SonGosteri { get; set; }
        public int? GosteriId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? AktorResim { get; set; }

        [ForeignKey("GosteriId")]
        [InverseProperty("Aktors")]
        public virtual Gosteri? Gosteri { get; set; }
    }
}
