using Chama.OnlineCourses.Domain.AggregateModels.Shared;
using Chama.OnlineCourses.Infrastructure.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chama.OnlineCourses.Infrastructure.Repositories
{
    public interface ICosmosRepository<TContext,TEntity, TId>
        where TContext : ICosmosDbContext
        where TEntity : Entity<TId>
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> FindById(TId id);
        Task Upsert(TEntity course);
    }
}
