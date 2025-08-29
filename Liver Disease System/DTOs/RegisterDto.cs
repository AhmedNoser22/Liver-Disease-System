namespace Liver_Disease_System.DTOs
{
    public class RegisterDto
    {
        [Display(Name ="Email/UserName")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; } = default!;
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;

        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmedPassword { get; set; } = default!; // القيمة الافتراضية مش هتبقا فاضية وقت الاستخدام

    }
}
