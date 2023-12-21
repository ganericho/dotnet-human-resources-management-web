using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using api.Models;

namespace api.Dtos.EmployeeDtos;

public class JobHistoryDto
{
    public Guid Guid { get; set; }
    public string EmployeeName { get; set; }

    public Guid JobGuid { get; set; }
    public string JobName { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

}
