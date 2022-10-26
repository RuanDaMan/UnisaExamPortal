using ExamPortal.Application.Domain.Models;

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
}