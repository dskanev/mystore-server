using Common.Services;
using Mystore.Api.Data.Models.Nomenclature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystore.Api.Repositories.Nomenclature
{
    public interface IUnitOfMeasurementRepository : IDataService<UnitOfMeasurement>
    {
        IQueryable<UnitOfMeasurement> GetAll();
        Task SaveAsync(UnitOfMeasurement unit);
    }
}
