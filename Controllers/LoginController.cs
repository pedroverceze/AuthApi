using AuthApi.Repositories;
using AuthApi.Token;
using AuthApi.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace AuthApi.Controllers
{
    [ApiController]
    [Route("v1")]
    public class LoginController : Controller
    {
        private IUserRepository _userRepository;
        private ITokenService _tokenService;

        public LoginController(IUserRepository userRepository,
                                ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User user)
        {
            var userFound = _userRepository.Get(user.UserName, user.Password);

            if (userFound == null)
            {
                return NotFound(new { Message = "Usuario não encontrado" });
            }

            var token = _tokenService.GenerateToken(userFound);

            user.Password = string.Empty;

            return new
            {
                User = user,
                Token = token
            };
        }
    }
}
