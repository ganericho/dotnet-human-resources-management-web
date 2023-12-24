using api.Dtos.DepartmentData;
using api.Utilities.ServiceResponses;

namespace api.Contracts.Services;

public interface IDepartmentService
{
    public ServiceResponse GetAll();

}
