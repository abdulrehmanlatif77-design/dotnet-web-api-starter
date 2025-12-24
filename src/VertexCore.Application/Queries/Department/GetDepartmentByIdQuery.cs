using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VertexCore.Infrastructure.Interfaces.Services;

namespace VertexCore.Application.Queries.Department
{
    public class GetDepartmentByIdQuery : IRequest<VertexCore.Domain.Entities.Department?>
    {
        public Guid Id { get; set; }
    }

    public class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, VertexCore.Domain.Entities.Department?>
    {
        private readonly IDepartmentService _departmentService;

        public GetDepartmentByIdQueryHandler(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<VertexCore.Domain.Entities.Department?> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _departmentService.GetByIdAsync(request.Id, cancellationToken);
        }
    }
}
