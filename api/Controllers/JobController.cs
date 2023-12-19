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
            IEnumerable<JobDto> jobDto = getJobs.Data.Select(job => (JobDto) job);

            return Ok(ResponseOkHandler.Success(jobDto));
        }
        catch(Exception ex)
        {


            return StatusCode(StatusCodes.Status500InternalServerError, ResponseErrorHandler.InternalServerError(ex.Message));
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
                return NotFound(ResponseErrorHandler.NotFound("Job with specified ID not found."));
            }

            // Create Job Detail Dto
            JobDetailDto jobDetailDto = (JobDetailDto) getJob.Data;

            // Get a list of employees with related jobs.
            var getEmployees = employeeRepository.GetByJob(guid);

            if(getEmployees.Status == RepositoryStatus.ERROR)
            {
                throw getEmployees.Exception;
            }

            if(getEmployees.Status == RepositoryStatus.NOT_FOUND)
            {
                jobDetailDto.Employees = Enumerable.Empty<JobEmployeeDto>();
                
                return Ok(ResponseOkHandler.Success(jobDetailDto));
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
            jobDetailDto.Employees = from employee in getEmployees.Data
                                     join account in getAccounts.Data on employee.Guid equals account.Guid
                                     join department in getDepartments.Data on employee.DepartmentGuid equals department.Guid
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
            return Ok(ResponseOkHandler.Success(jobDetailDto));
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ResponseErrorHandler.InternalServerError(ex.Message));
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
                return NotFound(ResponseErrorHandler.NotFound("Job with specified ID not found."));
            }

            // Delete Job
            var deleteJob = jobRepository.Delete(getJob.Data);

            if(deleteJob.Status == RepositoryStatus.ERROR)
            {
                throw deleteJob.Exception;
            }

            return Ok(ResponseOkHandler.DeleteSuccess());
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ResponseErrorHandler.InternalServerError(ex.Message));
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
            return Ok(ResponseOkHandler.CreateSuccess());
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

            return StatusCode(StatusCodes.Status500InternalServerError, ResponseErrorHandler.InternalServerError(ex.Message));
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
                return NotFound(ResponseErrorHandler.NotFound("Job with specified ID not found."));
            }

            // Update job
            var job = getJob.Data;
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
            return Ok(ResponseOkHandler.UpdateSuccess());
        }
        catch(Exception ex)
        {
            string? innerException = ex.InnerException.Message;

            if (innerException.Contains("code"))
            {
                return Conflict();
            }

            if (innerException.Contains("name"))
            {
                return Conflict();
            }

            return StatusCode(StatusCodes.Status500InternalServerError, ResponseErrorHandler.InternalServerError(ex.Message));
        }
    }
}
