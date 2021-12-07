using Common.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mystore.Api.Data.Models.Nomenclature
{
    public class UnitOfMeasurement : DatabaseModel
    {
        [Required]
        public string Description { get; set; }
    }

    public class UnitOfMeasurementInputModel
    {
        [Required]
        public string Description { get; set; }
    }
}
