using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VertexCore.Infrastructure.Interfaces.Services;

namespace VertexCore.Application.Queries.Department
{
    public class GetAllDepartmentsQuery : IRequest<IEnumerable<VertexCore.Domain.Entities.Department>>
    {
    }

    public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQuery, IEnumerable<VertexCore.Domain.Entities.Department>>
    {
        private readonly IDepartmentService _departmentService;

        public GetAllDepartmentsQueryHandler(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<IEnumerable<VertexCore.Domain.Entities.Department>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            return await _departmentService.GetAllAsync(cancellationToken);
        }
    }
}
