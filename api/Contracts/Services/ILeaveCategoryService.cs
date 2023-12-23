using api.Dtos.LeaveDtos;
using api.Models;
using api.Utilities;
using api.Utilities.Handlers;

namespace api.Contracts.Services;

public interface ILeaveCategoryService
{
    public ServiceHandler<IEnumerable<LeaveCategoryDto>> GetAll();
    public ServiceHandler<LeaveCategoryDto> GetByGuid(Guid guid);
    public ServiceHandler<bool> Create(CreateLeaveCategoryDto createData);
    public ServiceHandler<bool> Update(LeaveCategoryDto updateData);
    public ServiceHandler<bool> Delete(Guid guid);
   
}
