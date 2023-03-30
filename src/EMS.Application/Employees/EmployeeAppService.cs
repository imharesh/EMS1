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

        }
    }
}
