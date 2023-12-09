using System.ComponentModel.DataAnnotations.Schema;
using Vezeta.Domain.Enums;

namespace Vezeta.Domain.Entities;

public class ScheduleDay
{
    public int Id { get; set; }
    public Day Day { get; set; }
    public ICollection<DayTimeSlot> DayTimeSlots { get; set; }
    public ICollection<DoctorSchedule> DoctorSchedules { get; set; }
}
