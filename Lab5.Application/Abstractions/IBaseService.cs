using Lab5.Domain.Entities;

namespace Lab5.Application.Abstractions
{
    public interface IBaseService<T> where T : Entity
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task<T> AddAsync(T item);

        Task<T> UpdateAsync(T item);

        Task<T> DeleteAsync(int id);
    }
}
