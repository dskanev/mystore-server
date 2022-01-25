using AutoMapper;
using Common.Services;
using Microsoft.EntityFrameworkCore;
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

        public async Task SaveUserDetails(string userId, string email)
        {
            var dbUser = await this.All()
                .Where(x => x.Id == userId)
                .FirstOrDefaultAsync();

            dbUser.Email = email;

            await this.Data.SaveChangesAsync();
        }
    }


}
