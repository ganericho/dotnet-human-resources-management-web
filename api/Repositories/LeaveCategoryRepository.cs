using api.Contracts;
using api.Database;
using api.Models;

namespace api.Repositories;

public class LeaveCategoryRepository : GeneralRepository<LeaveCategory>, ILeaveCategoryRepository
{
    public LeaveCategoryRepository(HumanResourcesDbContext context) : base(context)
    {
    }
}
