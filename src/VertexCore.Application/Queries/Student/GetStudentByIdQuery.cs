using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VertexCore.Infrastructure.Interfaces.Services;

namespace VertexCore.Application.Queries.Student
{
    public class GetStudentByIdQuery : IRequest<VertexCore.Domain.Entities.Student?>
    {
        public Guid Id { get; set; }
    }

    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, VertexCore.Domain.Entities.Student?>
    {
        private readonly IStudentService _studentService;

        public GetStudentByIdQueryHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<VertexCore.Domain.Entities.Student?> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _studentService.GetByIdAsync(request.Id, cancellationToken);
        }
    }
}
