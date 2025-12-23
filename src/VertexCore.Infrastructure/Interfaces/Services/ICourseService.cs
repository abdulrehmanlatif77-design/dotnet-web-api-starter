using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VertexCore.Domain.Entities;

namespace VertexCore.Infrastructure.Interfaces.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Course?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Course> CreateAsync(Course course, CancellationToken cancellationToken = default);
        Task UpdateAsync(Course course, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
