using ExamPortal.Application.Shared.Dto;

namespace ExamPortal.Application.Shared.State;

public interface IAuthStateProvider
{
    public Task<(bool Valid, CurrentUserDto? User)> Authenticate(string number, string password, UserType type);
    public bool IsAuthenticated();
    public void Logout();
}