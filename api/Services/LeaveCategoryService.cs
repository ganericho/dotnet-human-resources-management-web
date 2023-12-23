using api.Contracts;
using api.Contracts.Services;
using api.Dtos.LeaveDtos;
using api.Utilities;
using api.Utilities.Enums;
using api.Utilities.Handlers;

namespace api.Services;

public class LeaveCategoryService : ILeaveCategoryService
{
    private readonly ILeaveCategoryRepository leaveCategoryRepository;
    private readonly ILeaveRecordRepository leaveRecordRepository;

    public LeaveCategoryService(ILeaveCategoryRepository leaveCategoryRepository, ILeaveRecordRepository leaveRecordRepository)
    {
        this.leaveCategoryRepository = leaveCategoryRepository;
        this.leaveRecordRepository = leaveRecordRepository;
    }

    public ServiceHandler<bool> Create(CreateLeaveCategoryDto createData)
    {
        // Create leave category via repository.
        var createLeaveCategory = leaveCategoryRepository.Create(createData);

        // Create service handler entity.
        var service = new ServiceHandler<bool>
        {
            Status = createLeaveCategory.Status,
            Message = createLeaveCategory.Message
        };

        // Return failed result.
        if (createLeaveCategory.Status != ActionStatus.SUCCESS)
        {
            service.Result = false;

            return service;
        }

        // Return success result.
        service.Result = true;

        return service;
    }

    public ServiceHandler<bool> Delete(Guid guid)
    {
        throw new NotImplementedException();
    }

    public ServiceHandler<IEnumerable<LeaveCategoryDto>> GetAll()
    {
        // Get leave category data from repository.
        var getLeaveCategories = leaveCategoryRepository.GetAll();

        // Create service handler entity.
        var service = new ServiceHandler<IEnumerable<LeaveCategoryDto>>
        {
            Status = getLeaveCategories.Status,
            Message = getLeaveCategories.Message
        };

        // Return empty result;
        if (getLeaveCategories.Status != ActionStatus.SUCCESS)
        {
            service.Result = Enumerable.Empty<LeaveCategoryDto>();
            
            return service;
        }

        // Return with data.
        service.Result = getLeaveCategories.Result.Select(item => (LeaveCategoryDto)item);

        return service;
    }

    public ServiceHandler<LeaveCategoryDto> GetByGuid(Guid guid)
    {
        throw new NotImplementedException();
    }

    public ServiceHandler<bool> Update(LeaveCategoryDto updateData)
    {
        throw new NotImplementedException();
    }
}
