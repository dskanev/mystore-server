using Common.Data.Models;
using Mystore.Api.Data.Models.Nomenclature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystore.Api.Data.Models.Project
{
    public class Project : DatabaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public UnitOfMeasurement UnitOfMeasurement { get; set; }
        public City City { get; set; }
        public int Measurement { get; set; }
        public string[] ImageUrls { get; set; }
        public DateTime? Deadline { get; set; }
        public User Author { get; set; }
    }
}
