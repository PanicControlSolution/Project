using Lab5.Domain.Entities;

namespace Lab5.Application.Abstractions
{
    public interface ISetService : IBaseService<Set>
    {
        public Task<IEnumerable<Sushi>> GetAllBySetIdAsync(int setId);
    }
}
