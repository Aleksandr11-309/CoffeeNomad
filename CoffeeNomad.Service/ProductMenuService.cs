using CoffeeNomad.DataBase.Entities;
using CoffeeNomad.DataBase.Repositories;
using CoffeeNomad.DataBase.Repositories.Interfaces;

namespace CoffeeNomad.Services
{
    public class ProductMenuService
    {
        private readonly IGenericRepository<ProductMenu> _repository;
        public ProductMenuService(
            IGenericRepository<ProductMenu> repository
            ) 
        {
            _repository = repository;
        }

        public async Task CreateProduct(ProductMenu product) 
        {
            await _repository.AddAsync(product);
        }

        public async Task UpdateProduct(ProductMenu product) 
        {
            await _repository.UpdateAsync(product);
        }

        public async Task DeleteProduct(Guid id) 
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<ProductMenu>> GetAll() 
        {
            return await _repository.GetAll();
        }

        public async Task<ProductMenu> GetById(Guid id) 
        {
            return await _repository.GetById(id);
        }
    }
}
