using Jbit.API.Models.ViewModels;
using Jbit.API.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Jbit.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("new")]
        public Task<UserViewModel> RegisterUserAsync([FromBody]RegistrationViewModel model)
            => _authService.RegisterAsync(model);

        [HttpPost]
        public Task<JwtResponse> LoginAsync([FromBody] LoginViewModel model)
            => _authService.AuthAsync(model);

    }
}
