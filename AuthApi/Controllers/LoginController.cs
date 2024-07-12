using AuthApi.Helpers;
using DataService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private TokenGeneration _tokenGeneration;
        public LoginController(TokenGeneration tokenGeneration)
        {
            _tokenGeneration = tokenGeneration;
        }
        [HttpPost]
        public async Task<IActionResult> Post(string username, string password)
        {
            //If login usrename and password are valid then proceed to generate token
            string token = await _tokenGeneration.Validate(username, password);
            if (!string.IsNullOrEmpty(token))
            {
                return Ok(token);
            }
            else
            {
                return NotFound("Invalid username or password.");
            }
        }
    }
}
