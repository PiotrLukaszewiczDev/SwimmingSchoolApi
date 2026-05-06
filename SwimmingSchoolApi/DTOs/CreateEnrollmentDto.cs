using SwimmingSchoolApi.Models;
using System.ComponentModel.DataAnnotations;

namespace SwimmingSchoolApi.DTOs
{
    public class CreateEnrollmentDto
    {
        [Required(ErrorMessage = "Please provide the participant's name ")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "The name could not be longer then 20 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please provide the participant's surname ")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "The surname cannot be longer then 30 characters.")]
        public string Surname { get; set; } = string.Empty;

        [Required(ErrorMessage ="Please provide the advancement level")]
        public Level Level { get; set; }

        [Required]
        public int LessonId{ get; set; } 
    }
}
