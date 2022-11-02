using ExamPortal.Application.Shared;
using ExamPortal.Application.Shared.Dto;

namespace ExamPortal.Application.Repositories;

public interface IExamPortalRepository
{
    Task<List<StudentDto>> GetStudents();
    Task<List<ModuleCountDto>> NumberOfStudentsPerModule(DateTime reportDate);
    Task<List<StudentModuleCountDto>> StudentModulesBetweenDateRange(DateTime start, DateTime end);
    Task<List<StaffMemberModuleDto>> StaffMemberOnDuty(DateTime day);
    Task<List<ExamCountDto>> TotalExamsWrittenPerModule();
    Task<List<ModuleDto>> AllModules();
}