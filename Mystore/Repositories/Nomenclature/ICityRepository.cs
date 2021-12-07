using Common.Services;
using Mystore.Api.Data.Models.Nomenclature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystore.Api.Repositories.Nomenclature
{
    public interface ICityRepository : IDataService<City>
    {
        public IQueryable<City> GetAll();
        Task<Result<City>> SaveAsync(City city);
        Task<City> GetById(long id);
    }
}
