using Chama.OnlineCourses.Api.Models.V1.Models;
using MediatR;

namespace Chama.OnlineCourses.Api.V1.Commands
{
    public class RegisterStudentCommand : Models.V1.Commands.RegisterStudentCommand, IRequest<CourseDto> { }
}
