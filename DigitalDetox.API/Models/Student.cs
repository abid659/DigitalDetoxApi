using System.ComponentModel.DataAnnotations;

namespace DigitalDetox.API.Models;

public class Student
{
    public int StudentId { get; set; }
    
    
    [MaxLength(50)]
    public string? Name { get; set; }
    public int Class { get; set; } // 3 or 4
    public int Roll { get; set; }


    public ICollection<StudentResponse>? StudentResponses { get; set; }
}
