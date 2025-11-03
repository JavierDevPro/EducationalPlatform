namespace webEscuela.Domain.Models;

public class Student
{
    public int Id { get; set; }
    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DocumentNumber { get; set; }
    public string Email { get; set; }
    public DateOnly BirthDate { get; set; }
    public string Phone { get; set; }
    public DateTime CreatedAt { get; set; }

    public List<Enrollment> enrollments = new List<Enrollment>();

}