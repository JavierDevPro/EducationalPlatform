using EPlatform.Application.DTOs;
using webEscuela.Application.DTOs;

namespace EPlatform.Application.Interfaces
{
    public interface IGradeService
    {
        Task<IEnumerable<GradeDto>> GetAllAsync();
        Task<GradeDto?> GetByIdAsync(int id);
        Task<GradeDto> CreateAsync(CreateGradeDto dto);
        Task<bool> UpdateAsync(int id, UpdateGradeDto dto);
        Task<bool> DeleteAsync(int id);
    }
}