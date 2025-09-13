using CoffeeNomad.DataBase.Entities;

namespace CoffeeNomad.DataBase.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<User> GetByEmail(string email);

        public Task CreateAccount(User user, string password);
    }
}
