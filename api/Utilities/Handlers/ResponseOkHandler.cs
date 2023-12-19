using System.Net;

namespace api.Utilities.Handlers;

public class ResponseOkHandler
{
    public int Code { get; set; } = StatusCodes.Status200OK;
    public string Status { get; set; } = HttpStatusCode.OK.ToString();
    public string Message { get; set; } = ResponseMessages.SuccessRetrieveData;
    public object? Data { get; set; } = ResponseMessages.Empty;

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

    public static ResponseOkHandler CreateSuccess()
    {
        return new ResponseOkHandler()
        {
            Message = ResponseMessages.DataCreatedSuccessfully
        };
    }

    public static ResponseOkHandler DeleteSuccess()
    {
        return new ResponseOkHandler()
        {
            Status = ResponseMessages.DataDeletedSuccessfully
        };
    }

    public static ResponseOkHandler UpdateSuccess()
    {
        return new ResponseOkHandler()
        {
            Status = ResponseMessages.DataUpdatedSuccessfully
        };
    }
}
