using SwimmingSchoolApi.Models;

namespace SwimmingSchoolApi.Interfaces
{
    public interface IEnrollmentRepository
    {
        Task<Enrollment> CreateAsync(Enrollment enrollment);
        Task<IEnumerable<Enrollment>> GetByLessonIdAsync(int lessonId);
        Task<Enrollment?> GetByIdAsync(int id);
        Task<bool> DeleteMemberAsync(int id);
    }
}
