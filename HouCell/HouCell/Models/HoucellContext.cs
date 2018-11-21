using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HouCell.Models
{
    public partial class HouCellContext : DbContext
    {
        public HouCellContext()
        {
        }

        public HouCellContext(DbContextOptions<HouCellContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Senzorji> Senzorji { get; set; }
        public virtual DbSet<Sobe> Sobe { get; set; }
        public virtual DbSet<TipiSenzorjev> TipiSenzorjev { get; set; }
        public virtual DbSet<Uporabniki> Uporabniki { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=HouCell;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Senzorji>(entity =>
            {
                entity.HasKey(e => e.IdSenzor);

                entity.ToTable("senzorji");

                entity.Property(e => e.IdSenzor).HasColumnName("idSenzor");

                entity.Property(e => e.IdSobe).HasColumnName("idSobe");

                entity.Property(e => e.IdTip).HasColumnName("idTip");

                entity.Property(e => e.Vrednost).HasColumnName("vrednost");

                entity.HasOne(d => d.IdSobeNavigation)
                    .WithMany(p => p.Senzorji)
                    .HasForeignKey(d => d.IdSobe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__senzorji__idSobe__145C0A3F");

                entity.HasOne(d => d.IdTipNavigation)
                    .WithMany(p => p.Senzorji)
                    .HasForeignKey(d => d.IdTip)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__senzorji__idTip__15502E78");
            });

            modelBuilder.Entity<Sobe>(entity =>
            {
                entity.ToTable("sobe");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasColumnName("ime")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipiSenzorjev>(entity =>
            {
                entity.ToTable("tipiSenzorjev");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasColumnName("ime")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Uporabniki>(entity =>
            {
                entity.ToTable("uporabniki");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Geslo)
                    .IsRequired()
                    .HasColumnName("geslo")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasColumnName("ime")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });
        }
    }
}
