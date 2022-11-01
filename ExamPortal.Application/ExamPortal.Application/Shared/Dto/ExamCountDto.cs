namespace ExamPortal.Application.Shared.Dto;

public class ExamCountDto
{
    public string ModuleCode { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int ExamsWritten { get; set; }
}