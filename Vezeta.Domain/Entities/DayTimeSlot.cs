namespace Vezeta.Domain.Entities;

public class DayTimeSlot
{
    public int ScheduleDayID { get; set; }
    public int TimeSlotID { get; set; }

    public ScheduleDay ScheduleDay { get; set; }
    public TimeSlot TimeSlot { get; set; }
}