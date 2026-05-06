namespace SwimmingSchoolApi.Models
{
    public class Lesson
    {
        public int Id { get; set; } 
        public DateTime StartTime { get; set; }
        public int LimitedPlaces { get; set; }
        public List<Enrollment> Enrollments { get; set; } = new();
    }
}
