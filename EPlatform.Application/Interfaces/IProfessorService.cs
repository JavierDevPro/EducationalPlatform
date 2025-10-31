using webEscuela.Application.DTOs;

namespace webEscuela.Application.Interfaces
{
    public interface IProfessorService
    {
        Task<IEnumerable<ProfessorDto>> GetAllAsync();
        Task<ProfessorDto?> GetByIdAsync(int id);
        Task<ProfessorDto> CreateAsync(CreateProfessorDto dto);
        Task<bool> UpdateAsync(int id, UpdateProfessorDto dto);
        Task<bool> DeleteAsync(int id);
    }
}