using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IntProg.Models
{
    [Table("Gosteri")]
    public partial class Gosteri
    {
        public Gosteri()
        {
            Aktors = new HashSet<Aktor>();
        }

        [Key]
        public int GosteriId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? GosteriAd { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? GosteriTarih { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? GosteriYeri { get; set; }

        [InverseProperty("Gosteri")]
        public virtual ICollection<Aktor> Aktors { get; set; }
    }
}
