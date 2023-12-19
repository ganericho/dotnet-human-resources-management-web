using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using api.Models;

namespace api.Dtos.JobDto;

public class JobDto
{
    public Guid Guid { get; set; }
    public int Code { get; set; }
    public String Name { get; set; }
    public int MinSalary { get; set; }
    public int MaxSalary { get; set; }

    public static explicit operator JobDto(Job dto)
    {
        return new JobDto
        {
            Guid = dto.Guid,
            Code = dto.Code,
            Name = dto.Name,
            MinSalary = dto.MinSalary,
            MaxSalary = dto.MaxSalary
        };
    }

    public static implicit operator Job(JobDto dto)
    {
        return new Job
        {
            Guid = dto.Guid,
            Code = dto.Code,
            Name = dto.Name,
            MinSalary = dto.MinSalary,
            MaxSalary = dto.MaxSalary,
            ModifiedDate = DateTime.Now
        };
    }
}
