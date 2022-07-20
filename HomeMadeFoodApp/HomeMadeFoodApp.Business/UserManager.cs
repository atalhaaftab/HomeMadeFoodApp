using HomeMadeFoodApp.Data;
using HomeMadeFoodApp.Model;
using HomeMadeFoodApp.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeMadeFoodApp.Business
{
    public class UserManager : IUserManager
    {
        private readonly IAuthManager _authManager;
        private readonly IUserRepository _userRepository;
        public UserManager(IAuthManager authManager, IUserRepository userRepository)
        {
            _authManager = authManager;
            _userRepository = userRepository;
        }

        public async Task<User> CheckUserAsync(string emailAddress)
        {
            var result = await this._userRepository.CheckUserExistAsync(emailAddress);
            return result;
        }

        public async Task<List<User?>> GetAllUserAsync()
        {
            return await this._userRepository.GetAllUserAsync();
        }

        public async Task<ApiResponse<User?>> RegisterUserAsync(AuthRequest request)
        {
            var userHash = await _authManager.CreatePasswordHashAsync(request.Password);
            var user = new User()
            {
                EmailAddress = request.EmailAddress,
                PasswordHash = userHash?.PasswordHash,
                PasswordSalt = userHash?.PasswordSalt,
            };
            var result = await this._userRepository.RegisterUserAsync(user);
            return result;
        }
    }
}
