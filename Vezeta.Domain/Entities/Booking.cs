using System.ComponentModel.DataAnnotations.Schema;

namespace Vezeta.Domain.Entities;

public class Booking
{
    public int Id { get; set; }
    [ForeignKey("ScheduleDay")]
    public int ScheduleDayId { get; set; }
    public ScheduleDay ScheduleDay { get; set; }

    [ForeignKey("TimeSlot")]
    public int TimeSlotId { get; set; }
    public TimeSlot TimeSlot { get; set; }
    public int PatientId { get; set; }
    public Patient Patient { get; set; } = null!;
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Status Status { get; set; }
    public bool IsConfirmed { get; set; } = false;
    public string? Coupon { get; set; } = null;

}