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
        try
        {
            var result = base.context.Set<Job>().FirstOrDefault(job => job.Code == code);

            return new RepositoryHandler<Job>()
            {
                Result = result
            };
        }
        catch(Exception ex)
        {
            return new RepositoryHandler<Job>()
            {
                IsFailed = true,
                Exception = ex.Message
            };
        }
    }

    public RepositoryHandler<Job> GetByName(string name)
    {
        try
        {
            var result = base.context.Set<Job>().FirstOrDefault(job => job.Name.ToLower() == name.ToLower());

            return new RepositoryHandler<Job>()
            {
                Result = result
            };
        }
        catch (Exception ex)
        {
            return new RepositoryHandler<Job>()
            {
                IsFailed = true,
                Exception = ex.Message
            };
        }
    }
}
