using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VertexCore.Infrastructure.Interfaces.Services;

namespace VertexCore.Application.Queries.Section
{
    public class GetSectionByIdQuery : IRequest<VertexCore.Domain.Entities.Section?>
    {
        public Guid Id { get; set; }
    }

    public class GetSectionByIdQueryHandler : IRequestHandler<GetSectionByIdQuery, VertexCore.Domain.Entities.Section?>
    {
        private readonly ISectionService _sectionService;

        public GetSectionByIdQueryHandler(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }

        public async Task<VertexCore.Domain.Entities.Section?> Handle(GetSectionByIdQuery request, CancellationToken cancellationToken)
        {
            return await _sectionService.GetByIdAsync(request.Id, cancellationToken);
        }
    }
}
