namespace Liver_Disease_System.DTOs
{
    public class LoginDto
    {
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password, ErrorMessage = "Invalid Password")]
        public string Password { get; set; } = default!;
    }
}
