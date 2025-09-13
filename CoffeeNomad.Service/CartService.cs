using CoffeeNomad.DataBase.Entities;
using CoffeeNomad.DataBase.Repositories.Interfaces;

namespace CoffeeNomad.Services
{
    public class CartService
    {
        private readonly ICartRepository _cartRepository;
        public CartService(
            ICartRepository cartRepository
            )
        {
            _cartRepository = cartRepository;
        }

        public async Task AddToCart(Guid userId, Guid itemId, int quantity)
        {
            await _cartRepository.Create(userId, itemId, quantity);
        }

        public async Task UpdateCartItem(Guid cartItemId, int newQuantity)
        {
            await _cartRepository.UpdateAsync(cartItemId, newQuantity);
        }

        public async Task RemoveFromCart(Guid cartItemId)
        {
            await _cartRepository.DeleteAsync(cartItemId);
        }

        public async Task<List<Cart>> GetUserCart(Guid userId)
        {
            return await _cartRepository.GetByUserId(userId);
        }

        public async Task ProcessOrder(Guid userId)
        {
            var cartItems = await _cartRepository.GetByUserId(userId);

            // Очищаем корзину после оформления заказа
            await _cartRepository.DeleteAsync(userId);
        }
    }
}
