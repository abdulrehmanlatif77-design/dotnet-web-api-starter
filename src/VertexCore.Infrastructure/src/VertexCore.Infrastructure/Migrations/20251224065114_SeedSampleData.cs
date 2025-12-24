using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VertexCore.Infrastructure.src.VertexCore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedSampleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Budget", "CreatedAt", "InstructorId", "Location", "Name", "PhoneNumber", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), 100000m, new DateTime(2025, 12, 24, 6, 51, 13, 593, DateTimeKind.Utc).AddTicks(8186), null, "Building A", "Computer Science", "555-0101", null },
                    { new Guid("22222222-2222-2222-2222-222222222222"), 150000m, new DateTime(2025, 12, 24, 6, 51, 13, 593, DateTimeKind.Utc).AddTicks(8186), null, "Building B", "Electrical Engineering", "555-0202", null }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "Address", "CreatedAt", "EmailAddress", "FirstName", "HireDate", "HomePhone", "LastName", "OfficePhone", "Position", "Salary", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("33333333-3333-3333-3333-333333333333"), "123 Main St", new DateTime(2025, 12, 24, 6, 51, 13, 593, DateTimeKind.Utc).AddTicks(8186), "alice.anderson@example.com", "Alice", new DateTime(2015, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "555-1001", "Anderson", "555-2001", "Professor", 80000m, null },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "456 Elm St", new DateTime(2025, 12, 24, 6, 51, 13, 593, DateTimeKind.Utc).AddTicks(8186), "bob.brown@example.com", "Bob", new DateTime(2018, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "555-1002", "Brown", "555-2002", "Associate Professor", 75000m, null }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "CourseId", "CreatedAt", "InstructorId", "MeetingDay", "MeetingTime", "RoomNumber", "SectionNumber", "Semester", "UpdatedAt", "Year" },
                values: new object[,]
                {
                    { new Guid("99999999-9999-9999-9999-999999999999"), null, new DateTime(2025, 12, 24, 6, 51, 13, 593, DateTimeKind.Utc).AddTicks(8186), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 9, 0, 0, 0), "101", "S01", "Fall", null, 2024 },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), null, new DateTime(2025, 12, 24, 6, 51, 13, 593, DateTimeKind.Utc).AddTicks(8186), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 11, 0, 0, 0), "202", "S02", "Spring", null, 2025 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "CreatedAt", "DateOfBirth", "Degree", "EmailAddress", "EnrollmentDate", "FirstName", "GPA", "Gender", "LastName", "MiddleInitial", "PhoneNumber", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("77777777-7777-7777-7777-777777777777"), "789 Oak St", new DateTime(2025, 12, 24, 6, 51, 13, 593, DateTimeKind.Utc).AddTicks(8186), new DateTime(2000, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "charlie.chaplin@example.com", new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charlie", 3.6m, "M", "Chaplin", "D", "555-3001", null },
                    { new Guid("88888888-8888-8888-8888-888888888888"), "321 Pine St", new DateTime(2025, 12, 24, 6, 51, 13, 593, DateTimeKind.Utc).AddTicks(8186), new DateTime(2001, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "diana.dawson@example.com", new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diana", 3.9m, "F", "Dawson", null, "555-3002", null }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CreatedAt", "Credits", "DepartmentId", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2025, 12, 24, 6, 51, 13, 593, DateTimeKind.Utc).AddTicks(8186), 3, new Guid("11111111-1111-1111-1111-111111111111"), "Intro to Programming", null },
                    { new Guid("66666666-6666-6666-6666-666666666666"), new DateTime(2025, 12, 24, 6, 51, 13, 593, DateTimeKind.Utc).AddTicks(8186), 4, new Guid("22222222-2222-2222-2222-222222222222"), "Circuits 101", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));
        }
    }
}
