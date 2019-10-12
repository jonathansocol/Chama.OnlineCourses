using Chama.OnlineCourses.Domain.AggregateModels.Course;
using System;
using System.Threading.Tasks;

namespace Chama.OnlineCourses.Infrastructure.Repositories
{
    public interface ICourseRepository
    {
        Task<Course> FindById(Guid id);
        Task Upsert(Course course);
    }
}
