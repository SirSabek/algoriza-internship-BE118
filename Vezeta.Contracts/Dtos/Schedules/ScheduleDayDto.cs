using Vezeta.Domain.Enums;

namespace Vezeta.Contract.Dtos.Schedules;

public class ScheduleDayDto
{
    public int Id { get; set; }
    public List<TimeSlotDto> TimeSlots { get; set; }
}
