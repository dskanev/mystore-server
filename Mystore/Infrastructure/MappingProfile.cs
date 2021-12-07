using AutoMapper;
using Mystore.Api.Data.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystore.Api.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDetailsInputModel, UserDetails>();
        }
    }
}
