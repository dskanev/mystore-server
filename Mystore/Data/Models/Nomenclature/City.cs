using Common.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystore.Api.Data.Models.Nomenclature
{
    public class City : DatabaseModel
    {
        public string Name { get; set; }
    }

    public class CityInputModel
    {
        public string Name { get; set; }
    }
}
