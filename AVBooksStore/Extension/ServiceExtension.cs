using AVBooksStore.Middlewares;
using AVBooksStore.Models.ServiceModel;
using BusinessLayer.BusinessServices.UserService;
using BusinessLayer.IBusinessServices.UserService;
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

            #region DB Service

            builder.Services.AddSingleton<DBService>();

            #endregion

            return builder;
        }

        public static WebApplication WebApplicationPipeline(this WebApplication app) 
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseMiddleware();

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}
