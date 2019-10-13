using Chama.OnlineCourses.Api.Models.V1.Models;
using MediatR;
using System.Collections.Generic;

namespace Chama.OnlineCourses.Api.V1.Queries
{
    public class GetCoursesQuery : Models.V1.Queries.GetCoursesQuery, IRequest<List<CourseDetailsDto>> { }
}
