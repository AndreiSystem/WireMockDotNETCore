using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RegisterUsers.Core.Services.Interfaces;

namespace RegisterUsers.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet("{userName}")]
        public async Task<ActionResult> GetUsersFromGithub([FromRoute] string userName)
        {

            var user = await _userServices.GetUserGithub(userName);

            return Ok(user);
        }
    }
}