using Jbit.API.Services.Contracts;
using Jbit.Common.Data;
using Jbit.Common.Models;
using System;
using System.Threading.Tasks;

namespace Jbit.API.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> GetUserAsync(Guid id)
            => _userRepository.FirstOrDefaultAsync(u => u.Id == id);
    }
}
