using System.Collections.Generic;
using System.Threading.Tasks;
using webEscuela.Domain.Entities;

namespace webEscuela.Domain.Interfaces
{
    public interface IGradeRepository
    {
        Task<IEnumerable<Grade>> GetAllAsync();
        Task<Grade?> GetByIdAsync(int id);
        Task<Grade> CreateAsync(Grade grade);
        Task<Grade?> UpdateAsync(int id, Grade grade);
        Task<bool> DeleteAsync(int id);
    }
}