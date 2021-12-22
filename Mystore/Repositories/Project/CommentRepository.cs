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
    public class CommentRepository : DataService<Comment>, ICommentRepository
    {
        private readonly IMapper mapper;

        public CommentRepository(IdentityDbContext db, IMapper mapper)
        : base(db)
            => this.mapper = mapper;

        public async Task<IList<CommentOutputModel>> GetCommentsForProject(long projectId)
        {
            return await this
                .mapper
                .ProjectTo<CommentOutputModel>(this.All()
                .Where(x => x.ProjectId == projectId)
                .Include(x => x.UserDetails))
                .ToListAsync();
        }

        public async Task<Result<CommentOutputModel>> PostComment(CommentInputModel input)
        {
            var dbModel = this.mapper.Map<Comment>(input);
            await this.Data.AddAsync(dbModel);
            await this.Data.SaveChangesAsync();

            return Result<CommentOutputModel>.SuccessWith(this.mapper.Map<CommentOutputModel>(dbModel));            
        }
    }
}
