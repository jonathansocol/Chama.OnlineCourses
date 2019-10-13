using AutoMapper;
using Chama.OnlineCourses.Api.Models.V1.Models;
using Chama.OnlineCourses.Api.V1.Exceptions;
using Chama.OnlineCourses.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chama.OnlineCourses.Api.V1.Queries
{
    public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, CourseStudentsDetailsDto>
    {
        private readonly IReportingRepository _reportingRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public GetCourseByIdQueryHandler(IReportingRepository reportingRepository, ICourseRepository courseRepository, IMapper mapper)
        {
            _reportingRepository = reportingRepository;
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<CourseStudentsDetailsDto> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.FindById(request.CourseId);
            var courseStatistics = await _reportingRepository.FindById(request.CourseId);

            if (course == null || courseStatistics == null)
            {
                throw new CourseNotFoundException(request.CourseId.ToString());
            }

            var courseStudentsDetails = new CourseStudentsDetailsDto
            {
                Id = course.Id,
                Name = course.Name,
                Teacher = course.Teacher,
                Capacity = course.Capacity,
                NumberOfStudents = course.Students.Count,
                MinimumStudentAge = courseStatistics.MinimumStudentAge,
                MaximumStudentAge = courseStatistics.MaximumStudentAge,
                AverageStudentAge = courseStatistics.AverageStudentAge,
                Students = _mapper.Map<List<StudentDto>>(course.Students)
            };

            return courseStudentsDetails;
        }
    }
}
