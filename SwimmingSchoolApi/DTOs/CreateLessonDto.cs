using System.ComponentModel.DataAnnotations;

namespace SwimmingSchoolApi.DTOs
{
    public class CreateLessonDto
    {
        [Required(ErrorMessage = "Please provide the lesson date and time.")]
        public DateTime StartTime {  get; set; }

        [Required]
        public int LimitedPlaces { get; set; }
    }
}
