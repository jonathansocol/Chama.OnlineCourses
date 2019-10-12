using System;
using System.Threading.Tasks;
using Chama.OnlineCourses.Domain.AggregateModels.Course;

namespace Chama.OnlineCourses.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ICosmosDbContext _context;

        public CourseRepository(ICosmosDbContext context)
        {
            _context = context;
        }

        public async Task<Course> FindById(Guid id)
        {
            var client = _context.GetClient();
            var uri = _context.GetDocumentUri("course");

            var course = await client.ReadDocumentAsync<Course>(uri);

            return course;
        }

        public async Task Upsert(Course course)
        {
            var client = _context.GetClient();
            var uri = _context.GetDocumentUri("course");

            await client.UpsertDocumentAsync(uri, course);
        }
    }
}
