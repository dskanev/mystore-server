namespace Common.Infrastructure
{
    using Common.Services;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using System.Reflection;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseWebService(
            this IApplicationBuilder app,
            IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseRouting()
                .UseCors(options => options
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod())
                .UseJwtHeaderAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints => endpoints
                    .MapControllers());

            return app;
        }

        public static IApplicationBuilder Initialize(
            this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var serviceProvider = serviceScope.ServiceProvider;
            
            var db = serviceProvider.GetRequiredService<DbContext>();

            db.Database.Migrate();

            var seeders = serviceProvider.GetServices<IDataSeeder>();

            foreach (var seeder in seeders)
            {
                seeder.SeedData();
            }

            return app;
        }

        public static IApplicationBuilder AddSwagger(
            this IApplicationBuilder app)
        {
            return app
                .UseSwagger()
                .UseSwaggerUI(c =>
                {                    
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", Assembly.GetEntryAssembly().GetName().Name);
                });
        }
    }
}
