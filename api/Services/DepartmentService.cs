using api.Contracts;
using api.Contracts.Services;
using api.Dtos.DepartmentData;
using api.Utilities;
using api.Utilities.Handlers;
using api.Utilities.ServiceResponses;

namespace api.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository departmentRepository;
    private readonly IEmployeeRepository employeeRepository;
    private readonly IAccountRepository accountRepository;
    private readonly IJobRepository jobRepository;

    public DepartmentService(IDepartmentRepository departmentRepository, IEmployeeRepository employeeRepository, IAccountRepository accountRepository, IJobRepository jobRepository)
    {
        this.departmentRepository = departmentRepository;
        this.employeeRepository = employeeRepository;
        this.accountRepository = accountRepository;
        this.jobRepository = jobRepository;
    }

    public ServiceResponse GetAll()
    {
        ServiceResponse response;
        try
        {
            // Get department data from repository.
            var getDepartment = departmentRepository.GetAll();

            if(getDepartment.Status == RepositoryStatus.FAILED)
            {
                throw new Exception(getDepartment.Message);
            }

            // Empty data return.
            if (!getDepartment.Result.Any())
            {
                response = OkResponse<IEnumerable<DepartmentDto>>.GetSuccess(Enumerable.Empty<DepartmentDto>());

                return response;
            }

            // Success return.
            IEnumerable<DepartmentDto> departmentDto = getDepartment.Result.Select(item => (DepartmentDto)item);

            response = OkResponse<IEnumerable<DepartmentDto>>.GetSuccess(departmentDto);

            return response;
        }
        catch(Exception ex)
        {
            response = ErrorResponse.InternalServerError(ex.Message);

            return response;
        }
    }
}
