using AutoMapper;
using Common.Services;
using Mystore.Api.Data;
using Mystore.Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystore.Api.Services
{
    public class UserRepository : DataService<User>, IUserRepository
    {
        private readonly IMapper mapper;

        public UserRepository(IdentityDbContext db, IMapper mapper)
        : base(db)
            => this.mapper = mapper;
    }


}
