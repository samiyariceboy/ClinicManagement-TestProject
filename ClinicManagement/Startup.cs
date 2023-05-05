using ClinicManagement.Services.Common.Pagination;
using ClinicManagement.WebFramework.Configuration;
using ClinicManagement.WebFramework.Middlewares;
using ClinicManagement.WebFramework.Swagger;

namespace Mc2.CrudTest.Presentation.Server
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCustomDbContext(Configuration);
            services.AddCustomMediateR(typeof(BasePagination).Assembly);
            services.AddCustomApiVersioning();
            services.AddMinimalMvc();
            services.AddCustomSwagger();

        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            app.UseCustomExceptionHandler();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCustomSwaggerUI();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
