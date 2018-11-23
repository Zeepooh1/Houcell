using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HouCell.Models
{
    public partial class HoucellContext : DbContext
    {
        public HoucellContext()
        {
        }

        public HoucellContext(DbContextOptions<HoucellContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Hisa> Hisa { get; set; }
        public virtual DbSet<Senzorji> Senzorji { get; set; }
        public virtual DbSet<Soba> Soba { get; set; }
        public virtual DbSet<Tipsenzorja> Tipsenzorja { get; set; }
        public virtual DbSet<Uporabnik> Uporabnik { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //**********************************************************************
                //*NUJNO!!!! v spodnjem stringu morš spremenit server, user pa password*
                //*server=houcellbase.ddns.net                                         *
                //*user=remote                                                         *
                //*password=seminarskaGeslo                                            *
                //**********************************************************************
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=;database=Houcell");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hisa>(entity =>
            {
                entity.ToTable("hisa", "houcell");

                entity.HasIndex(e => e.UserId)
                    .HasName("userID");

                entity.Property(e => e.HisaId)
                    .HasColumnName("hisaID")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Naslov)
                    .IsRequired()
                    .HasColumnName("naslov")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("userID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Hisa)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("hisa_ibfk_1");
            });

            modelBuilder.Entity<Senzorji>(entity =>
            {
                entity.HasKey(e => new { e.SenzorId, e.SobaId });

                entity.ToTable("senzorji", "houcell");

                entity.HasIndex(e => e.SobaId)
                    .HasName("sobaID");

                entity.Property(e => e.SenzorId)
                    .HasColumnName("senzorID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SobaId)
                    .HasColumnName("sobaID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.VrednostSenzorja)
                    .HasColumnName("vrednostSenzorja")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Senzor)
                    .WithMany(p => p.Senzorji)
                    .HasForeignKey(d => d.SenzorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("senzorji_ibfk_1");

                entity.HasOne(d => d.Soba)
                    .WithMany(p => p.Senzorji)
                    .HasForeignKey(d => d.SobaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("senzorji_ibfk_2");
            });

            modelBuilder.Entity<Soba>(entity =>
            {
                entity.ToTable("soba", "houcell");

                entity.HasIndex(e => e.HisaId)
                    .HasName("hisaID");

                entity.Property(e => e.SobaId)
                    .HasColumnName("sobaID")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.HisaId)
                    .HasColumnName("hisaID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ImeSobe)
                    .IsRequired()
                    .HasColumnName("imeSobe")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.HasOne(d => d.Hisa)
                    .WithMany(p => p.Soba)
                    .HasForeignKey(d => d.HisaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("soba_ibfk_1");
            });

            modelBuilder.Entity<Tipsenzorja>(entity =>
            {
                entity.HasKey(e => e.SenzorId);

                entity.ToTable("tipsenzorja", "houcell");

                entity.Property(e => e.SenzorId)
                    .HasColumnName("senzorID")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.ImeSenzorja)
                    .IsRequired()
                    .HasColumnName("imeSenzorja")
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Uporabnik>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("uporabnik", "houcell");

                entity.Property(e => e.UserId)
                    .HasColumnName("userID")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });
        }
    }
}
