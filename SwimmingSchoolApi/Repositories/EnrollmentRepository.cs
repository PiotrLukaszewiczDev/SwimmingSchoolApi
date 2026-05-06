using Microsoft.EntityFrameworkCore;
using SwimmingSchoolApi.Data;
using SwimmingSchoolApi.Interfaces;
using SwimmingSchoolApi.Models;

namespace SwimmingSchoolApi.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly AppDbContext _context;

        public EnrollmentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Enrollment> CreateAsync(Enrollment enrollment)
        {
            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();
            return enrollment;
        }

        public async Task<bool> DeleteMemberAsync(int id)
        {
            var enrollment = await _context.Enrollments.FindAsync(id);
            
            if(enrollment == null)
            {
                return false;
            }
            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Enrollment?> GetByIdAsync(int id)
        {
            return await _context.Enrollments.FindAsync(id);
        }

        public async Task<IEnumerable<Enrollment>> GetByLessonIdAsync(int lessonId)
        {
            return await _context.Enrollments
                .Where(e => e.LessonId == lessonId)
                .ToListAsync();
        }
    }
}
