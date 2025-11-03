using webEscuela.Application.DTOs;

namespace webEscuela.Application.Interfaces
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