using Chama.OnlineCourses.Api.Models.V1.Models;
using Chama.OnlineCourses.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chama.OnlineCourses.Api.V1.Queries
{
    public class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, List<CourseDetailsDto>>
    {
        private readonly IReportingRepository _reportingRepository;
        private readonly ICourseRepository _courseRepository;

        public GetCoursesQueryHandler(IReportingRepository reportingRepository, ICourseRepository courseRepository)
        {
            _reportingRepository = reportingRepository;
            _courseRepository = courseRepository;
        }

        public async Task<List<CourseDetailsDto>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = await _courseRepository.GetAll();
            var coursesStatistics = await _reportingRepository.GetAll();

            var courseDetailsList = from c in courses
                               join s in coursesStatistics on c.Id equals s.CourseId
                               select new CourseDetailsDto
                               {
                                   Id = c.Id,
                                   Name = c.Name,
                                   Capacity = c.Capacity,
                                   NumberOfStudents = c.Students.Count,
                                   MinimumStudentAge = s.MinimumStudentAge,
                                   MaximumStudentAge = s.MaximumStudentAge,
                                   AverageStudentAge = s.AverageStudentAge
                               };

            return courseDetailsList.ToList();
        }
    }
}
