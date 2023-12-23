using api.Contracts;
using api.Database;
using api.Utilities;
using api.Utilities.Handlers;

namespace api.Repositories;

public class RoleRepository : GeneralRepository<Role>, IRoleRepository
{
    public RoleRepository(HumanResourcesDbContext context) : base(context)
    {
    }

    public RepositoryHandler<Role> GetByName(string name)
    {
        var repository = new RepositoryHandler<Role>();

        try
        {
            var data = base.context.Set<Role>().FirstOrDefault(role => role.Name.ToLower() == name.ToLower());

            if (data is null)
            {
                repository.Status = ActionStatus.NOT_FOUND;
                repository.Exception = new Exception("Role not available.");

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
