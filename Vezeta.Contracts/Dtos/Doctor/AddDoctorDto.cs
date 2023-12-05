namespace Vezeta.Contract.Dtos.Doctor;

public class AddDoctorDto : BaseDoctorDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    //public byte[] Image { get; set; } = new byte[0];
    public int SpecializationId { get; set; }
}