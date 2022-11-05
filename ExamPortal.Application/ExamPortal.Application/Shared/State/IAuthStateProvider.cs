using ExamPortal.Application.Shared.Dto;

namespace ExamPortal.Application.Shared.State;

public interface IAuthStateProvider
{
    public Task<(bool Valid, CurrentUserDto? User)> Authenticate(int number, string password, UserType type);
    public bool IsAuthenticated();
    public void Logout();
    public CurrentUserDto GetCurrentUser();
    public void SetUserType(UserType type);
    public void SetAuthenticated(CurrentUserDto user);
}