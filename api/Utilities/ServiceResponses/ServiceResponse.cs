namespace api.Utilities.ServiceResponses;

public abstract class ServiceResponse
{
    public int Code { get; set; }
    public string? Status { get; set; }
    public string? Message { get; set; }
}
