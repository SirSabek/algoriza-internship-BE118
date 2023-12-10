using Vezeta.Domain.Enums;

namespace Vezeta.Contract.Dtos.Admin;
public class AddAdminDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Gender Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
}