using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using api.Models;

namespace api.Dtos.DepartmentData;

public class DepartmentDetailDto
{
    public Guid Guid { get; set; }
    public int Code { get; set; }
    public string Name { get; set; }
    public Guid? ManagerGuid { get; set; }
    public IEnumerable<DepartmentEmployeeDto>? Employees { get; set; }

    public static explicit operator DepartmentDetailDto(Department data)
    {
        return new DepartmentDetailDto
        {
            Guid = data.Guid,
            Code = data.Code,
            ManagerGuid = data.ManagerGuid,
            Name = data.Name,
            Employees = Enumerable.Empty<DepartmentEmployeeDto>()
        };
    }
}
