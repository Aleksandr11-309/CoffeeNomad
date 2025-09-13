using CoffeeNomad.DataBase.Entities;
using CoffeeNomad.DataBase.Entities.Types;

namespace CoffeeNomad.DataBase.Repositories.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        public Task<List<Order>> GetByUserID(Guid userID);
        public Task UpdateAsync(Guid orderId, PaymentStatus newStatus);
    }
}
