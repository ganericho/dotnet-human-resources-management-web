using api.Contracts;
using api.Database;
using api.Utilities;
using api.Utilities.Handlers;

namespace api.Repositories;

public class JobRepository : GeneralRepository<Job>, IJobRepository
{
    public JobRepository(HumanResourcesDbContext context) : base(context)
    {
    }

    public RepositoryHandler<Job> GetByCode(int code)
    {
        var repository = new RepositoryHandler<Job>();

        try
        {
            var data = base.context.Set<Job>().FirstOrDefault(job => job.Code == code);

            if(data is null)
            {
                repository.Status = RepositoryStatus.NOT_FOUND;
                repository.Exception = new Exception("Job not registered.");

                return repository;
            }

            repository.Result = data;

            return repository;
        }
        catch(Exception ex)
        {
            repository.Status = RepositoryStatus.ERROR;
            repository.Exception = ex;

            return repository;
        }
    }

    public RepositoryHandler<Job> GetByName(string name)
    {
        var repository = new RepositoryHandler<Job>();

        try
        {
            var data = base.context.Set<Job>().FirstOrDefault(job => job.Name.ToLower() == name.ToLower());


            if(data is null)
            {
                repository.Status = RepositoryStatus.NOT_FOUND;
                repository.Exception = new Exception("Job not registered.");

                return repository;
            }

            repository.Result = data;

            return repository;
        }
        catch (Exception ex)
        {
            repository.Status = RepositoryStatus.ERROR;
            repository.Exception = ex;

            return repository;
        }
    }
}
