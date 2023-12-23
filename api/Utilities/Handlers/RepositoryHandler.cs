namespace api.Utilities.Handlers;

public class RepositoryHandler<T>
{
    public bool IsFailedOrEmpty { get; set; } = false;
    public ActionStatus Status { get; set; } = ActionStatus.SUCCESS;
    public Exception? Exception { get; set; } = new Exception("No exception.");
    public string? Message { get; set; } = ResponseMessages.SuccessRetrieveData;
    public T? Result { get; set; }
}
