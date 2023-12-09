using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vezeta.Domain.Entities;

namespace Vezeta.Infrastructure.Configurations;

public class DoctorScheduleConfiguration : IEntityTypeConfiguration<DoctorSchedule>
{
    public void Configure(EntityTypeBuilder<DoctorSchedule> builder)
    {
       builder.HasKey(ds => new { ds.DoctorID, ds.ScheduleDayID, ds.TimeSlotID });
           
            builder.HasOne(ds => ds.Doctor)
                .WithMany(d => d.DoctorSchedules)
                .HasForeignKey(ds => ds.DoctorID);
    
            builder.HasOne(ds => ds.ScheduleDay)
                .WithMany(sd => sd.DoctorSchedules)
                .HasForeignKey(ds => ds.ScheduleDayID);
    
            builder.HasOne(ds => ds.TimeSlot)
                .WithMany(ts => ts.DoctorSchedules)
                .HasForeignKey(ds => ds.TimeSlotID);
    
            builder.HasData(
                new DoctorSchedule
                {
                    DoctorID = 1,
                    ScheduleDayID = 1,
                    TimeSlotID = 1
                },
                new DoctorSchedule
                {
                    DoctorID = 1,
                    ScheduleDayID = 1,
                    TimeSlotID = 2
                },
                new DoctorSchedule
                {
                    DoctorID = 1,
                    ScheduleDayID = 1,
                    TimeSlotID = 3
                },
                new DoctorSchedule
                {
                    DoctorID = 1,
                    ScheduleDayID = 1,
                    TimeSlotID = 4
                },
                new DoctorSchedule
                {
                    DoctorID = 1,
                    ScheduleDayID = 1,
                    TimeSlotID = 5
                },
                new DoctorSchedule
                {
                    DoctorID = 1,
                    ScheduleDayID = 1,
                    TimeSlotID = 6
                },
                new DoctorSchedule
                {
                    DoctorID = 1,
                    ScheduleDayID = 1,
                    TimeSlotID = 7
                },
                new DoctorSchedule
                {
                    DoctorID = 1,
                    ScheduleDayID = 1,
                    TimeSlotID = 8
                },
                new DoctorSchedule
                {
                    DoctorID = 1,
                    ScheduleDayID = 2,
                    TimeSlotID = 1
                },
                new DoctorSchedule
                {
                    DoctorID = 1,
                    ScheduleDayID = 2,
                    TimeSlotID = 2
                },
                new DoctorSchedule
                {
                    DoctorID = 1,
                    ScheduleDayID = 2,
                    TimeSlotID = 3
                },
                new DoctorSchedule
                {
                    DoctorID = 1,
                    ScheduleDayID = 2,
                    TimeSlotID = 4
                },
                new DoctorSchedule
                {
                    DoctorID = 1,
                    ScheduleDayID = 2,
                    TimeSlotID = 5
                },
                new DoctorSchedule
                {
                    DoctorID = 1,
                    ScheduleDayID = 2,
                    TimeSlotID = 6
                },
                new DoctorSchedule
                {
                    DoctorID = 2,
                    ScheduleDayID = 1,
                    TimeSlotID = 1
                },
                new DoctorSchedule
                {
                    DoctorID = 2,
                    ScheduleDayID = 1,
                    TimeSlotID = 2
                },
                new DoctorSchedule
                {
                    DoctorID = 2,
                    ScheduleDayID = 1,
                    TimeSlotID = 3
                },
                new DoctorSchedule
                {
                    DoctorID = 2,
                    ScheduleDayID = 1,
                    TimeSlotID = 4
                },
                new DoctorSchedule
                {
                    DoctorID = 3,
                    ScheduleDayID = 1,
                    TimeSlotID = 1
                },
                new DoctorSchedule
                {
                    DoctorID = 3,
                    ScheduleDayID = 1,
                    TimeSlotID = 2
                },
                new DoctorSchedule
                {
                    DoctorID = 3,
                    ScheduleDayID = 1,
                    TimeSlotID = 3
                },
                new DoctorSchedule
                {
                    DoctorID = 3,
                    ScheduleDayID = 1,
                    TimeSlotID = 4
                }
            );
    }
}