using AutoMapper;
using Common.Data.Mappings;
using Common.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystore.Api.Data.Models.Nomenclature
{
    public class ImageMapping : DatabaseModel, IMapping
    {
        public string ImageUrl { get; set; }
        public Data.Models.Project.Project Project { get; set; }
        public long ProjectId { get; set; }

        public void MappingProfile(Profile mapper)
        {
            mapper.CreateMap<ImageInputModel, ImageMapping>();
            mapper.CreateMap<ImageMapping, ImageOutputModel>();
        }
    }

    public class ImageInputModel
    {
        public string ImageUrl { get; set; }
        public long ProjectId { get; set; }
    }

    public class ImageOutputModel
    {
        public long Id { get; set; }
        public string ImageUrl { get; set; }
    }
}
