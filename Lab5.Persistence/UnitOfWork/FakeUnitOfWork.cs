using Lab5.Domain.Abstractions;
using Lab5.Domain.Entities;
using Lab5.Persistence.Data;
using Lab5.Persistence.Repository;

namespace Lab5.Persistence.UnitOfWork
{
    internal class FakeUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Lazy<IRepository<Set>> _setRepository;
        private readonly Lazy<IRepository<Sushi>> _sushiRepository;


        //implementation of interface
        IRepository<Set> IUnitOfWork._setRepository => _setRepository.Value;
        IRepository<Sushi> IUnitOfWork._sushiRepository => _sushiRepository.Value;



        public FakeUnitOfWork(AppDbContext context)
        {
            _context = context;
            _setRepository = new Lazy<IRepository<Set>>(() => new FakeSetRepository(context));
            _sushiRepository = new Lazy<IRepository<Sushi>>(() => new FakeSushiRepository(context));
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
