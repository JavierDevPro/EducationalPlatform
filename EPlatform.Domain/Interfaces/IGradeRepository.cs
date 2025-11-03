using System.Collections.Generic;
using System.Threading.Tasks;
using EPlatform.Domain.Entities;

namespace EPlatform.Domain.Interfaces
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