using api.Dtos.ResponseDtos;
using System.Net;

namespace api.Utilities.Handlers;

public class ResponseHandler
{
    public static SuccessResponseDto<T> Ok<T>(string message, T data)
    {
        return new SuccessResponseDto<T> {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = message,
            Data = data
        };
    }

    public static SuccessResponseDto<T> Ok<T>(string message)
    {
        return new SuccessResponseDto<T>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = message
        };
    }

    public static ErrorResponseDto InternalServerError(string message)
    {
        return new ErrorResponseDto
        {
            Code = StatusCodes.Status500InternalServerError,
            Status = HttpStatusCode.InternalServerError.ToString(),
            Message = message
        };
    }

    public static ErrorResponseDto Conflict(string message)
    {
        return new ErrorResponseDto
        {
            Code = StatusCodes.Status409Conflict,
            Status = HttpStatusCode.Conflict.ToString(),
            Message = message
        };
    }
}
