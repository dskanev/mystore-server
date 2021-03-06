using AutoMapper;
using Common.Controllers;
using Common.Services.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mystore.Api.Data.Models.Nomenclature;
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
        private readonly IImageRepository imageRepository;
        private readonly ICommentRepository commentRepository;
        private readonly IMapper mapper;

        public ProjectController(
            ICurrentUserService currentUser,
            IUserDetailsRepository userDetailsRepository,
            IProjectRepository projectRepository,
            IImageRepository imageRepository,
            ICommentRepository commentRepository,
            IMapper mapper)
        {
            this.currentUser = currentUser;
            this.userDetailsRepository = userDetailsRepository;
            this.projectRepository = projectRepository;
            this.imageRepository = imageRepository;
            this.commentRepository = commentRepository;
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
            input.AuthorId = currentUser.UserId;
            var result = await projectRepository.Create(input);
            if (!result.Succeeded)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route(nameof(UpdateProject))]
        public async Task<ActionResult> UpdateProject(ProjectInputModel input)
        {
            var result = await projectRepository.Edit(input);
            if (!result.Succeeded)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpDelete]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route(nameof(DeleteProject))]
        public async Task<ActionResult> DeleteProject(long projectId)
        { 
            var result = await projectRepository.Delete(projectId);
            if (!result.Succeeded)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route(nameof(GetImageById))]
        public async Task<ActionResult> GetImageById(long id)
        {
            var result = await imageRepository.GetById(id);
            if (result == default)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route(nameof(GetImagesForProject))]
        public async Task<ActionResult> GetImagesForProject(long id)
        {
            var result = await imageRepository.GetAllForProject(id);
            if (result == default)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route(nameof(SaveProjectImage))]
        public async Task<ActionResult> SaveProjectImage(ImageInputModel input)
        {
            var result = await imageRepository.CreateImage(input);
            if (result == default)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route(nameof(PostComment))]
        public async Task<ActionResult> PostComment(CommentInputModel input)
        {
            input.AuthorId = currentUser.UserId;
            var result = await commentRepository.PostComment(input);
            if (!result.Succeeded)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route(nameof(GetCommentsForProject))]
        public async Task<ActionResult> GetCommentsForProject(long projectId)
        {
            var result = await commentRepository.GetCommentsForProject(projectId);
            if(result == default)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route(nameof(ApplyForProject))]
        public async Task<ActionResult> ApplyForProject(long projectId)
        {
            var userId = currentUser.UserId;
            var result = await projectRepository.AssignApplicantToProject(projectId, userId);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.FirstOrDefault());
            }
            return Ok(result);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route(nameof(GetProjectApplicants))]
        public async Task<ActionResult> GetProjectApplicants(long projectId)
        {
            var result = await projectRepository.GetProjectApplicants(projectId);
            if (!result.Succeeded)
            {
                return BadRequest();
            }    
            return Ok(result);
        }
    }
}
