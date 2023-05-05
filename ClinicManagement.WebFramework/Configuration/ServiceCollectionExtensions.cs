using ClinicManagement.Data.DbContexts.Sql.SqlServer;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace ClinicManagement.WebFramework.Configuration
{

    public static class ServiceCollectionExtensions
    {
        public static void AddCustomDbContext(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SqlServer"));
            }, ServiceLifetime.Scoped);
        }

        public static void AddCustomMediateR(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddMediatR(assemblies);
        }
        public static void AddMinimalMvc(this IServiceCollection services)
        {
            services.AddControllersWithViews(options =>
            {
                //options.Filters.Add(new AuthorizeFilter());
            })
            .AddNewtonsoftJson(option =>
            {
                option.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
                option.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;

                option.SerializerSettings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.MicrosoftDateFormat;
                option.SerializerSettings.DateParseHandling = Newtonsoft.Json.DateParseHandling.DateTime;
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
                /*this method use for Deprecated DescribeAllParametersInCamelCase() method*/
            });
            services.AddRazorPages();
            #region Old way (We don't need Muhammad from ASP.NET Core 3.0 onwards)
            ////https://github.com/aspnet/Mvc/blob/release/2.2/src/Microsoft.AspNetCore.Mvc/MvcServiceCollectionExtensions.cs
            //services.AddMvcCore(options =>
            //{
            //    options.Filters.Add(new AuthorizeFilter());

            //    //Like [ValidateAntiforgeryToken] attribute but dose not validatie for GET and HEAD http method
            //    //You can ingore validate by using [IgnoreAntiforgeryToken] attribute
            //    //Use this filter when use cookie 
            //    //options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());

            //    //options.UseYeKeModelBinder();
            //})
            //.AddApiExplorer()
            //.AddAuthorization()
            //.AddFormatterMappings()
            //.AddDataAnnotations()
            //.AddJsonOptions(option =>
            //{
            //    //option.JsonSerializerOptions
            //})
            //.AddNewtonsoftJson(/*option =>
            //{
            //    option.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            //    option.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            //}*/)

            ////Microsoft.AspNetCore.Mvc.Formatters.Json
            ////.AddJsonFormatters(/*options =>
            ////{
            ////    options.Formatting = Newtonsoft.Json.Formatting.Indented;
            ////    options.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            ////}*/)

            //.AddCors()
            //.SetCompatibilityVersion(CompatibilityVersion.Latest); //.SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            #endregion
        }
        public static void AddCustomApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(option =>
            {
                option.AssumeDefaultVersionWhenUnspecified = true;
                option.DefaultApiVersion = new ApiVersion(1, 0);
                option.ApiVersionReader = new UrlSegmentApiVersionReader();
                option.ReportApiVersions = true;
            });
        }
        public static void AddCustomForwardedHeadersOptions(this IServiceCollection services)
        {
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });
        }

    }
}
