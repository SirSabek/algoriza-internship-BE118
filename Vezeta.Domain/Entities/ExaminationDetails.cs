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

    // update these two to be a list of objects
    public string WorkingDays { get; set; } = null!; // "sat, sun, mon"
    public string WorkingHours { get; set; } = null!; // "from 10:00 to 12:00"

}
