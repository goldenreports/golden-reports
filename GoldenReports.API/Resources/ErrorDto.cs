namespace GoldenReports.API.Resources;

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