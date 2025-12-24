using MediatR;
using VertexCore.Application.Common.Models;
using VertexCore.Infrastructure.Interfaces.Services;

namespace VertexCore.Application.Commands.Section
{
    public class CreateSectionCommand : IRequest<Result>
    {
        public required string SectionNumber { get; set; }
        public required string Semester { get; set; }
        public int Year { get; set; }
        public string? RoomNumber { get; set; }
        public DateTime MeetingDay { get; set; }
        public TimeSpan MeetingTime { get; set; }
        public Guid CourseId { get; set; }

        public Guid InstructorId { get; set; }

    }

    public class CreateSectionCommandHandler : IRequestHandler<CreateSectionCommand, Result>
    {
        private readonly ISectionService _sectionService;

        public CreateSectionCommandHandler(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }

        public async Task<Result> Handle(CreateSectionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var section = new VertexCore.Domain.Entities.Section
                {
                    Id = Guid.NewGuid(),
                    SectionNumber = request.SectionNumber,
                    Semester = request.Semester,
                    Year = request.Year,
                    RoomNumber = request.RoomNumber,
                    MeetingDay = request.MeetingDay,
                    MeetingTime = request.MeetingTime,
                    CourseId = request.CourseId,
                    InstructorId = request.InstructorId
                };

                var result = await _sectionService.CreateAsync(section, cancellationToken);
                if (result == null)
                    return Result.Failure("SectionCreationFailed", "Failed to create section.");

                return Result.Success("Section created successfully.");
            }
            catch (Exception ex)
            {
                return Result.Failure(ex, "Failed to create section.");
            }
        }
    }
}
