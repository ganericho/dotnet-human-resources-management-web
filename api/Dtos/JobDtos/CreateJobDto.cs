using api.Models;

namespace api.Dtos.JobDtos;

public class CreateJobDto
{
    public int Code { get; set; }
    public string Name { get; set; }
    public int MinSalary { get; set; }
    public int MaxSalary { get; set; }

    public static implicit operator Job(CreateJobDto dto)
    {
        return new Job
        {
            Guid = Guid.NewGuid(),
            Code = dto.Code,
            Name = dto.Name,
            MinSalary = dto.MinSalary,
            MaxSalary = dto.MaxSalary,
            ModifiedDate = DateTime.Now,
            CreatedDate = DateTime.Now
        };
    }
}
