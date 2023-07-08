using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IntProg.Models
{
    public partial class tiyatroContext : DbContext
    {
        public tiyatroContext()
        {
        }

        public tiyatroContext(DbContextOptions<tiyatroContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aktor> Aktors { get; set; } = null!;
        public virtual DbSet<Gosteri> Gosteris { get; set; } = null!;
        public virtual DbSet<Login> Logins { get; set; } = null!;
        public virtual DbSet<Tur> Turs { get; set; } = null!;
        public virtual DbSet<Yazar> Yazars { get; set; } = null!;
        public virtual DbSet<Yonetman> Yonetmen { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(" Data Source=LAPTOP-P9Q5LKQ9\\SQLEXPRESS;initial Catalog=tiyatro;trusted_connection=yes ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aktor>(entity =>
            {
                entity.Property(e => e.AktorId).ValueGeneratedNever();

                entity.HasOne(d => d.Gosteri)
                    .WithMany(p => p.Aktors)
                    .HasForeignKey(d => d.GosteriId)
                    .HasConstraintName("FK_Aktor_Gosteri");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
