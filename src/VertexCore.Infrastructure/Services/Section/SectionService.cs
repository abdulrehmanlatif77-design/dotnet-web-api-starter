using Microsoft.EntityFrameworkCore;
using VertexCore.Domain.Entities;
using VertexCore.Infrastructure.Identity;
using VertexCore.Infrastructure.Interfaces.Services;

namespace VertexCore.Infrastructure.Services
{
    public class SectionService : ISectionService
    {
        private readonly ApplicationDbContext _context;

        public SectionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Section>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Sections
                .Include(s => s.Course)
                .Include(s => s.Instructor)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<Section?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Sections
                .Include(s => s.Course)
                .Include(s => s.Instructor)
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        }

        public async Task<Section> CreateAsync(Section section, CancellationToken cancellationToken = default)
        {
            if (section.Id == Guid.Empty)
                section.Id = Guid.NewGuid();

            _context.Sections.Add(section);
            await _context.SaveChangesAsync(cancellationToken);
            return section;
        }

        public async Task UpdateAsync(Section section, CancellationToken cancellationToken = default)
        {
            var exists = await _context.Sections.AnyAsync(s => s.Id == section.Id, cancellationToken);
            if (!exists)
                throw new KeyNotFoundException($"Section with id {section.Id} not found.");

            _context.Sections.Update(section);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var section = await _context.Sections.FindAsync(new object[] { id }, cancellationToken);
            if (section == null)
                return;

            _context.Sections.Remove(section);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Sections.AnyAsync(s => s.Id == id, cancellationToken);
        }
    }
}
