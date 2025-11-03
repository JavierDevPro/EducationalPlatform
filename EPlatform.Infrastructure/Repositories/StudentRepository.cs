using EPlatform.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using webEscuela.Domain.Models;
using webEscuela.Infrastructure.Data;

namespace EPlatform.Infrastructure.Repositories;

public class StudentRepository : IStudentRepository<Student>
{
    private readonly AppDbContext _context;

    public StudentRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Student>> GetAll()
    {
        return await _context.Students.ToListAsync();
    }

    public async Task<Student> Create(Student entity)
    {
        var student = _context.Students.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Student> Update(int Id, Student entity)
    {
        var existingStudent = _context.Students.FirstOrDefault(s => s.Id == Id);
        if (existingStudent == null) return null;
        existingStudent.FirstName = entity.FirstName;
        existingStudent.LastName = entity.LastName;
        existingStudent.DocumentNumber = entity.DocumentNumber;
        existingStudent.Email = entity.Email;
        existingStudent.BirthDate = entity.BirthDate;
        existingStudent.Phone = entity.Phone;
        existingStudent.CreatedAt = entity.CreatedAt;

        _context.Students.Update(existingStudent);
        await _context.SaveChangesAsync();
        return existingStudent;
    }

    public async Task<bool> Delete(int Id)
    {
        var existingStudent = _context.Students.FirstOrDefault(s => s.Id == Id);
        if (existingStudent == null) return false;
        _context.Students.Remove(existingStudent);
        await _context.SaveChangesAsync();
        return true;
    }
    
    public async Task<bool> AlreadyExist(int Id)
    {
        var request = await _context.Professors.FirstOrDefaultAsync(c => c.Id == Id);
        return (request == null) ? false : true;
    }
}
    
