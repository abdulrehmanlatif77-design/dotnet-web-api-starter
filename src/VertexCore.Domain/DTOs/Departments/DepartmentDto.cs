using System;

namespace VertexCore.Domain.Dtos
{
    public class DepartmentDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Location { get; set; }
        public string? PhoneNumber { get; set; }
        public decimal Budget { get; set; }
        public Guid? InstructorId { get; set; }
    }
}
