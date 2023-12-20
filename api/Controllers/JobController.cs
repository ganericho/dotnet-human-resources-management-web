using api.Contracts;
using api.Dtos.JobDto;
using api.Dtos.JobDtos;
using api.Utilities;
using api.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobController : ControllerBase
{

    private readonly IDepartmentRepository departmentRepository;
    private readonly IEmployeeRepository employeeRepository;
    private readonly IAccountRepository accountRepository;
    private readonly IJobRepository jobRepository;

    public JobController(IDepartmentRepository departmentRepository, IEmployeeRepository employeeRepository, IAccountRepository accountRepository, IJobRepository jobRepository)
    {
        this.departmentRepository = departmentRepository;
        this.employeeRepository = employeeRepository;
        this.accountRepository = accountRepository;
        this.jobRepository = jobRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            var getJobs = jobRepository.GetAll();

            if (getJobs.IsFailedOrEmpty)
            {
                throw getJobs.Exception;
            }

            // Convert repository result to dto format
            IEnumerable<JobDto> jobDto = getJobs.Result.Select(job => (JobDto) job);

            return Ok(OkResponseHandler.Success(jobDto));
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponseHandler.InternalServerError(ex.Message));
        }
    }

    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        try
        {
            // Get job data with specified id.
            var getJob = jobRepository.GetByGuid(guid);

            if(getJob.Status == RepositoryStatus.ERROR)
            {
                throw getJob.Exception;
            }

            if(getJob.Status == RepositoryStatus.NOT_FOUND)
            {
                return NotFound(ErrorResponseHandler.NotFound("Job with specified ID not found."));
            }

            // Create Job Detail Dto
            JobDetailDto jobDetailDto = (JobDetailDto) getJob.Result;

            // Get a list of employees with related jobs.
            var getEmployees = employeeRepository.GetByJob(guid);

            if(getEmployees.Status == RepositoryStatus.ERROR)
            {
                throw getEmployees.Exception;
            }

            if(getEmployees.Status == RepositoryStatus.NOT_FOUND)
            {
                jobDetailDto.Employees = Enumerable.Empty<JobEmployeeDto>();
                
                return Ok(OkResponseHandler.Success(jobDetailDto));
            }

            // Get Accounts and Departments
            var getAccounts = accountRepository.GetAll();

            if (getAccounts.Status != RepositoryStatus.SUCCESS)
            {
                throw getAccounts.Exception;
            }

            var getDepartments = departmentRepository.GetAll();

            if (getDepartments.Status != RepositoryStatus.SUCCESS)
            {
                throw getDepartments.Exception;
            }

            // Create Data For Job Employees
            jobDetailDto.Employees = from employee in getEmployees.Result
                                     join account in getAccounts.Result on employee.Guid equals account.Guid
                                     join department in getDepartments.Result on employee.DepartmentGuid equals department.Guid
                                     select new JobEmployeeDto
                                     {
                                         Guid = employee.Guid,
                                         FirstName = employee.FirstName,
                                         LastName = employee.LastName,
                                         Gender = employee.Gender,
                                         BirthDate = employee.BirthDate,
                                         HiringDate = employee.HiringDate,
                                         PhoneNumber = employee.PhoneNumber,
                                         Email = account.Email,
                                         Department = department.Name
                                     };


            // Success Response with employees 
            return Ok(OkResponseHandler.Success(jobDetailDto));
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponseHandler.InternalServerError(ex.Message));
        }
    }

    [HttpDelete("{guid}")]
    public IActionResult Delete(Guid guid)
    {
        try
        {
            // Check data availability.
            var getJob = jobRepository.GetByGuid(guid);

            if(getJob.Status == RepositoryStatus.ERROR)
            {
                throw getJob.Exception;
            }

            if(getJob.Status == RepositoryStatus.NOT_FOUND)
            {
                return NotFound(ErrorResponseHandler.NotFound("Job with specified ID not found."));
            }

            // Delete Job
            var deleteJob = jobRepository.Delete(getJob.Result);

            if(deleteJob.Status == RepositoryStatus.ERROR)
            {
                throw deleteJob.Exception;
            }

            return Ok(OkResponseHandler.DeleteSuccess());
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponseHandler.InternalServerError(ex.Message));
        }
    }

    [HttpPost]
    public IActionResult Create(CreateJobDto createData)
    {
        try
        {
            // Create job data.
            var createJob = jobRepository.Create(createData);

            if(createJob.Status == RepositoryStatus.ERROR)
            {
                throw createJob.Exception;
            }

            // Return success response
            return Ok(OkResponseHandler.CreateSuccess());
        }
        catch(Exception ex)
        {
            string? innerException = ex.InnerException.Message ;

            if (innerException.Contains("code"))
            {
                return Conflict();
            }

            if (innerException.Contains("name"))
            {
                return Conflict();
            }

            return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponseHandler.InternalServerError(ex.Message));
        }
    }

    [HttpPut()]
    public IActionResult Update(JobDto jobDto)
    {
        try
        {
            // Check data availability.
            var getJob = jobRepository.GetByGuid(jobDto.Guid);

            if(getJob.Status == RepositoryStatus.ERROR)
            {
                throw getJob.Exception;
            }

            if(getJob.Status == RepositoryStatus.NOT_FOUND)
            {
                return NotFound(ErrorResponseHandler.NotFound("Job with specified ID not found."));
            }

            // Update job
            var job = getJob.Result;
            job.ModifiedDate = DateTime.Now;
            job.Code = jobDto.Code;
            job.Name = jobDto.Name;
            job.MinSalary = jobDto.MinSalary;
            job.MaxSalary = jobDto.MaxSalary;

            var updateJob = jobRepository.Update(job);

            if(updateJob.Status != RepositoryStatus.SUCCESS)
            {
                throw updateJob.Exception;
            }

            // Success Response
            return Ok(OkResponseHandler.UpdateSuccess());
        }
        catch(Exception ex)
        {
            string? innerException = ex.InnerException.Message;

            if (innerException.Contains("code"))
            {
                return Conflict(ErrorResponseHandler.Conflict("Job code already registered."));
            }

            if (innerException.Contains("name"))
            {
                return Conflict(ErrorResponseHandler.Conflict("Job name already registered."));
            }

            return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponseHandler.InternalServerError(ex.Message));
        }
    }
}
