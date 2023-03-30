using AutoMapper;
using EMS.Departments;
using EMS.Employees;

namespace EMS;

public class EMSApplicationAutoMapperProfile : Profile
{
    public EMSApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Employee, EmployeeDto>();
        CreateMap<CreateUpdateEmployeeDto, Employee>();
        CreateMap<Department, DepartmentDto>();
        CreateMap<Department, DepartmentLookupDto>();


    }
}
