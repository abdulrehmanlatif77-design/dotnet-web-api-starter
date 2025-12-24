using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VertexCore.Application.Common.Models;
using VertexCore.Infrastructure.Interfaces.Services;

namespace VertexCore.Application.Commands.Course
{
    public class CreateCourseCommand : IRequest<Result>
    {
        public required string Title { get; set; }
        public int Credits { get; set; }
    }

    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, Result>
    {
        private readonly ICourseService _courseService;

        public CreateCourseCommandHandler(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<Result> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var course = new VertexCore.Domain.Entities.Course
                {
                    Id = Guid.NewGuid(),
                    Title = request.Title,
                    Credits = request.Credits
                };

                var result = await _courseService.CreateAsync(course, cancellationToken);
                if (result == null)
                    return Result.Failure("CourseCreationFailed", "Failed to create course.");

                return Result.Success("Course created successfully.");
            }
            catch (Exception ex)
            {
                return Result.Failure(ex, "Failed to create course.");
            }
        }
    }
}
