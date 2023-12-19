using api.Models;
using api.Utilities.Handlers;

namespace api.Contracts;

public interface IAccountRoleRepository : IGeneralRepository<AccountRole>
{
    public RepositoryHandler<IEnumerable<AccountRole>> GetByAccountGuid(Guid accountGuid);
}
