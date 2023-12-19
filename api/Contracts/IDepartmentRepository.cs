using api.Models;
using api.Utilities.Handlers;

namespace api.Contracts;

public interface IDepartmentRepository : IGeneralRepository<Department>
{
    public RepositoryHandler<Department> GetByName(string name);
    public RepositoryHandler<Department> GetByCode(int code);
}
