using AVBooksStore.Middlewares;
using AVBooksStore.Models.ServiceModel;
using BusinessLayer.BusinessServices.UserService;
using BusinessLayer.BusinessServices.Validation;
using BusinessLayer.IBusinessServices.UserService;
using MapObjectLibrary.DBMapping.IMapping;
using MapObjectLibrary.DBMapping.Mapping;
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

            #region DB Service

            builder.Services.AddSingleton<DBService>(_ => new DBService(builder.Configuration.GetSection("ConnectionString").Get<string>()));


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
