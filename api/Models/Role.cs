using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api.Models;

namespace api;

[Table("tb_roles")]
public class Role : GeneralModel
{
    [Required, Column("name", TypeName = "nvarchar(20)")]
    public string Name { get; set; }

    // Table cardinality
    public IEnumerable<AccountRole>? AccountRoles { get; set; }
}
