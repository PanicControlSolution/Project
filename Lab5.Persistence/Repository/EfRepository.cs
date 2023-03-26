using Lab5.Domain.Abstractions;
using Lab5.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lab5.Persistence.Repository
{
    internal class EfRepository<T> : IRepository<T> where T : Entity
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _entities;

        public EfRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _entities = dbContext.Set<T>();
        }
        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _entities.AddAsync(entity, cancellationToken);
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
            }

            _dbContext.Set<T>().Remove(entity);
        }

        public async Task<T> FirstOrDefaultAsync(System.Linq.Expressions.Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(filter, cancellationToken);
        }

        public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default, params System.Linq.Expressions.Expression<Func<T, object>>[]? includesProperties)
        {
            var query = _dbContext.Set<T>().AsQueryable();

            if (includesProperties != null)
            {
                query = includesProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            }

            return await query.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<T>> ListAsync(System.Linq.Expressions.Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default, params System.Linq.Expressions.Expression<Func<T, object>>[]? includesProperties)
        {
            var query = _dbContext.Set<T>().Where(filter);

            if (includesProperties != null)
            {
                query = includesProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            }

            return await query.ToListAsync(cancellationToken);

            /////////Example from technical  task is below:

            /*IQueryable<T>? query = _entities.AsQueryable();
            if (includesProperties.Any())
            {
                foreach (Expression<Func<T, object>>? included in
                includesProperties)
                {
                    query = query.Include(included);
                }
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();*/
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
