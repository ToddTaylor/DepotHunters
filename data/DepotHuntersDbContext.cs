using data.Models;
using Microsoft.EntityFrameworkCore;

namespace data
{
    public partial class DepotHunterDbContext : DbContext
    {
        public DepotHunterDbContext(DbContextOptions<DepotHunterDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Depot> Depot { get; set; }
        public virtual DbSet<DepotLocation> DepotLocation { get; set; }
        public virtual DbSet<DepotPhoto> DepotPhoto { get; set; }
        public virtual DbSet<Railroad> Railroad { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Depot>(entity =>
            {
                entity.HasMany(d => d.Railroad)
                    .WithMany(p => p.Depot)
                    .UsingEntity<Dictionary<string, object>>(
                        "DepotRailroad",
                        l => l.HasOne<Railroad>().WithMany().HasForeignKey("RailroadId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_DepotRailroad_Railroad"),
                        r => r.HasOne<Depot>().WithMany().HasForeignKey("DepotId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_DepotRailroad_Depot"),
                        j =>
                        {
                            j.HasKey("DepotId", "RailroadId");

                            j.ToTable("DepotRailroad");
                        });
            });

            modelBuilder.Entity<DepotLocation>(entity =>
            {
                entity.Property(e => e.Latitude)
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Longitude)
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Depot)
                    .WithMany(p => p.DepotLocation)
                    .HasForeignKey(d => d.DepotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DepotLocation_Depot");
            });

            modelBuilder.Entity<DepotPhoto>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Photographer)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.YearTaken)
                    .HasMaxLength(4)
                    .IsFixedLength();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.DepotPhoto)
                    .HasForeignKey<DepotPhoto>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DepotPhoto_Depot");
            });

            modelBuilder.Entity<Railroad>(entity =>
            {
                entity.Property(entity => entity.Id).ValueGeneratedOnAdd();
                entity.Property(entity => entity.Name).HasMaxLength(75);
                entity.Property(entity => entity.ReportingMark).HasMaxLength(4);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}