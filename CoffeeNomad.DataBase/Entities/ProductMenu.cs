using CoffeeNomad.DataBase.Entities.Types;
using System.Drawing;

namespace CoffeeNomad.DataBase.Entities
{
    public class ProductMenu
    {
        public Guid Id { get; set; }

        public string Picture { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public Sizes Size { get; set; }

        public ProductMenu CreateProduct(ProductMenu product) 
        {
            return new ProductMenu
            {
                Id = Guid.NewGuid(),
                Picture = product.Picture,
                Name = product.Name,
                Price = product.Price,
                Size = product.Size,
            };
        }
    }
}
