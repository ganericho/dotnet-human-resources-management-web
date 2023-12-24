namespace api.Utilities.Handlers;

public class RepositoryHandler<T>
{
    public bool IsFailedOrEmpty { get; set; } = false;
    public RepositoryStatus Status { get; set; } = RepositoryStatus.SUCCESS;
    public Exception? Exception { get; set; } = new Exception("No exception.");
    public string? Message { get; set; } = Messages.SuccessRetrieveData;
    public T? Result { get; set; }
}
