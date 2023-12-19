using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api;


public class GeneralModel
{
    [Key, Column("guid")]
    public Guid Guid { get; set; }

    [Required, Column("created_date")]
    public DateTime CreatedDate { get; set; }
    
    [Required, Column("modified_date")]
    public DateTime ModifiedDate { get; set; }
}
