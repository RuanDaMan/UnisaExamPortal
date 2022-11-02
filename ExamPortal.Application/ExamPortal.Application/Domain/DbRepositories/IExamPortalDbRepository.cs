using ExamPortal.Application.Domain.Models;
using ExamPortal.Application.Shared.Dto;

namespace ExamPortal.Application.Domain.DbRepositories;

public interface IExamPortalDbRepository
{
    Task<List<Student>> GetStudents();
    Task<List<ModuleCountDto>> NumberOfStudentsPerModule(DateTime reportDate);
    Task<List<StudentModuleCountDto>> StudentModulesBetweenDateRange(DateTime start, DateTime end);
    Task<List<StaffMemberModuleDto>> StaffMemberOnDuty(DateTime day);
    Task<List<ExamCountDto>> TotalExamsWrittenPerModule();
    Task<List<Module>> AllModules();
}