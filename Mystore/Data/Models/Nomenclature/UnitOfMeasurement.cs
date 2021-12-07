using Common.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystore.Api.Data.Models.Nomenclature
{
    public class UnitOfMeasurement : DatabaseModel
    {
        public string Description { get; set; }
    }

    public class UnitOfMeasurementInputModel
    {
        public string Description { get; set; }
    }
}
