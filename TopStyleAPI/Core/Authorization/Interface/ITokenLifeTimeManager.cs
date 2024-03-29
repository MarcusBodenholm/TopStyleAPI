using Microsoft.IdentityModel.Tokens;

namespace TopStyleAPI.Core.Authorization.Interface
{
    public interface ITokenLifeTimeManager
    {
        public bool ValidateTokenLifeTime(DateTime? notBefore,
                                          DateTime? expires,
                                          SecurityToken securityToken,
                                          TokenValidationParameters validationParameters);
        public void SignOut(SecurityToken securityToken);
    }
}
