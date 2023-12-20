using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using api.Models;

namespace api.Dtos.EmployeeData;

public class CreateJobHistoryDto
{
    public Guid EmployeeGuid { get; set; }

    public Guid JobGuid { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public static implicit operator JobHistory(CreateJobHistoryDto dto)
    {
        return new JobHistory
        {
            Guid = Guid.NewGuid(),
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now,
            EmployeeGuid = dto.EmployeeGuid,
            JobGuid = dto.JobGuid,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate
        };
    }
}
