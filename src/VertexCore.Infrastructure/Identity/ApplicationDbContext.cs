using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VertexCore.Domain.Entities;

namespace VertexCore.Infrastructure.Identity
{
    /**
     * This class represents the application database context for identity.
     * It extends the IdentityDbContext class provided by ASP.NET Core Identity.
     * This context is used to interact with the database for user management,
     * roles, and other identity-related operations.
     **/
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<Instructor> Instructors { get; set; }


        public DbSet<Department> Departments { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Section> Sections { get; set; }


        /**
         * This method is used to configure the model for the identity context.
         * It can be overridden to customize the model, such as adding custom tables or relationships.
         **/
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Apply configurations for identity entities
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            // Seed sample data
            var createdAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            var dept1Id = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var dept2Id = Guid.Parse("22222222-2222-2222-2222-222222222222");

            var instr1Id = Guid.Parse("33333333-3333-3333-3333-333333333333");
            var instr2Id = Guid.Parse("44444444-4444-4444-4444-444444444444");

            var course1Id = Guid.Parse("55555555-5555-5555-5555-555555555555");
            var course2Id = Guid.Parse("66666666-6666-6666-6666-666666666666");

            var student1Id = Guid.Parse("77777777-7777-7777-7777-777777777777");
            var student2Id = Guid.Parse("88888888-8888-8888-8888-888888888888");

            var section1Id = Guid.Parse("99999999-9999-9999-9999-999999999999");
            var section2Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");

            builder.Entity<Department>().HasData(
                new Department
                {
                    Id = dept1Id,
                    Name = "Computer Science",
                    Location = "Building A",
                    PhoneNumber = "555-0101",
                    Budget = 100000m,
                    CreatedAt = createdAt
                },
                new Department
                {
                    Id = dept2Id,
                    Name = "Electrical Engineering",
                    Location = "Building B",
                    PhoneNumber = "555-0202",
                    Budget = 150000m,
                    CreatedAt = createdAt
                }
            );

            builder.Entity<Instructor>().HasData(
                new Instructor
                {
                    Id = instr1Id,
                    FirstName = "Alice",
                    LastName = "Anderson",
                    Address = "123 Main St",
                    HomePhone = "555-1001",
                    OfficePhone = "555-2001",
                    EmailAddress = "alice.anderson@example.com",
                    Salary = 80000m,
                    Position = "Professor",
                    HireDate = new DateTime(2015, 8, 1),
                    CreatedAt = createdAt
                },
                new Instructor
                {
                    Id = instr2Id,
                    FirstName = "Bob",
                    LastName = "Brown",
                    Address = "456 Elm St",
                    HomePhone = "555-1002",
                    OfficePhone = "555-2002",
                    EmailAddress = "bob.brown@example.com",
                    Salary = 75000m,
                    Position = "Associate Professor",
                    HireDate = new DateTime(2018, 9, 15),
                    CreatedAt = createdAt
                }
            );

            builder.Entity<Course>().HasData(
                new
                {
                    Id = course1Id,
                    Title = "Intro to Programming",
                    Credits = 3,
                    DepartmentId = dept1Id,
                    CreatedAt = createdAt
                },
                new
                {
                    Id = course2Id,
                    Title = "Circuits 101",
                    Credits = 4,
                    DepartmentId = dept2Id,
                    CreatedAt = createdAt
                }
            );

            builder.Entity<Student>().HasData(
                new Student
                {
                    Id = student1Id,
                    FirstName = "Charlie",
                    MiddleInitial = "D",
                    LastName = "Chaplin",
                    DateOfBirth = new DateTime(2000, 1, 15),
                    Gender = "M",
                    Address = "789 Oak St",
                    PhoneNumber = "555-3001",
                    EmailAddress = "charlie.chaplin@example.com",
                    EnrollmentDate = new DateTime(2019, 9, 1),
                    Degree = DegreeType.BE,
                    GPA = 3.6m,
                    CreatedAt = createdAt
                },
                new Student
                {
                    Id = student2Id,
                    FirstName = "Diana",
                    MiddleInitial = null,
                    LastName = "Dawson",
                    DateOfBirth = new DateTime(2001, 5, 24),
                    Gender = "F",
                    Address = "321 Pine St",
                    PhoneNumber = "555-3002",
                    EmailAddress = "diana.dawson@example.com",
                    EnrollmentDate = new DateTime(2020, 9, 1),
                    Degree = DegreeType.BTech,
                    GPA = 3.9m,
                    CreatedAt = createdAt
                }
            );

            builder.Entity<Section>().HasData(
                new Section
                {
                    Id = section1Id,
                    SectionNumber = "S01",
                    Semester = "Fall",
                    Year = 2024,
                    RoomNumber = "101",
                    MeetingDay = new DateTime(2025, 12, 23),
                    MeetingTime = new TimeSpan(9, 0, 0),
                    CreatedAt = createdAt,
                    CourseId = course1Id,
                    InstructorId = instr1Id
                },
                new Section
                {
                    Id = section2Id,
                    SectionNumber = "S02",
                    Semester = "Spring",
                    Year = 2025,
                    RoomNumber = "202",
                    MeetingDay = new DateTime(2025, 12, 23),
                    MeetingTime = new TimeSpan(11, 0, 0),
                    CreatedAt = createdAt,
                    CourseId = course2Id,
                    InstructorId = instr2Id
                }
            );
        }

    }
}