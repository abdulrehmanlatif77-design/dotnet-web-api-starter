using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VertexCore.Infrastructure.Interfaces.Services;

namespace VertexCore.Application.Queries.Instructor
{
    public class GetAllInstructorsQuery : IRequest<IEnumerable<VertexCore.Domain.Entities.Instructor>>
    {
    }

    public class GetAllInstructorsQueryHandler : IRequestHandler<GetAllInstructorsQuery, IEnumerable<VertexCore.Domain.Entities.Instructor>>
    {
        private readonly IInstructorService _instructorService;

        public GetAllInstructorsQueryHandler(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        public async Task<IEnumerable<VertexCore.Domain.Entities.Instructor>> Handle(GetAllInstructorsQuery request, CancellationToken cancellationToken)
        {
            return await _instructorService.GetAllAsync(cancellationToken);
        }
    }
}
