using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace api.Dtos.EmployeeDtos;

public class UpdateJobHistoryDto
{
    public Guid Guid { get; set; }
    public int JobCode { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool IsActive { get; set; }
}
