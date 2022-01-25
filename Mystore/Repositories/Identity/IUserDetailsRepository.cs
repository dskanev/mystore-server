using Common.Services;
using Mystore.Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystore.Api.Repositories.Identity
{
    public interface IUserDetailsRepository : IDataService<User>
    {
        Task<Result<User>> SaveUserDetails(UserDetailsInputModel userDetails);
        Task<User> GetByUserId(string userId);
    }
}
