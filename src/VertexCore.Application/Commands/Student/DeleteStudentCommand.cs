using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VertexCore.Application.Common.Models;
using VertexCore.Infrastructure.Interfaces.Services;

namespace VertexCore.Application.Commands.Student
{
    public class DeleteStudentCommand : IRequest<Result>
    {
        public Guid Id { get; set; }
    }

    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, Result>
    {
        private readonly IStudentService _studentService;

        public DeleteStudentCommandHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<Result> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _studentService.DeleteAsync(request.Id, cancellationToken);
                return Result.Success("Student deleted successfully.");
            }
            catch (Exception ex)
            {
                return Result.Failure(ex, "Failed to delete student.");
            }
        }
    }
}
