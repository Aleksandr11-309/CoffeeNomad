using CoffeeNomad.DataBase.Entities;
using CoffeeNomad.DataBase.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoffeeNomad.DataBase.Repositories
{
    public class ProductMenuRepository : IGenericRepository<ProductMenu>
    {
        private readonly ApplicationDBContext _context;

        public ProductMenuRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ProductMenu entity)
        {
            var result = entity.CreateProduct(entity);

            await _context.AddAsync(result);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _context.products
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<List<ProductMenu>> GetAll()
        {
            var result = await _context.products
                .AsNoTracking()
                .ToListAsync();

            return result;
        }

        public async Task<ProductMenu> GetById(Guid id)
        {
            var result = await _context.products
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task UpdateAsync(ProductMenu entity)
        {
            _context.products.Update(entity);   
            await _context.SaveChangesAsync();
        }
    }
}
