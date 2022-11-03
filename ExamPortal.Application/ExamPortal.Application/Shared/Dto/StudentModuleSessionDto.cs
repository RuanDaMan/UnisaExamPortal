namespace ExamPortal.Application.Shared.Dto;

public class StudentModuleSessionDto
{
    public string ModuleCode { get; set; } = string.Empty;
    public string ModuleDescription { get; set; } = string.Empty;
    public bool SessionActive { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

}