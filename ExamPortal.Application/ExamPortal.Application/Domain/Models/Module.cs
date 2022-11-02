using Dapper;

namespace ExamPortal.Application.Domain.Models;

[Table("ModuleInfo")]
public class Module
{
    public string ModuleCode { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}