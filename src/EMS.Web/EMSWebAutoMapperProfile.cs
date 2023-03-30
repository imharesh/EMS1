using AutoMapper;
using EMS.Departments;
using EMS.Employees;

namespace EMS.Web;

public class EMSWebAutoMapperProfile : Profile
{
    public EMSWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<EmployeeDto, CreateUpdateEmployeeDto>();
        CreateMap<Pages.Departments.CreateModalModel.CreateDepartmentViewModel,
                    CreateDepartmentDto>();


        // ADD THESE NEW MAPPINGS
        CreateMap<DepartmentDto, Pages.Departments.EditModalModel.EditDepartmentViewModel>();
        CreateMap<Pages.Departments.EditModalModel.EditDepartmentViewModel,
                    UpdateDepartmentDto>();


        CreateMap<Pages.Employees.CreateModalModel.CreateEmployeeViewModel, CreateUpdateEmployeeDto>();
        CreateMap<EmployeeDto, Pages.Employees.EditModalModel.EditEmployeeViewModel>();
        CreateMap<Pages.Employees.EditModalModel.EditEmployeeViewModel, CreateUpdateEmployeeDto>();

    }
}

