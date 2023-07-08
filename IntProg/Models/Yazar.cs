using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IntProg.Models
{
    [Table("Yazar")]
    public partial class Yazar
    {
        [Key]
        public int YazarId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? YazarAd { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? YazarMemleket { get; set; }
        public int? YazarYas { get; set; }
    }
}
