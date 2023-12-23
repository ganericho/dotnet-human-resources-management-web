using api.Contracts;
using api.Database;
using api.Dtos.EmployeeData;
using api.Dtos.EmployeeDtos;
using api.Repositories;
using api.Utilities;
using api.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/Employee/[controller]")]
public class JobHistoryController : ControllerBase
{
    private readonly HumanResourcesDbContext context;
    private readonly IAccountRepository accountRepository;
    private readonly IAccountRoleRepository accountRoleRepository;
    private readonly IEmployeeRepository employeeRepository;
    private readonly IDepartmentRepository departmentRepository;
    private readonly IJobRepository jobRepository;
    private readonly IJobHistoryRepository jobHistoryRepository;
    private readonly IRoleRepository roleRepository;

    public JobHistoryController(HumanResourcesDbContext context, IAccountRepository accountRepository, IAccountRoleRepository accountRoleRepository, IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository, IJobRepository jobRepository, IJobHistoryRepository jobHistoryRepository, IRoleRepository roleRepository)
    {
        this.context = context;
        this.accountRepository = accountRepository;
        this.accountRoleRepository = accountRoleRepository;
        this.employeeRepository = employeeRepository;
        this.departmentRepository = departmentRepository;
        this.jobRepository = jobRepository;
        this.jobHistoryRepository = jobHistoryRepository;
        this.roleRepository = roleRepository;
    }

    [HttpGet("{guid}")]
    public IActionResult GetAllByEmployeeGuid(Guid guid)
    {
        try
        {
            var getJobHistory = jobHistoryRepository.GetByEmployeeGuid(guid);

            if (getJobHistory.Status == Utilities.ActionStatus.ERROR)
            {
                throw getJobHistory.Exception;
            }

            if (getJobHistory.Status == Utilities.ActionStatus.NOT_FOUND)
            {
                var emptyResult = Enumerable.Empty<JobHistoryDto>();

                return NotFound(OkResponseHandler.Empty("Job history with specified employee ID is empty.", emptyResult));
            }

            return Ok(OkResponseHandler.Success(getJobHistory.Result));
        }
        catch (Exception ex)
        {
            var exceptionMessage = ExceptionHandler.GetMessage(ex);

            return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponseHandler.InternalServerError(exceptionMessage));
        }
    }

    [HttpDelete("{guid}")]
    public IActionResult Delete(Guid guid)
    {
        try
        {
            // Get job history data from repository.
            var getJobHistory = jobHistoryRepository.GetByGuid(guid);

            if(getJobHistory.Status == Utilities.ActionStatus.ERROR)
            {
                throw getJobHistory.Exception;
            }

            if (getJobHistory.Status == Utilities.ActionStatus.NOT_FOUND)
            {
                return NotFound(ErrorResponseHandler.NotFound("Job history with specified ID not found."));
            }

            // Delete job history data via repository.
            var deleteJobHistory = jobHistoryRepository.Delete(getJobHistory.Result);

            if(deleteJobHistory.Status != ActionStatus.SUCCESS)
            {
                throw deleteJobHistory.Exception;
            }

            // Success response.
            return Ok(OkResponseHandler.DeleteSuccess());
        }
        catch(Exception ex)
        {
            string exceptionMessage = ExceptionHandler.GetMessage(ex);

            return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponseHandler.InternalServerError(exceptionMessage));
        }
    }

    [HttpPost]
    public IActionResult Create(CreateJobHistoryDto createData)
    {
        try
        {
            // Get job data from repository.
            var getJob = jobRepository.GetByCode(createData.JobCode);

            if (getJob.Status != ActionStatus.SUCCESS)
            {
                throw getJob.Exception;
            }

            var job = getJob.Result;

            // Create job history via repository.
            JobHistory jobHistory = createData;
            jobHistory.JobGuid = job.Guid;

            var createJobHistory = jobHistoryRepository.Create(jobHistory);

            if (createJobHistory.Status != ActionStatus.SUCCESS)
            {
                throw createJobHistory.Exception;
            }

            // Success response.
            return Ok(OkResponseHandler.CreateSuccess());
        }
        catch(Exception ex)
        {
            string exceptionMessage = ExceptionHandler.GetMessage(ex);

            return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponseHandler.InternalServerError(exceptionMessage));
        }
    }

    [HttpPut]
    public IActionResult Update(UpdateJobHistoryDto updateData)
    {
        var transaction = context.Database.BeginTransaction();
        try
        {
            // Get job history data from repository.
            var getJobHistory = jobHistoryRepository.GetByGuid(updateData.Guid);

            if (getJobHistory.Status != ActionStatus.SUCCESS)
            {
                throw getJobHistory.Exception;
            }

            // Get job data from repository.
            var getJob = jobRepository.GetByCode(updateData.JobCode);
            
            if (getJob.Status != ActionStatus.SUCCESS)
            {
                throw getJob.Exception;
            }

            // Replace job history entity attribute with update data
            var jobHistory = getJobHistory.Result;
            jobHistory.ModifiedDate = DateTime.Now;
            jobHistory.JobGuid = getJob.Result.Guid;
            jobHistory.StartDate = updateData.StartDate;
            jobHistory.EndDate = updateData.EndDate;
            jobHistory.IsActive = updateData.IsActive;

            // Get employee job histories from repository.
            var getEmployeeJobHistories = jobHistoryRepository.GetByEmployeeGuid(jobHistory.EmployeeGuid);

            if (getEmployeeJobHistories.Status != ActionStatus.SUCCESS)
            {
                throw getEmployeeJobHistories.Exception;
            }

            var employeeJobHistories = getEmployeeJobHistories.Result;

            // Set current active job history to inactive.
            var activeJobHistory = employeeJobHistories.First(item => item.IsActive == true);

            if(activeJobHistory != null)
            {
                activeJobHistory.IsActive = false;

                var updateActiveJobHistory = jobHistoryRepository.Update(activeJobHistory);

                if (updateActiveJobHistory.Status != ActionStatus.SUCCESS)
                {
                    throw updateActiveJobHistory.Exception;
                }
            }

            // Update job history.
            var updateJobHistory = jobHistoryRepository.Update(jobHistory);

            // Commit changes.
            transaction.Commit();

            // Success response.
            return Ok(OkResponseHandler.UpdateSuccess());
        }
        catch(Exception ex)
        {
            transaction.Rollback();

            string exceptionMessage = ExceptionHandler.GetMessage(ex);

            return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponseHandler.InternalServerError(exceptionMessage));
        }
    }
}
