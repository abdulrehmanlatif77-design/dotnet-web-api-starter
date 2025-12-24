using System;

namespace VertexCore.Domain.Dtos
{
    public class InstructorDto
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Address { get; set; }
        public string? HomePhone { get; set; }
        public string? OfficePhone { get; set; }
        public required string EmailAddress { get; set; }
        public decimal Salary { get; set; }
        public string? Position { get; set; }
        public DateTime HireDate { get; set; }
    }
}
