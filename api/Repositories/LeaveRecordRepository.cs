using api.Contracts;
using api.Database;
using api.Models;

namespace api.Repositories;

public class LeaveRecordRepository : GeneralRepository<LeaveRecord>, ILeaveRecordRepository
{
    public LeaveRecordRepository(HumanResourcesDbContext context) : base(context)
    {
    }
}
