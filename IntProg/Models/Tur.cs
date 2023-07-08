using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IntProg.Models
{
    [Table("Tur")]
    public partial class Tur
    {
        [Key]
        public int TurId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? TurAd { get; set; }
    }
}
