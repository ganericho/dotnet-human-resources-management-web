using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using api.Models;

namespace api.Dtos.LeaveDtos;

public class CreateLeaveCategoryDto 
{
    public string Name { get; set; }
    public int MinDuration { get; set; }
    public int MaxDuration { get; set; }
    public bool IsFemaleOnly { get; set; }
    public int Limit { get; set; }
    public string LimitType { get; set; }
    public string? Description { get; set; }

    public static implicit operator LeaveCategory(CreateLeaveCategoryDto createData)
    {
        return new LeaveCategory
        {
            Guid = Guid.NewGuid(),
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now,
            Name = createData.Name,
            MinDuration = createData.MinDuration,
            MaxDuration = createData.MaxDuration,
            IsFemaleOnly = createData.IsFemaleOnly,
            Limit = createData.Limit,
            LimitType = createData.LimitType,
            Description = createData.Description
        };
    }
}
