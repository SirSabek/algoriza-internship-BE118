using Vezeta.Domain.Entities;
using Vezeta.Domain.Enums;

namespace Vezeta.Contract.Dtos.Admin;

public class BaseDoctorDto
{
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public Gender Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
}
