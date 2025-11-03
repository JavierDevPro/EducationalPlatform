namespace EPlatform.Application.Dtos
{
    public class CourseDto
    {
        public string Code { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int ProfessorId { get; set; }
    }
}