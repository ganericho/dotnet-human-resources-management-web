namespace api.Utilities.Handlers;

public class ServiceHandler<T>
{
    public RepositoryStatus Status { get; set; }
    public string? Message { get; set; }
    public T? Result { get; set; }
}
