using AutoMapper;
using Common.Controllers;
using Common.Services.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mystore.Api.Data.Models.Project;
using Mystore.Api.Repositories.Identity;
using Mystore.Api.Repositories.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Mystore.Api.Controllers
{
    public class ProjectController : ApiController
    {
        private readonly ICurrentUserService currentUser;
        private readonly IUserDetailsRepository userDetailsRepository;
        private readonly IProjectRepository projectRepository;
        private readonly IMapper mapper;

        public ProjectController(
            ICurrentUserService currentUser,
            IUserDetailsRepository userDetailsRepository,
            IProjectRepository projectRepository,
            IMapper mapper)
        {
            this.currentUser = currentUser;
            this.userDetailsRepository = userDetailsRepository;
            this.projectRepository = projectRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route(nameof(UserProjects))]
        public async Task<ActionResult> UserProjects()
        {
            var result = await projectRepository.GetUserProjects(currentUser.UserId);
            if (result == default)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route(nameof(All))]
        public async Task<ActionResult> All()
        {
            var result = await projectRepository.GetAll();
            if (result == default)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route(nameof(GetById))]
        public async Task<ActionResult> GetById(long id)
        {
            var result = await projectRepository.GetProject(id);
            if (result == default)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route(nameof(CreateProject))]
        public async Task<ActionResult> CreateProject(ProjectInputModel input)
        {
            input.AuthorId = await userDetailsRepository.GetDetailsIdForUser(currentUser.UserId);
            var result = await projectRepository.Create(input);
            if (!result.Succeeded)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
