namespace api.Utilities.Handlers;

public class RepositoryHandler<T>
{
    public bool IsFailed { get; set; } = false;
    public string? Exception { get; set; } = MessageCollection.NoException;
    public T? Result { get; set; }
}
