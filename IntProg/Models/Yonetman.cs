using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IntProg.Models
{
    public partial class Yonetman
    {
        [Key]
        public int YonetmenId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? YonetmenAd { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? YonetmenMemleket { get; set; }
        public int? YonetmenYas { get; set; }
    }
}
