using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vezeta.Domain.Entities;

public class Doctor : User
{
    [ForeignKey("Specialization")]
    public int SpecializationId { get; set; }
    public Specialization Specialization  { get; set; } = null!;
    [DataType(DataType.Currency)]
    public int Price { get; set; }
    public ICollection<Booking> Bookings { get; set; } 
    public ICollection<DoctorSchedule> DoctorSchedules { get; set; }
}