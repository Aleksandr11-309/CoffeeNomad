using CoffeeNomad.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeNomad.DataBase.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // Устанавливаем первичный ключ
            builder.HasKey(o => o.Id);

            // Связь с пользователем
            builder.HasOne(o => o.User)
                .WithMany() // У UserModel может быть много заказов
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Ограничение при удалении

            // Индекс для быстрого поиска по трек-номеру
            builder.HasIndex(o => o.OrderId)
                .IsUnique();
        }
    }
}
