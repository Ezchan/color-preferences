using colors.Models;
using Microsoft.EntityFrameworkCore;

namespace colors.Persistence
{
    public class ColorsDbContext : DbContext
    {
      public ColorsDbContext(DbContextOptions<ColorsDbContext> options): base(options) {
      
      }


      public DbSet<Entry> Entries { get; set; }
      public DbSet<StatsResult> StatsResults { get; set; }
      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
          modelBuilder.Ignore<StatsResult>();
          modelBuilder.Entity<StatsResult>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
          modelBuilder.Entity<StatsResult>().HasNoKey().ToTable("StatsResults", t => t.ExcludeFromMigrations());
      }
        
    }
}