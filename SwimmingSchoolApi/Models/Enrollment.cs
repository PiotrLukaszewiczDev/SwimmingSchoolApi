namespace SwimmingSchoolApi.Models
{
    public class Enrollment
    {
        public int Id {  get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname {  get; set; } = string.Empty;
        public Level Level { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; } = null!;
    }
}
