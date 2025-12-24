using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VertexCore.Application.Commands.Student;
using VertexCore.WebAPI.Extensions;

namespace VertexCore.WebAPI.Controllers.Student
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToActionResult();
        }

        [HttpPut("update")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToActionResult();
        }

        [HttpDelete("delete")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> DeleteStudent([FromBody] DeleteStudentCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToActionResult();
        }

        [HttpGet("getstudents")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetAllStudents()
        {
            var command = new Application.Queries.Student.GetAllStudentsQuery();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("getstudentbyid/{id}")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetStudentById([FromRoute] Guid id)
        {
            var command = new Application.Queries.Student.GetStudentByIdQuery { Id = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
