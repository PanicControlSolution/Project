using Lab5.Domain.Abstractions;
using Lab5.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Lab5.Persistence.Repository
{
    public class FakeSetRepository : IRepository<Set>
    {
        List<Set> _sets;
        private readonly DbContext _dbContext;

        public FakeSetRepository(DbContext dbContext)
        {
            _sets = new List<Set>()
            {
                new Set(1, 45.99, "Сяке сет", "Много огурцов", 450),
                new Set(2, 36.99, "Кунсей сет", "Нету огурцов", 300)
            };
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<Set>> ListAllAsync(CancellationToken
            cancellationToken = default)
        {
            return await Task.Run(() => _sets);
        }

        Task IRepository<Set>.AddAsync(Set entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task IRepository<Set>.DeleteAsync(Set entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Set> IRepository<Set>.FirstOrDefaultAsync(Expression<Func<Set, bool>> filter, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Set> IRepository<Set>.GetByIdAsync(int id, CancellationToken cancellationToken, params Expression<Func<Set, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        Task<IReadOnlyList<Set>> IRepository<Set>.ListAsync(Expression<Func<Set, bool>> filter, CancellationToken cancellationToken, params Expression<Func<Set, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        Task IRepository<Set>.UpdateAsync(Set entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class FakeSushiRepository : IRepository<Sushi>
    {
        List<Sushi> _list = new List<Sushi>();
        private readonly DbContext _dbContext;

        public FakeSushiRepository(DbContext dbContext)
        {
            _dbContext = dbContext;

            _list.Add(new Sushi(1, "Ролл с лососем", 8, 1));
            _list.Add(new Sushi(2, "Ролл с лососем и сливочным сыром", 8, 1));

            _list.Add(new Sushi(1, "Ролл морских водорослях со сливочным сыром, краб миксом, такуаном, соусом Ореховым и кунжутом", 8, 2));
            _list.Add(new Sushi(2, "Ролл в миксе копченого лосося и морского окуня со сливочным сыром и тобико с сливочным сыром, салатом айсберг, картофелем пай", 8, 2));
        }

        public async Task<IReadOnlyList<Sushi>> ListAsync(Expression<Func<Sushi, bool>> filter, CancellationToken
        cancellationToken = default, params Expression<Func<Sushi, object>>[]?
        includesProperties)
        {
            var data = _list.AsQueryable();
            return data.Where(filter).ToList();
        }

        Task IRepository<Sushi>.AddAsync(Sushi entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task IRepository<Sushi>.DeleteAsync(Sushi entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Sushi> IRepository<Sushi>.FirstOrDefaultAsync(Expression<Func<Sushi, bool>> filter, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Sushi> IRepository<Sushi>.GetByIdAsync(int id, CancellationToken cancellationToken, params Expression<Func<Sushi, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        Task<IReadOnlyList<Sushi>> IRepository<Sushi>.ListAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task IRepository<Sushi>.UpdateAsync(Sushi entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
