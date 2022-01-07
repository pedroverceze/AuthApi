using AuthApi.Users;

namespace AuthApi.Repositories
{
    public interface IUserRepository
    {
        User Get(string userName, string password);
    }
}