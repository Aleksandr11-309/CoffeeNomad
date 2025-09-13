using CoffeeNomad.DataBase.Entities;
using CoffeeNomad.DataBase.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoffeeNomad.DataBase.Repositories
{
    public class CartRepository : ICartRepository
    {
        public readonly ApplicationDBContext _context;

        public CartRepository(ApplicationDBContext context) 
        {
            _context = context;
        }
        public async Task Create(Guid userId, Guid productId, int qty)
        {
            // Проверяем наличие товара
            var item = await _context.products.FindAsync(productId);

            // Ищем существующую запись в корзине
            var existingCartItem = await _context.carts
                .FirstOrDefaultAsync(c => c.UserId == userId && c.ProductId == productId);

            if (existingCartItem != null)
            {
                existingCartItem.Qty += qty;
                _context.carts.Update(existingCartItem);
            }
            else
            {
                var newCartItem = new Cart
                {
                    UserId = userId,
                    ProductId = productId,
                    Qty = qty
                };
                await _context.carts.AddAsync(newCartItem);
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var cartItems = await _context.carts
            .Where(c => c.UserId == id)
            .ToListAsync();

            _context.carts.RemoveRange(cartItems);
            await _context.SaveChangesAsync();
        }

        public async Task<Cart> GetById(Guid id)
        {
            return await _context.carts
                .Include(c => c.Product)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Cart>> GetByUserId(Guid id)
        {
            return await _context.carts
                .Include(c => c.Product)
                .Where(c => c.UserId == id)
                .ToListAsync();
        }

        public async  Task UpdateAsync(Guid cartItemId, int newQty)
        {
            var cartItem = await _context.carts
           .Include(c => c.Product)
           .FirstOrDefaultAsync(c => c.Id == cartItemId);

            if (cartItem == null) return;

            cartItem.Qty = newQty;
            _context.carts.Update(cartItem);
            await _context.SaveChangesAsync();
        }
    }
}
