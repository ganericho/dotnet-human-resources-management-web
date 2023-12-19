using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api;

[Table("tb_departments")]
public class Department : GeneralModel
{
    [Required, Column("code", TypeName = "nvarchar(2)")]
    public int Code { get; set; }

    [Required, Column("name", TypeName = "nvarchar(30)")]
    public string Name { get; set; }

    [Column("manager_guid")]
    public Guid? ManagerGuid { get; set; }

    // Table cardinality
    public IEnumerable<Employee>? Employees { get; set; }
    public Employee? Manager { get; set; }
}
