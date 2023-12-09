using Vezeta.Domain.Enums;

namespace Vezeta.Application.Common;

public class DoctorSchedule
{
    public string FullName { get; set; }
    public string Specialization{ get; set; }
    public byte[] Image { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public int Price { get; set; }
    public Gender Gender { get; set; }
    public List<ScheduleDays> Schedule { get; set; }
}