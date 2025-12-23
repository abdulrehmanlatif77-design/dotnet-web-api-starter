using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VertexCore.Domain.Entities;

namespace VertexCore.Infrastructure.Interfaces.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Student?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Student> CreateAsync(Student student, CancellationToken cancellationToken = default);
        Task UpdateAsync(Student student, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
