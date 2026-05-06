using SwimmingSchoolApi.Models;

namespace SwimmingSchoolApi.DTOs
{
    public class EnrollmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string .Empty;
        public string Surname { get; set; } = string .Empty;
        public Level Level { get; set; }
        public int LessonId { get; set; }
    }
}
