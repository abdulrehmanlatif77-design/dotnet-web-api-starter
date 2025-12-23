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
    public class CourseService : ICourseService
    {
        private readonly ApplicationDbContext _context;

        public CourseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Courses.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<Course?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Courses.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }

        public async Task<Course> CreateAsync(Course course, CancellationToken cancellationToken = default)
        {
            if (course.Id == Guid.Empty)
                course.Id = Guid.NewGuid();

            _context.Courses.Add(course);
            await _context.SaveChangesAsync(cancellationToken);
            return course;
        }

        public async Task UpdateAsync(Course course, CancellationToken cancellationToken = default)
        {
            var exists = await _context.Courses.AnyAsync(c => c.Id == course.Id, cancellationToken);
            if (!exists)
                throw new KeyNotFoundException($"Course with id {course.Id} not found.");

            _context.Courses.Update(course);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var course = await _context.Courses.FindAsync(new object[] { id }, cancellationToken);
            if (course == null)
                return;

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Courses.AnyAsync(c => c.Id == id, cancellationToken);
        }
    }
}
