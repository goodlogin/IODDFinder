namespace IODDFinder.Models;

public class BaseResponse
{
    public bool HasError => !string.IsNullOrWhiteSpace(Error);
    public string? Error { get; set; }
    public string? Message { get; set; }
    public long? Timestamp { get; set; }
    public string? Code { get; set; }
}
