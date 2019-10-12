using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chama.OnlineCourses.Api.Models.V1.Routes;
using Chama.OnlineCourses.Api.V1.Commands;
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

        [HttpPost]
        [Route(CourseRoute.RegisterStudent)]
        public async Task<IActionResult> RegisterStudent([FromBody] RegisterStudentCommand command)
        {
            var result = await _mediator.Send(command);

            return Created(string.Empty, result);
        }
    }
}
