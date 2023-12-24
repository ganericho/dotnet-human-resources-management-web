using System.Net;

namespace api.Utilities.ServiceResponses;

public class ErrorResponse : ServiceResponse
{
    public int Code { get; set; }
    public string? Status { get; set; }
    public string? Message { get; set; }
    public static ErrorResponse InternalServerError(string message) 
    {
        return new ErrorResponse
        {
            Code = StatusCodes.Status500InternalServerError,
            Status = HttpStatusCode.InternalServerError.ToString(),
            Message = message
        };
    }
}
