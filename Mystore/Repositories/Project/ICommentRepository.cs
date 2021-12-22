using Common.Services;
using Mystore.Api.Data.Models.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystore.Api.Repositories.Project
{
    public interface ICommentRepository : IDataService<Comment>
    {
        Task<Result<CommentOutputModel>> PostComment(CommentInputModel input);
        Task<IList<CommentOutputModel>> GetCommentsForProject(long projectId);
    }
}
