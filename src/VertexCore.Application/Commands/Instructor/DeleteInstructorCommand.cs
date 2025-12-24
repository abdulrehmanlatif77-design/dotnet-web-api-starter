using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VertexCore.Application.Common.Models;
using VertexCore.Infrastructure.Interfaces.Services;

namespace VertexCore.Application.Commands.Instructor
{
    public class DeleteInstructorCommand : IRequest<Result>
    {
        public Guid Id { get; set; }
    }

    public class DeleteInstructorCommandHandler : IRequestHandler<DeleteInstructorCommand, Result>
    {
        private readonly IInstructorService _instructorService;

        public DeleteInstructorCommandHandler(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        public async Task<Result> Handle(DeleteInstructorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _instructorService.DeleteAsync(request.Id, cancellationToken);
                return Result.Success("Instructor deleted successfully.");
            }
            catch (Exception ex)
            {
                return Result.Failure(ex, "Failed to delete instructor.");
            }
        }
    }
}
