using Common.Services;
using Mystore.Api.Data.Models;
using Mystore.Api.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using Common.Extensions;

namespace Mystore.Api.Services
{
    public class IdentityService : IIdentityService
    {
        private const string InvalidErrorMessage = "Invalid credentials.";

        private readonly UserManager<User> userManager;
        private readonly ITokenGeneratorService jwtTokenGenerator;
        private readonly IUserRepository userRepository;

        public IdentityService(
            UserManager<User> userManager,
            ITokenGeneratorService jwtTokenGenerator,
            IUserRepository userRepository)
        {
            this.userManager = userManager;
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.userRepository = userRepository;
        }

        public async Task<Result<User>> Register(UserInputModel userInput)
        {
            var user = new User
            {
                Email = userInput.Email,
                UserName = userInput.Email
            };

            var identityResult = await this.userManager.CreateAsync(user, userInput.Password);

            if (identityResult.Succeeded)
            {
                await userRepository.SaveUserDetails(user.Id, userInput.Email);
            }

            var errors = identityResult.Errors.Select(e => e.Description);

            return identityResult.Succeeded
                ? Result<User>.SuccessWith(user)
                : Result<User>.Failure(errors);
        }

        public async Task<Result<UserOutputModel>> Login(UserInputModel userInput)
        {
            var user = await this.userManager.FindByEmailAsync(userInput.Email);
            if (user == null)
            {
                return InvalidErrorMessage;
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, userInput.Password);
            if (!passwordValid)
            {
                return InvalidErrorMessage;
            }

            var roles = await this.userManager.GetRolesAsync(user);

            var token = this.jwtTokenGenerator.GenerateToken(user, roles);

            return new UserOutputModel(token, user.Id);
        }

        public async Task<Result> ChangePassword(
            string userId,
            ChangePasswordInputModel changePasswordInput)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return InvalidErrorMessage;
            }

            var identityResult = await this.userManager.ChangePasswordAsync(
                user,
                changePasswordInput.CurrentPassword,
                changePasswordInput.NewPassword);

            var errors = identityResult.Errors.Select(e => e.Description);

            return identityResult.Succeeded
                ? Result.Success
                : Result.Failure(errors);
        }
    }
}
