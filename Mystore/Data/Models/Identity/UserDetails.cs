using AutoMapper;
using Common.Data.Mappings;
using Common.Data.Models;
using Mystore.Api.Data.Models.Nomenclature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystore.Api.Data.Models.Identity
{
    public class UserDetails : DatabaseModel, IMapping
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public City City { get; set; }
        public long CityId { get; set; }
        public IList<Mystore.Api.Data.Models.Project.Project> Projects { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }

        public void MappingProfile(Profile mapper)
        {
            mapper.CreateMap<UserDetailsInputModel, UserDetails>();
        }
    }

    public class UserDetailsInputModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public long CityId { get; set; }
    }
}
