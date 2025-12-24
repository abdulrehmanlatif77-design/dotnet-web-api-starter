using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VertexCore.Application.Common.Models;
using VertexCore.Infrastructure.Interfaces.Services;

namespace VertexCore.Application.Commands.Student
{
    public class CreateStudentCommand : IRequest<Result>
    {
        public required string FirstName { get; set; }
        public string? MiddleInitial { get; set; }
        public required string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string? Gender { get; set; }

        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public required string EmailAddress { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public VertexCore.Domain.Entities.DegreeType Degree { get; set; }

        public decimal GPA { get; set; }
    }

    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Result>
    {
        private readonly IStudentService _studentService;

        public CreateStudentCommandHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<Result> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var student = new VertexCore.Domain.Entities.Student
                {
                    Id = Guid.NewGuid(),
                    FirstName = request.FirstName,
                    MiddleInitial = request.MiddleInitial,
                    LastName = request.LastName,
                    DateOfBirth = request.DateOfBirth,
                    Gender = request.Gender,
                    Address = request.Address,
                    PhoneNumber = request.PhoneNumber,
                    EmailAddress = request.EmailAddress,
                    EnrollmentDate = request.EnrollmentDate,
                    Degree = request.Degree,
                    GPA = request.GPA
                };

                var result = await _studentService.CreateAsync(student, cancellationToken);
                if (result == null)
                    return Result.Failure("StudentCreationFailed", "Failed to create student.");

                return Result.Success("Student created successfully.");
            }
            catch (Exception ex)
            {
                return Result.Failure(ex, "Failed to create student.");
            }
        }
    }
}
