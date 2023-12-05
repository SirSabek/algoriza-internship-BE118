namespace Vezeta.Domain.Entities;

public class Booking
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int PatientId { get; set; }
    public Patient Patient { get; set; } = null!;
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Status Status { get; set; }
}