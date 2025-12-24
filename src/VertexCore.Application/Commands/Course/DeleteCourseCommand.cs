using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VertexCore.Application.Common.Models;
using VertexCore.Infrastructure.Interfaces.Services;

namespace VertexCore.Application.Commands.Course
{
    public class DeleteCourseCommand : IRequest<Result>
    {
        public Guid Id { get; set; }
    }

    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, Result>
    {
        private readonly ICourseService _courseService;

        public DeleteCourseCommandHandler(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<Result> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _courseService.DeleteAsync(request.Id, cancellationToken);
                return Result.Success("Course deleted successfully.");
            }
            catch (Exception ex)
            {
                return Result.Failure(ex, "Failed to delete course.");
            }
        }
    }
}
