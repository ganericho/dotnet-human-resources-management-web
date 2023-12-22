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

            return new RepositoryHandler<string>();
        }
        catch (Exception ex)
        {
            return new RepositoryHandler<string>()
            {
                Status = RepositoryStatus.ERROR,
                Exception = ex
            };
        }
    }

    public RepositoryHandler<string> Delete(T entity)
    {
        try
        {
            context.Set<T>().Remove(entity);
            context.SaveChanges();

            return new RepositoryHandler<string>();
        }
        catch (Exception ex)
        {
            return new RepositoryHandler<string>()
            {
                Status = RepositoryStatus.ERROR,
                Exception = ex
            };
        }
    }

    public RepositoryHandler<IEnumerable<T>> GetAll()
    {
        try
        {
            var getAll = context.Set<T>().ToList();

            var result = new RepositoryHandler<IEnumerable<T>>();

            if (!getAll.Any())
            {
                result.Status = RepositoryStatus.NOT_FOUND;
                result.Exception = new Exception($"{typeof(T).Name}s is empty");

                return result;
            }

            result.Result = getAll;

            return result;
        }
        catch (Exception ex)
        {
            return new RepositoryHandler<IEnumerable<T>>()
            {
                Status = RepositoryStatus.ERROR,
                Exception = ex
            };
        }
    }

    public RepositoryHandler<T> GetByGuid(Guid guid)
    {
        try
        {
            T? getData = context.Set<T>().Find(guid);

            var result = new RepositoryHandler<T>();

            if(getData is null)
            {
                result.Status = RepositoryStatus.NOT_FOUND;
                result.Exception = new Exception($"{typeof(T).Name}s is not found.");
                return result;
            }

            result.Result = getData;

            return result;
        }
        catch (Exception ex)
        {
            return new RepositoryHandler<T>()
            {
                Status = RepositoryStatus.ERROR,
                Exception = ex
            };
        }
    }

    public RepositoryHandler<string> Update(T entity)
    {
        try
        {
            context.Set<T>().Update(entity);
            context.SaveChanges();

            return new RepositoryHandler<string>();
        }
        catch (Exception ex)
        {
            return new RepositoryHandler<string>()
            {
                Status = RepositoryStatus.ERROR,
                Exception = ex
            };
        }
    }
}
