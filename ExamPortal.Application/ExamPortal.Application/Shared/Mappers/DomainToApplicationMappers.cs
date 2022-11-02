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
}