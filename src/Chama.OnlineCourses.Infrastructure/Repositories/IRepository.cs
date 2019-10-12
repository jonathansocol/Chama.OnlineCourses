using Chama.OnlineCourses.Domain.AggregateModels.Course;
using Chama.OnlineCourses.Domain.AggregateModels.Shared;
using System;
using System.Threading.Tasks;

namespace Chama.OnlineCourses.Infrastructure.Repositories
{
    public interface IRepository<TContext,TEntity, TId>
        where TContext : ICosmosDbContext
        where TEntity : Entity<TId>
    {
        Task<TEntity> FindById(TId id);
        Task Upsert(TEntity course);
    }
}
