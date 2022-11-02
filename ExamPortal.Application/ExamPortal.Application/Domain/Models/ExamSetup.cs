using Dapper;

namespace ExamPortal.Application.Domain.Models;

public class ExamSetup
{
    [Key] public int Id { get; set; }
    public string ModuleCode { get; set; } = string.Empty;
    [Column("ExamPaperPDF")] public string ExamPaperPdf { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}