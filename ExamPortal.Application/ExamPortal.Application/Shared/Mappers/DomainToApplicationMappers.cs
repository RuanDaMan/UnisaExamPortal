using ExamPortal.Application.Domain.Models;
using ExamPortal.Application.Shared.Dto;

namespace ExamPortal.Application.Shared.Mappers;

public static class DomainToApplicationMappers
{
    public static StudentDto Map(this Student data) => new StudentDto()
    {
        Name = data.Name,
        StudentNumber = data.StudentNumber,
        Email = data.Email,
        Password = data.Password
    };

    public static ModuleDto Map(this Module data) => new()
    {
        ModuleCode = data.ModuleCode,
        Description = data.Description
    };

    public static ExamSetupDto Map(this ExamSetup data) => new()
    {
        Id = data.Id,
        ModuleCode = data.ModuleCode,
        ExamPaperPdf = data.ExamPaperPdf,
        StartDate = data.StartDate,
        EndDate = data.EndDate,
    };

    public static StudentModuleSessionDto Map(this StudentModuleSessions data) => new()
    {
        ModuleCode = data.ModuleCode,
        ModuleDescription = data.ModuleDescription,
        SessionActive = DateTime.Now.Ticks > data.StartDate.Ticks && DateTime.Now.Ticks < data.EndDate.Ticks,
        StartTime = data.StartDate,
        EndTime = data.EndDate,
    };
}