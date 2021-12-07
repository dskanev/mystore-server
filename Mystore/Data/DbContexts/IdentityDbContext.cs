using Mystore.Api.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Mystore.Api.Data.Models.Nomenclature;
using Mystore.Api.Data.Models.Identity;
using Mystore.Api.Data.Models.Project;

namespace Mystore.Api.Data
{
    public class IdentityDbContext : IdentityDbContext<User>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
            : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<UnitOfMeasurement> UnitsOfMeasurement { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ImageMapping> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
