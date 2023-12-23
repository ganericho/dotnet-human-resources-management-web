using api.Contracts;
using api.Database;
using api.Utilities;
using api.Utilities.Handlers;

namespace api.Repositories;

public class DepartmentRepository : GeneralRepository<Department>, IDepartmentRepository
{
    public DepartmentRepository(HumanResourcesDbContext context) : base(context)
    {
    }

    public RepositoryHandler<Department> GetByCode(int code)
    {
        var repository = new RepositoryHandler<Department>();

        try
        {
            var data = base.context.Set<Department>().FirstOrDefault(department => department.Code == code);

            if (data is null)
            {
                repository.Status = ActionStatus.NOT_FOUND;
                repository.Exception = new Exception("Department not registered.");

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

    public RepositoryHandler<Department> GetByName(string name)
    {
        var repository = new RepositoryHandler<Department>();

        try
        {
            var data = base.context.Set<Department>().FirstOrDefault(department => department.Name.ToLower() == name.ToLower());

            if (data is null)
            {
                repository.Status = ActionStatus.NOT_FOUND;
                repository.Exception = new Exception("Department not registered.");

                return repository;
            }

            repository.Result = data;

            return repository;
        }
        catch (Exception ex)
        {
            repository.Status = ActionStatus.ERROR;
            repository.Exception = ex;

            return repository;
        }
    }
}  
