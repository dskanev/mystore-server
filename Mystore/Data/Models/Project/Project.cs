using AutoMapper;
using Common.Data.Mappings;
using Common.Data.Models;
using Mystore.Api.Data.Models.Identity;
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
        public long UnitOfMeasurementId { get; set; }
        public City City { get; set; }
        public long CityId { get; set; }
        public int Measurement { get; set; }
        public IList<ImageMapping> Images { get; set; }
        public DateTime? Deadline { get; set; }
        public UserDetails Author { get; set; }
        public long AuthorId { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class ProjectInputModel : IMapping
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long UnitOfMeasurementId { get; set; }
        public long CityId { get; set; }
        public int Measurement { get; set; }
        public DateTime? Deadline { get; set; }
        public long AuthorId { get; set; }

        public void MappingProfile(Profile mapper)
        {
            mapper.CreateMap<ProjectInputModel, Project>();
        }
    }

    public class ProjectOutputModel : IMapping
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public UnitOfMeasurement UnitOfMeasurement { get; set; }
        public City City { get; set; }
        public int Measurement { get; set; }
        public DateTime? Deadline { get; set; }
        public string CreatedBy { get; set; }

        public void MappingProfile(Profile mapper)
        {
            mapper.CreateMap<Project, ProjectOutputModel>();
        }
    }
}
