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
                Data = result
            };
        }
        catch (Exception ex)
        {
            return new RepositoryHandler<IEnumerable<Employee>>()
            {
                IsFailedOrEmpty = true,
                Exception = ex,
                Data = Enumerable.Empty<Employee>()
            };
        }
    }

    public RepositoryHandler<IEnumerable<Employee>> GetByJob(Guid jobGuid)
    {
        try
        {
            var getData = base.context.Set<Employee>().Where(employee => employee.JobGuid == jobGuid);

            var result = new RepositoryHandler<IEnumerable<Employee>>();

            if (!getData.Any())
            {
                result.Status = RepositoryStatus.NOT_FOUND;
            }

            result.Data = getData;

            return result;
            
        }
        catch (Exception ex)
        {
            return new RepositoryHandler<IEnumerable<Employee>>()
            {
                Status = RepositoryStatus.ERROR,
                Exception = ex
            };
        }
    }
}
