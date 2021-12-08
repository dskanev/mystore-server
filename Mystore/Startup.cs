using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Common.Infrastructure;
using Common.Services;
using Mystore.Api.Data;
using Mystore.Api.Infrastructure;
using Mystore.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Mystore.Api.Data.Seeders;
using Mystore.Api.Repositories.Identity;
using Mystore.Api.Repositories.Nomenclature;
using Mystore.Api.Repositories.Project;
using Common.Services.Identity;
using System.Text.Json.Serialization;

namespace Mystore
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
               .AddWebService<IdentityDbContext>(this.Configuration)
               .AddUserStorage()
               .AddTransient<IDataSeeder, IdentityDataSeeder>()
               .AddTransient<IDataSeeder, NomenclaturesDataSeeder>()
               .AddTransient<IIdentityService, IdentityService>()
               .AddTransient<ITokenGeneratorService, TokenGeneratorService>()
               .AddTransient<IUserRepository, UserRepository>()
               .AddTransient<IUserDetailsRepository, UserDetailsRepository>()
               .AddTransient<ICityRepository, CityRepository>()
               .AddTransient<IUnitOfMeasurementRepository, UnitOfMeasurementRepository>()
               .AddTransient<IProjectRepository, ProjectRepository>()
               .AddTransient<IImageRepository, ImageRepository>()
               .AddSwagger();

            services
                .AddControllers();
                /*
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                });*/
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env)
                .Initialize()
                .AddSwagger();
    }
}
