namespace webEscuela.Domain.Models;

public class Professor
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string HireNumber { get; set; }
    public string CreatedAt { get; set; }

    public List<Course> courses = new List<Course>();
}