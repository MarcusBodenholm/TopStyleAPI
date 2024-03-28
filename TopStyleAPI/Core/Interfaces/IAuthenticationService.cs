using Microsoft.AspNetCore.Identity;
using TopStyleAPI.Domain.DTO;

namespace TopStyleAPI.Core.Interfaces
{
    public interface IAuthenticationService
    {
        public Task<IdentityResult> RegisterUser(UserForRegistrationDTO userForRegistration);
        public Task<bool> ValidateUser(UserForAuthenticationDTO userForAuth);
        public Task<string> CreateToken();
    }
}
