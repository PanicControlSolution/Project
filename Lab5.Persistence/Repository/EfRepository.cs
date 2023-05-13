using Lab5.Domain.Abstractions;
using Lab5.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Lab5.Persistence.Repository
{
    public class EfSushiRepository : IRepository<Sushi>
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<Sushi> _entities;

        public EfSushiRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _entities = dbContext.Set<Sushi>();
        }

        public async Task AddAsync(Sushi entity, CancellationToken cancellationToken = default)
        {
            await _entities.AddAsync(entity, cancellationToken);
        }

        public void AddSet(Sushi sushi, Set set)
        {
            sushi.Sets.Add(set);
            _entities.Update(sushi);
        }

        public void DeleteAsync(Sushi entity, CancellationToken cancellationToken = default)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
            }
            _entities.Remove(entity);
        }

        public async Task<Sushi> FirstAsync(Expression<Func<Sushi, bool>> filter, CancellationToken cancellationToken = default)
        {
            return await _entities.FirstAsync(filter, cancellationToken);
        }

        public async Task<Sushi> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Sushi, object>>[]? includesProperties)
        {
            var query = _entities.AsQueryable();
            if (includesProperties != null)
            {
                query = includesProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            }
            return await query.FirstAsync(e => e.Id == id, cancellationToken);
        }

        public async Task<IReadOnlyList<Sushi>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await _entities.ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<Sushi>> ListAsync(Expression<Func<Sushi, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Sushi, object>>[]? includesProperties)
        {
            var query = _entities.Where(filter);
            if (includesProperties != null)
            {
                query = includesProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            }
            return await query.ToListAsync(cancellationToken);
        }

        public async Task UpdateAsync(Sushi entity, CancellationToken cancellationToken = default)
        {
            var old = await GetByIdAsync(entity.Id, cancellationToken);
            _dbContext.Entry(old).CurrentValues.SetValues(entity);
        }
    }

    public class EfSetRepository : IRepository<Set>
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<Set> _entities;

        public EfSetRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _entities = dbContext.Set<Set>();
        }

        public async Task AddAsync(Set entity, CancellationToken cancellationToken = default)
        {
            await _entities.AddAsync(entity, cancellationToken);
        }

        public void AddSushi(Set entity, Sushi sushi)
        {
            entity.Sushi.Add(sushi);
            _entities.Update(entity);
        }

        public void DeleteAsync(Set entity, CancellationToken cancellationToken = default)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
            }
            _entities.Remove(entity);
        }

        public async Task<Set> FirstAsync(Expression<Func<Set, bool>> filter, CancellationToken cancellationToken = default)
        {
            return await _entities.FirstAsync(filter, cancellationToken);
        }

        public async Task<Set> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Set, object>>[]? includesProperties)
        {
            var query = _entities.AsQueryable();
            if (includesProperties != null)
            {
                query = includesProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            }
            return await query.FirstAsync(e => e.Id == id, cancellationToken);
        }

        public async Task<IReadOnlyList<Set>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await _entities.ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<Set>> ListAsync(Expression<Func<Set, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Set, object>>[]? includesProperties)
        {
            var query = _entities.Where(filter);
            if (includesProperties != null)
            {
                query = includesProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            }
            return await query.ToListAsync(cancellationToken);
        }

        public async Task UpdateAsync(Set entity, CancellationToken cancellationToken = default)
        {
            var old = await GetByIdAsync(entity.Id, cancellationToken);
            _dbContext.Entry(old).CurrentValues.SetValues(entity);
        }
    }
}
