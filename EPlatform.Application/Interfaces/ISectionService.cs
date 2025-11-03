using EPlatform.Application.Dtos;

namespace EPlatform.Application.Interfaces;

public interface ISectionService
{
    Task<IEnumerable<SectionDto>> GetAll();
    Task<SectionDto?> Create(SectionCreateDto entity);
    Task<SectionDto?> Update(int id, SectionUpdateDto entity);
    Task<bool> Delete(int id);
}