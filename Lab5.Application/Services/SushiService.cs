using Lab5.Application.Abstractions;
using Lab5.Domain.Abstractions;
using Lab5.Domain.Entities;

namespace Lab5.Application.Services
{
    public class SushiService : ISushiService
    {
        private IUnitOfWork _unitOfWork;
        public SushiService(IUnitOfWork unit) {
            _unitOfWork = unit;
        }
        public Task AddAsync(Sushi item)
        {
            return _unitOfWork._sushiRepository.AddAsync(item);
        }

        public Task DeleteAsync(Sushi item)
        {
            return _unitOfWork._sushiRepository.DeleteAsync(item);
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
