using Chama.OnlineCourses.Domain.AggregateModels.Course;
using System;

namespace Chama.OnlineCourses.Infrastructure.Repositories
{
    public interface ICourseRepository : IRepository<ICosmosDbContext, Course, Guid> { }
}
