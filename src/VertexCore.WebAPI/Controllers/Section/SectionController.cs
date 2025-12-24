using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VertexCore.Application.Commands.Section;
using VertexCore.WebAPI.Extensions;

namespace VertexCore.WebAPI.Controllers.Section
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class SectionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SectionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> CreateSection([FromBody] CreateSectionCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToActionResult();
        }

        [HttpPut("update")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> UpdateSection([FromBody] UpdateSectionCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToActionResult();
        }

        [HttpDelete("delete")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> DeleteSection([FromBody] DeleteSectionCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToActionResult();
        }

        [HttpGet("getsections")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetAllSections()
        {
            var command = new Application.Queries.Section.GetAllSectionsQuery();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("getsectionbyid/{id}")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetSectionById([FromRoute] Guid id)
        {
            var command = new Application.Queries.Section.GetSectionByIdQuery { Id = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
