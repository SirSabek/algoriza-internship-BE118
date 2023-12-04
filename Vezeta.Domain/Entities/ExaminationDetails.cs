using System.ComponentModel.DataAnnotations.Schema;
using Vezeta.Domain.Enums;

namespace Vezeta.Domain.Entities;

public class ExaminationDetails
{
    public int Id { get; set; }
    [ForeignKey(nameof(Doctor))]
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; } = null!;
    public int Price { get; set; }
    [NotMapped]
    public ICollection<WorkingDays> WorkingDays { get; set; } = null!;
    public string WorkingHours { get; set; } = null!; // "from 10:00 to 12:00"

}
