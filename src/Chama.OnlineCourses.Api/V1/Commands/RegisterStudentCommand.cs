using Chama.OnlineCourses.Api.Models.V1.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chama.OnlineCourses.Api.V1.Commands
{
    public class RegisterStudentCommand : Models.V1.Commands.RegisterStudentCommand, IRequest<CourseDto> { }
}
