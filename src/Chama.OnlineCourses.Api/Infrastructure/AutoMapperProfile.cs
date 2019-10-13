using AutoMapper;
using Chama.OnlineCourses.Api.Models.V1.Models;
using Chama.OnlineCourses.Api.V1.Commands;
using Chama.OnlineCourses.Domain.AggregateModels.Course;
using Chama.OnlineCourses.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chama.OnlineCourses.Api.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<RegisterStudentAsyncCommand, RegisterStudentIntegrationCommand>()
                .ForMember(src => src.FirstName, opt => opt.MapFrom(des => des.Student.FirstName))
                .ForMember(src => src.LastName, opt => opt.MapFrom(des => des.Student.LastName))
                .ForMember(src => src.Age, opt => opt.MapFrom(des => des.Student.Age));
        }
    }
}
