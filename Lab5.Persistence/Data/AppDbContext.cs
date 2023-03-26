using Microsoft.EntityFrameworkCore;

namespace Lab5.Persistence.Data
{
    internal class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
    }
}
