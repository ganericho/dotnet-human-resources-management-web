using api.Contracts;
using api.Dtos.JobDto;
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

            if (getJobs.IsFailed)
            {
                throw new Exception(getJobs.Exception);
            }

            // Convert repository result to dto format
            IEnumerable<JobDto> jobDto = getJobs.Result.Select(job => (JobDto) job);

            return Ok(ResponseOkHandler.Success(jobDto));
        }
        catch(Exception ex)
        {
            if(ex.Message.Contains(MessageCollection.DataNotFound))
            {
                return NotFound(ResponseErrorHandler.NotFound(ex.Message));
            }

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

            if (getJob.IsFailed)
            {
                throw new Exception(getJob.Exception);
            }

            // Get a list of employees with related jobs.
            var getEmployees = employeeRepository.GetByJob(guid);

            if (getEmployees.IsFailed) { }

            return Ok(ResponseOkHandler.Success(getJob.Result));
        }
        catch(Exception ex)
        {
            if (ex.Message.Contains(MessageCollection.DataNotFound))
            {
                return NotFound(ResponseErrorHandler.NotFound(MessageCollection.JobNotFound));
            }

            return StatusCode(StatusCodes.Status500InternalServerError, ResponseErrorHandler.InternalServerError(ex.Message));
        }
    }
}
