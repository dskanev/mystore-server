using AutoMapper;
using Common.Services;
using Microsoft.EntityFrameworkCore;
using Mystore.Api.Data;
using Mystore.Api.Data.Models.Nomenclature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystore.Api.Repositories.Project
{
    public class ImageRepository : DataService<ImageMapping>, IImageRepository
    {
        private readonly IMapper mapper;

        public ImageRepository(IdentityDbContext db, IMapper mapper)
        : base(db)
            => this.mapper = mapper;

        public async Task<Result<ImageOutputModel>> CreateImage(ImageInputModel input)
        {
            var dbModel = mapper.Map<ImageMapping>(input);
            await this.Data.AddAsync(dbModel);
            await this.Data.SaveChangesAsync();
            return Result<ImageOutputModel>.SuccessWith(mapper.Map<ImageOutputModel>(dbModel));
        }

        public async Task<IList<ImageOutputModel>> GetAllForProject(long projectId)
        => await this
            .mapper
            .ProjectTo<ImageOutputModel>(this.All()
            .Where(x => x.ProjectId == projectId))
            .ToListAsync();

        public async Task<ImageOutputModel> GetById(long id)
        => await this.mapper
            .ProjectTo<ImageOutputModel>(this.All()
            .Where(x => x.Id == id))
            .FirstOrDefaultAsync();
    }
}
