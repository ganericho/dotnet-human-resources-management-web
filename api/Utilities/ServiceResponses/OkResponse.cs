using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace api.Utilities.ServiceResponses;

public class OkResponse<T> : ServiceResponse
{
    public int Code { get; set; }
    public string? Status { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }

    public static OkResponse<T> GetSuccess(T data)
    {
        return new OkResponse<T>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = Messages.SuccessRetrieveData,
            Data = data
        };
    }
}
