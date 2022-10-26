using ExamPortal.Application.Shared;

namespace ExamPortal.Application.Repositories;

public interface IExamPortalRepository
{
    Task<List<StudentDto>> GetStudents();
}