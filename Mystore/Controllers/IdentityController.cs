using System.Threading.Tasks;
using Common.Controllers;
using Common.Services.Identity;
using Mystore.Api.Models;
using Mystore.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mystore.Api.Data.Models.Identity;
using Mystore.Api.Repositories.Identity;
using AutoMapper;

namespace Mystore.Api.Controllers
{
    public class IdentityController : ApiController
    {
        private readonly IIdentityService identity;
        private readonly ICurrentUserService currentUser;
        private readonly IUserDetailsRepository userDetailsRepository;
        private readonly IMapper mapper;

        public IdentityController(
            IIdentityService identity,
            ICurrentUserService currentUser,
            IUserDetailsRepository userDetailsRepository,
            IMapper mapper)
        {
            this.identity = identity;
            this.currentUser = currentUser;
            this.userDetailsRepository = userDetailsRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult<UserOutputModel>> Register(UserInputModel input)
        {
            var result = await this.identity.Register(input);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return await Login(input);
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<UserOutputModel>> Login(UserInputModel input)
        {
            var result = await this.identity.Login(input);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return new UserOutputModel(result.Data.Token);
        }

        [HttpPut]
        [Authorize]
        [Route(nameof(ChangePassword))]
        public async Task<ActionResult> ChangePassword(ChangePasswordInputModel input)
            => await this.identity.ChangePassword(this.currentUser.UserId, new ChangePasswordInputModel
            {
                CurrentPassword = input.CurrentPassword,
                NewPassword = input.NewPassword
            });

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [Route(nameof(SaveUserDetails))]
        public async Task<ActionResult> SaveUserDetails(UserDetailsInputModel userDetails)
        {
            var dbModel = mapper.Map<UserDetails>(userDetails);
            dbModel.UserId = currentUser.UserId;

            var result = await userDetailsRepository.SaveUserDetails(dbModel);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Ok(result.Data);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        [Route(nameof(GetCurrentUserDetails))]
        public async Task<ActionResult> GetCurrentUserDetails()
        {
            var result = await userDetailsRepository.GetByUserId(currentUser.UserId);
            if (result == default)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
