using AuthApi.Users;

namespace AuthApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User Get(string userName, string password)
        {
            var users = new List<User>
            {
                new User{Id=1, UserName="Pedro", Password="123", Role="Manager"},
                new User{Id=2, UserName="Gilberto", Password="123456", Role="Employee"}
            };

            return users.FirstOrDefault(u => Equals(u.UserName, userName)
                                && Equals(u.Password, password));
        }
    }
}
