using Blazored.LocalStorage;
using ExamPortal.Application.Domain.DbRepositories;
using ExamPortal.Application.Repositories;
using ExamPortal.Application.Shared.State;
using ExamPortal.Extensions;
using ExamPortal.Infrastructure;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMudServices();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var connectionFactory = new MsSqlDbConnectionFactory(connectionString);
builder.Services.AddSingleton<IDbConnectionFactory>(connectionFactory);
builder.Services.AddSingleton<IExamPortalDbRepository, ExamPortalDbRepository>();
builder.Services.AddSingleton<IExamPortalRepository, ExamPortalRepository>();
builder.Services.AddScoped<IAuthStateProvider, AuthStateProvider>();

builder.Services.AddBlazoredLocalStorage();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.MapControllers();
app.MapBlazorHub();

app.MapFallbackToPage("/_Host");


app.Run();