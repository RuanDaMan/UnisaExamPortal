namespace ExamPortal.Application.Domain.Models;

public class StudentModuleSessions
{
    public string ModuleCode { get; set; } = string.Empty;
    public string ModuleDescription { get; set; } = string.Empty;
    public bool SessionActive { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    

}