using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vezeta.Domain.Entities;
using Vezeta.Domain.Enums;

namespace Vezeta.Infrastructure.Configurations;

public class ScheduleDayConfiguration : IEntityTypeConfiguration<ScheduleDay>
{
    // add list of time slots
    private  List<TimeSlot> _timeSlots = new List<TimeSlot> {
        new TimeSlot
        {
            Id = 1,
            StartTime = new TimeSpan(8, 0, 0),
            EndTime = new TimeSpan(9, 0, 0)
        },
        new TimeSlot
        {
            Id = 2,
            StartTime = new TimeSpan(9, 0, 0),
            EndTime = new TimeSpan(10, 0, 0)
        },
        new TimeSlot
        {
            Id = 3,
            StartTime = new TimeSpan(10, 0, 0),
            EndTime = new TimeSpan(11, 0, 0)
        },
        new TimeSlot
        {
            Id = 4,
            StartTime = new TimeSpan(11, 0, 0),
            EndTime = new TimeSpan(12, 0, 0)
        },
        new TimeSlot
        {
            Id = 5,
            StartTime = new TimeSpan(12, 0, 0),
            EndTime = new TimeSpan(13, 0, 0)
        },
        new TimeSlot
        {
            Id = 6,
            StartTime = new TimeSpan(13, 0, 0),
            EndTime = new TimeSpan(14, 0, 0)
        },
        new TimeSlot
        {
            Id = 7,
            StartTime = new TimeSpan(14, 0, 0),
            EndTime = new TimeSpan(15, 0, 0)
        },
        new TimeSlot
        {
            Id = 8,
            StartTime = new TimeSpan(15, 0, 0),
            EndTime = new TimeSpan(16, 0, 0)
        },
        new TimeSlot
        {
            Id = 9,
            StartTime = new TimeSpan(16, 0, 0),
            EndTime = new TimeSpan(17, 0, 0)
        },
        new TimeSlot
        {
            Id = 10,
            StartTime = new TimeSpan(17, 0, 0),
            EndTime = new TimeSpan(18, 0, 0)
        },
        new TimeSlot
        {
            Id = 11,
            StartTime = new TimeSpan(18, 0, 0),
            EndTime = new TimeSpan(19, 0, 0)
        },
        new TimeSlot
        {
            Id = 12,
            StartTime = new TimeSpan(19, 0, 0),
            EndTime = new TimeSpan(20, 0, 0)
        },
                new TimeSlot
        {
            Id = 13,
            StartTime = new TimeSpan(20, 0, 0),
            EndTime = new TimeSpan(21, 0, 0)
        },
        new TimeSlot
        {
            Id = 14,
            StartTime = new TimeSpan(21, 0, 0),
            EndTime = new TimeSpan(22, 0, 0)
        },
        new TimeSlot
        {
            Id = 15,
            StartTime = new TimeSpan(22, 0, 0),
            EndTime = new TimeSpan(23, 0, 0)
        },
        new TimeSlot
        {
            Id = 16,
            StartTime = new TimeSpan(23, 0, 0),
            EndTime = new TimeSpan(24, 0, 0)
        },
        new TimeSlot
        {
            Id = 17,
            StartTime = new TimeSpan(24, 0, 0),
            EndTime = new TimeSpan(1, 0, 0)
        },
        new TimeSlot
        {
            Id = 18,
            StartTime = new TimeSpan(1, 0, 0),
            EndTime = new TimeSpan(2, 0, 0)
        },
        new TimeSlot
        {
            Id = 19,
            StartTime = new TimeSpan(2, 0, 0),
            EndTime = new TimeSpan(3, 0, 0)
        },
        new TimeSlot
        {
            Id = 20,
            StartTime = new TimeSpan(3, 0, 0),
            EndTime = new TimeSpan(4, 0, 0)
        },
        new TimeSlot
        {
            Id = 21,
            StartTime = new TimeSpan(4, 0, 0),
            EndTime = new TimeSpan(5, 0, 0)
        },
        new TimeSlot
        {
            Id = 22,
            StartTime = new TimeSpan(5, 0, 0),
            EndTime = new TimeSpan(6, 0, 0)
        },
        new TimeSlot
        {
            Id = 23,
            StartTime = new TimeSpan(6, 0, 0),
            EndTime = new TimeSpan(7, 0, 0)
        },
        new TimeSlot
        {
            Id = 24,
            StartTime = new TimeSpan(7, 0, 0),
            EndTime = new TimeSpan(8, 0, 0)
        }
    };
    public void Configure(EntityTypeBuilder<ScheduleDay> builder)
    {
        builder.HasData(
            new ScheduleDay
            {
                Id = 1,
                Day = Day.Saturday,
            },
            new ScheduleDay
            {
                Id = 2,
                Day = Day.Sunday,
            },
            new ScheduleDay
            {
                Id = 3,
                Day = Day.Monday,
            },
            new ScheduleDay
            {
                Id = 4,
                Day = Day.Tuesday,
            },
            new ScheduleDay
            {
                Id = 5,
                Day = Day.Wednesday,
            },
            new ScheduleDay
            {
                Id = 6,
                Day = Day.Thursday,
            },
            new ScheduleDay
            {
                Id = 7,
                Day = Day.Friday,
            }
        );

    }
}
   
