using Lab5.Application.Abstractions;
using Lab5.Domain.Abstractions;
using Lab5.Domain.Entities;

namespace Lab5.Application.Services
{
    public class SetService : ISetService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SetService(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }

        public Task AddAsync(Set item)
        {
            return _unitOfWork._setRepository.AddAsync(item);
        }

        public void DeleteAsync(Set item)
        {
            _unitOfWork._setRepository.DeleteAsync(item);
        }

        public Task<IReadOnlyList<Set>> GetAllAsync()
        {
            return _unitOfWork._setRepository.ListAllAsync();
        }

        public async Task<IReadOnlyList<Sushi>> GetAllBySetIdAsync(int setId)
        {
            var set = await _unitOfWork._setRepository.GetByIdAsync(setId, default, s => s.Sushi);

            return (IReadOnlyList<Sushi>)set.Sushi;
        }

        public Task<Set> GetByIdAsync(int id)
        {
            return _unitOfWork._setRepository.GetByIdAsync(id);
        }

        public Task UpdateAsync(Set item)
        {
            return _unitOfWork._setRepository.UpdateAsync(item);
        }
    }
}
