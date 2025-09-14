using CoffeeNomad.DataBase.Entities.Types;

namespace CoffeeNomad.DataBase.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int MobileNumber { get; set; }

        //public string Location { get; set; }

        public Roles Role { get; set; } = Roles.Costumer;

        public static User CreateUser(User user, string password) 
        {
            return new User
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = password,
                MobileNumber = user.MobileNumber,
                //Location = user.Location,
                Role = user.Role,
            };
        }
    }
}
