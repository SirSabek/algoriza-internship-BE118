using Vezeta.Contract.Dtos.Schedules;

namespace Vezeta.Contract.Dtos.Doctor;

public class GetDoctorDto : BaseDoctorDto
{
    public string FullName { get; set; }
    public string SpecializationName { get; set; }
    public byte[] Image { get; set; }
}
