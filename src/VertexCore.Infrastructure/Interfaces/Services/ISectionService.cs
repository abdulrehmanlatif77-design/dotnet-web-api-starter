using VertexCore.Domain.Entities;

namespace VertexCore.Infrastructure.Interfaces.Services
{
    public interface ISectionService
    {
        Task<IEnumerable<Section>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Section?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Section> CreateAsync(Section section, CancellationToken cancellationToken = default);
        Task UpdateAsync(Section section, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
