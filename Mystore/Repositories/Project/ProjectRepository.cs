using AutoMapper;
using Common.Services;
using Mystore.Api.Data;
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
    }
}
