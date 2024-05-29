using AVBooksStore.Middlewares;
using AVBooksStore.Models.ServiceModel;
using BusinessLayer.BusinessServices.UserService;
using BusinessLayer.BusinessServices.Validation;
using BusinessLayer.IBusinessServices.UserService;
using MapObjectLibrary.DBMapping.IMapping;
using MapObjectLibrary.DBMapping.Mapping;
using Microsoft.OpenApi.Models;
using NSwag;
using RepositoryLayer.DatabaseServices;
using RepositoryLayer.IRepositoryServices;
using RepositoryLayer.RepositoryServices;

namespace AVBooksStore.Extension
{
    public static class ServiceExtension
    {
        public static WebApplicationBuilder AddDomainServices(this WebApplicationBuilder builder) 
        {
            builder.Services.Configure<DomainServices>(builder.Configuration.GetSection("DomainSetting"));

            #region BusinessServices

            builder.Services.AddScoped<IUserServices, UserServices>();

            #endregion
            #region Repository Services

            builder.Services.AddScoped<IUserRepoServices, UserRepoServices>();

            #endregion

            #region Mapping services
            builder.Services.AddScoped<IDatabaseMapper, DatabaseMapper>();
            builder.Services.AddScoped<SignupValidator>();
            #endregion

            #region swagger services
            builder.AddSwaggerService();
            #endregion

            #region DB Service

            builder.Services.AddSingleton<DBService>(_ => new DBService(builder.Configuration.GetSection("ConnectionString").Get<string>()));


            #endregion

            return builder;
        }

        private static WebApplicationBuilder AddSwaggerService(this WebApplicationBuilder builder)
        {
            builder.Services.AddOpenApiDocument(settings =>
            {
                settings.Title = "Book Store API.";
                settings.AddSecurity("Bearer", Enumerable.Empty<string>(), new NSwag.OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = OpenApiSecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = OpenApiSecurityApiKeyLocation.Header
                });
            });
            return builder;
        }

        public static WebApplication WebApplicationPipeline(this WebApplication app) 
        {

          

            app.UseMiddleware();

            app.UseJWTMiddleware();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseSwaggerService();

            app.MapControllers();

            return app;
        }
        private static IApplicationBuilder UseSwaggerService(this IApplicationBuilder app)
        {
            app.UseOpenApi(a =>
            {
                a.PostProcess = (document, _) =>
                {
                    document.Schemes = new[] { NSwag.OpenApiSchema.Https, NSwag.OpenApiSchema.Http };
                };

            });
            app.UseSwaggerUi3();
            return app;
        }

    }
}
