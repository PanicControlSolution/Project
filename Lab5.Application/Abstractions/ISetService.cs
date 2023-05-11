using Lab5.Domain.Entities;

namespace Lab5.Application.Abstractions
{
    public interface ISetService : IBaseService<Set>
    {
        public Task<IReadOnlyList<Sushi>> GetAllBySetIdAsync(int setId);

        public void AddSushi(Set set, Sushi item);
    }
}
