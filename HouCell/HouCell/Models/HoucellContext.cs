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
                optionsBuilder.UseMySQL("server=houcellbase.ddns.net ;port=3306;user=remote;password=seminarskaGeslo;database=Houcell");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hisa>(entity =>
            {
                entity.ToTable("hisa", "houcell");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_userID");

                entity.Property(e => e.HisaId)
                    .HasColumnName("hisaID")
                    .HasColumnType("int(11)");

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
                    .HasConstraintName("fk_userID");
            });

            modelBuilder.Entity<Senzorji>(entity =>
            {
                entity.HasKey(e => new { e.SenzorId, e.SobaId });

                entity.ToTable("senzorji", "houcell");

                entity.HasIndex(e => e.SobaId)
                    .HasName("fk_sobaID");

                entity.Property(e => e.SenzorId)
                    .HasColumnName("senzorID")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.SobaId)
                    .HasColumnName("sobaID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.VrednostSenzorja)
                    .HasColumnName("vrednostSenzorja")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Senzor)
                    .WithMany(p => p.Senzorji)
                    .HasForeignKey(d => d.SenzorId)
                    .HasConstraintName("fk_senzorID");

                entity.HasOne(d => d.Soba)
                    .WithMany(p => p.Senzorji)
                    .HasForeignKey(d => d.SobaId)
                    .HasConstraintName("fk_sobaID");
            });

            modelBuilder.Entity<Soba>(entity =>
            {
                entity.ToTable("soba", "houcell");

                entity.HasIndex(e => e.HisaId)
                    .HasName("fk_hisaID");

                entity.Property(e => e.SobaId)
                    .HasColumnName("sobaID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.HisaId)
                    .HasColumnName("hisaID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ImeSobe)
                    .IsRequired()
                    .HasColumnName("imeSobe")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Hisa)
                    .WithMany(p => p.Soba)
                    .HasForeignKey(d => d.HisaId)
                    .HasConstraintName("fk_hisaID");
            });

            modelBuilder.Entity<Tipsenzorja>(entity =>
            {
                entity.HasKey(e => e.SenzorId);

                entity.ToTable("tipsenzorja", "houcell");

                entity.Property(e => e.SenzorId)
                    .HasColumnName("senzorID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ImeSenzorja)
                    .IsRequired()
                    .HasColumnName("imeSenzorja")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Uporabnik>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("uporabnik", "houcell");

                entity.Property(e => e.UserId)
                    .HasColumnName("userID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasColumnName("pass")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
