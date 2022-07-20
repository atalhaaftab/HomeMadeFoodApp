using HomeMadeFoodApp.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeMadeFoodApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;
        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<ActionResult> GetAllUserAsync()
        {
            var result = await this._userManager.GetAllUserAsync();
            return Ok(result);
        }
    }
}
