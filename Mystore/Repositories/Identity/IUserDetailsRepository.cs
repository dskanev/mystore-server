using Common.Services;
using Mystore.Api.Data.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystore.Api.Repositories.Identity
{
    public interface IUserDetailsRepository : IDataService<UserDetails>
    {
        Task<Result<UserDetails>> SaveUserDetails(UserDetails userDetails);
        Task<UserDetails> GetByUserId(string userId);
        Task<long> GetDetailsIdForUser(string userId);
    }
}
