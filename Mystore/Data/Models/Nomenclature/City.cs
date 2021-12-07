using Common.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mystore.Api.Data.Models.Nomenclature
{
    public class City : DatabaseModel
    {
        [Required]
        public string Name { get; set; }
    }

    public class CityInputModel
    {
        [Required]
        public string Name { get; set; }
    }
}
