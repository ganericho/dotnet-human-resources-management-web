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
            string exceptionMessage = ExceptionHandler.GetMessage(ex);

            if (exceptionMessage.Contains("duplicate"))
            {
                return new RepositoryHandler<string>()
                {
                    Status = RepositoryStatus.CONFLICT,
                    Message = exceptionMessage
                };
            }

            return new RepositoryHandler<string>()
            {
                Status = RepositoryStatus.FAILED,
                Message = ExceptionHandler.GetMessage(ex)
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
                Status = RepositoryStatus.FAILED,
                Exception = ex
            };
        }
    }

    public RepositoryHandler<IEnumerable<T>> GetAll()
    {
        // Create repository result entity.
        var repository = new RepositoryHandler<IEnumerable<T>>();
        
        try
        {
            // Get all data from database.
            var getAll = context.Set<T>().ToList();

            repository.Result = getAll;

            // Return empty data.
            if (!getAll.Any())
            {
                repository.Message = Messages.Empty;

                return repository;
            }

            // Return with data.
            repository.Message = Messages.SuccessRetrieveData;

            return repository;
        }
        catch (Exception ex)
        {
            repository.Status = RepositoryStatus.FAILED;
            repository.Message = ExceptionHandler.GetMessage(ex);
            repository.Result = Enumerable.Empty<T>();

            return repository;
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
                Status = RepositoryStatus.FAILED,
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
                Status = RepositoryStatus.FAILED,
                Exception = ex
            };
        }
    }
}
