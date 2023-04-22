using Lab5.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lab5.Persistence.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Set> Sets { get; set; }
        public DbSet<Sushi> Sushi { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Set>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Set>().Property(x => x.Cost).IsRequired();
            modelBuilder.Entity<Set>().Property(x => x.Weight).IsRequired();
            modelBuilder.Entity<Set>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Set>().HasMany(x => x.Sushi).WithMany(x => x.Sets);

            modelBuilder.Entity<Sushi>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Sushi>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Sushi>().Property(x => x.Count).IsRequired();
            modelBuilder.Entity<Sushi>().HasMany(x => x.Sets).WithMany(x => x.Sushi);
        }
    }
}
