namespace Vezeta.Domain.Entities;

public class Doctor : User
{
    public Specialization specialization  { get; set; } = null!;
    public ExaminationDetails ExaminationDetails { get; set; } = null!;
    public ICollection<Booking> Bookings { get; set; } 
}