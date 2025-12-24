using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VertexCore.Application.Commands.Department;
using VertexCore.WebAPI.Extensions;

namespace VertexCore.WebAPI.Controllers.Department
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToActionResult();
        }

        [HttpPut("update")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> UpdateDepartment([FromBody] UpdateDepartmentCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToActionResult();
        }

        [HttpDelete("delete")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> DeleteDepartment([FromBody] DeleteDepartmentCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToActionResult();
        }

        [HttpGet("getdepartments")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetAllDepartments()
        {
            var command = new Application.Queries.Department.GetAllDepartmentsQuery();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("getdepartmentbyid/{id}")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetDepartmentById([FromRoute] Guid id)
        {
            var command = new Application.Queries.Department.GetDepartmentByIdQuery { Id = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("assign-instructor")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> AssignInstructor([FromBody] AssignInstructorCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToActionResult();
        }
    }
}
