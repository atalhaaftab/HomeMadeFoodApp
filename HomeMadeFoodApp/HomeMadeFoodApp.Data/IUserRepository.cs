using HomeMadeFoodApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeMadeFoodApp.Data
{
    public interface IUserRepository
    {
        Task<ApiResponse<User?>> RegisterUserAsync(User user);
        Task<User?> CheckUserExistAsync(string emailAddress);
        Task<List<User?>> GetAllUserAsync();
    }
}
