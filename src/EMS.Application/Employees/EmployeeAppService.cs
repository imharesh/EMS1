using EMS.Permissions;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace EMS.Employees
{
    public class EmployeeAppService :
       CrudAppService<
        Employee, //The Book entity
        EmployeeDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateEmployeeDto>, //Used to create/update a book
    IEmployeeAppService
    {
        public EmployeeAppService(IRepository<Employee, Guid> repository)
        : base(repository)
        {
            GetPolicyName = EMSPermissions.Employees.Default;
            GetListPolicyName = EMSPermissions.Employees.Default;
            CreatePolicyName = EMSPermissions.Employees.Create;
            UpdatePolicyName = EMSPermissions.Employees.Edit;
            DeletePolicyName = EMSPermissions.Employees.Delete;
        }
    }
}
