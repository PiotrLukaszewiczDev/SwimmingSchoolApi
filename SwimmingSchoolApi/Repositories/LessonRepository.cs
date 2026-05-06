using Microsoft.EntityFrameworkCore;
using SwimmingSchoolApi.Data;
using SwimmingSchoolApi.Interfaces;
using SwimmingSchoolApi.Models;

namespace SwimmingSchoolApi.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly AppDbContext _context;

        public LessonRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> HasAvailablePlacesAsync(int lessonId)
        {
            var lesson = await _context.Lessons
                .Include(l => l.Enrollments)
                .FirstOrDefaultAsync(l => l.Id == lessonId);

            if (lesson == null)
            {
                return false;
            }

            return lesson.Enrollments.Count < lesson.LimitedPlaces;
        }

        public async Task<Lesson> CreateAsync(Lesson lesson)
        {
            _context.Lessons.Add(lesson);
            await _context.SaveChangesAsync();
            return lesson;
        }

        public async Task<IEnumerable<Lesson>> GetAllAsync()
        {
            return await _context.Lessons.ToListAsync();
        }

        public async Task<Lesson?> GetByIdAsync(int id)
        {
            return await _context.Lessons.FindAsync(id);
        }
    }
}
