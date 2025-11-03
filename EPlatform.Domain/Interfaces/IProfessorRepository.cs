using System.Collections.Generic;
using System.Threading.Tasks;
using webEscuela.Domain.Entities;

namespace webEscuela.Domain.Interfaces
{
    public interface IProfessorRepository
    {
        Task<IEnumerable<Professor>> GetAllAsync();
        Task<Professor?> GetByIdAsync(int id);
        Task<Professor> CreateAsync(Professor professor);
        Task<Professor?> UpdateAsync(int id, Professor professor);
        Task<bool> DeleteAsync(int id);
    }
}