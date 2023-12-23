using api.Utilities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

[Table("tb_leave_records")]
public class LeaveRecord : GeneralModel
{
    [Required, Column("leave_category_guid")]
    public Guid LeaveCategoryGuid { get; set; }

    [Required, Column("employee_guid")]
    public Guid EmployeeGuid { get; set; }

    [Required, Column("start_date")]
    public DateTime StartDate { get; set; }

    [Column("end_date")]
    public DateTime? EndDate { get; set; }

    [Column("user_remark")]
    public string? UserRemark { get; set; }

    [Required, Column("status")]
    public LeaveStatus Status { get; set; }

    [Column("admin_remark")]
    public string? AdminRemark { get; set; }

    // Table cardinality.
    public Employee? Employee { get; set; }
    public LeaveCategory? LeaveCategory { get; set; }

}
