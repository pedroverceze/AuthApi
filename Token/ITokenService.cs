using AuthApi.Users;

namespace AuthApi.Token
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}