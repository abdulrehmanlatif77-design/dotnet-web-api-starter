using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VertexCore.Infrastructure.Interfaces.Services;

namespace VertexCore.Application.Queries.Section
{
    public class GetAllSectionsQuery : IRequest<IEnumerable<VertexCore.Domain.Entities.Section>>
    {
    }

    public class GetAllSectionsQueryHandler : IRequestHandler<GetAllSectionsQuery, IEnumerable<VertexCore.Domain.Entities.Section>>
    {
        private readonly ISectionService _sectionService;

        public GetAllSectionsQueryHandler(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }

        public async Task<IEnumerable<VertexCore.Domain.Entities.Section>> Handle(GetAllSectionsQuery request, CancellationToken cancellationToken)
        {
            return await _sectionService.GetAllAsync(cancellationToken);
        }
    }
}
