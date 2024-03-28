using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TopStyleAPI.Core.Interfaces;
using TopStyleAPI.Domain.DTO;

namespace TopStyleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser(UserForRegistrationDTO userForRegistration)
        {
            if (userForRegistration == null) return BadRequest("Invalid data.");
            if (!ModelState.IsValid) return UnprocessableEntity(userForRegistration);
            var result = await _authenticationService.RegisterUser(userForRegistration);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return StatusCode(201);
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDTO user)
        {
            if (!await _authenticationService.ValidateUser(user)) return Unauthorized();
            return Ok(new { Token = await _authenticationService.CreateToken() });
        }
    }
}
