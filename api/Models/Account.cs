using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api.Models;

namespace api;

[Table("tb_accounts")]
public class Account : GeneralModel
{
    [Required, Column("email", TypeName = "nvarchar(100)")]
    public string Email { get; set; }

    [Required, Column("password", TypeName = "nvarchar(max)")]
    public string Password { get; set; }

    [Required, Column("is_disabled")]
    public bool IsDisabled { get; set; }

    [Required, Column("otp")]
    public int Otp { get; set; }

    [Required, Column("is_otp_used")]
    public bool IsOtpUsed { get; set; }

    [Required, Column("otp_expire_time")]
    public DateTime OtpExpireTime { get; set; }

    // Table cardinality
    public Employee? Employee { get; set; }
    public IEnumerable<AccountRole>? AccountRoles { get; set; }

}
