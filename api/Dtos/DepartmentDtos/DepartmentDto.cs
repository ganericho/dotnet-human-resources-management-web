using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using api.Models;

namespace api.Dtos.DepartmentData;

public class DepartmentDto
{
    public Guid Guid { get; set; }
    public int Code { get; set; }
    public string Name { get; set; }
    public Guid? ManagerGuid { get; set; }

    public static explicit operator DepartmentDto(Department data)
    {
        return new DepartmentDto
        {
            Guid = data.Guid,
            Code = data.Code,
            ManagerGuid = data.ManagerGuid,
            Name = data.Name
        };
    }
}
