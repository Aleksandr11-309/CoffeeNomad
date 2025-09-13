using CoffeeNomad.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeNomad.DataBase.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductMenu>
    {
        public void Configure(EntityTypeBuilder<ProductMenu> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
