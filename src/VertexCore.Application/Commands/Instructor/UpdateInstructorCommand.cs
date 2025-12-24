using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VertexCore.Application.Common.Models;
using VertexCore.Infrastructure.Interfaces.Services;

namespace VertexCore.Application.Commands.Instructor
{
    public class UpdateInstructorCommand : IRequest<Result>
    {
        public Guid Id { get; set; }
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

    public class UpdateInstructorCommandHandler : IRequestHandler<UpdateInstructorCommand, Result>
    {
        private readonly IInstructorService _instructorService;

        public UpdateInstructorCommandHandler(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        public async Task<Result> Handle(UpdateInstructorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var instructor = new VertexCore.Domain.Entities.Instructor
                {
                    Id = request.Id,
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

                await _instructorService.UpdateAsync(instructor, cancellationToken);
                return Result.Success("Instructor updated successfully.");
            }
            catch (KeyNotFoundException knfEx)
            {
                return Result.Failure("InstructorNotFound", knfEx.Message);
            }
            catch (Exception ex)
            {
                return Result.Failure(ex, "Failed to update instructor.");
            }
        }
    }
}
