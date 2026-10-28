using System.ComponentModel.DataAnnotations;

namespace DemoCinema.WebApp.Models
{
    public class AuthLoginFrom
    {
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public required string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
    }

    public class AuthRegisterFrom
    {
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public required string Email { get; set; }

        [Required]
        [MinLength(3)]
        [RegularExpression(@"^[^@]*$")]
        public required string Username { get; set; }

        [Required]
        [MinLength(6)]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^A-Za-z0-9\s]).*$")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public required string PasswordConfirm { get; set; }
    }
}
