using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VertexCore.Application.Common.Models;
using VertexCore.Infrastructure.Interfaces.Services;

namespace VertexCore.Application.Commands.Department
{
    public class DeleteDepartmentCommand : IRequest<Result>
    {
        public Guid Id { get; set; }
    }

    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, Result>
    {
        private readonly IDepartmentService _departmentService;

        public DeleteDepartmentCommandHandler(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<Result> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _departmentService.DeleteAsync(request.Id, cancellationToken);
                return Result.Success("Department deleted successfully.");
            }
            catch (Exception ex)
            {
                return Result.Failure(ex, "Failed to delete department.");
            }
        }
    }
}
