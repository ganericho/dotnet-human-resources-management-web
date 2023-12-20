using System.Net;

namespace api.Utilities.Handlers;

public class OkResponseHandler
{
    public int Code { get; set; } = StatusCodes.Status200OK;
    public string Status { get; set; } = HttpStatusCode.OK.ToString();
    public string Message { get; set; } = ResponseMessages.SuccessRetrieveData;
    public object? Data { get; set; } = ResponseMessages.Empty;

    public OkResponseHandler() { }

    public static OkResponseHandler Success(object data)
    {
        return new OkResponseHandler
        {
            Data = data
        };
    }

    public static OkResponseHandler Success()
    {
        return new OkResponseHandler();
    }

    public static OkResponseHandler CreateSuccess()
    {
        return new OkResponseHandler()
        {
            Message = ResponseMessages.DataCreatedSuccessfully
        };
    }

    public static OkResponseHandler DeleteSuccess()
    {
        return new OkResponseHandler()
        {
            Status = ResponseMessages.DataDeletedSuccessfully
        };
    }

    public static OkResponseHandler UpdateSuccess()
    {
        return new OkResponseHandler()
        {
            Status = ResponseMessages.DataUpdatedSuccessfully
        };
    }
}
