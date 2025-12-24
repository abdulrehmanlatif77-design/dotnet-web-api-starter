using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VertexCore.Infrastructure.Interfaces.Services;

namespace VertexCore.Application.Queries.Course
{
    public class GetAllCoursesQuery : IRequest<IEnumerable<VertexCore.Domain.Entities.Course>>
    {
    }

    public class GetAllCoursesQueryHandler : IRequestHandler<GetAllCoursesQuery, IEnumerable<VertexCore.Domain.Entities.Course>>
    {
        private readonly ICourseService _courseService;

        public GetAllCoursesQueryHandler(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<IEnumerable<VertexCore.Domain.Entities.Course>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            return await _courseService.GetAllAsync(cancellationToken);
        }
    }
}
