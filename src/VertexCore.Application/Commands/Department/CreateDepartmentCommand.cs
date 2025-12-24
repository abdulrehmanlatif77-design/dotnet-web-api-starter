using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VertexCore.Application.Common.Models;
using VertexCore.Infrastructure.Interfaces.Services;

namespace VertexCore.Application.Commands.Department
{
    public class CreateDepartmentCommand : IRequest<Result>
    {
        public required string Name { get; set; }
        public string? Location { get; set; }
        public string? PhoneNumber { get; set; }
        public decimal Budget { get; set; }
    }

    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, Result>
    {
        private readonly IDepartmentService _departmentService;

        public CreateDepartmentCommandHandler(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<Result> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var department = new VertexCore.Domain.Entities.Department
                {
                    Id = Guid.NewGuid(),
                    Name = request.Name,
                    Location = request.Location,
                    PhoneNumber = request.PhoneNumber,
                    Budget = request.Budget
                };

                var result = await _departmentService.CreateAsync(department, cancellationToken);
                if (result == null)
                    return Result.Failure("DepartmentCreationFailed", "Failed to create department.");

                return Result.Success("Department created successfully.");
            }
            catch (Exception ex)
            {
                return Result.Failure(ex, "Failed to create department.");
            }
        }
    }
}
