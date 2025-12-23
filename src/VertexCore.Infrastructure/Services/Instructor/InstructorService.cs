using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VertexCore.Domain.Entities;
using VertexCore.Infrastructure.Identity;
using VertexCore.Infrastructure.Interfaces.Services;

namespace VertexCore.Infrastructure.Services
{
    public class InstructorService : IInstructorService
    {
        private readonly ApplicationDbContext _context;

        public InstructorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Instructor>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Instructors.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<Instructor?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Instructors.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
        }

        public async Task<Instructor> CreateAsync(Instructor instructor, CancellationToken cancellationToken = default)
        {
            if (instructor.Id == Guid.Empty)
                instructor.Id = Guid.NewGuid();

            _context.Instructors.Add(instructor);
            await _context.SaveChangesAsync(cancellationToken);
            return instructor;
        }

        public async Task UpdateAsync(Instructor instructor, CancellationToken cancellationToken = default)
        {
            var exists = await _context.Instructors.AnyAsync(i => i.Id == instructor.Id, cancellationToken);
            if (!exists)
                throw new KeyNotFoundException($"Instructor with id {instructor.Id} not found.");

            _context.Instructors.Update(instructor);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var instructor = await _context.Instructors.FindAsync(new object[] { id }, cancellationToken);
            if (instructor == null)
                return;

            _context.Instructors.Remove(instructor);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Instructors.AnyAsync(i => i.Id == id, cancellationToken);
        }
    }
}
