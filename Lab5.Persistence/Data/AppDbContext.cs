using Microsoft.EntityFrameworkCore;

namespace Lab5.Persistence.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }
    }
}
