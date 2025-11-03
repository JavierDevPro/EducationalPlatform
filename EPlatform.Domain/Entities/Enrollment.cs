using System.ComponentModel.DataAnnotations.Schema;

namespace webEscuela.Domain.Models;

public class Enrollment
{
    public int Id { get; set; }
    public int Cancelled { get; set; }
    public DateTime EnrolledAt { get; set; }
    
    public int SectionId { get; set; }
    [ForeignKey("SectionId")]
    public  Section section { get; set; }
    
    public int StudentId { get; set; }
    [ForeignKey("StudentId")]
    public  Student student { get; set; }
    
    public int GradeId { get; set; }
    [ForeignKey("GradeId")]
    public  Grade grade { get; set; }

}