using System.Runtime.InteropServices.JavaScript;
using EPlatform.Application.Dtos;
using EPlatform.Application.Interfaces;
using EPlatform.Domain.Entities;
using EPlatform.Domain.Interfaces;

namespace Institution.Application.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository<Student> _repository;
    
    public StudentService(IStudentRepository<Student> repository)
    {
        _repository = repository;
    }
    
    //MapDto
    public StudentDto MapDto(Student student)
    {
        var Student = new StudentDto
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            DocumentNumber = student.DocumentNumber,
            Email = student.Email,
            Phone = student.Phone,
            CreatedAt = student.CreatedAt,
            BirthDate = student.BirthDate
        };
        return Student;
    } 
    
    public async Task<IEnumerable<StudentDto>> GetAll()
    {
        var students = await _repository.GetAll();
        return students.Select(MapDto);
    }

    public async Task<StudentDto>? Create(StudentCreateDto entity)
    {
        var student = new Student
        {
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            DocumentNumber = entity.DocumentNumber,
            Email = entity.Email,
            Phone = entity.Phone,
            BirthDate = entity.BirthDate
        };
        var studentDto = await _repository.Create(student);
        return MapDto(studentDto);
    }

    public async Task<StudentDto> Update(int Id, StudentUpdateDto entity)
    {
        var maped = new Student
        {
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            DocumentNumber = entity.DocumentNumber,
            Email = entity.Email,
            Phone = entity.Phone,
            BirthDate = entity.BirthDate
        };
        var student = await _repository.Update(Id,maped);
        return MapDto(student);
    }

    public async Task<bool> Delete(int Id)
    {
        return await _repository.Delete(Id);
    }
}