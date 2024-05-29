using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace AVBooksStore.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware
    {
        private readonly RequestDelegate _next;

        public Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            try
            {
                httpContext.Request.EnableBuffering();
                var bodyAsText = new StreamReader(httpContext.Request.Body).ReadToEndAsync().Result;
                httpContext.Request.Body.Position = 0;
                var result = JsonConvert.DeserializeObject<dynamic>(bodyAsText);
                if (result != null && !httpContext.Request.Headers.ContainsKey("Authorization"))
                {
                    var token = ExtractTokenFromJson(bodyAsText);
                    if (!string.IsNullOrEmpty(token))
                        httpContext.Request.Headers.Add("Authorization", $"Bearer {token}");
                }
                return _next(httpContext);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
        private string ExtractTokenFromJson(string json)
        {
            // Implement your logic to extract the token from the JSON payload
            // This will depend on the structure of your JSON payload
            // For example, if the token is in the "SecurityToken" property:
            var jsonObject = JObject.Parse(json);
            return (string)jsonObject["SecurityToken"];

            // Replace this with your own implementation
            // return "";
        }
    }

    

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            try
            {
                return builder.UseMiddleware<Middleware>();
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }
    }
}
