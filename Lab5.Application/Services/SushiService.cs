using Lab5.Application.Abstractions;
using Lab5.Domain.Abstractions;
using Lab5.Domain.Entities;

namespace Lab5.Application.Services
{
    public class SushiService : ISushiService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SushiService(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }
        public async Task AddAsync(Sushi item)
        {
            await _unitOfWork._sushiRepository.AddAsync(item);
            await _unitOfWork.SaveAllAsync();
        }

        public async void DeleteAsync(Sushi item)
        {
            _unitOfWork._sushiRepository.DeleteAsync(item);
            await _unitOfWork.SaveAllAsync();
        }

        public Task<IReadOnlyList<Sushi>> GetAllAsync()
        {
            return _unitOfWork._sushiRepository.ListAllAsync();
        }

        public Task<Sushi> GetByIdAsync(int id)
        {
            return _unitOfWork._sushiRepository.GetByIdAsync(id);
        }

        public Task UpdateAsync(Sushi item)
        {
            return _unitOfWork._sushiRepository.UpdateAsync(item);
        }
    }
}
