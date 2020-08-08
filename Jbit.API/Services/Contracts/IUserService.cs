using Jbit.Common.Models;
using System;
using System.Threading.Tasks;

namespace Jbit.API.Services.Contracts
{
    public interface IUserService
    {
        Task<User> GetUserAsync(Guid id);
    }
}
