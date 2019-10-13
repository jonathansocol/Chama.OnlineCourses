using Chama.OnlineCourses.Domain.AggregateModels.Shared;
using Chama.OnlineCourses.Infrastructure.Contexts;
using System.Threading.Tasks;

namespace Chama.OnlineCourses.Infrastructure.Repositories
{
    public interface ICosmosRepository<TContext,TEntity, TId>
        where TContext : ICosmosDbContext
        where TEntity : Entity<TId>
    {
        Task<TEntity> FindById(TId id);
        Task Upsert(TEntity course);
    }
}
