using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    using Common.Data.Models;
    using System.Threading.Tasks;

    public interface IDataService<in TEntity>
        where TEntity : class
    {
        Task MarkMessageAsPublished(long id);
        Task Save(TEntity entity, params Message[] messages);
        Task Insert(TEntity entity);
    }
}
