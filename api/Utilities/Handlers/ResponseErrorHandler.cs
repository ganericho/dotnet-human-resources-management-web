using System.Net;
using System.Security;

namespace api.Utilities.Handlers;

public class ResponseErrorHandler
{
    public int Code { get; set; }
    public string Status { get; set; } 
    public string Message { get; set; }

    public static ResponseErrorHandler InternalServerError(string message)
    {
        return new ResponseErrorHandler
        {
            Code = StatusCodes.Status500InternalServerError,
            Status = HttpStatusCode.InternalServerError.ToString(),
            Message = message
        };
    }

    public static ResponseErrorHandler NotFound(string message)
    {
        return new ResponseErrorHandler
        {
            Code = StatusCodes.Status404NotFound,
            Status = HttpStatusCode.NotFound.ToString(),
            Message = message
        };
    }
}
