using Lab5.Application.Abstractions;
using Lab5.Domain.Abstractions;
using Lab5.Domain.Entities;
using Lab5.Persistence.Repository;

namespace Lab5.Application.Services
{
    public class SetService : ISetService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SetService(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }

        public async Task AddAsync(Set item)
        {
            await _unitOfWork._setRepository.AddAsync(item);
            await _unitOfWork.SaveAllAsync();
        }

        public void AddSushi(Set set, Sushi item)
        {
            var repo = _unitOfWork._setRepository as EfSetRepository;
            repo.AddSushi(set, item);
            _unitOfWork.SaveAllAsync();
        }

        public void DeleteAsync(Set item)
        {
            _unitOfWork._setRepository.DeleteAsync(item);
            _unitOfWork.SaveAllAsync();
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
