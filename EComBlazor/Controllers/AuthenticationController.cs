using EComBlazor.Base;
using EComBlazor.lib.DTOs.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EComBlazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(IAuthenticationService service) : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> CreateUser(CreateUser user)
        {
            var result = await service.CreateUser(user);
            return result.success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogInUser(LogInUser user)
        {
            var result = await service.LogInUser(user);
            return result.success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("refreshToken/{refreshToken}")]
        public async Task<IActionResult> RefreshToken(string refreshToken)
        {
            var result = await service.RetriveToken(refreshToken);
            return result.success ? Ok(result) : BadRequest(result);
        }
    }
}
