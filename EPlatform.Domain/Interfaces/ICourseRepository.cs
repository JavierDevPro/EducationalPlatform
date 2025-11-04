using System.Collections.Generic;
using System.Threading.Tasks;
using EPlatform.Domain.Entities;

namespace EPlatform.Domain.Interfaces
{
    public interface ICourseRepository
    {
        Task<Course?> GetByIdAsync(int id);
        Task<IEnumerable<Course>> GetAllAsync();
        Task AddAsync(Course course);
        Task UpdateAsync(Course course);
        Task DeleteAsync(int Id);
    }
}