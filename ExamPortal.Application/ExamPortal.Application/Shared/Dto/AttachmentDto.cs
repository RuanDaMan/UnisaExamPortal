namespace ExamPortal.Application.Shared.Dto;

public class AttachmentDto
{
    public byte[] ByteArray { get; set; } = default!;
    public string FileName { get; set; } = default!;
    public string ContentType { get; set; } = default!;
}