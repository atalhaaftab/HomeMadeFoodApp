using HomeMadeFoodApp.Model;
using HomeMadeFoodApp.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeMadeFoodApp.Business
{
    public interface IAuthManager
    {
        Task<User?> CreatePasswordHashAsync(string password);
        Task<bool> VerifyPasswordAsync(User user, string password);
        Task<AuthResponse> GenerateTokenAsync(User user, string ipAddress);
        string GetClaimName();
    }
}
