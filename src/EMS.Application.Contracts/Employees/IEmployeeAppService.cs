using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EMS.Employees
{
    public interface IEmployeeAppService :
        ICrudAppService< //Defines CRUD methods
        EmployeeDto, //Used to show books
        Guid, //Primary key of the book entity
        MySearchFilterDto, //Used for paging/sorting
        CreateUpdateEmployeeDto> //Used 
    {
        Task<ListResultDto<DepartmentLookupDto>> GetDepartmentLookupAsync();
    }
}
