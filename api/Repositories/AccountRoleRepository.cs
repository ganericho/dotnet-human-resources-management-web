using api.Contracts;
using api.Database;
using api.Models;
using api.Utilities;
using api.Utilities.Handlers;

namespace api.Repositories;

public class AccountRoleRepository : GeneralRepository<AccountRole>, IAccountRoleRepository
{
    public AccountRoleRepository(HumanResourcesDbContext context) : base(context)
    {
    }
    public RepositoryHandler<IEnumerable<AccountRole>> GetByAccountGuid(Guid accountGuid)
    {
        try
        {
            var result = base.context.Set<AccountRole>().Where(accountRole => accountRole.AccountGuid == accountGuid);

            return new RepositoryHandler<IEnumerable<AccountRole>>()
            {
                Result = result
            };
        }
        catch(Exception ex)
        {
            return new RepositoryHandler<IEnumerable<AccountRole>>()
            {
                IsFailedOrEmpty = true,
                Exception = ex,
                Result = Enumerable.Empty<AccountRole>()
            };
        }
    }
}
