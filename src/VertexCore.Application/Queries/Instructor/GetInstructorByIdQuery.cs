using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VertexCore.Infrastructure.Interfaces.Services;

namespace VertexCore.Application.Queries.Instructor
{
    public class GetInstructorByIdQuery : IRequest<VertexCore.Domain.Entities.Instructor?>
    {
        public Guid Id { get; set; }
    }

    public class GetInstructorByIdQueryHandler : IRequestHandler<GetInstructorByIdQuery, VertexCore.Domain.Entities.Instructor?>
    {
        private readonly IInstructorService _instructorService;

        public GetInstructorByIdQueryHandler(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        public async Task<VertexCore.Domain.Entities.Instructor?> Handle(GetInstructorByIdQuery request, CancellationToken cancellationToken)
        {
            return await _instructorService.GetByIdAsync(request.Id, cancellationToken);
        }
    }
}
