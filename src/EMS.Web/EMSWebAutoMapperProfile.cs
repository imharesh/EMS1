using AutoMapper;
using EMS.Employees;

namespace EMS.Web;

public class EMSWebAutoMapperProfile : Profile
{
    public EMSWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<EmployeeDto, CreateUpdateEmployeeDto>();
    }
}

