using CoffeeNomad.DataBase.Entities;
using System.Runtime.CompilerServices;

namespace CoffeeNomad.DataBase.Repositories.Interfaces
{
    public interface ICartRepository
    {
        Task Create(Guid userId, Guid productId, int qty);
        Task<List<Cart>> GetByUserId(Guid id);
        Task<Cart> GetById(Guid id);
        Task UpdateAsync(Guid cartItemId, int newQty);
        Task DeleteAsync(Guid id);
    }
}
