using System.ComponentModel.DataAnnotations;

namespace SwimmingSchoolApi.DTOs
{
    public class LessonDto
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public int LimitedPlaces { get; set; }
        public int EnrollmentCount {  get; set; }
    }
}
