﻿using AutoMapper;
using Chama.OnlineCourses.Api.Models.V1.Models;
using Chama.OnlineCourses.Domain.AggregateModels.Course;
using Chama.OnlineCourses.Infrastructure.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Chama.OnlineCourses.Api.V1.Commands
{
    public class RegisterStudentCommandHandler : IRequestHandler<RegisterStudentCommand, CourseDto>
    {
        private readonly ICourseRepository _repository;
        private readonly IMapper _mapper;

        public RegisterStudentCommandHandler(ICourseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CourseDto> Handle(RegisterStudentCommand request, CancellationToken cancellationToken)
        {
            var course = await _repository.FindById(request.CourseId);

            if (course == null)
            {
                throw new NullReferenceException(nameof(course));
            }

            var student = _mapper.Map<Student>(request.Student);

            course.AddStudent(student);

            return _mapper.Map<CourseDto>(course);
        }
    }
}
