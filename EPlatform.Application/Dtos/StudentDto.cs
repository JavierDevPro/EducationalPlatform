namespace EPlatform.Application.Dtos;

public class StudentDto
{

public int Id { get; set; }
public string FirstName {get; set;} 
public string LastName {get; set;}
public string DocumentNumber {get; set;}
public string Email {get; set;}
public string? Phone {get; set;}
    
public DateOnly BirthDate { get; set; }

public DateTime CreatedAt { get; set; }
}

public class StudentCreateDto
{
    public string FirstName {get; set;} 
    public string LastName {get; set;}
    public string DocumentNumber {get; set;}
    public string Email {get; set;}
    public string? Phone {get; set;}
    
    
    public DateOnly BirthDate { get; set; }

    public DateTime CreatedAt { get; set; }
}

public class StudentUpdateDto
{
    public string FirstName {get; set;} 
    public string LastName {get; set;}
    public string DocumentNumber {get; set;}
    public string Email {get; set;}
    public string? Phone {get; set;}

    public DateOnly BirthDate { get; set; }

    public DateTime CreatedAt { get; set; }
}