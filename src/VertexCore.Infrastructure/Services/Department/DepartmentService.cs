using Microsoft.EntityFrameworkCore;
using VertexCore.Domain.Entities;
using VertexCore.Infrastructure.Identity;
using VertexCore.Infrastructure.Interfaces.Services;

namespace VertexCore.Infrastructure.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDbContext _context;

        public DepartmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Departments.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<Department?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Departments.AsNoTracking().FirstOrDefaultAsync(d => d.Id == id, cancellationToken);
        }

        public async Task<Department> CreateAsync(Department department, CancellationToken cancellationToken = default)
        {
            if (department.Id == Guid.Empty)
                department.Id = Guid.NewGuid();

            _context.Departments.Add(department);
            await _context.SaveChangesAsync(cancellationToken);
            return department;
        }

        public async Task UpdateAsync(Department department, CancellationToken cancellationToken = default)
        {
            var exists = await _context.Departments.AnyAsync(d => d.Id == department.Id, cancellationToken);
            if (!exists)
                throw new KeyNotFoundException($"Department with id {department.Id} not found.");

            _context.Departments.Update(department);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var department = await _context.Departments.FindAsync(new object[] { id }, cancellationToken);
            if (department == null)
                return;

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Departments.AnyAsync(d => d.Id == id, cancellationToken);
        }

        public async Task AssignInstructorAsync(Guid departmentId, Guid instructorId, CancellationToken cancellationToken = default)
        {
            var department = await _context.Departments.FindAsync(new object[] { departmentId }, cancellationToken);
            if (department == null)
                throw new KeyNotFoundException($"Department with id {departmentId} not found.");

            var instructor = await _context.Instructors.FindAsync(new object[] { instructorId }, cancellationToken);
            if (instructor == null)
                throw new KeyNotFoundException($"Instructor with id {instructorId} not found.");

            department.InstructorId = instructorId;
            department.Instructor = instructor;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
