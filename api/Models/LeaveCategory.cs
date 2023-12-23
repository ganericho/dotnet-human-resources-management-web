using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

[Table("tb_leave_categories")]
public class LeaveCategory : GeneralModel
{
    [Required, Column("name", TypeName = "nvarchar(100)")]
    public string Name { get; set; }

    [Required, Column("min_duration")]
    public int MinDuration { get; set; }

    [Required, Column("max_duration")]
    public int MaxDuration { get; set; }

    [Required, Column("gender")]
    public Gender Gender { get; set; } 

    [Column("description")]
    public string? Description { get; set; }

    // Table cardinality.
    public IEnumerable<LeaveRecord>? LeaveRecords { get; set; }
}
