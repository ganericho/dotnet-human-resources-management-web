using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using api.Models;

namespace api.Dtos.JobDtos;

public class JobDetailDto
{
    public Guid Guid { get; set; }
    public int Code { get; set; }
    public string Name { get; set; }
    public int MinSalary { get; set; }
    public int MaxSalary { get; set; }
    public IEnumerable<JobEmployeeDto> Employees { get; set; }

    public static explicit operator JobDetailDto(Job data)
    {
        return new JobDetailDto
        {
            Guid = data.Guid,
            Code = data.Code,
            Name = data.Name,
            MinSalary = data.MinSalary,
            MaxSalary = data.MaxSalary,
            Employees = Enumerable.Empty<JobEmployeeDto>()
        };
    }
}
