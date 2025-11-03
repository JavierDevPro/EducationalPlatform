namespace webEscuela.Application.DTOs
{
    public class ProfessorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string HireNumber { get; set; } = string.Empty;
        public string? CreateAt { get; set; }
        public int Course_id { get; set; }
    }

    public class CreateProfessorDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string HireNumber { get; set; } = string.Empty;
        public int Course_id { get; set; }
    }

    public class UpdateProfessorDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? HireNumber { get; set; }
        public int? Course_id { get; set; }
    }
}