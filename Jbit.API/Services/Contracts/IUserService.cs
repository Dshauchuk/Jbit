using Jbit.API.Models.ViewModels;
using System;
using System.Threading.Tasks;

namespace Jbit.API.Services.Contracts
{
    public interface IUserService
    {
        Task<UserViewModel> GetUserAsync(Guid id);
    }
}
