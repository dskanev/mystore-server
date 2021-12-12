using AutoMapper;
using Common.Services;
using Mystore.Api.Data;
using Mystore.Api.Data.Models;
using Mystore.Api.Data.Models.Identity;
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

        public async Task SaveUserDetails(string userId)
        {
            var userDetails = new UserDetails
            {
                UserId = userId
            };

            await this.Data.AddAsync(userDetails);
            await this.Data.SaveChangesAsync();
        }
    }


}
