using System.ComponentModel.DataAnnotations.Schema;

namespace webEscuela.Domain.Models;

public class Course
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt {get; set;}
    
    public int ProfessorId { get; set; }
    [ForeignKey("ProfessorId")]
    public  Professor professor { get; set; }

    public List<Section> sections = new List<Section>();
}