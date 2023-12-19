using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api;

[Table("tb_job_histories")]
public class JobHistory : GeneralModel
{
    [Required, Column("employee_guid")]
    public Guid EmployeeGuid { get; set; }

    [Required, Column("job_guid")]
    public Guid JobGuid { get; set; }

    [Required, Column("start_date")]
    public DateTime StartDate { get; set; }

    [Column("end_date")]
    public DateTime? EndDate { get; set; }

    [Required, Column("is_active")]
    public bool IsActive { get; set; }

    // Table cardinality
    public Employee? Employee { get; set; }
    public Job? Job { get; set; }
}
