using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Final.Models
{
    public partial class FinalContext : DbContext
    {
        public FinalContext()
        {
        }

        public FinalContext(DbContextOptions<FinalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Format> Formats { get; set; } = null!;
        public virtual DbSet<Player> Players { get; set; } = null!;
        public virtual DbSet<SeriesEntry> SeriesEntries { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=DEVELOPER;Database=Final;Trusted_Connection=True;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Format>(entity =>
            {
                entity.Property(e => e.FormatName).HasMaxLength(100);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Phone).HasMaxLength(100);

                entity.Property(e => e.PlayerName).HasMaxLength(100);
            });

            modelBuilder.Entity<SeriesEntry>(entity =>
            {
                entity.ToTable("SeriesEntry");

                entity.HasOne(d => d.Format)
                    .WithMany(p => p.SeriesEntries)
                    .HasForeignKey(d => d.FormatId)
                    .HasConstraintName("FK__SeriesEnt__Forma__29572725");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.SeriesEntries)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("FK__SeriesEnt__Playe__286302EC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
