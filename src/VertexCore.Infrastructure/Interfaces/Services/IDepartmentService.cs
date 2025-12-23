using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VertexCore.Domain.Entities;

namespace VertexCore.Infrastructure.Interfaces.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Department?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Department> CreateAsync(Department department, CancellationToken cancellationToken = default);
        Task UpdateAsync(Department department, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
