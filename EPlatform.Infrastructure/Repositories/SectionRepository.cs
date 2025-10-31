using Microsoft.EntityFrameworkCore;
using webEscuela.Infrastructure.Data;
using webEscuela.Domain.Models;
using EPlatform.Domain.Interfaces;

namespace EPlatform.Infrastructure.Repositories;

public class SectionRepository : ISectionRepository<Section>
{
    private readonly AppDbContext _context;

    public SectionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Section>> GetAll()
    {
        return await _context.Sections.ToListAsync();
    }

    public async Task<Section> Create(Section entity)
    {
        _context.Sections.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Section?> Update(int id, Section entity)
    {
        var existingSection = await _context.Sections.FirstOrDefaultAsync(s => s.Id == id);
        if (existingSection == null) return null;

        existingSection.DayOfWeed = entity.DayOfWeed;
        existingSection.StartTime = entity.StartTime;
        existingSection.EndTime = entity.EndTime;
        existingSection.Clasroom = entity.Clasroom;
        existingSection.Capacity = entity.Capacity;
        existingSection.IsActive = entity.IsActive;
        existingSection.CourseId = entity.CourseId;

        _context.Sections.Update(existingSection);
        await _context.SaveChangesAsync();
        return existingSection;
    }

    public async Task<bool> Delete(int id)
    {
        var existingSection = await _context.Sections.FirstOrDefaultAsync(s => s.Id == id);
        if (existingSection == null) return false;

        _context.Sections.Remove(existingSection);
        await _context.SaveChangesAsync();
        return true;
    }
}