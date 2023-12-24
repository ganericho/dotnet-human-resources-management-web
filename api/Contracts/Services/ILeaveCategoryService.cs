using api.Dtos.LeaveDtos;
using api.Models;
using api.Utilities;
using api.Utilities.Handlers;
using api.Utilities.ServiceResponses;

namespace api.Contracts.Services;

public interface ILeaveCategoryService
{
    public ServiceResponse GetAll();
    public ServiceResponse GetByGuid(Guid guid);
    public ServiceResponse Create(CreateLeaveCategoryDto createData);
    public ServiceResponse Update(LeaveCategoryDto updateData);
    public ServiceResponse Delete(Guid guid);
   
}
