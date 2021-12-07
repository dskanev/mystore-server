using Common.Infrastructure;
using Common.Services;
using Microsoft.EntityFrameworkCore;
using Mystore.Api.Data.Models.Nomenclature;
using Mystore.Api.Repositories.Nomenclature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystore.Api.Data.Seeders
{
    public class NomenclaturesDataSeeder : IDataSeeder
    {
        private readonly IdentityDbContext db;

        public NomenclaturesDataSeeder(IdentityDbContext db) => this.db = db;

        public void SeedData()
        {
            if (!db.Set<City>().Any())
            {
                SeedCities();
            }

            if (!db.Set<UnitOfMeasurement>().Any())
            {
                SeedUnits();
            }
        }

        private void SeedCities()
        {
            Task
                .Run(async () =>
                {
                    var cities = new City[]
                    {
                        new City { Name = "Varna" },
                        new City { Name = "Sofia" },
                        new City { Name = "Plovdiv" }
                    };

                    foreach(var city in cities)
                    {
                        await db.AddAsync(city);
                        await db.SaveChangesAsync();
                    }
                })
                .GetAwaiter()
                .GetResult();
        }

        private void SeedUnits()
        {
            Task
                .Run(async () =>
                {
                    var units = new UnitOfMeasurement[]
                    {
                        new UnitOfMeasurement { Description = "Linear meters" },
                        new UnitOfMeasurement { Description = "Square meters" },
                        new UnitOfMeasurement { Description = "Quantity" }
                    };

                    foreach (var unit in units)
                    {
                        await db.AddAsync(unit);
                        await db.SaveChangesAsync();
                    }
                })
                .GetAwaiter()
                .GetResult();
        }
    }
}
