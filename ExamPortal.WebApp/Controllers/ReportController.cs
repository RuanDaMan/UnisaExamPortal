using ExamPortal.Application.Reports;
using ExamPortal.Application.Repositories;
using ExamPortal.Application.Shared.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamPortal.Controllers;

[Route("/ExcelReports")]
[ApiController]
public class ReportController : Controller
{
    private IExamPortalRepository Repository { get; set; }

    public ReportController(IExamPortalRepository repository)
    {
        Repository = repository;
    }

    // GET
    public IActionResult Index()
    {
        return Ok("OK");
    }

    [AllowAnonymous]
    [HttpGet]
    [Route("numberOfStudentsPerModule")]
    public async Task<IActionResult> NumberOfStudentsPerModuleXlsx([FromQuery] DateTime reportDate)
    {
        var data = await Repository.NumberOfStudentsPerModule(reportDate);
        var byteResult = NumberOfStudentsPerModuleReport.Generate(data);

        var attachment = new AttachmentDto()
        {
            ByteArray = byteResult,
            ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            FileName = $"Number Of Students Per Module - {reportDate: yyyy-MM-dd}.xlsx"
        };
        return File(attachment.ByteArray, attachment.ContentType, attachment.FileName);
    }

    [AllowAnonymous]
    [HttpGet]
    [Route("studentModulesBetweenDateRange")]
    public async Task<IActionResult> StudentModulesBetweenDateRangeXlsx([FromQuery] DateTime start, [FromQuery] DateTime end)
    {
        var data = await Repository.StudentModulesBetweenDateRange(start, end);
        var byteResult = StudentModulesBetweenDateRangeReport.Generate(data, start, end);

        var attachment = new AttachmentDto()
        {
            ByteArray = byteResult,
            ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            FileName = $"Student Modules Count.xlsx"
        };
        return File(attachment.ByteArray, attachment.ContentType, attachment.FileName);
    }

    [AllowAnonymous]
    [HttpGet]
    [Route("staffMemberOnDuty")]
    public async Task<IActionResult> StaffMemberOnDutyXlsx([FromQuery] DateTime reportDate)
    {
        var data = await Repository.StaffMemberOnDuty(reportDate);
        var byteResult = StaffMembersOnDutyReport.Generate(data);

        var attachment = new AttachmentDto()
        {
            ByteArray = byteResult,
            ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            FileName = $"Staff Members On Duty.xlsx"
        };
        return File(attachment.ByteArray, attachment.ContentType, attachment.FileName);
    }

    [AllowAnonymous]
    [HttpGet]
    [Route("totalExamsWrittenPerModule")]
    public async Task<IActionResult> TotalExamsWrittenPerModuleXlsx()
    {
        var data = await Repository.TotalExamsWrittenPerModule();
        var byteResult = TotalExamsWrittenPerModuleReport.Generate(data);

        var attachment = new AttachmentDto()
        {
            ByteArray = byteResult,
            ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            FileName = $"Total Exams Written Per Module.xlsx"
        };
        return File(attachment.ByteArray, attachment.ContentType, attachment.FileName);
    }
}