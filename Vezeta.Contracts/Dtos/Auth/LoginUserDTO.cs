using System.ComponentModel.DataAnnotations;

namespace Vezeta.Contract.Dtos.Auth;

public class LoginUserDTO
{
    [Required]
    public string Email { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
}