using System.Net;

namespace api.Utilities.Handlers;

public class ResponseOkHandler
{
    public int Code { get; set; } = StatusCodes.Status200OK;
    public string Status { get; set; } = HttpStatusCode.OK.ToString();
    public string Message { get; set; } = MessageCollection.SuccessRetrieveData;
    public object? Data { get; set; } = MessageCollection.Empty;

    public ResponseOkHandler() { }

    public static ResponseOkHandler Success(object data)
    {
        return new ResponseOkHandler
        {
            Data = data
        };
    }

    public static ResponseOkHandler Success()
    {
        return new ResponseOkHandler();
    }
}
