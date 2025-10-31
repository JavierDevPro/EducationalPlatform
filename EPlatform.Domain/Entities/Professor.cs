using EPlatform.Domain.Entities;

namespace webEscuela.Domain.Entities
{
    public class Professor
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string HireNumber { get; set; } = string.Empty;

        // Relación: un profesor puede tener muchos cursos
        public ICollection<Course>? Courses { get; set; }
    }
}