namespace ExamPortal.Application.Shared.Dto;

public class StudentModuleCountDto
{
    public string StudentNumber { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int NumberOfModules { get; set; }
}