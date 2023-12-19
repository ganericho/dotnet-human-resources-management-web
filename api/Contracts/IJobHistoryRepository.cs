using api.Models;
using api.Utilities.Handlers;

namespace api.Contracts;

public interface IJobHistoryRepository  : IGeneralRepository<JobHistory>
{
    public RepositoryHandler<IEnumerable<JobHistory>> GetByEmployeeGuid(Guid employeeGuid);
}
