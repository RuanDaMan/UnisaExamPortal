namespace ExamPortal.Application.Domain.Models;

public class StudentSubmission
{
    public int StudentNumber { get; set; }
    public TimeSpan? UploadTime { get; set; }
    public string StudentName { get; set; } = string.Empty;
    public string StudentEmail { get; set; } = string.Empty;
    public string? FileName { get; set; }
}