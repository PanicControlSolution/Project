using Lab5.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lab5.Persistence.Data
{
    public class AppDbContext : DbContext
    {
        private DbSet<Set> _sets => Set<Set>();
        private DbSet<Sushi> _sushi => Set<Sushi>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Set>().HasKey(x => x.Id);
            modelBuilder.Entity<Set>().Property(x => x.Cost).IsRequired();
            modelBuilder.Entity<Set>().Property(x => x.Weight).IsRequired();
            modelBuilder.Entity<Set>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Set>().HasMany(x => x.Sushi).WithMany(x => x.Sets);
        }
    }
}
