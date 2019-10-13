using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Chama.OnlineCourses.Domain.AggregateModels.Analytics;

namespace Chama.OnlineCourses.Infrastructure.Repositories
{
    public interface IReportingRepository
    {
        Task<List<CourseStudentsStatistic>> GetAll();
        Task<CourseStudentsStatistic> FindById(Guid id);
        Task Upsert(CourseStudentsStatistic courseStudentsStatistic);
    }
}