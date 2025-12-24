using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VertexCore.Infrastructure.Interfaces.Services;

namespace VertexCore.Application.Queries.Student
{
    public class GetAllStudentsQuery : IRequest<IEnumerable<VertexCore.Domain.Entities.Student>>
    {
    }

    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, IEnumerable<VertexCore.Domain.Entities.Student>>
    {
        private readonly IStudentService _studentService;

        public GetAllStudentsQueryHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<IEnumerable<VertexCore.Domain.Entities.Student>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            return await _studentService.GetAllAsync(cancellationToken);
        }
    }
}
