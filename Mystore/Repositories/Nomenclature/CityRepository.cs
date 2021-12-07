using AutoMapper;
using Common.Services;
using Microsoft.EntityFrameworkCore;
using Mystore.Api.Data;
using Mystore.Api.Data.Models.Nomenclature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystore.Api.Repositories.Nomenclature
{
    public class CityRepository : DataService<City>, ICityRepository
    {
        private readonly IMapper mapper;

        public CityRepository(IdentityDbContext db, IMapper mapper)
        : base(db)
            => this.mapper = mapper;

        public IQueryable<City> GetAll()
            => this.All();

        public async Task<Result<City>> SaveAsync(City city)
        {
            try
            {
                if (city.Name == null || city.Name == "")
                {
                    return Result<City>.Failure("City name is required.");
                }

                await this.Data.AddAsync(city);
                await this.Data.SaveChangesAsync();

                return Result<City>.SuccessWith(city);
            }
            catch(Exception e)
            {
                return Result<City>.Failure(e.Message);
            }
        }

        public async Task<City> GetById(long id)
            => await this
                .All()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
    }
}
