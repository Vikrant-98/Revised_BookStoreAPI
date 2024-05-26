using Microsoft.IdentityModel.Tokens;
using ModelsLibrary.DataBaseModels.TempModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BusinessLayer.BusinessServices.Validation
{
    public class TokenService
    {
        public static Tuple<string, DateTime> GenerateJwtToken(UserDetails details)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("thisismysecretkeythisismysecretkeythisismysecretkeythisismysecretkeythisismysecretkeythisismysecretkeythisismysecretkey");
                var expiry = GetDateTimeBasedOnDisplayValue("D", 1);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] {
                    new Claim("Role", details.Role),
                    new Claim("Email", details.Email),
                    new Claim("Mobile", details.Mobile)
                }),
                    Expires = DateTime.Now.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return Tuple.Create(tokenHandler.WriteToken(token), expiry);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static DateTime GetDateTimeBasedOnDisplayValue(string DisplayValue, int TokenValidity)
        {
            return DisplayValue.ToUpper() switch
            {
                "D" => DateTime.UtcNow.AddDays(TokenValidity),
                "H" => DateTime.UtcNow.AddHours(TokenValidity),
                "M" => DateTime.UtcNow.AddMinutes(TokenValidity),
                _ => DateTime.UtcNow.AddSeconds(TokenValidity),
            };
        }

    }
}
