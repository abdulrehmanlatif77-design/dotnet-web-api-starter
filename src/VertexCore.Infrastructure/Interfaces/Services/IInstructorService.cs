using VertexCore.Domain.Entities;

namespace VertexCore.Infrastructure.Interfaces.Services
{
    public interface IInstructorService
    {
        Task<IEnumerable<Instructor>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Instructor?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Instructor> CreateAsync(Instructor instructor, CancellationToken cancellationToken = default);
        Task UpdateAsync(Instructor instructor, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
