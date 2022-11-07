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
    Task<List<Module>> AllModules(int staffNumber);
    Task CreateExamSession(ExamSetup examSetup);
    Task<List<ExamSessionListItemDto>> AllExamSessions(int staffNumber);
    Task<List<StudentModuleSessions>> GetStudentModuleSession(int studentNumber);
    Task<(string TransactionId, string ExamPaper, DateTime StartTime)> StartExamSession(string moduleCode, int studentNumber);
    Task<(string TransactionId, bool Exist, DateTime? StartTime)> CheckExistingStudentExamSession(string moduleCode, int studentNumber);
    Task SubmitExamSession(string examOutputId, string moduleCode, int studentNumber, string fileName);
    Task<(bool Valid, CurrentUserDto? User)> Authenticate(int number, string password, UserType type);
}