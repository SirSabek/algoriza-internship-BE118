namespace Vezeta.Contract.Dtos.Admin;

public class GetDoctorDto : BaseDoctorDto
{
    public string FullName { get; set; }
    public string SpecializationName { get; set; }
    public byte[] Image { get; set; }

}
