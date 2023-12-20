using api.Models;
using api.Utilities;

namespace api.Dtos.EmployeeData;

public class CreateEmployeeDto
{
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime HiringDate { get; set; }
    public Gender Gender { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }

    public int DepartmentCode { get; set; }
    public int JobCode { get; set; }
    public string Role { get; set; }

    public static implicit operator Employee(CreateEmployeeDto createData)
    {
        return new Employee
        {
            Guid = Guid.NewGuid(),
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now,
            FirstName = createData.FirstName,
            LastName = createData.LastName,
            BirthDate = createData.BirthDate,
            HiringDate = createData.HiringDate,
            Gender = createData.Gender,
            PhoneNumber = createData.PhoneNumber
        };
    }
}
