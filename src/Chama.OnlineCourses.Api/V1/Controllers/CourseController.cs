using System.Threading.Tasks;
using Chama.OnlineCourses.Api.Models.V1.Routes;
using Chama.OnlineCourses.Api.V1.Commands;
using Chama.OnlineCourses.Api.V1.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Chama.OnlineCourses.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Registers a student for a given course.
        /// </summary>
        /// <param name="command"><see cref="RegisterStudentCommand"/></param>
        /// <returns>The course the student was registered to.</returns>
        [HttpPost]
        [Route(CourseRoute.RegisterStudent)]
        public async Task<IActionResult> RegisterStudent([FromBody] RegisterStudentCommand command)
        {
            var result = await _mediator.Send(command);

            return Created(string.Empty, result);
        }

        [HttpGet]
        [Route(CourseRoute.GetCourses)]
        public async Task<IActionResult> GetCourses([FromQuery] GetCoursesQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route(CourseRoute.GetCourseDetails)]
        public async Task<IActionResult> GetCourseDetails([FromQuery] GetCourseByIdQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}