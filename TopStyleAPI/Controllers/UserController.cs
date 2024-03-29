using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using TopStyleAPI.Core.Interfaces;
using TopStyleAPI.Domain.DTO;

namespace TopStyleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserDetails()
        {
            var result = await _userService.GetUserDetails();
            return Ok(result);
        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateUser(UserUpdateDTO updated)
        {
            await _userService.UpdateUser(updated);
            return Ok("User has been updated.");
        }
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteUser([FromHeader(Name = "Authorization")] string authorization)
        {
            if (string.IsNullOrWhiteSpace(authorization)) return BadRequest();
            await _userService.DeleteUser(authorization);
            return Ok("User deleted.");
        }
    }
}
