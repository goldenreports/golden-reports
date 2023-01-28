namespace GoldenReports.Application.DTOs.Common;

public class ErrorDto
{
    public ErrorDto(int errorCode, string errorMessage)
    {
        this.ErrorCode = errorCode;
        this.ErrorMessage = errorMessage;
    }

    public int ErrorCode { get; set; }
    public string ErrorMessage { get; set; }
}