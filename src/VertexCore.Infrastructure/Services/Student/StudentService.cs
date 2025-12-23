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
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;

        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Students.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<Student?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Students.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        }

        public async Task<Student> CreateAsync(Student student, CancellationToken cancellationToken = default)
        {
            if (student.Id == Guid.Empty)
                student.Id = Guid.NewGuid();

            _context.Students.Add(student);
            await _context.SaveChangesAsync(cancellationToken);
            return student;
        }

        public async Task UpdateAsync(Student student, CancellationToken cancellationToken = default)
        {
            var exists = await _context.Students.AnyAsync(s => s.Id == student.Id, cancellationToken);
            if (!exists)
                throw new KeyNotFoundException($"Student with id {student.Id} not found.");

            _context.Students.Update(student);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var student = await _context.Students.FindAsync(new object[] { id }, cancellationToken);
            if (student == null)
                return;

            _context.Students.Remove(student);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Students.AnyAsync(s => s.Id == id, cancellationToken);
        }
    }
}
