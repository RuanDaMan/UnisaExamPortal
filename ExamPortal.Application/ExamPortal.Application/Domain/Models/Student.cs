using Dapper;

namespace ExamPortal.Application.Domain.Models;

[Table("StudentInfo")]
public class Student
{
    [Key] public int StudentNumber { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}