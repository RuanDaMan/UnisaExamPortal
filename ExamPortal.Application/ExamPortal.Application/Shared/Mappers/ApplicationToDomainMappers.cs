using ExamPortal.Application.Domain.Models;
using ExamPortal.Application.Shared.Dto;

namespace ExamPortal.Application.Shared.Mappers;

public static class ApplicationToDomainMappers
{
    public static ExamSetup Map(this ExamSetupDto data) => new()
    {
        Id = data.Id,
        ModuleCode = data.ModuleCode,
        ExamPaperPdf = data.ExamPaperPdf,
        StartDate = data.StartDate,
        EndDate = data.EndDate,
    };
}