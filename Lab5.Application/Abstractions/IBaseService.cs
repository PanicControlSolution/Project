using Lab5.Domain.Entities;

namespace Lab5.Application.Abstractions
{
    public interface IBaseService<T> where T : Entity
    {
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task AddAsync(T item);

        Task UpdateAsync(T item);

        void DeleteAsync(T item);
    }
}
