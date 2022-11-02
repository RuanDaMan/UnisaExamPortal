namespace ExamPortal.Application.Shared.Dto;

public class CurrentUserDto
{
    public string Number { get; set; } = "";
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public UserType Type { get; set; }

    public CurrentUserDto()
    {
    }

    public CurrentUserDto(string number, string name, string email, UserType type)
    {
        Number = number;
        Name = name;
        Email = email;
        Type = type;
    }
}

public enum UserType
{
    Student,
    Lecturer,
    Staff
}