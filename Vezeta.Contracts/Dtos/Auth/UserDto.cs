using System.ComponentModel.DataAnnotations;
using Vezeta.Domain.Enums;

namespace Vezeta.Contract.Dtos.Auth;

public class UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNember { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        [StringLength(maximumLength: 15, ErrorMessage = "Your {0} must be between {2} and {1} characters.", MinimumLength = 6)]
        public string Password { get; set; } = null!;
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; } = null!;
        public Gender Gender { get; set; } = Gender.Male;
        public DateTime DateOfBirth {get; set;} 
    }