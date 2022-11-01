using ClosedXML.Excel;
using ExamPortal.Application.Shared.Dto;

namespace ExamPortal.Application.Reports;

public static class TotalExamsWrittenPerModuleReport
{
    public static byte[] Generate(List<ExamCountDto> exams)
    {
        var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add();

        //Column Header

        string fileName = "Exams Written";
        var title = fileName;

        worksheet.Cell(1, 1).Value = title;

        var headerStyle = workbook.Style;
        headerStyle.Font.Bold = true;
        headerStyle.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        headerStyle.Font.FontSize = 16;

        worksheet.Range(1, 1, 1, 7).Style = headerStyle;
        worksheet.Range(1, 1, 1, 7).Merge();

        var row = 3;
        // column names 

        worksheet.Cell(row, 1).Value = "Module Code";
        worksheet.Cell(row, 2).Value = "Description";
        worksheet.Cell(row, 3).Value = "Count";

        var titlesStyle = workbook.Style;
        titlesStyle.Font.Bold = true;
        titlesStyle.Border.OutsideBorder = XLBorderStyleValues.Medium;
        titlesStyle.Border.OutsideBorderColor = XLColor.Black;
        titlesStyle.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
        titlesStyle.Font.FontSize = 12;


        // format all titles in one shot
        worksheet.Range(row, 1, row, 9).Style = titlesStyle;

        row += 1;
        foreach (var exam in exams)
        {
            worksheet.Cell(row, 1).Value = exam.ModuleCode;
            worksheet.Cell(row, 2).Value = exam.Description;
            worksheet.Cell(row, 3).Value = exam.ExamsWritten;
            row++;
        }

        worksheet.Columns().AdjustToContents(); // auto adjust cell to contents 

        MemoryStream memoryStream = new MemoryStream();
        workbook.SaveAs(memoryStream);
        memoryStream.Seek(0L, SeekOrigin.Begin);

        var content = memoryStream.ToArray();
        memoryStream.Close();
        return content;
    }
}