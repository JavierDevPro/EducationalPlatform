namespace EPlatform.Application.Dtos;

public class SectionDto
{

    public int Id { get; set; }
    public string DayOfWeed { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public string Clasroom {get; set;}
    public int Capacity {get; set;}
    public string IsActive { get; set; }
    
    public int CourseId { get; set; }
}

public class SectionCreateDto
{
    public int Id { get; set; }
    public string DayOfWeed { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public string Clasroom {get; set;}
    public int Capacity {get; set;}
    public string IsActive { get; set; }
    
    public int CourseId { get; set; }
}

public class SectionUpdateDto
{
    public int Id { get; set; }
    public string DayOfWeed { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public string Clasroom {get; set;}
    public int Capacity {get; set;}
    public string IsActive { get; set; }
    
    public int CourseId { get; set; }
}