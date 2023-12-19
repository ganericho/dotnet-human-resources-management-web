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
        try
        {
            var result = base.context.Set<JobHistory>().Where(jobHistory => jobHistory.EmployeeGuid == employeeGuid);

            return new RepositoryHandler<IEnumerable<JobHistory>>()
            {
                Data = result
            };
        }
        catch(Exception ex)
        {
            return new RepositoryHandler<IEnumerable<JobHistory>>()
            {
                IsFailedOrEmpty = true,
                Exception = ex,
                Data = Enumerable.Empty<JobHistory>()
            };
        }
    }
}
