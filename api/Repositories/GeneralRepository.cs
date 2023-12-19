using api.Contracts;
using api.Database;
using api.Utilities;
using api.Utilities.Handlers;

namespace api.Repositories;

public class GeneralRepository<T> : IGeneralRepository<T> where T : class
{
    protected readonly HumanResourcesDbContext context;

    public GeneralRepository(HumanResourcesDbContext context)
    {
        this.context = context;
    }

    public RepositoryHandler<string> Create(T entity)
    {
        try
        {
            context.Set<T>().Add(entity);

            context.SaveChanges();

            return new RepositoryHandler<string>()
            {
                Result = MessageCollection.DataCreated
            };
        }
        catch (Exception ex)
        {
            return new RepositoryHandler<string>()
            {
                IsFailed = true,
                Exception = ex.Message,
                Result = MessageCollection.DataCreated
            };
        }
    }

    public RepositoryHandler<string> Delete(T entity)
    {
        try
        {
            context.Set<T>().Remove(entity);
            context.SaveChanges();

            return new RepositoryHandler<string>()
            {
                Result = MessageCollection.DataDeleted
            };
        }
        catch (Exception ex)
        {
            return new RepositoryHandler<string>()
            {
                IsFailed = true,
                Exception = ex.Message,
                Result = MessageCollection.NoResult
            };
        }
    }

    public RepositoryHandler<IEnumerable<T>> GetAll()
    {
        try
        {
            var result = context.Set<T>().ToList();

            return new RepositoryHandler<IEnumerable<T>>()
            {
                Result = result
            };
        }
        catch (Exception ex)
        {
            return new RepositoryHandler<IEnumerable<T>>()
            {
                IsFailed = true,
                Exception = ex.Message,
                Result = Enumerable.Empty<T>()
            };
        }
    }

    public RepositoryHandler<T> GetByGuid(Guid guid)
    {
        try
        {
            T? result = context.Set<T>().Find(guid);

            return new RepositoryHandler<T>()
            {
                Result = result
            };
        }
        catch (Exception ex)
        {
            return new RepositoryHandler<T>()
            {
                IsFailed = true,
                Exception = ex.Message
            };
        }
    }

    public RepositoryHandler<string> Update(T entity)
    {
        try
        {
            context.Set<T>().Update(entity);
            context.SaveChanges();

            return new RepositoryHandler<string>()
            {
                Result = MessageCollection.DataUpdated
            };
        }
        catch (Exception ex)
        {
            return new RepositoryHandler<string>()
            {
                IsFailed = true,
                Exception = ex.Message,
                Result = MessageCollection.NoResult
            };
        }
    }
}
