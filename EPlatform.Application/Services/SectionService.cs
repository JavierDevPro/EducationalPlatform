using EPlatform.Application.Dtos;
using EPlatform.Application.Interfaces;
using EPlatform.Domain.Interfaces;
using EPlatform.Domain.Entities;

namespace Institution.Application.Services;

public class SectionService : ISectionService
{
    private readonly ISectionRepository<Section> _repository;

    public SectionService(ISectionRepository<Section> repository)
    {
        _repository = repository;
    }
    
    private SectionDto MapDto(Section section)
    {
        return new SectionDto
        {
            Id = section.Id,
            DayOfWeed = section.DayOfWeed,
            StartTime = section.StartTime,
            EndTime = section.EndTime,
            Clasroom = section.Clasroom,
            Capacity = section.Capacity,
            IsActive = section.IsActive,
            CourseId = section.CourseId
        };
    }

    private Section MapCreateDto(SectionCreateDto dto)
    {
        return new Section
        {
            DayOfWeed = dto.DayOfWeed,
            StartTime = dto.StartTime,
            EndTime = dto.EndTime,
            Clasroom = dto.Clasroom,
            Capacity = dto.Capacity,
            IsActive = dto.IsActive,
            CourseId = dto.CourseId
        };
    }

    private Section MapUpdateDto(SectionUpdateDto dto)
    {
        return new Section
        {
            DayOfWeed = dto.DayOfWeed,
            StartTime = dto.StartTime,
            EndTime = dto.EndTime,
            Clasroom = dto.Clasroom,
            Capacity = dto.Capacity,
            IsActive = dto.IsActive,
            CourseId = dto.CourseId
        };
    }

    public async Task<IEnumerable<SectionDto>> GetAll()
    {
        var sections = await _repository.GetAll();
        return sections.Select(MapDto);
    }

    public async Task<SectionDto?> Create(SectionCreateDto dto)
    {
        var section = MapCreateDto(dto);
        var created = await _repository.Create(section);
        return MapDto(created);
    }

    public async Task<SectionDto?> Update(int id, SectionUpdateDto dto)
    {
        var section = MapUpdateDto(dto);
        var updated = await _repository.Update(id, section);
        if (updated == null) return null;
        return MapDto(updated);
    }

    public async Task<bool> Delete(int id)
    {
        return await _repository.Delete(id);
    }
}
