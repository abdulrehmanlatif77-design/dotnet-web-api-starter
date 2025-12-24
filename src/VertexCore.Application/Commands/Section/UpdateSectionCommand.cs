using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VertexCore.Application.Common.Models;
using VertexCore.Infrastructure.Interfaces.Services;

namespace VertexCore.Application.Commands.Section
{
    public class UpdateSectionCommand : IRequest<Result>
    {
        public Guid Id { get; set; }
        public required string SectionNumber { get; set; }
        public required string Semester { get; set; }
        public int Year { get; set; }
        public string? RoomNumber { get; set; }
        public DateTime MeetingDay { get; set; }
        public TimeSpan MeetingTime { get; set; }

        // allow updating the associated course and instructor
        public Guid CourseId { get; set; }
        public Guid InstructorId { get; set; }
    }

    public class UpdateSectionCommandHandler : IRequestHandler<UpdateSectionCommand, Result>
    {
        private readonly ISectionService _sectionService;

        public UpdateSectionCommandHandler(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }

        public async Task<Result> Handle(UpdateSectionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var section = new VertexCore.Domain.Entities.Section
                {
                    Id = request.Id,
                    SectionNumber = request.SectionNumber,
                    Semester = request.Semester,
                    Year = request.Year,
                    RoomNumber = request.RoomNumber,
                    MeetingDay = request.MeetingDay,
                    MeetingTime = request.MeetingTime,
                    CourseId = request.CourseId,
                    InstructorId = request.InstructorId
                };

                await _sectionService.UpdateAsync(section, cancellationToken);
                return Result.Success("Section updated successfully.");
            }
            catch (KeyNotFoundException knfEx)
            {
                return Result.Failure("SectionNotFound", knfEx.Message);
            }
            catch (Exception ex)
            {
                return Result.Failure(ex, "Failed to update section.");
            }
        }
    }
}
