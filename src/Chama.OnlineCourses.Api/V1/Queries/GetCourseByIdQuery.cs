using Chama.OnlineCourses.Api.Models.V1.Models;
using MediatR;

namespace Chama.OnlineCourses.Api.V1.Queries
{
    public class GetCourseByIdQuery : Models.V1.Queries.GetCourseByIdQuery, IRequest<CourseStudentsDetailsDto> { }
}
