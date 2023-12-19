namespace api.Utilities.Handlers;

public class RepositoryHandler<T>
{
    public bool IsFailedOrEmpty { get; set; } = false;
    public RepositoryStatus Status { get; set; } = RepositoryStatus.SUCCESS;
    public Exception? Exception { get; set; }
    public T? Data { get; set; }
}
