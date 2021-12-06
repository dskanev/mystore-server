using Common.Services;
using Mystore.Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystore.Api.Services
{
    public interface IUserRepository : IDataService<User>
    {
    }
}
