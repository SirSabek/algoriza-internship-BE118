namespace Vezeta.Contract.Dtos.Doctor;

public class UpdateDoctorDto : BaseDoctorDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int SpecializationId { get; set; }
}
