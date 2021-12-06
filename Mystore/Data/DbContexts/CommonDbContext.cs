using Microsoft.EntityFrameworkCore;
using Mystore.Api.Data.Models.Identity;
using Mystore.Api.Data.Models.Nomenclature;
using Mystore.Api.Data.Models.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Mystore.Api.Data.DbContexts
{
    public class CommonDbContext : DbContext
    {
        public CommonDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<UnitOfMeasurement> UnitsOfMeasurement { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
