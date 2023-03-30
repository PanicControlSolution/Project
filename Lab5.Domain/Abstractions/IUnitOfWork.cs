using Lab5.Domain.Entities;

namespace Lab5.Domain.Abstractions
{
    public interface IUnitOfWork
    {

        IRepository<Set> _setRepository { get; }

        IRepository<Sushi> _sushiRepository { get; }

        public Task RemoveDatbaseAsync();

        public Task CreateDatabaseAsync();

        public Task SaveAllAsync();

    }
}
