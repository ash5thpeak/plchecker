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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicine>().ToTable("Medicine");
            modelBuilder.Entity<MedicineAttribution>().ToTable("MedicineAttribution");
        }
    }
}

