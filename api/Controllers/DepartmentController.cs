using api.Contracts;
using api.Contracts.Services;
using api.Dtos.DepartmentData;
using api.Utilities;
using api.Utilities.Handlers;
using api.Utilities.ServiceResponses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentRepository departmentRepository;
    private readonly IEmployeeRepository employeeRepository;
    private readonly IAccountRepository accountRepository;
    private readonly IJobRepository jobRepository;
    private readonly IDepartmentService departmentService;

    public DepartmentController(IDepartmentRepository departmentRepository, IEmployeeRepository employeeRepository, IAccountRepository accountRepository, IJobRepository jobRepository, IDepartmentService departmentService)
    {
        this.departmentRepository = departmentRepository;
        this.employeeRepository = employeeRepository;
        this.accountRepository = accountRepository;
        this.jobRepository = jobRepository;
        this.departmentService = departmentService;
    }

    [HttpPost()]
    public IActionResult Create(CreateDepartmentDto createData)
    {
        try
        {
            // Create new department
            var createDepartment = departmentRepository.Create(createData);

            if (createDepartment.Status == RepositoryStatus.FAILED)
            {
                throw createDepartment.Exception;
            }

            // Success response
            return Ok(OkResponseHandler.CreateSuccess());
        }
        catch (Exception ex)
        {
            string? innerException = ex.InnerException.Message;

            if (innerException.Contains("code")) {
                return Conflict(ErrorResponseHandler.Conflict("Department code already registered."));
            }

            if (innerException.Contains("name"))
            {
                return Conflict(ErrorResponseHandler.Conflict("Department name already registered."));
            }

            return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponseHandler.InternalServerError(ex.Message));
        }
    }

    [HttpPut()]
    public IActionResult Update(DepartmentDto updateData)
    {
        try
        {
            // Get department data
            var getDepartment = departmentRepository.GetByGuid(updateData.Guid);

            if (getDepartment.Status == RepositoryStatus.FAILED)
            {
                throw getDepartment.Exception;
            }

            if (getDepartment.Status == RepositoryStatus.NOT_FOUND)
            {
                return NotFound(ErrorResponseHandler.NotFound("Department with specified ID not found."));
            }

            // Update department
            var department = getDepartment.Result;

            department.ModifiedDate = DateTime.Now;
            department.Name = updateData.Name;
            department.Code = updateData.Code;
            department.ManagerGuid = updateData.ManagerGuid;

            var updateDepartment = departmentRepository.Update(department);

            if (updateDepartment.Status == RepositoryStatus.FAILED)
            {
                throw updateDepartment.Exception;
            }

            // Success response
            return Ok(OkResponseHandler.UpdateSuccess());
        }
        catch (Exception ex)
        {
            string? innerException = ex.InnerException.Message;

            if (innerException.Contains("code"))
            {
                return Conflict(ErrorResponseHandler.Conflict("Department code already registered."));
            }

            if (innerException.Contains("name"))
            {
                return Conflict(ErrorResponseHandler.Conflict("Department name already registered."));
            }

            return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponseHandler.InternalServerError(ex.Message));
        }

    }

    [HttpDelete("{guid}")]
    public IActionResult Delete(Guid guid)
    {
        try
        {
            // Check department availability
            var getDepartment = departmentRepository.GetByGuid(guid);

            if (getDepartment.Status == RepositoryStatus.FAILED)
            {
                throw getDepartment.Exception;
            }

            if (getDepartment.Status == RepositoryStatus.NOT_FOUND)
            {
                return NotFound(ErrorResponseHandler.NotFound("Department with specified ID not found."));
            }

            // Delete department
            var deleteDepartment = departmentRepository.Delete(getDepartment.Result);

            if (deleteDepartment.Status == RepositoryStatus.FAILED)
            {
                throw deleteDepartment.Exception;
            }

            // Success response
            return Ok(OkResponseHandler.DeleteSuccess());
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponseHandler.InternalServerError(ex.Message));
        }
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        ServiceResponse getDepartments = departmentService.GetAll();

        switch (getDepartments.Code)
        {
            case StatusCodes.Status200OK:
                return Ok(getDepartments);

            default:
                return StatusCode(StatusCodes.Status500InternalServerError, getDepartments);
        }
    }

    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        try
        {
            // Get department data
            var getDepartment = departmentRepository.GetByGuid(guid);

            if(getDepartment.Status == RepositoryStatus.FAILED)
            {
                throw getDepartment.Exception;
            }

            if(getDepartment.Status == RepositoryStatus.NOT_FOUND)
            {
                return NotFound(ErrorResponseHandler.NotFound("Department with specified ID not found."));
            }

            // Create department detail DTO
            var departmentDetailDto = (DepartmentDetailDto)getDepartment.Result;

            // Get department Employee
            var getEmployees = employeeRepository.GetByDepartment(guid);

            if(getEmployees.Status == RepositoryStatus.FAILED)
            {
                throw getEmployees.Exception;
            }

            if(getEmployees.Status == RepositoryStatus.NOT_FOUND)
            {
                departmentDetailDto.Employees = Enumerable.Empty<DepartmentEmployeeDto>();

                return Ok(OkResponseHandler.Success(departmentDetailDto));
            }

            // Merge employees data
            var getAccounts = accountRepository.GetAll();

            if(getAccounts.Status == RepositoryStatus.FAILED)
            {
                throw getAccounts.Exception;
            }

            var getJobs = jobRepository.GetAll();

            if(getJobs.Status == RepositoryStatus.FAILED)
            {
                throw getJobs.Exception;
            }

            departmentDetailDto.Employees = from employee in getEmployees.Result
                                            join account in getAccounts.Result on employee.Guid equals account.Guid
                                            join job in getJobs.Result on employee.JobGuid equals job.Guid
                                            select new DepartmentEmployeeDto
                                            {
                                                Guid = employee.Guid,
                                                FirstName = employee.FirstName,
                                                LastName = employee.LastName,
                                                BirthDate = employee.BirthDate,
                                                HiringDate = employee.HiringDate,
                                                Gender = employee.Sex,
                                                PhoneNumber = employee.PhoneNumber,
                                                Email = account.Email,
                                                Job = job.Name
                                            };

            // Success response
            return Ok(OkResponseHandler.Success(departmentDetailDto));
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponseHandler.InternalServerError(ex.Message));
        }
    }

}
