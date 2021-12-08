using Common.Services;
using Mystore.Api.Data.Models.Nomenclature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystore.Api.Repositories.Project
{
    public interface IImageRepository : IDataService<ImageMapping>
    {
        Task<IList<ImageOutputModel>> GetAllForProject(long projectId);
        Task<ImageOutputModel> GetById(long id);
        Task<Result<ImageOutputModel>> CreateImage(ImageInputModel input);
    }
}
