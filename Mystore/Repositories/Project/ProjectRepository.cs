using AutoMapper;
using Common.Services;
using Microsoft.EntityFrameworkCore;
using Mystore.Api.Data;
using Mystore.Api.Data.Models.Identity;
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
            .ProjectTo<ProjectOutputModel>(this.All().Where(x => !x.IsDeleted))
            .ToListAsync();

        public async Task<ProjectOutputModel> GetProject(long id)
        {
            var result = await this
                .All()
                .Where(x => x.Id == id)
                .Where(x => !x.IsDeleted)
                .Include(x => x.City)
                .Include(x => x.UnitOfMeasurement)
                .FirstOrDefaultAsync();

            var userId = await this.Data.Set<UserDetails>()
                .Where(x => x.Id == result.AuthorId)
                .Select(x => x.UserId)
                .FirstOrDefaultAsync();

            var output = mapper.Map<ProjectOutputModel>(result);
            output.CreatedBy = userId;

            return output;
        }

        public async Task<IList<ProjectOutputModel>> GetUserProjects(string userId)
        => await this
            .mapper
            .ProjectTo<ProjectOutputModel>(this.All().Where(x => x.Author.UserId == userId).Where(x => !x.IsDeleted))
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

        public async Task<Result<long>> Delete(long id)
        {
            var dbProject = await this.Data
                .Set<Mystore.Api.Data.Models.Project.Project>()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            dbProject.IsDeleted = true;

            await this.Data.SaveChangesAsync();

            return Result<long>.SuccessWith(dbProject.Id);
        }
    }
}
