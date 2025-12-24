using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VertexCore.Application.Common.Models;
using VertexCore.Infrastructure.Interfaces.Services;

namespace VertexCore.Application.Commands.Department
{
    public class UpdateDepartmentCommand : IRequest<Result>
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Location { get; set; }
        public string? PhoneNumber { get; set; }
        public decimal Budget { get; set; }
    }

    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, Result>
    {
        private readonly IDepartmentService _departmentService;

        public UpdateDepartmentCommandHandler(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<Result> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var department = new VertexCore.Domain.Entities.Department
                {
                    Id = request.Id,
                    Name = request.Name,
                    Location = request.Location,
                    PhoneNumber = request.PhoneNumber,
                    Budget = request.Budget
                };

                await _departmentService.UpdateAsync(department, cancellationToken);
                return Result.Success("Department updated successfully.");
            }
            catch (KeyNotFoundException knfEx)
            {
                return Result.Failure("DepartmentNotFound", knfEx.Message);
            }
            catch (Exception ex)
            {
                return Result.Failure(ex, "Failed to update department.");
            }
        }
    }
}
