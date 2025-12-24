using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VertexCore.Application.Commands.Course;
using VertexCore.WebAPI.Extensions;

namespace VertexCore.WebAPI.Controllers.Course
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToActionResult();
        }

        [HttpPut("update")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> UpdateCourse([FromBody] UpdateCourseCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToActionResult();
        }

        [HttpDelete("delete")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> DeleteCourse([FromBody] DeleteCourseCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToActionResult();
        }

        [HttpGet("getcourses")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetAllCourses()
        {
            var command = new Application.Queries.Course.GetAllCoursesQuery();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("getcoursebyid/{id}")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetCourseById([FromRoute] Guid id)
        {
            var command = new Application.Queries.Course.GetCourseByIdQuery { Id = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
