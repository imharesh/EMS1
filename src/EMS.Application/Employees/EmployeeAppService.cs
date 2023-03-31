using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using EMS.Departments;
using EMS.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace EMS.Employees
{
    [Authorize(EMSPermissions.Employees.Default)]
    public class EmployeeAppService :
       CrudAppService<
        Employee, //The Book entity
        EmployeeDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateEmployeeDto>, //Used to create/update a book
    IEmployeeAppService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public EmployeeAppService(
            IRepository<Employee, Guid> repository,
            IDepartmentRepository departmentRepository)
            : base(repository)
        {
            _departmentRepository = departmentRepository;
            GetPolicyName = EMSPermissions.Employees.Default;
            GetListPolicyName = EMSPermissions.Employees.Default;
            CreatePolicyName = EMSPermissions.Employees.Create;
            UpdatePolicyName = EMSPermissions.Employees.Edit;
            DeletePolicyName = EMSPermissions.Employees.Create;
        }

        public override async Task<EmployeeDto> GetAsync(Guid id)
        {
            //Get the IQueryable<Book> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join books and authors
            var query = from employee in queryable
                        join department in await _departmentRepository.GetQueryableAsync() on employee.DepartmentId equals department.Id
                        where employee.Id == id
                        select new { employee, department };

            //Execute the query and get the book with author
            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(Employee), id);
            }

            var employeeDto = ObjectMapper.Map<Employee, EmployeeDto>(queryResult.employee);
            employeeDto.DepartmentName = queryResult.department.Name;
            return employeeDto;
        }

        public override async Task<PagedResultDto<EmployeeDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            //Get the IQueryable<Book> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join books and authors
            var query = from employee in queryable
                        join department in await _departmentRepository.GetQueryableAsync() on employee.DepartmentId equals department.Id
                        select new { employee, department };

            //Paging
            query = query
                .OrderBy(NormalizeSorting(input.Sorting))
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            //Execute the query and get a list
            var queryResult = await AsyncExecuter.ToListAsync(query);

            //Convert the query result to a list of BookDto objects
            var employeeDtos = queryResult.Select(x =>
            {
                var employeeDto = ObjectMapper.Map<Employee, EmployeeDto>(x.employee);
                employeeDto.DepartmentName = x.department.Name;
                return employeeDto;
            }).ToList();

            //Get the total count with another query
            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<EmployeeDto>(
                totalCount,
                employeeDtos
            );
        }

        public async Task<ListResultDto<DepartmentLookupDto>> GetDepartmentLookupAsync()
        {
            var departments = await _departmentRepository.GetListAsync();

            return new ListResultDto<DepartmentLookupDto>(
                ObjectMapper.Map<List<Department>, List<DepartmentLookupDto>>(departments)
            );
        }

        private static string NormalizeSorting(string sorting)
        {
            if (sorting.IsNullOrEmpty())
            {
                return $"employee.{nameof(Employee.Name)}";
            }

            if (sorting.Contains("departmentName", StringComparison.OrdinalIgnoreCase))
            {
                return sorting.Replace(
                    "departmentName",
                    "department.Name",
                    StringComparison.OrdinalIgnoreCase
                );
            }

            return $"employee.{sorting}";
        }
    }
}
