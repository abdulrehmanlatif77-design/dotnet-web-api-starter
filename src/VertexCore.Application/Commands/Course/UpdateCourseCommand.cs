using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VertexCore.Application.Common.Models;
using VertexCore.Infrastructure.Interfaces.Services;

namespace VertexCore.Application.Commands.Course
{
    public class UpdateCourseCommand : IRequest<Result>
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public int Credits { get; set; }
    }

    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, Result>
    {
        private readonly ICourseService _courseService;

        public UpdateCourseCommandHandler(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<Result> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var course = new VertexCore.Domain.Entities.Course
                {
                    Id = request.Id,
                    Title = request.Title,
                    Credits = request.Credits
                };

                await _courseService.UpdateAsync(course, cancellationToken);
                return Result.Success("Course updated successfully.");
            }
            catch (KeyNotFoundException knfEx)
            {
                return Result.Failure("CourseNotFound", knfEx.Message);
            }
            catch (Exception ex)
            {
                return Result.Failure(ex, "Failed to update course.");
            }
        }
    }
}
