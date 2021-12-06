using Common.Services;
using Mystore.Api.Data.Models;
using Mystore.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystore.Api.Services
{
    public interface IIdentityService
    {
        Task<Result<User>> Register(UserInputModel userInput);
        Task<Result<UserOutputModel>> Login(UserInputModel userInput);
        Task<Result> ChangePassword(string userId, ChangePasswordInputModel changePasswordInput);
    }
}
