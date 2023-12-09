using System.ComponentModel.DataAnnotations.Schema;

namespace Vezeta.Domain.Entities;

public class TimeSlot
{
    public int Id { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }

    public ICollection<DayTimeSlot> DayTimeSlots { get; set; }
    public ICollection<DoctorSchedule> DoctorSchedules { get; set; }

}
