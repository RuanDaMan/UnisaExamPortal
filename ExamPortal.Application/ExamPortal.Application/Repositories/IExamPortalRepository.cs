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
    Task CreateExamSession(ExamSetupDto examSetup);
    Task<List<ExamSessionListItemDto>> AllExamSessions();
    Task<List<StudentModuleSessionDto>> GetStudentModuleSession(int studentNumber);
    Task<(string TransactionId, string ExamPaper, DateTime StartTime)> StartExamSession(string moduleCode, int studentNumber);
    Task SubmitExamSession(string examOutputId, string moduleCode, int studentNumber, string fileName);
    Task<(string TransactionId, bool Exist, DateTime? StartTime)> CheckExistingStudentExamSession(string moduleCode, int studentNumber);
}