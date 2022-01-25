using Common.Services;
using Mystore.Api.Data.Models;
using Mystore.Api.Data.Models.Project;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mystore.Api.Repositories.Project
{
    public interface IProjectRepository : IDataService<Mystore.Api.Data.Models.Project.Project>
    {
        Task<IList<ProjectOutputModel>> GetAll();
        Task<IList<ProjectOutputModel>> GetUserProjects(string userId);
        Task<ProjectOutputModel> GetProject(long id);
        Task<Result<ProjectOutputModel>> Create(ProjectInputModel input);
        Task<Result<ProjectOutputModel>> Edit(ProjectInputModel input);
        Task<Result<long>> Delete(long id);
        Task<Result> AssignApplicantToProject(long projectId, string userId);
        Task<Result<IList<User>>> GetProjectApplicants(long projectId);
    }
}
