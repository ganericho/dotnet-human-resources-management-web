using api.Models;
using api.Utilities.Handlers;

namespace api.Contracts;

public interface IJobRepository : IGeneralRepository<Job>
{
    public RepositoryHandler<Job> GetByName(string name);
    public RepositoryHandler<Job> GetByCode(int code);
}
