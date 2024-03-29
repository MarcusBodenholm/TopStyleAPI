using Microsoft.IdentityModel.Tokens;
using System.Collections.Concurrent;
using System.IdentityModel.Tokens.Jwt;
using TopStyleAPI.Core.Authorization.Interface;

namespace TopStyleAPI.Core.Authorization.TokenLifeTimeManager
{
    public class JwtTokenLifeTimeManager : ITokenLifeTimeManager
    {
        private static readonly ConcurrentDictionary<string, DateTime> DisavowedSignatures = new();
        public bool ValidateTokenLifeTime(DateTime? notBefore, 
                                          DateTime? expires, 
                                          SecurityToken securityToken, 
                                          TokenValidationParameters validationParameters)
        {

            if (DisavowedSignatures.ContainsKey(securityToken.UnsafeToString()) is false)
            {
                return true;
            }
            return false;
        }
        public void SignOut(SecurityToken securityToken)
        {
            DisavowedSignatures.TryAdd(securityToken.UnsafeToString(), securityToken.ValidTo);
            foreach ((string? key, DateTime _) in DisavowedSignatures.Where(x => x.Value < DateTime.UtcNow))
            {
                DisavowedSignatures.TryRemove(key, out DateTime _);
            }
        }
    }
}
