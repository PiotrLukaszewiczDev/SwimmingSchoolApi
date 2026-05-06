using Microsoft.EntityFrameworkCore;
using SwimmingSchoolApi.Models;

namespace SwimmingSchoolApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)  : base(options)
        {
        }

        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
    }
}
