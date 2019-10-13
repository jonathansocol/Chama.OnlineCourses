using Chama.OnlineCourses.Domain.AggregateModels.Analytics;
using Microsoft.EntityFrameworkCore;

namespace Chama.OnlineCourses.Infrastructure.Contexts
{
    public class ReportingContext : DbContext
    {
        public ReportingContext(DbContextOptions<ReportingContext> options)
           : base(options)
        { }

        public DbSet<CourseStudentsStatistic> CourseStudentsStatistics { get; set; }
    }
}
