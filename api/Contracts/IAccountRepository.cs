using api.Models;
using api.Utilities.Handlers;

namespace api.Contracts;

public interface IAccountRepository : IGeneralRepository<Account>
{
    public RepositoryHandler<Account> GetByEmail(string email);    
}
