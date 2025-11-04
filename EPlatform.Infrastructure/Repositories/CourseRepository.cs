using System.Collections.Generic;
using System.Threading.Tasks;
using EPlatform.Application.Services;
using Microsoft.EntityFrameworkCore;
using EPlatform.Domain.Entities;
using EPlatform.Domain.Interfaces;
using EPlatform.Infrastructure.Data;

namespace EPlatform.Infrastructure.Repositories
{
    public class CourseRepository: ICourseRepository
    {
        private readonly AppDbContext _context;

        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _context.Courses
                .Include(c => c.professor)
                .Include(c => c.sections)
                .ToListAsync();
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            return await _context.Courses
                .Include(c => c.professor)
                .Include(c => c.sections)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }
        }
    }
}