using api.Contracts;
using api.Database;
using api.Utilities;
using api.Utilities.Handlers;

namespace api.Repositories;

public class EmployeeRepository : GeneralRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(HumanResourcesDbContext context) : base(context)
    {
    }

    public RepositoryHandler<IEnumerable<Employee>> GetByDepartment(Guid departmentGuid)
    {
        try
        {
            var result = base.context.Set<Employee>().Where(employee => employee.DepartmentGuid == departmentGuid);

            return new RepositoryHandler<IEnumerable<Employee>>()
            {
                Result = result
            };
        }
        catch (Exception ex)
        {
            return new RepositoryHandler<IEnumerable<Employee>>()
            {
                IsFailed = true,
                Exception = ex.Message,
                Result = Enumerable.Empty<Employee>()
            };
        }
    }

    public RepositoryHandler<IEnumerable<Employee>> GetByJob(Guid jobGuid)
    {
        try
        {
            var result = base.context.Set<Employee>().Where(employee => employee.JobGuid == jobGuid);

            return new RepositoryHandler<IEnumerable<Employee>>()
            {
                Result = result
            };
        }
        catch (Exception ex)
        {
            return new RepositoryHandler<IEnumerable<Employee>>()
            {
                IsFailed = true,
                Exception = ex.Message,
                Result = Enumerable.Empty<Employee>()
            };
        }
    }
}
