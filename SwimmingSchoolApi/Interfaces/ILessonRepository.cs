using SwimmingSchoolApi.Models;

namespace SwimmingSchoolApi.Interfaces
{
    public interface ILessonRepository
    {
        Task<IEnumerable<Lesson>> GetAllAsync();
        Task<bool> HasAvailablePlacesAsync(int lessonId);
        Task<Lesson?> GetByIdAsync(int id);
        Task<Lesson> CreateAsync(Lesson lesson);
    }
}
