using AVBooksStore.Middlewares;
using AVBooksStore.Models.ServiceModel;
using BusinessLayer.BusinessServices.UserService;
using BusinessLayer.IBusinessServices.UserService;

namespace AVBooksStore.Extension
{
    public static class ServiceExtension
    {
        public static WebApplicationBuilder AddDomainServices(this WebApplicationBuilder builder) 
        {
            builder.Services.Configure<DomainServices>(builder.Configuration.GetSection("DomainSetting"));
            builder.Services.AddScoped<IUserServices, UserServices>();
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
