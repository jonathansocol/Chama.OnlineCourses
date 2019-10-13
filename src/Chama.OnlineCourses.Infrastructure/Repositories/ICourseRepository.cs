using Chama.OnlineCourses.Domain.AggregateModels.Course;
using Chama.OnlineCourses.Infrastructure.Contexts;
using System;

namespace Chama.OnlineCourses.Infrastructure.Repositories
{
    public interface ICourseRepository : ICosmosRepository<ICosmosDbContext, Course, Guid> { }
}
