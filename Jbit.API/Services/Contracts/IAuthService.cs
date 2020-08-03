using Jbit.API.Models.ViewModels;
using System.Threading.Tasks;

namespace Jbit.API.Services.Contracts
{
    public interface IAuthService
    {
        Task<UserViewModel> RegisterAsync(RegistrationViewModel registrationModel);
        Task<JwtResponse> AuthAsync(LoginViewModel loginModel);
        Task<EmailValidationResponse> VeryfyEmailUniquenessAsync(string email);
    }
}
