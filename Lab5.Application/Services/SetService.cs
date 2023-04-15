using Lab5.Application.Abstractions;
using Lab5.Domain.Abstractions;
using Lab5.Domain.Entities;

namespace Lab5.Application.Services
{
    public class SetService : ISetService
    {
        private IUnitOfWork _unitOfWork;

        public SetService(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }

        public Task AddAsync(Set item)
        {
            return _unitOfWork._setRepository.AddAsync(item);
        }

        public Task DeleteAsync(Set item)
        {
            return _unitOfWork._setRepository.DeleteAsync(item);
        }

        public Task<IReadOnlyList<Set>> GetAllAsync()
        {
            return _unitOfWork._setRepository.ListAllAsync();
        }

        public Task<IReadOnlyList<Sushi>> GetAllBySetIdAsync(int setId)
        {
            var set = _unitOfWork._setRepository.ListAsync((set) => set.Id == setId).Result;
            var result = set.Select(x => x.Sushi).First().ToList().AsReadOnly();
            return Task.FromResult((IReadOnlyList<Sushi>)result);
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
