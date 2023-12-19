using api.Utilities.Handlers;

namespace api.Contracts;

public interface IGeneralRepository<T>
{
    RepositoryHandler<T> GetByGuid(Guid guid);
    RepositoryHandler<string> Update(T entity);
    RepositoryHandler<string> Create(T entity);
    RepositoryHandler<string> Delete(T entity);
    RepositoryHandler<IEnumerable<T>> GetAll();
}
