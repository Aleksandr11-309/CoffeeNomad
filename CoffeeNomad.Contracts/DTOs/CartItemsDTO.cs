using CoffeeNomad.DataBase.Entities.Types;

namespace CoffeeNomad.Contracts.DTOs
{
    public class CartItemsDTO
    { 
        public string Name { get; set; }

        public Sizes Size { get; set; }

        public int Price { get; set; }

        public string Qty {  get; set; }
    }
}
