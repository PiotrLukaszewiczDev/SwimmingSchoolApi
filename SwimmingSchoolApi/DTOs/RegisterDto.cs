using System.ComponentModel.DataAnnotations;

namespace SwimmingSchoolApi.DTOs
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Please provide the participant's username ")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "The username cannot be longer then 30 characters.")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please provide the participant's password ")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "The password cannot be longer then 30 characters.")]
        public string Password {  get; set; } = string.Empty;
    }
}
