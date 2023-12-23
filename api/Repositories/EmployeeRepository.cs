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
            var getAll = base.context.Set<Employee>().Where(employee => employee.DepartmentGuid == departmentGuid);

            var result = new RepositoryHandler<IEnumerable<Employee>>();

            if (!getAll.Any())
            {
                result.Status = ActionStatus.NOT_FOUND;
                result.Exception = new Exception("Employees is empty");

                return result;
            }

            result.Result = getAll;

            return result;
        }
        catch (Exception ex)
        {
            return new RepositoryHandler<IEnumerable<Employee>>()
            {
                Status = ActionStatus.ERROR,
                Exception = ex
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
                result.Status = ActionStatus.NOT_FOUND;
            }

            result.Result = getData;

            return result;
            
        }
        catch (Exception ex)
        {
            return new RepositoryHandler<IEnumerable<Employee>>()
            {
                Status = ActionStatus.ERROR,
                Exception = ex
            };
        }
    }
}
