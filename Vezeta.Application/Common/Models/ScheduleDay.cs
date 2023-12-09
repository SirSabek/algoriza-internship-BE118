using Vezeta.Domain.Enums;

namespace Vezeta.Application.Common;

public class ScheduleDays
{
    public int DayId { get; set; }
    public List<WorkingHours> Hours { get; set; }
}

public class WorkingHours
{
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}