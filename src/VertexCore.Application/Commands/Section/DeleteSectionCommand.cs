using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VertexCore.Application.Common.Models;
using VertexCore.Infrastructure.Interfaces.Services;

namespace VertexCore.Application.Commands.Section
{
    public class DeleteSectionCommand : IRequest<Result>
    {
        public Guid Id { get; set; }
    }

    public class DeleteSectionCommandHandler : IRequestHandler<DeleteSectionCommand, Result>
    {
        private readonly ISectionService _sectionService;

        public DeleteSectionCommandHandler(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }

        public async Task<Result> Handle(DeleteSectionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _sectionService.DeleteAsync(request.Id, cancellationToken);
                return Result.Success("Section deleted successfully.");
            }
            catch (Exception ex)
            {
                return Result.Failure(ex, "Failed to delete section.");
            }
        }
    }
}
