using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VertexCore.Infrastructure.Interfaces.Services;

namespace VertexCore.Application.Queries.Course
{
    public class GetCourseByIdQuery : IRequest<VertexCore.Domain.Entities.Course?>
    {
        public Guid Id { get; set; }
    }

    public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, VertexCore.Domain.Entities.Course?>
    {
        private readonly ICourseService _courseService;

        public GetCourseByIdQueryHandler(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<VertexCore.Domain.Entities.Course?> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            return await _courseService.GetByIdAsync(request.Id, cancellationToken);
        }
    }
}
