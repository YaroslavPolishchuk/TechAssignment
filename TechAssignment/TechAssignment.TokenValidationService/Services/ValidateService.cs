using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace TechAssignment.TokenValidationService.Services
{
    public class ValidateService
    {
        private readonly RsaSecurityKey _rsaKey;

        public ValidateService(RsaSecurityKey rsaKey)
        {
            _rsaKey = rsaKey;
        }

        public bool ValidateJwt(string token)
        {
            try
            {
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    RequireSignedTokens = true,
                    IssuerSigningKey = _rsaKey                    
                };

                var handler = new JwtSecurityTokenHandler();
                handler.ValidateToken(token, validationParameters, out _);
                return true;
            }
            catch (Exception ex)
            {                
                return false;
            }
        }
    }
}
