using Chama.OnlineCourses.Domain.AggregateModels.Analytics;
using Chama.OnlineCourses.Infrastructure.Contexts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Chama.OnlineCourses.Infrastructure.Repositories
{
    public class ReportingRepository : IReportingRepository
    {
        private readonly ReportingContext _context;

        public ReportingRepository(ReportingContext context)
        {
            _context = context;
        }

        public async Task<CourseStudentsStatistic> FindById(Guid id)
        {
            return _context.CourseStudentsStatistics.FirstOrDefault(x => x.CourseId == id);
        }

        public async Task Upsert(CourseStudentsStatistic courseStudentsStatistic)
        {
            var statistics = _context.CourseStudentsStatistics.FirstOrDefault(x => x.CourseId == courseStudentsStatistic.CourseId);

            if (statistics != null)
            {
                statistics.MinimumStudentAge = courseStudentsStatistic.MinimumStudentAge;
                statistics.MaximumStudentAge = courseStudentsStatistic.MaximumStudentAge;
                statistics.AverageStudentAge = courseStudentsStatistic.AverageStudentAge;

                _context.Update(statistics);
            }
            else
            {
                _context.Add(courseStudentsStatistic);
            }

            await _context.SaveChangesAsync();
        }
    }
}
