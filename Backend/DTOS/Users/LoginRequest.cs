using System.ComponentModel.DataAnnotations;

namespace Backend.DTOS.Users
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(6)]
        public string Password { get; set; }
    }
}
