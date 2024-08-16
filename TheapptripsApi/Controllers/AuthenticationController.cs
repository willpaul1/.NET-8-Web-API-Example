using BaseLibrary.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Repositories.Contracts;

namespace ServerTest.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    [AllowAnonymous]
    [EnableCors("Optional")]
    public class AuthenticationController(IUserAccount accountInterface) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> CreateAsync(RegisterDto user)
        {
            if (user == null) return BadRequest("Model is Empty");
            var result = await accountInterface.CreateAsync(user);
            return Ok(result);
        }


        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginDto user)
        {
            if (user == null) return BadRequest("Model is Empty");
            var result = await accountInterface.LoginAsync(user);
            return Ok(result);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshTokenAsync(RefreshTokenDto token)
        {
            if (token == null) return BadRequest("Model is Empty");
            var result = await accountInterface.RefreshTokenAsync(token);
            return Ok(result);
        }
    }
}