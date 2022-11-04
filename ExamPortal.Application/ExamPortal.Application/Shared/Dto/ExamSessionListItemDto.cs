namespace ExamPortal.Application.Shared.Dto;

public class ExamSessionListItemDto
{
    public int Id { get; set; }
    public string ModuleCode { get; set; } = string.Empty;
    public string ModuleDescription { get; set; } = string.Empty;
    public string ExamPaperPdf { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}