namespace Vezeta.Domain.Entities;

public class DoctorSchedule
{
    public int DoctorID { get; set; }
    public int ScheduleDayID { get; set; }
    public int TimeSlotID { get; set; }

    public Doctor Doctor { get; set; }
    public ScheduleDay ScheduleDay { get; set; }
    public TimeSlot TimeSlot { get; set; }
}