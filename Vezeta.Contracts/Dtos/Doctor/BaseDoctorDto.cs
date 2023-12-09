using Microsoft.AspNetCore.Http;
using Vezeta.Domain.Enums;
namespace Vezeta.Contract.Dtos.Doctor;

public class BaseDoctorDto
{
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public Gender Gender { get; set; }
    public int Price { get; set; }
    public DateTime DateOfBirth { get; set; }
    public IFormFile Image { get; set; }
}
