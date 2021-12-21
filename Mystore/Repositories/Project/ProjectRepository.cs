using AutoMapper;
using Common.Services;
using Microsoft.EntityFrameworkCore;
using Mystore.Api.Data;
using Mystore.Api.Data.Models.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystore.Api.Repositories.Project
{
    public class ProjectRepository : DataService<Mystore.Api.Data.Models.Project.Project>, IProjectRepository
    {
        private readonly IMapper mapper;

        public ProjectRepository(IdentityDbContext db, IMapper mapper)
        : base(db)
            => this.mapper = mapper;

        public async Task<IList<ProjectOutputModel>> GetAll()
        =>  await this
            .mapper
            .ProjectTo<ProjectOutputModel>(this.All())
            .ToListAsync();

        public async Task<ProjectOutputModel> GetProject(long id)
        => await this
            .mapper
            .ProjectTo<ProjectOutputModel>(this
                .All()
                .Where(x => x.Id == id))
                .FirstOrDefaultAsync();

        public async Task<IList<ProjectOutputModel>> GetUserProjects(string userId)
        => await this
            .mapper
            .ProjectTo<ProjectOutputModel>(this.All().Where(x => x.Author.UserId == userId))
            .ToListAsync();

        public async Task<Result<ProjectOutputModel>> Create(ProjectInputModel input)
        {
            var dbModel = this.mapper.Map<Mystore.Api.Data.Models.Project.Project>(input);
            await this.Data.AddAsync(dbModel);
            await this.Data.SaveChangesAsync();

            return Result<ProjectOutputModel>.SuccessWith(this.mapper.Map<ProjectOutputModel>(dbModel));
        }

        public async Task<Result<ProjectOutputModel>> Edit(ProjectInputModel input)
        {
            var dbProject = await this.Data
                .Set<Mystore.Api.Data.Models.Project.Project>()
                .Where(x => x.Id == input.Id)
                .FirstOrDefaultAsync();

            dbProject.Description = input.Description;
            dbProject.Deadline = input.Deadline;
            dbProject.CityId = input.CityId;
            dbProject.Measurement = input.Measurement;
            dbProject.UnitOfMeasurementId = input.UnitOfMeasurementId;
            dbProject.Name = input.Name;

            await this.Data.SaveChangesAsync();

            return Result<ProjectOutputModel>.SuccessWith(this.mapper.Map<ProjectOutputModel>(dbProject));
        }
    }
}
