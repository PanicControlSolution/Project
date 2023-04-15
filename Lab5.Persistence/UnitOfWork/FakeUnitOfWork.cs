using Lab5.Domain.Abstractions;
using Lab5.Domain.Entities;
using Lab5.Persistence.Data;
using Lab5.Persistence.Repository;

namespace Lab5.Persistence.UnitOfWork
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IRepository<Set> _setRepository;
        private readonly IRepository<Sushi> _sushiRepository;

        //implementation of interface
        IRepository<Set> IUnitOfWork._setRepository => _setRepository;
        IRepository<Sushi> IUnitOfWork._sushiRepository => _sushiRepository;
        public FakeUnitOfWork(AppDbContext context)
        {
            _context = context;
            _sushiRepository = new FakeSushiRepository(context);
            _setRepository = new FakeSetRepository(context);
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
