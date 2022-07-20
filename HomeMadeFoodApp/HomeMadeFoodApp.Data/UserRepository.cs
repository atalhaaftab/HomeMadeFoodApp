using HomeMadeFoodApp.Data.Context;
using HomeMadeFoodApp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeMadeFoodApp.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _context;
        public UserRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<User?> CheckUserExistAsync(string emailAddress)
        {
            var query = (from x in this._context.Users
                         where x.EmailAddress.Equals(emailAddress)
                         select x);
            var result = await query.FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<User?>> GetAllUserAsync()

        {
            var query = (from x in this._context.Users
                         select x);
            var result = await query.ToListAsync();
            return result;
        }
        public async Task<ApiResponse<User?>> RegisterUserAsync(User user)
        {
            var apiResponse = new ApiResponse<User?>();
            try
            {
                _ = await _context.AddAsync(user);
                var result = await this._context.SaveChangesAsync();
                if (result > 0)
                {
                    apiResponse.Content = user;
                    apiResponse.Message = "New user has been registerd.";
                    apiResponse.Status = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    apiResponse.Content = null;
                    apiResponse.Message = "Not registerd.";
                    apiResponse.Status = System.Net.HttpStatusCode.ExpectationFailed;
                }
            }
            catch (Exception ex)
            {
                apiResponse.Content = null;
                apiResponse.Message = ex.Message;
                apiResponse.Status = System.Net.HttpStatusCode.BadRequest;
            }
            return apiResponse;
        }
    }
}
