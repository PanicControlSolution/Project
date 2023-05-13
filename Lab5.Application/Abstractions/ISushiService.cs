using Lab5.Domain.Entities;

namespace Lab5.Application.Abstractions
{
    public interface ISushiService : IBaseService<Sushi>
    {
        public Task AddSetAsync(Sushi sushi, Set set);
    }
}
