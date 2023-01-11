using Microsoft.EntityFrameworkCore;
using PL_Checker.Models;

namespace PL_Checker.Data.Context
{
    public class PharmaDbContext : DbContext
    {
        public PharmaDbContext(DbContextOptions<PharmaDbContext> options) : base(options)
        {
        }

        public DbSet<Medicine>? Medicines { get; set; }
        public DbSet<MedicineAttribution>? MedicineAttributions { get; set; }
        public DbSet<Location>? Locations { get; set; }
        public DbSet<SearchResult>? SearchResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicine>().ToTable(nameof(Medicine))
                .HasMany(ma => ma.MedicineAttributions);
            modelBuilder.Entity<MedicineAttribution>().ToTable(nameof(MedicineAttribution))
                .HasMany(l => l.Locations);
            modelBuilder.Entity<Location>().ToTable(nameof(Locations));
            modelBuilder.Entity<SearchResult>().ToTable(nameof(SearchResults));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            }
        }
    }
}

