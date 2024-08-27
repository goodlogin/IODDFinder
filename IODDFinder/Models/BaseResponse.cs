namespace IODDFinder.Models;

public class BaseResponse
{
    public string? Error { get; set; }
    public string? Message { get; set; }
    public long? Timestamp { get; set; }
    public string? Code { get; set; }
}
