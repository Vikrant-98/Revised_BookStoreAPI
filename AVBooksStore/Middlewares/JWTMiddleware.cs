using CommonLibrary.CommonServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Core.Tokens;

namespace AVBooksStore.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class JWTMiddleware
    {
        private readonly RequestDelegate _next;

        public JWTMiddleware(RequestDelegate next)
        {            
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            try
            {
                //HeaderDetails? headerDetails = await commonService.GetSecretKey(token);
                //if (headerDetails != null)
                //{
                var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                if (token != null) {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("thisismysecretkeythisismysecretkeythisismysecretkeythisismysecretkeythisismysecretkeythisismysecretkeythisismysecretkey");
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;
                
                    //httpContext.Request.Headers.Add(Common.ProgramCode, jwtToken.Claims.First(claim => claim.Type == Common.ProgramCode).Value);
                    //httpContext.Request.Headers.Add(Common.TenantID, headerDetails.TenantID);
                    //}
                }
                return _next(httpContext);
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class Middleware1Extensions
    {
        public static IApplicationBuilder UseJWTMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<JWTMiddleware>();
        }
    }
}
