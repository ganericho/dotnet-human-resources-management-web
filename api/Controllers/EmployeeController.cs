using api.Contracts;
using api.Database;
using api.Models;
using api.Utilities.Handlers;
using api;
using Microsoft.AspNetCore.Mvc;
using api.Utilities;
using api.Dtos.EmployeeData;
using System.Security.Principal;
using System.Data;
using api.Utilities.Sample;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly HumanResourcesDbContext context;
    private readonly IAccountRepository accountRepository;
    private readonly IAccountRoleRepository accountRoleRepository;
    private readonly IEmployeeRepository employeeRepository;
    private readonly IDepartmentRepository departmentRepository;
    private readonly IJobRepository jobRepository;
    private readonly IJobHistoryRepository jobHistoryRepository;
    private readonly IRoleRepository roleRepository;

    public EmployeeController(HumanResourcesDbContext context,
        IAccountRepository accountRepository,
        IAccountRoleRepository accountRoleRepository,
        IEmployeeRepository employeeRepository,
        IDepartmentRepository departmentRepository,
        IJobRepository jobRepository,
        IRoleRepository roleRepository,
        IJobHistoryRepository jobHistoryRepository)
    {
        this.context = context;
        this.accountRepository = accountRepository;
        this.accountRoleRepository = accountRoleRepository;
        this.employeeRepository = employeeRepository;
        this.departmentRepository = departmentRepository;
        this.jobRepository = jobRepository;
        this.roleRepository = roleRepository;
        this.jobHistoryRepository = jobHistoryRepository;
    }

    [HttpGet()]
    public IActionResult GetAllEmployee()
    {
        try
        {
            // Get all employee data from repository.
            var getEmployees = employeeRepository.GetAll();

            if (getEmployees.Status == RepositoryStatus.ERROR)
            {
                throw getEmployees.Exception;
            }

            if (getEmployees.Status == RepositoryStatus.NOT_FOUND)
            {
                return NotFound(ErrorResponseHandler.NotFound("Employees data is empty."));
            }

            // Get all account data from repository.
            var getAccounts = accountRepository.GetAll();

            if(getAccounts.Status != RepositoryStatus.SUCCESS)
            {
                throw getAccounts.Exception;
            }

            // Get all department data from repository.
            var getDepartments = departmentRepository.GetAll();

            if (getDepartments.Status != RepositoryStatus.SUCCESS)
            {
                throw getDepartments.Exception;
            }

            // Get all job data from repository.
            var getJobs = jobRepository.GetAll();

            if (getJobs.Status != RepositoryStatus.SUCCESS)
            {
                throw getJobs.Exception;
            }

            // Create employee details DTO.
            var employeeDetailsDto = from employee in getEmployees.Result
                                     join account in getAccounts.Result on employee.Guid equals account.Guid
                                     join department in getDepartments.Result on employee.DepartmentGuid equals department.Guid
                                     join job in getJobs.Result on employee.JobGuid equals job.Guid
                                     select new EmployeeDetailDto
                                     {
                                         Guid = employee.Guid,
                                         CreatedDate = employee.CreatedDate,
                                         ModifiedDate = employee.ModifiedDate,
                                         FirstName = employee.FirstName,
                                         LastName = employee.LastName,
                                         BirthDate = employee.BirthDate,
                                         HiringDate = employee.HiringDate,
                                         Gender = employee.Gender,
                                         Department = department.Name,
                                         Job = job.Name,
                                         Email = account.Email,
                                         PhoneNumber = employee.PhoneNumber,
                                         IsAccountDisabled = account.IsDisabled
                                     };

            // Success response.
            return Ok(OkResponseHandler.Success(employeeDetailsDto));
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponseHandler.InternalServerError(ex.Message));
        }
    }

    [HttpGet("{guid}")]
    public IActionResult GetEmployeeByGuid(Guid guid)
    {
        try
        {
            // Get employee data from repository.
            var getEmployee = employeeRepository.GetByGuid(guid);

            if (getEmployee.Status == RepositoryStatus.ERROR)
            {
                throw getEmployee.Exception;
            }

            if (getEmployee.Status == RepositoryStatus.NOT_FOUND)
            {
                return NotFound(ErrorResponseHandler.NotFound("Employee data with specified ID not found."));
            }

            var employee = getEmployee.Result;

            // Get employee account data from repository.
            var getAccount = accountRepository.GetByGuid(employee.Guid);

            if (getAccount.Status != RepositoryStatus.SUCCESS)
            {
                throw getAccount.Exception;
            }

            // Get department data from repository.
            var getDepartment = departmentRepository.GetByGuid(employee.DepartmentGuid);

            if (getDepartment.Status != RepositoryStatus.SUCCESS)
            {
                throw getDepartment.Exception;
            }
            
            // Get job data from repository.
            var getJob = jobRepository.GetByGuid(employee.JobGuid);

            if (getJob.Status != RepositoryStatus.SUCCESS)
            {
                throw getJob.Exception;
            }

            // Create employee detail DTO.
            var employeeDetailDto = new EmployeeDetailDto
            {
                Guid = employee.Guid,
                CreatedDate = employee.CreatedDate,
                ModifiedDate = employee.ModifiedDate,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                BirthDate = employee.BirthDate,
                HiringDate = employee.HiringDate,
                Gender = employee.Gender,
                Department = getDepartment.Result.Name,
                Job = getJob.Result.Name,
                Email = getAccount.Result.Email,
                PhoneNumber = employee.PhoneNumber,
                IsAccountDisabled = getAccount.Result.IsDisabled
            };

            // Success response.
            return Ok(OkResponseHandler.Success(employeeDetailDto));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponseHandler.InternalServerError(ex.Message));
        }
    }


    [HttpDelete("{guid}")]
    public IActionResult DeleteEmployee(Guid guid)
    {
        try
        {
            // Get employee data from repository.
            var getEmployee = employeeRepository.GetByGuid(guid);

            if (getEmployee.Status == RepositoryStatus.ERROR)
            {
                throw getEmployee.Exception;
            }

            if (getEmployee.Status == RepositoryStatus.NOT_FOUND)
            {
                return NotFound(ErrorResponseHandler.NotFound("Employee with specified ID not found."));
            }

            // Delete employee data.
            var deleteEmployee = employeeRepository.Delete(getEmployee.Result);

            if (deleteEmployee.Status != RepositoryStatus.SUCCESS)
            {
                throw deleteEmployee.Exception;
            }

            // Success response.
            return Ok(OkResponseHandler.DeleteSuccess());
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponseHandler.InternalServerError(ex.Message));
        }
    }

    [HttpPost]
    public IActionResult RegisterEmployee(CreateEmployeeDto createData)
    {
        using var transaction = context.Database.BeginTransaction();
        try
        {
            // Check new employee job, department and role availability.
            var getJob = jobRepository.GetByCode(createData.JobCode);

            if(getJob.Status != RepositoryStatus.SUCCESS)
            {
                throw getJob.Exception;
            }

            var getDepartment = departmentRepository.GetByCode(createData.DepartmentCode);

            if(getDepartment.Status != RepositoryStatus.SUCCESS)
            {
                throw getDepartment.Exception;
            }

            var getRole = roleRepository.GetByName(createData.Role);

            if (getRole.Status != RepositoryStatus.SUCCESS)
            {
                throw getRole.Exception;
            }

            // Create employee data to database.
            Employee employee = createData;
            employee.JobGuid = getJob.Result.Guid;
            employee.DepartmentGuid = getDepartment.Result.Guid;

            var createEmployee = employeeRepository.Create(employee);

            if (createEmployee.Status != RepositoryStatus.SUCCESS)
            {
                throw createEmployee.Exception;
            }

            // Create account data to database.
            Account account = new Account()
            {
                Guid = employee.Guid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Email = createData.Email,
                Password = HashHandler.Password(createData.Password),
                IsDisabled = false,
                Otp = 0,
                IsOtpUsed = true,
                OtpExpireTime = DateTime.Now
            };

            var createAccount = accountRepository.Create(account);

            if (createAccount.Status != RepositoryStatus.SUCCESS)
            {
                throw createAccount.Exception;
            }

            // Create account role data to database.
            AccountRole accountRole = new AccountRole
            {
                Guid = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                AccountGuid = employee.Guid,
                RoleGuid = getRole.Result.Guid
            };

            var createAccountRole = accountRoleRepository.Create(accountRole);

            if(createAccountRole.Status != RepositoryStatus.SUCCESS)
            {
                throw createAccountRole.Exception;
            }

            // Create job history data to database.
            JobHistory jobHistory = new JobHistory
            {
                Guid = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                EmployeeGuid = employee.Guid,
                JobGuid = getJob.Result.Guid,
                StartDate = createData.HiringDate,
                EndDate = null
            };

            var createJobHistory = jobHistoryRepository.Create(jobHistory);

            if(createJobHistory.Status != RepositoryStatus.SUCCESS)
            {
                throw createJobHistory.Exception;
            }

            // Commit changes to database.
            transaction.Commit();

            // Success response.
            return Ok(OkResponseHandler.CreateSuccess());
        }
        catch(Exception ex)
        {
            context.Database.RollbackTransaction();

            var exceptionMessage = ExceptionHandler.GetMessage(ex);

            if (exceptionMessage.Contains("email"))
            {
                return Conflict(ErrorResponseHandler.Conflict("Email has already registered."));
            }

            if (exceptionMessage.Contains("phone_number"))
            {
                return Conflict(ErrorResponseHandler.Conflict("Phone number has already registered."));
            }

            return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponseHandler.InternalServerError(ex.Message));
        }
    }
  
}
