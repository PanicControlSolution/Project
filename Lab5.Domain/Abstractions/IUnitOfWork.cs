using Lab5.Domain.Entities;

namespace Lab5.Domain.Abstractions {
    public interface IUnitOfWork {

        IRepository<Set> SetRepository { get; }

        IRepository<Sushi> SushiRepository { get; }

        public Task RemoveDatbaseAsync();

        public Task CreateDatabaseAsync();

        public Task SaveAllAsync();

    }
}
