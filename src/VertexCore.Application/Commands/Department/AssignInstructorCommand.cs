using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VertexCore.Application.Common.Models;
using VertexCore.Infrastructure.Interfaces.Services;

namespace VertexCore.Application.Commands.Department
{
    public class AssignInstructorCommand : IRequest<Result>
    {
        public Guid DepartmentId { get; set; }
        public Guid InstructorId { get; set; }
    }

    public class AssignInstructorCommandHandler : IRequestHandler<AssignInstructorCommand, Result>
    {
        private readonly IDepartmentService _departmentService;

        public AssignInstructorCommandHandler(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<Result> Handle(AssignInstructorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _departmentService.AssignInstructorAsync(request.DepartmentId, request.InstructorId, cancellationToken);
                return Result.Success("Instructor assigned to department successfully.");
            }
            catch (KeyNotFoundException knfEx)
            {
                return Result.Failure("NotFound", knfEx.Message);
            }
            catch (Exception ex)
            {
                return Result.Failure(ex, "Failed to assign instructor to department.");
            }
        }
    }
}
