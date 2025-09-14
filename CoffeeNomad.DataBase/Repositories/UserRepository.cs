using CoffeeNomad.DataBase.Entities;
using CoffeeNomad.DataBase.Entities.Types;
using CoffeeNomad.DataBase.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoffeeNomad.DataBase.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;

        public UserRepository(ApplicationDBContext context) 
        {
            _context = context;
        }

        public async Task AddAsync(User entity)
        {
            if (entity == null) 
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _context.users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task CreateAccount(User user, string hashedPassword)
        {
            //var result = User.CreateUser(user, password);

            user.Password = hashedPassword; // Просто обновляем пароль
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _context.users
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<List<User>> GetAll()
        {
            var result = await _context.users
                .AsNoTracking()
                .Where(x => x.Role == Roles.Costumer)
                .ToListAsync();

            return result;
        }

        public async Task<User> GetByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return null;
            }

            var result = await _context.users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == email);

            return result;
        }

        public async Task<User> GetById(Guid id)
        {
            var result = await _context.users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task UpdateAsync(User entity)
        {
            _context.users.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
