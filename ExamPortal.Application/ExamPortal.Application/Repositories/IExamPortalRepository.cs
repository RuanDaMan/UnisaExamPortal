using ExamPortal.Application.Shared;
using ExamPortal.Application.Shared.Dto;

namespace ExamPortal.Application.Repositories;

public interface IExamPortalRepository
{
    Task<List<StudentDto>> GetStudents();
}