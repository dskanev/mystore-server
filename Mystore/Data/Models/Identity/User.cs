using AutoMapper;
using Common.Data.Mappings;
using Microsoft.AspNetCore.Identity;
using Mystore.Api.Data.Models.Nomenclature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystore.Api.Data.Models
{
    public class User : IdentityUser, IMapping
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public City City { get; set; }
        public long? CityId { get; set; }

        public void MappingProfile(Profile mapper)
        {
            mapper.CreateMap<UserDetailsInputModel, User>();
            mapper.CreateMap<User, UserDetailsOutputModel>();
        }
    }

    public class UserDetailsInputModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public long CityId { get; set; }
    }

    public class UserDetailsOutputModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public City City { get; set; }
        public IList<Mystore.Api.Data.Models.Project.Project> Projects { get; set; }
        public string UserId { get; set; }
    }
}
