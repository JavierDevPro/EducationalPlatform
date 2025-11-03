using System.Collections.Generic;
using System.Threading.Tasks;
using EPlatform.Domain.Entities;

namespace EPlatform.Application.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course> GetByIdAsync(int id);
        Task AddAsync(Course course);
        Task UpdateAsync(Course course);
        Task DeleteAsync(int id);
    }
}