using Microsoft.EntityFrameworkCore;
using EPlatform.Domain.Entities;

namespace EPlatform.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; } // ✅ importante
    }
}