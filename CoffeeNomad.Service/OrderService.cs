using CoffeeNomad.DataBase.Entities;
using CoffeeNomad.DataBase.Repositories.Interfaces;

namespace CoffeeNomad.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateOrder(Order order) 
        {
            await _repository.AddAsync(order);
        }

        public async Task UpdateOrder(Order order) 
        {
            await _repository.UpdateAsync(order);
        }

        public async Task DeleteOrder(Guid id) 
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<Order> GetOrderById(Guid id) 
        {
            return await _repository.GetById(id);
        }

        public async Task<List<Order>> GetOrders() 
        {
            return await _repository.GetAll();
        }
    }
}
