using AutoMapper;
using Common.Services;
using Mystore.Api.Data;
using Mystore.Api.Data.Models.Identity;

namespace Mystore.Api.Repositories.Identity
{
    public class UserDetailsRepository : DataService<UserDetails>, IUserDetailsRepository
    {
        private readonly IMapper mapper;

        public UserDetailsRepository(IdentityDbContext db, IMapper mapper)
        : base(db)
            => this.mapper = mapper;
    }
}
