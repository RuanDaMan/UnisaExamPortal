using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ExamPortal.Shared;

public abstract class SharedComponent : ComponentBase
{
    [Inject] private IDialogService DialogService { get; set; } = default!;

    [Inject] protected ISnackbar Snackbar { get; set; } = default!;


    public void ShowError(string message, string title = "Error", string subject = "Error")
    {
        var messages = new List<string>() { message };
        ShowError(messages, title, subject);
    }

    public void ShowError(List<string> messages, string title = "Error", string subject = "Error")
    {
        if (title != "Error" && subject == "WorkList Error")
        {
            subject = title;
        }

        var parameters = new DialogParameters { { "Messages", messages }, { "Subject", subject } };
        var options = new DialogOptions() { MaxWidth = MaxWidth.Large };

        DialogService.Show<Error>(title, parameters, options);
    }
    

    public void ShowSuccess(string message)
    {
        Snackbar.Add(message, Severity.Success);
    }
}