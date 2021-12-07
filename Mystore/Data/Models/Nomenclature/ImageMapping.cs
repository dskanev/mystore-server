using Common.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystore.Api.Data.Models.Nomenclature
{
    public class ImageMapping : DatabaseModel
    {
        public string ImageUrl { get; set; }
        public Data.Models.Project.Project Project { get; set; }
        public long ProjectId { get; set; }
    }
}
