using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VertexCore.Application.Commands.Instructor;
using VertexCore.WebAPI.Extensions;

namespace VertexCore.WebAPI.Controllers.Instructor
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class InstructorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public InstructorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> CreateInstructor([FromBody] CreateInstructorCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToActionResult();
        }

        [HttpPut("update")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> UpdateInstructor([FromBody] UpdateInstructorCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToActionResult();
        }

        [HttpDelete("delete")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> DeleteInstructor([FromBody] DeleteInstructorCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToActionResult();
        }

        [HttpGet("getinstructors")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetAllInstructors()
        {
            var command = new Application.Queries.Instructor.GetAllInstructorsQuery();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("getinstructorbyid/{id}")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetInstructorById([FromRoute] Guid id)
        {
            var command = new Application.Queries.Instructor.GetInstructorByIdQuery { Id = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
