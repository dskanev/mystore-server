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
    }
}
