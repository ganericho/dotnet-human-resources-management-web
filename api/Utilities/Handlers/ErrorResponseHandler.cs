using System.Net;
using System.Security;

namespace api.Utilities.Handlers;

public class ErrorResponseHandler
{
    public int Code { get; set; }
    public string Status { get; set; } 
    public string Message { get; set; }

    public static ErrorResponseHandler InternalServerError(string message)
    {
        return new ErrorResponseHandler
        {
            Code = StatusCodes.Status500InternalServerError,
            Status = HttpStatusCode.InternalServerError.ToString(),
            Message = message
        };
    }

    public static ErrorResponseHandler NotFound(string message)
    {
        return new ErrorResponseHandler
        {
            Code = StatusCodes.Status404NotFound,
            Status = HttpStatusCode.NotFound.ToString(),
            Message = message
        };
    }

    public static ErrorResponseHandler Conflict(string message)
    {
        return new ErrorResponseHandler
        {
            Code = StatusCodes.Status409Conflict,
            Status = HttpStatusCode.Conflict.ToString(),
            Message = message
        };
    }
}
