using System.ComponentModel.DataAnnotations.Schema;

namespace EPlatform.Domain.Entities;

public class Section
{
    public int Id { get; set; }
    public string DayOfWeed { get; set; } = string.Empty;
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public string Clasroom {get; set;} = string.Empty;
    public int Capacity {get; set;}
    public string IsActive { get; set; } = "true";
    
    public int CourseId { get; set; }
    [ForeignKey("CourseId")]
    public  Course course { get; set; }

    public List<Enrollment> enrollments = new List<Enrollment>();
}