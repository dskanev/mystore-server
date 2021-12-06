using Mystore.Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystore.Api.Services
{
    public interface ITokenGeneratorService
    {
        /// <summary>
        /// Generates a jwt token
        /// </summary>
        /// <param name="user"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        string GenerateToken(User user, IEnumerable<string> roles = null);
    }
}
