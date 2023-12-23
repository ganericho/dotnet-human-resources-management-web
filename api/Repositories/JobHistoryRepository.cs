using api.Contracts;
using api.Database;
using api.Utilities;
using api.Utilities.Handlers;

namespace api.Repositories;

public class JobHistoryRepository : GeneralRepository<JobHistory>, IJobHistoryRepository
{
    public JobHistoryRepository(HumanResourcesDbContext context) : base(context)
    {
    }

    public RepositoryHandler<IEnumerable<JobHistory>> GetByEmployeeGuid(Guid employeeGuid)
    {
        var repository = new RepositoryHandler<IEnumerable<JobHistory>>();

        try
        {
            var data = base.context.Set<JobHistory>().Where(jobHistory => jobHistory.EmployeeGuid == employeeGuid);

            if (!data.Any())
            {
                repository.Status = ActionStatus.NOT_FOUND;
                repository.Exception = new Exception("Job history not found.");

                return repository;
            }

            repository.Result = data;

            return repository;
        }
        catch(Exception ex)
        {
            repository.Status = ActionStatus.ERROR;
            repository.Exception = ex;

            return repository;
        }
    }
}
