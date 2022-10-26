namespace ExamPortal.Application.Shared;

public class StudentDto
{
    public int StudentNumber { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}