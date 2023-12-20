using api.Models;
using api.Utilities;

namespace api.Dtos.EmployeeData;

public class UpdateEmployeeDto
{
    public Guid Guid { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime HiringDate { get; set; }
    public Gender Gender { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public int DepartmentCode { get; set; }
    public int JobCode { get; set; }
    public string Role { get; set; }
}
