using System.ComponentModel.DataAnnotations.Schema;

namespace Vezeta.Domain.Entities;

public class Doctor : User
{
    [ForeignKey("Specialization")]
    public int SpecializationId { get; set; }
    public Specialization Specialization  { get; set; } = null!;
    public ExaminationDetails ExaminationDetails { get; set; } = null!;
    public ICollection<Booking> Bookings { get; set; } 
}