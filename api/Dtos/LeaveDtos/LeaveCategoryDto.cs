using api.Models;

namespace api.Dtos.LeaveDtos;

public class LeaveCategoryDto
{
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public int MinDuration { get; set; }
    public int MaxDuration { get; set; }
    public bool IsFemaleOnly { get; set; }
    public int Limit { get; set; }
    public string LimitType { get; set; }
    public string? Description { get; set; }

    public static explicit operator LeaveCategoryDto(LeaveCategory data)
    {
        return new LeaveCategoryDto
        {
            Guid = data.Guid,
            Name = data.Name,
            MinDuration = data.MinDuration,
            MaxDuration = data.MaxDuration,
            IsFemaleOnly = data.IsFemaleOnly,
            Limit = data.Limit,
            LimitType = data.LimitType,
            Description = data.Description
        };
    }
}
