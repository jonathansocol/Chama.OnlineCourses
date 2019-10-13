using System;

namespace Chama.OnlineCourses.Domain.AggregateModels.Analytics
{
    public class CourseStudentsStatistic
    {
        public Guid Id { get; set; }

        public Guid CourseId { get; set; }

        public int? MinimumStudentAge { get; set; }

        public int? MaximumStudentAge { get; set; }

        public int? AverageStudentAge { get; set; }
    }
}
