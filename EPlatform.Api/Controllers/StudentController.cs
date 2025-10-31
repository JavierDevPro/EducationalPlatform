using EPlatform.Application.Dtos;
using EPlatform.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EPlatform.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _service;

    public StudentController(IStudentService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StudentDto>>> GetAll()
    {
        try
        {
            var result = await _service.GetAll();
            return (result == null) ? NotFound():Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<ActionResult<StudentDto>> Create(StudentCreateDto studentToCreate)
    {
        try
        {
            var result = await _service.Create(studentToCreate);
            return (result != null)?Created($"/{result.Id}", result):NotFound();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return NotFound();
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<StudentDto>> Update(int Id, StudentUpdateDto studentToUpdate)
    {
        try
        {
            var result = await _service.Update(Id, studentToUpdate);
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return NotFound();
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<bool>> Delete(int Id)
    {
        try
        {
            var result = await _service.Delete(Id);
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return NotFound();
        }
    }
}