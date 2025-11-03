using EPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using webEscuela.Domain.Entities;

namespace webEscuela.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Course>  Courses { get; set; }
    public DbSet<Student>  Students { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<Section>  Sections { get; set; }
    public DbSet<Professor> Professors { get; set; }
    public DbSet<Grade>  Grades { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 
        //Profesor - Course
        
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Professor>()
            .HasMany(f => f.courses)
            .WithOne(p => p.professor)
            .HasForeignKey(p => p.ProfessorId);
        
        //Enrolment - Student/Section
        
        modelBuilder.Entity<Enrollment>()
            .HasOne(p => p.student)
            .WithMany(r => r.enrollments)
            .HasForeignKey(p => p.StudentId);
        
        modelBuilder.Entity<Enrollment>()
            .HasOne(p => p.section)
            .WithMany(r => r.enrollments)
            .HasForeignKey(p => p.SectionId);
        
        //Enrolment - Grade
        
        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.grade)
            .WithOne(g => g.enrollment)
            .HasForeignKey<Grade>(g => g.EnrollmentId);
        
        //Course - Section
        
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Course>()
            .HasMany(f => f.sections)
            .WithOne(p => p.course)
            .HasForeignKey(p => p.CourseId);

    }
}