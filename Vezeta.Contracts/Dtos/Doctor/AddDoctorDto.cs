namespace Vezeta.Contract.Dtos.Doctor;

public class AddDoctorDto : BaseDoctorDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public int SpecializationId { get; set; }
}