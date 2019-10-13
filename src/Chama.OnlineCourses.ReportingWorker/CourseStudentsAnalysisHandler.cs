using System.Collections.Generic;
using Chama.OnlineCourses.Domain.AggregateModels.Analytics;
using Chama.OnlineCourses.Domain.AggregateModels.Course;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using System;
using Chama.OnlineCourses.Infrastructure.Contexts;
using Chama.OnlineCourses.Infrastructure.Repositories;

namespace Chama.OnlineCourses.ReportingWorker
{
    public class CourseStudentsAnalysisHandler
    {
        private readonly ReportingRepository _repository;

        public CourseStudentsAnalysisHandler(ReportingContext context)
        {
            _repository = new ReportingRepository(context);
        }

        [FunctionName("CourseStudentsAnalysisHandler")]
        public async Task Run([CosmosDBTrigger(
            databaseName: "onlinecourses",
            collectionName: "courses",
            ConnectionStringSetting = "CosmosDb:ConnectionString",
            LeaseCollectionName = "leases",
            CreateLeaseCollectionIfNotExists = true,
            StartFromBeginning = true)]IReadOnlyList<Document> input, ILogger log)
        {
            foreach (var document in input)
            {
                var course = JsonConvert.DeserializeObject<Course>(document.ToString());

                if (course.Students.Any())
                {
                    var statistics = GetCourseStatistics(course);

                    await _repository.Upsert(statistics);
                }
            }
        }

        private static CourseStudentsStatistic GetCourseStatistics(Course course)
        {
            var statistics = new CourseStudentsStatistic
            {
                CourseId = course.Id,
                MinimumStudentAge = course.Students.Min(x => x.Age),
                MaximumStudentAge = course.Students.Max(x => x.Age),
                AverageStudentAge = Convert.ToInt32(course.Students.Average(x => x.Age))
            };

            return statistics;
        }
    }
}
