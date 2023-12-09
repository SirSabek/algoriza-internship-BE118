using Microsoft.EntityFrameworkCore;
using Vezeta.Domain.Entities;

namespace Vezeta.Infrastructure.Configurations;

public class DayTimeSlotConfiguration : IEntityTypeConfiguration<DayTimeSlot>
{
  
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<DayTimeSlot> builder)
    {
        builder.HasKey(dts => new { dts.ScheduleDayID, dts.TimeSlotID });

        builder.HasOne(dts => dts.ScheduleDay)
            .WithMany(sd => sd.DayTimeSlots)
            .HasForeignKey(dts => dts.ScheduleDayID);

        builder.HasOne(dts => dts.TimeSlot)
            .WithMany(ts => ts.DayTimeSlots)
            .HasForeignKey(dts => dts.TimeSlotID);

        builder.HasData(
            new DayTimeSlot
            {
                ScheduleDayID = 1,
                TimeSlotID = 1
            },
            new DayTimeSlot
            {
                ScheduleDayID = 1,
                TimeSlotID = 2
            },
            new DayTimeSlot
            {
                ScheduleDayID = 1,
                TimeSlotID = 3
            },
            new DayTimeSlot
            {
                ScheduleDayID = 1,
                TimeSlotID = 4
            },
            new DayTimeSlot
            {
                ScheduleDayID = 1,
                TimeSlotID = 5
            },
            new DayTimeSlot
            {
                ScheduleDayID = 1,
                TimeSlotID = 6
            },
            new DayTimeSlot
            {
                ScheduleDayID = 1,
                TimeSlotID = 7
            },
            new DayTimeSlot
            {
                ScheduleDayID = 1,
                TimeSlotID = 8
            },
            new DayTimeSlot
            {
                ScheduleDayID = 2,
                TimeSlotID = 1
            },
            new DayTimeSlot
            {
                ScheduleDayID = 2,
                TimeSlotID = 2
            },
            new DayTimeSlot
            {
                ScheduleDayID = 2,
                TimeSlotID = 3
            },
            new DayTimeSlot
            {
                ScheduleDayID = 2,
                TimeSlotID = 4
            },
            new DayTimeSlot
            {
                ScheduleDayID = 2,
                TimeSlotID = 5
            },
            new DayTimeSlot
            {
                ScheduleDayID = 2,
                TimeSlotID = 6
            },
            new DayTimeSlot
            {
                ScheduleDayID = 2,
                TimeSlotID = 7
            },
            new DayTimeSlot
            {
                ScheduleDayID = 2,
                TimeSlotID = 8
            },
            new DayTimeSlot
            {
                ScheduleDayID = 3,
                TimeSlotID = 1
            },
            new DayTimeSlot
            {
                ScheduleDayID = 3,
                TimeSlotID = 2
            },
            new DayTimeSlot
            {
                ScheduleDayID = 3,
                TimeSlotID = 3
            },
            new DayTimeSlot
            {
                ScheduleDayID = 3,
                TimeSlotID = 4
            },
            new DayTimeSlot
            {
                ScheduleDayID = 3,
                TimeSlotID = 5
            },
            new DayTimeSlot
            {
                ScheduleDayID = 3,
                TimeSlotID = 6
            },
            new DayTimeSlot
            {
                ScheduleDayID = 3,
                TimeSlotID = 7
            },
            new DayTimeSlot
            {
                ScheduleDayID = 3,
                TimeSlotID = 8
            },
            new DayTimeSlot
            {
                ScheduleDayID = 4,
                TimeSlotID = 1
            },
            new DayTimeSlot
            {
                ScheduleDayID = 4,
                TimeSlotID = 2
            },
            new DayTimeSlot
            {
                ScheduleDayID = 4,
                TimeSlotID = 3
            },
            new DayTimeSlot
            {
                ScheduleDayID = 4,
                TimeSlotID = 4
            },
            new DayTimeSlot
            {
                ScheduleDayID = 4,
                TimeSlotID = 5
            },
            new DayTimeSlot
            {
                ScheduleDayID = 4,
                TimeSlotID = 6
            },
            new DayTimeSlot
            {
                ScheduleDayID = 4,
                TimeSlotID = 7
            },
            new DayTimeSlot
            {
                ScheduleDayID = 4,
                TimeSlotID = 8
            },
            new DayTimeSlot
            {
                ScheduleDayID = 5,
                TimeSlotID = 1
            },
            new DayTimeSlot
            {
                ScheduleDayID = 5,
                TimeSlotID = 2
            },
            new DayTimeSlot
            {
                ScheduleDayID = 5,
                TimeSlotID = 3
            },
            new DayTimeSlot
            {
                ScheduleDayID = 5,
                TimeSlotID = 4
            },
            new DayTimeSlot
            {
                ScheduleDayID = 5,
                TimeSlotID = 5
            },
            new DayTimeSlot
            {
                ScheduleDayID = 5,
                TimeSlotID = 6
            },
            new DayTimeSlot
            {
                ScheduleDayID = 5,
                TimeSlotID = 7
            },
            new DayTimeSlot
            {
                ScheduleDayID = 5,
                TimeSlotID = 8
            },
            new DayTimeSlot
            {
                ScheduleDayID = 6,
                TimeSlotID = 1
            },
            new DayTimeSlot
            {
                ScheduleDayID = 6,
                TimeSlotID = 2
            },
            new DayTimeSlot
            {
                ScheduleDayID = 6,
                TimeSlotID = 3
            },
            new DayTimeSlot
            {
                ScheduleDayID = 6,
                TimeSlotID = 4
            },
            new DayTimeSlot
            {
                ScheduleDayID = 6,
                TimeSlotID = 5
            },
            new DayTimeSlot
            {
                ScheduleDayID = 6,
                TimeSlotID = 6
            },
            new DayTimeSlot
            {
                ScheduleDayID = 6,
                TimeSlotID = 7
            },
            new DayTimeSlot
            {
                ScheduleDayID = 6,
                TimeSlotID = 8
            },
            new DayTimeSlot
            {
                ScheduleDayID = 7,
                TimeSlotID = 1
            },
            new DayTimeSlot
            {
                ScheduleDayID = 7,
                TimeSlotID = 2
            },
            new DayTimeSlot
            {
                ScheduleDayID = 7,
                TimeSlotID = 3
            },
            new DayTimeSlot
            {
                ScheduleDayID = 7,
                TimeSlotID = 4
            },
            new DayTimeSlot
            {
                ScheduleDayID = 7,
                TimeSlotID = 5
            },
            new DayTimeSlot
            {
                ScheduleDayID = 7,
                TimeSlotID = 6
            },
            new DayTimeSlot
            {
                ScheduleDayID = 7,
                TimeSlotID = 7
            },
            new DayTimeSlot
            {
                ScheduleDayID = 7,
                TimeSlotID = 8
            }
        );
    }
}