using api.Utilities;
using api.Utilities.Enums;

namespace api.Dtos.JobDtos;

public class JobEmployeeDto
{
    public Guid Guid { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime HiringDate { get; set; }
    public Sex Gender { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Department { get; set; }
}
