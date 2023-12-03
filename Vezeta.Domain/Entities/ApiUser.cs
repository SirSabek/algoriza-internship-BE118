using Microsoft.AspNetCore.Identity;

namespace Vezeta.Domain.Entities;
public class ApiUser: IdentityUser<int>
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public byte[] Image { get; set; } = null;
}