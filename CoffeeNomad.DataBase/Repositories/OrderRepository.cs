using CoffeeNomad.DataBase.Entities;
using CoffeeNomad.DataBase.Entities.Types;
using CoffeeNomad.DataBase.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoffeeNomad.DataBase.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDBContext _context;

        public OrderRepository(ApplicationDBContext context) 
        {
            _context = context;
        }
        public async Task AddAsync(Order entity)
        {
            await _context.orders.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _context.orders
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<List<Order>> GetAll()
        {
            return await _context.orders
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Order> GetById(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Invalid User ID");

            return _context.orders
                .FirstOrDefault(o => o.UserId == id);
        }

        public async Task<List<Order>> GetByUserID(Guid userID)
        {
            if (userID == Guid.Empty)
                throw new ArgumentException("Invalid User ID");

            return await _context.orders
                .AsNoTracking()
                .Where(o => o.UserId == userID)
                .ToListAsync();
        }

        public async Task UpdateAsync(Guid orderId, PaymentStatus newStatus)
        {
            var order = await _context.orders.FirstOrDefaultAsync(x => x.Id == orderId);
            order.Status = newStatus;
            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
