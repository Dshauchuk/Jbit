using Jbit.API.Models.ViewModels;
using Jbit.API.Services.Contracts;
using Jbit.Common.Auth.Interfaces;
using Jbit.Common.Data;
using Jbit.Common.Exceptions;
using Jbit.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jbit.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Person> _personRepository;
        private readonly IRepository<Identity> _identityRepository;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthService(IJwtTokenGenerator jwtTokenGenerator,
            IRepository<User> userRepository,
            IRepository<Person> personRepository,
            IRepository<Identity> identityRepository,
            IPasswordHasher<User> passwordHasher)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
            _personRepository = personRepository;
            _identityRepository = identityRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<JwtResponse> AuthAsync(LoginViewModel loginModel)
        {
            if (loginModel is null)
                throw new ArgumentNullException(nameof(loginModel));

            var vResult = loginModel.Validate();
            if (!vResult.Success)
            {
                throw new ArgumentException(string.Join(";", vResult.Errors.Select(e => e.ErrorMessage)));
            }

            var user = await _userRepository.FirstOrDefaultAsync(u => u.Email.Equals(loginModel.Email), q => q.Include(u => u.UserLogins));

            if (user is null)
                throw new JbitException($"User with email '{loginModel.Email}' doesn't exist", "user_not_found");

            if (_passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginModel.Password) != PasswordVerificationResult.Success)
                throw new JbitException($"Wrong password", "auth_failed");

            var jwt = _jwtTokenGenerator.Generate(user, new List<string> { nameof(Role.Types.User) });
            var refreshToken = Guid.NewGuid().ToString();

            await SaveIdentityAsync(user, loginModel.DeviceId, loginModel.Device, jwt.AccessToken, refreshToken);

            return new JwtResponse(user.Id, jwt.AccessToken, refreshToken, jwt.Expires.TotalSeconds);
        }

        private async Task SaveIdentityAsync(User user, string deviceId, string device,
            string accessToken, string refreshToken)
        {
            var uIdentity = user.UserLogins.FirstOrDefault(i => i.DeviceId.Equals(deviceId));

            // update
            if(uIdentity != null)
            {
                uIdentity.DeviceId = deviceId;
                uIdentity.Device = device;
                uIdentity.AccessToken = accessToken;
                uIdentity.RefreshToken = refreshToken;
                uIdentity.UpdateTimestamp = DateTime.UtcNow;

                await _identityRepository.UpdateAsync(uIdentity);
            }
            // create
            else
            {
                uIdentity = new Identity(Guid.NewGuid(), deviceId, device, user, accessToken, refreshToken)
                {
                    UpdateTimestamp = DateTime.UtcNow
                };
                await _identityRepository.AddAsync(uIdentity);
            }

            await _identityRepository.SaveChangesAsync();
        }

        public async Task<UserViewModel> RegisterAsync(RegistrationViewModel registrationModel)
        {
            if (registrationModel is null)
                throw new ArgumentNullException(nameof(registrationModel));

            var vResult = registrationModel.Validate();
            if (!vResult.Success)
            {
                throw new ArgumentException(string.Join(";", vResult.Errors.Select(e => e.ErrorMessage)));
            }

            if (!(await VeryfyEmailUniquenessAsync(registrationModel.Email)).IsEmailUnique)
                throw new JbitException("User with such email already exists", "email_is_busy");

            // try to find a person with such email
            // TODO: think about it
            //var person = _personRepository.FirstOrDefaultAsync(p => p.Email.Equals(registrationModel.Email));

            var user = new User(Guid.NewGuid(), registrationModel.Email, registrationModel.FirstName, registrationModel.LastName)
            {
                RegistrationTimestamp = DateTime.UtcNow
            };
            user.PasswordHash = _passwordHasher.HashPassword(user, registrationModel.Password);

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            return new UserViewModel(user.Id, user.FirstName, user.LastName, user.Email, user.RegistrationTimestamp, null);
        }

        public async Task<EmailValidationResponse> VeryfyEmailUniquenessAsync(string email)
        {
            var user = await _userRepository.FirstOrDefaultAsync(u => u.Email.Equals(email));

            return new EmailValidationResponse(user is null);
        }
    }
}
