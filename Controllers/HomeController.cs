using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers
{
    [ApiController]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() 
            => $"Autenticado - {User.Identity.Name} ";

        [HttpGet]
        [Route("manager")]
        [Authorize(Roles ="Manager")]
        public string Manager()
            => $"Gerente Autenticado - {User.Identity.Name} ";
    }
}
