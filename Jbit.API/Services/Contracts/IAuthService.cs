using Jbit.API.Models;
using Jbit.Common.Models;
using System.Threading.Tasks;

namespace Jbit.API.Services.Contracts
{
    public interface IAuthService
    {
        Task<User> RegisterAsync(RegistrationModel registrationModel);
        Task<JwtResponse> AuthAsync(LoginModel loginModel);
        Task<bool> VeryfyEmailUniquenessAsync(string email);
    }
}
