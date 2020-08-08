using AutoMapper;
using Jbit.API.Models;
using Jbit.API.Models.ViewModels;
using Jbit.API.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Jbit.API.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService, 
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
            : base(mapper, httpContextAccessor)
        {
            _authService = authService;
        }

        [HttpPost("api/sign-up")]
        public async Task<UserViewModel> RegisterUserAsync([FromBody] RegistrationModel model)
            => mapper.Map<UserViewModel>(await _authService.RegisterAsync(model));

        [HttpPost("api/sign-in")]
        public Task<JwtResponse> LoginAsync([FromBody] LoginModel model)
            => _authService.AuthAsync(model);

    }
}
