using HomeMadeFoodApp.Model;
using HomeMadeFoodApp.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeMadeFoodApp.Business
{
    public interface IUserManager
    {
        Task<ApiResponse<User?>> RegisterUserAsync(AuthRequest request);
        Task<User> CheckUserAsync(string emailAddress);
        Task<List<User>> GetAllUserAsync();
    }
}
