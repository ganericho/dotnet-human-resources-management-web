using api.Models;
using api.Utilities.Handlers;

namespace api.Contracts;

public interface IRoleRepository : IGeneralRepository<Role>
{
    public RepositoryHandler<Role> GetByName(string name);
}
