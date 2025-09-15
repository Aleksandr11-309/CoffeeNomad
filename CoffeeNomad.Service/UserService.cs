using AutoMapper;
using CoffeeNomad.Contracts.Contracts;
using CoffeeNomad.DataBase.Entities;
using CoffeeNomad.DataBase.Repositories.Interfaces;
using CoffeeNomad.Infrastructure.Password;

namespace CoffeeNomad.Services
{
    public class UserService
    {
        private readonly IUserRepository _repository;
        private readonly JwtProvider _jwtProvider;
        private readonly PasswordHasher _passwordHasher;
        private readonly IMapper _mapper;

        public UserService(
            IUserRepository repository,
            JwtProvider jwtProvider,
            PasswordHasher passwordHasher,
            IMapper mapper)
        {
            _repository = repository;
            _jwtProvider = jwtProvider;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }

        public async Task CreateUserProfile(RegisterContract registerContract) 
        {
            var user = _mapper.Map<User>(registerContract);

            var password = _passwordHasher.GenerateTokenSHA(user.Password);

            await _repository.CreateAccount(user, password);
        }

        public async Task<string> Login(LoginContract login)
        {
            var user = await _repository.GetByEmail(login.Email);

            if (user == null) throw new Exception("Такого пользователя с почтой не существует");

            var result = _passwordHasher.Verify(login.Password, user.Password);

            if (!result) throw new Exception("Неверный пароль");

            var token = _jwtProvider.GenerateToken(user);

            return token;
        }

        public async Task UpdateUserPofle(User user) 
        {
            await _repository.UpdateAsync(user);
        }

        public async Task DeleteUserProfile(Guid id) 
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<User> GetById(Guid id) 
        {
            return await _repository.GetById(id);
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _repository.GetByEmail(email);
        }

        public async Task<List<User>> GetAll() 
        {
            return await _repository.GetAll();
        }
    }
}
