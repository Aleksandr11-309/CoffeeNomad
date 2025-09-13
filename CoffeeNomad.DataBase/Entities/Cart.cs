namespace CoffeeNomad.DataBase.Entities
{
    public class Cart
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }

        // Навигационные свойства
        public User User { get; set; }
        public ProductMenu Product { get; set; }

        public int Qty { get; set; } = 1;
        public DateTime AddedDate { get; set; } = DateTime.UtcNow;

        // Добавляем свойства для отображения
        public string ItemName => Product?.Name;
        public decimal ItemPrice => Product?.Price ?? 0;
        public string ItemImage => Product?.Picture;
    }
}
