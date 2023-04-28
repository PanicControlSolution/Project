using Lab5.Domain.Abstractions;
using Lab5.Domain.Entities;
using Lab5.Persistence.Data;
using Lab5.Persistence.Repository;

namespace Lab5.Persistence.UnitOfWork
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private readonly IRepository<Set> _setRepository;

        private readonly IRepository<Sushi> _sushiRepository;

        IRepository<Set> IUnitOfWork._setRepository => _setRepository;

        IRepository<Sushi> IUnitOfWork._sushiRepository => _sushiRepository;

        public EfUnitOfWork(AppDbContext context)
        {
            _context = context;
            _setRepository = new EfRepository<Set>(context);
            _sushiRepository = new EfRepository<Sushi>(context);
        }

        public async Task CreateDatabaseAsync()
        {
            await _context.Database.EnsureCreatedAsync();
        }

        public async Task RemoveDatbaseAsync()
        {
            await _context.Database.EnsureDeletedAsync();
        }

        public async Task SaveAllAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
