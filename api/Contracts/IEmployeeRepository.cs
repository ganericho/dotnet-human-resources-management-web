using api.Models;
using api.Utilities.Handlers;

namespace api.Contracts;

public interface IEmployeeRepository : IGeneralRepository<Employee>
{
    public RepositoryHandler<IEnumerable<Employee>> GetByJob(Guid jobGuid);
    public RepositoryHandler<IEnumerable<Employee>> GetByDepartment(Guid departmentGuid);
}

