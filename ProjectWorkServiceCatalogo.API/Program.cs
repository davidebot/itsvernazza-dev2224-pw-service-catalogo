using System.Net;
//using Links.OpenLending.Services.Common.Database.Configurations;
//using Links.OpenLending.Services.Common.Database.Extensions;
using Links.OpenLending.Services.Common.Exception.Filters;
using Links.OpenLending.Services.Common.Logging.Configurations;
using Links.OpenLending.Services.Common.Logging.Extensions;
using Links.OpenLending.Services.Common.OpenAPI.Configurations;
using Links.OpenLending.Services.Common.OpenAPI.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectWorkServiceCatalogo.BL.Implementations;
using ProjectWorkServiceCatalogo.BL.Interfaces;
using ProjectWorkServiceCatalogo.DL;

namespace ProjectWorkServiceCatalogo.API
{
    /// <summary>
    /// Entry Point class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry Point method
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            builder.Services.AddLinksCommonOpenAPI(configuration.GetSection(OpenAPIConfigurationsModel.Section));
            //builder.Services.AddLinksCommonOpenAPIHeaderParameters<HeaderParameters>();
            builder.Services.AddLinksCommonLogging(configuration.GetSection(LoggingConfigurationsModel.Section));
            //builder.Services.AddLinksCommonDatabase<CatalogoServiceDbContext>(configuration.GetSection(DatabaseConfigurationsModel.Section));

            builder.Services.AddDbContext<CatalogoServiceDbContext>(options =>
                options.UseNpgsql(configuration.GetValue<string>("Common:Database:ConnectionString"))
            );

            builder.Host.UseLinksCommonLogging();

            builder.Services.AddScoped<IExceptionFilter, CustomExceptionFilter>();

            builder.Services.AddScoped<ICategoriaService, CategoriaService>();

            var app = builder.Build();

            app.UseLinksCommonOpenAPI(configuration.GetSection(OpenAPIConfigurationsModel.Section));
            app.UseLinksCommonLogging(configuration.GetSection(LoggingConfigurationsModel.Section));

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            app.Run();
        }
    }
}