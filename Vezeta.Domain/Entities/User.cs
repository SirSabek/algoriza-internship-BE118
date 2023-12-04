using Microsoft.AspNetCore.Identity;
using Vezeta.Domain.Enums;

namespace Vezeta.Domain.Entities;
public class User: IdentityUser<int>
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public Gender Gender { get; set; }
    public byte[] Image { get; set; } = new byte[0];
    public DateTime DateOfBirth { get; set; }
}