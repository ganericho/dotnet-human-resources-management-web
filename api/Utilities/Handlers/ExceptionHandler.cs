namespace api.Utilities.Handlers;

public class ExceptionHandler
{
    public static string GetMessage(Exception ex)
    {
        if (ex.InnerException is null)
        {
            return ex.Message;
        }

        return $"{ex.InnerException.Message}";
    }
}
