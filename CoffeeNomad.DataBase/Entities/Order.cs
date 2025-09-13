using CoffeeNomad.DataBase.Entities.Types;

namespace CoffeeNomad.DataBase.Entities
{
    public class Order
    {
        public Guid Id { get; set; }

        public string OrderId { get; set; } = GenerateOrderId();

        public Guid UserId { get; set; }

        public User User { get; set; }

        public DateOnly Date { get; set; }

        public int Amount { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public PaymentStatus Status { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public static Order CreateOrder(Order order) 
        {
            return new Order
            {
                Id = Guid.NewGuid(),
                OrderId = order.OrderId,
                User = order.User,
                Date = order.Date,
                Amount = order.Amount,
                PaymentMethod = order.PaymentMethod,
                Status = order.Status,
                OrderStatus = order.OrderStatus,
            };
        }

        private static string GenerateOrderId() 
        {
            var rand = new Random();
            return "#" + rand.Next(100_000, 999_999);
        }
    }
}
