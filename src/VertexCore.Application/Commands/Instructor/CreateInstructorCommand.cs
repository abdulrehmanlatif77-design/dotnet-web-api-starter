using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VertexCore.Application.Common.Models;
using VertexCore.Infrastructure.Interfaces.Services;

namespace VertexCore.Application.Commands.Instructor
{
    public class CreateInstructorCommand : IRequest<Result>
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public string? Address { get; set; }
        public string? HomePhone { get; set; }
        public string? OfficePhone { get; set; }

        public required string EmailAddress { get; set; }

        public decimal Salary { get; set; }
        public string? Position { get; set; }

        public DateTime HireDate { get; set; }
    }

    public class CreateInstructorCommandHandler : IRequestHandler<CreateInstructorCommand, Result>
    {
        private readonly IInstructorService _instructorService;

        public CreateInstructorCommandHandler(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        public async Task<Result> Handle(CreateInstructorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var instructor = new VertexCore.Domain.Entities.Instructor
                {
                    Id = Guid.NewGuid(),
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Address = request.Address,
                    HomePhone = request.HomePhone,
                    OfficePhone = request.OfficePhone,
                    EmailAddress = request.EmailAddress,
                    Salary = request.Salary,
                    Position = request.Position,
                    HireDate = request.HireDate
                };

                var result = await _instructorService.CreateAsync(instructor, cancellationToken);
                if (result == null)
                    return Result.Failure("InstructorCreationFailed", "Failed to create instructor.");

                return Result.Success("Instructor created successfully.");
            }
            catch (Exception ex)
            {
                return Result.Failure(ex, "Failed to create instructor.");
            }
        }
    }
}
